using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ClienteUbicacionTexto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Nuevas columnas de texto en clientes
            migrationBuilder.AddColumn<string>(
                name: "localidad",
                table: "clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "provincia",
                table: "clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pais",
                table: "clientes",
                type: "text",
                nullable: false,
                defaultValue: "");

            // 2. Copiar la ubicación desde las tablas relacionadas antes de eliminarlas
            migrationBuilder.Sql(
                """
                UPDATE clientes c
                SET localidad = l.name,
                    provincia = p.name,
                    pais      = pa.name
                FROM localidades l
                JOIN provincias p ON p.id = l.provincia_id
                JOIN paises pa    ON pa.id = p.pais_id
                WHERE c.localidad_id = l.id;
                """);

            // 3. Eliminar la relación y las tablas que ya no se usan
            migrationBuilder.DropForeignKey(
                name: "fk_clientes_localidades_localidad_id",
                table: "clientes");

            migrationBuilder.DropIndex(
                name: "ix_clientes_localidad_id",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "localidad_id",
                table: "clientes");

            migrationBuilder.DropTable(
                name: "localidades");

            migrationBuilder.DropTable(
                name: "provincias");

            migrationBuilder.DropTable(
                name: "paises");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Recrear las tablas de ubicación
            migrationBuilder.CreateTable(
                name: "paises",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_paises", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pais_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_provincias", x => x.id);
                    table.ForeignKey(
                        name: "fk_provincias_paises_pais_id",
                        column: x => x.pais_id,
                        principalTable: "paises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "localidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    provincia_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_localidades", x => x.id);
                    table.ForeignKey(
                        name: "fk_localidades_provincias_provincia_id",
                        column: x => x.provincia_id,
                        principalTable: "provincias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_provincias_pais_id",
                table: "provincias",
                column: "pais_id");

            migrationBuilder.CreateIndex(
                name: "ix_localidades_provincia_id",
                table: "localidades",
                column: "provincia_id");

            // 2. Recuperar la columna y reconstruir los datos a partir de los textos
            migrationBuilder.AddColumn<int>(
                name: "localidad_id",
                table: "clientes",
                type: "integer",
                nullable: true);

            migrationBuilder.Sql(
                """
                INSERT INTO paises (name, is_deleted)
                SELECT DISTINCT c.pais, false
                FROM clientes c
                WHERE c.pais <> ''
                  AND NOT EXISTS (SELECT 1 FROM paises p WHERE p.name = c.pais);

                INSERT INTO provincias (name, pais_id, is_deleted)
                SELECT DISTINCT c.provincia, pa.id, false
                FROM clientes c
                JOIN paises pa ON pa.name = c.pais
                WHERE c.provincia <> ''
                  AND NOT EXISTS (
                      SELECT 1 FROM provincias pr
                      WHERE pr.name = c.provincia AND pr.pais_id = pa.id);

                INSERT INTO localidades (name, provincia_id, is_deleted)
                SELECT DISTINCT c.localidad, pr.id, false
                FROM clientes c
                JOIN provincias pr ON pr.name = c.provincia
                JOIN paises pa ON pa.id = pr.pais_id AND pa.name = c.pais
                WHERE c.localidad <> ''
                  AND NOT EXISTS (
                      SELECT 1 FROM localidades l
                      WHERE l.name = c.localidad AND l.provincia_id = pr.id);

                UPDATE clientes c
                SET localidad_id = l.id
                FROM localidades l
                JOIN provincias pr ON pr.id = l.provincia_id
                JOIN paises pa ON pa.id = pr.pais_id
                WHERE l.name = c.localidad
                  AND pr.name = c.provincia
                  AND pa.name = c.pais;
                """);

            // 3. Clientes sin ubicación: se les asigna una localidad comodín
            migrationBuilder.Sql(
                """
                INSERT INTO paises (name, is_deleted)
                SELECT 'Sin especificar', false
                WHERE EXISTS (SELECT 1 FROM clientes WHERE localidad_id IS NULL)
                  AND NOT EXISTS (SELECT 1 FROM paises WHERE name = 'Sin especificar');

                INSERT INTO provincias (name, pais_id, is_deleted)
                SELECT 'Sin especificar', pa.id, false
                FROM paises pa
                WHERE pa.name = 'Sin especificar'
                  AND EXISTS (SELECT 1 FROM clientes WHERE localidad_id IS NULL)
                  AND NOT EXISTS (SELECT 1 FROM provincias WHERE name = 'Sin especificar');

                INSERT INTO localidades (name, provincia_id, is_deleted)
                SELECT 'Sin especificar', pr.id, false
                FROM provincias pr
                WHERE pr.name = 'Sin especificar'
                  AND EXISTS (SELECT 1 FROM clientes WHERE localidad_id IS NULL)
                  AND NOT EXISTS (SELECT 1 FROM localidades WHERE name = 'Sin especificar');

                UPDATE clientes
                SET localidad_id = (SELECT id FROM localidades WHERE name = 'Sin especificar' LIMIT 1)
                WHERE localidad_id IS NULL;
                """);

            migrationBuilder.Sql("ALTER TABLE clientes ALTER COLUMN localidad_id SET NOT NULL;");

            migrationBuilder.CreateIndex(
                name: "ix_clientes_localidad_id",
                table: "clientes",
                column: "localidad_id");

            migrationBuilder.AddForeignKey(
                name: "fk_clientes_localidades_localidad_id",
                table: "clientes",
                column: "localidad_id",
                principalTable: "localidades",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            // 4. Quitar las columnas de texto
            migrationBuilder.DropColumn(
                name: "localidad",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "provincia",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "pais",
                table: "clientes");
        }
    }
}
