using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class ProductoPlataformaFormato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. Crear las tablas de plataformas y formatos con sus datos semilla
            migrationBuilder.CreateTable(
                name: "formatos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_formatos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "plataformas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_plataformas", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "formatos",
                columns: new[] { "id", "name", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Físico", false },
                    { 2, "Digital", false }
                });

            migrationBuilder.InsertData(
                table: "plataformas",
                columns: new[] { "id", "name", "is_deleted" },
                values: new object[,]
                {
                    { 1, "PlayStation", false },
                    { 2, "Xbox", false },
                    { 3, "Nintendo", false },
                    { 4, "PC", false }
                });

            // 2. Agregar las columnas nuevas permitiendo nulos para poder migrar los datos existentes
            migrationBuilder.AddColumn<int>(
                name: "formato_id",
                table: "productos",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "plataforma_id",
                table: "productos",
                type: "integer",
                nullable: true);

            // 3. Copiar los valores de texto existentes (platform/format) a las nuevas relaciones
            migrationBuilder.Sql(
                """
                INSERT INTO formatos (name, is_deleted)
                SELECT DISTINCT p.format, false
                FROM productos p
                WHERE p.format <> ''
                  AND NOT EXISTS (SELECT 1 FROM formatos f WHERE f.name = p.format);

                INSERT INTO plataformas (name, is_deleted)
                SELECT DISTINCT p.platform, false
                FROM productos p
                WHERE p.platform <> ''
                  AND NOT EXISTS (SELECT 1 FROM plataformas pl WHERE pl.name = p.platform);

                UPDATE productos p
                SET formato_id = f.id
                FROM formatos f
                WHERE f.name = p.format;

                UPDATE productos p
                SET plataforma_id = pl.id
                FROM plataformas pl
                WHERE pl.name = p.platform;

                -- Productos sin coincidencia: se usa el primer registro disponible
                UPDATE productos
                SET formato_id = (SELECT id FROM formatos ORDER BY id LIMIT 1)
                WHERE formato_id IS NULL;

                UPDATE productos
                SET plataforma_id = (SELECT id FROM plataformas ORDER BY id LIMIT 1)
                WHERE plataforma_id IS NULL;

                ALTER TABLE productos ALTER COLUMN formato_id SET NOT NULL;
                ALTER TABLE productos ALTER COLUMN plataforma_id SET NOT NULL;
                """);

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 1, 2 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 1, 3 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 2, 4 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 2, 1 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "productos",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "formato_id", "plataforma_id" },
                values: new object[] { 2, 3 });

            migrationBuilder.CreateIndex(
                name: "ix_productos_formato_id",
                table: "productos",
                column: "formato_id");

            migrationBuilder.CreateIndex(
                name: "ix_productos_plataforma_id",
                table: "productos",
                column: "plataforma_id");

            migrationBuilder.AddForeignKey(
                name: "fk_productos_formatos_formato_id",
                table: "productos",
                column: "formato_id",
                principalTable: "formatos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_productos_plataformas_plataforma_id",
                table: "productos",
                column: "plataforma_id",
                principalTable: "plataformas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            // 4. Eliminar las columnas de texto que ya no se usan
            migrationBuilder.DropColumn(
                name: "format",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "platform",
                table: "productos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // 1. Recrear las columnas de texto permitiendo nulos para poder copiar los datos
            migrationBuilder.AddColumn<string>(
                name: "format",
                table: "productos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "platform",
                table: "productos",
                type: "text",
                nullable: true);

            // 2. Recuperar los nombres desde las tablas relacionadas antes de eliminarlas
            migrationBuilder.Sql(
                """
                UPDATE productos p
                SET format = f.name,
                    platform = pl.name
                FROM formatos f, plataformas pl
                WHERE f.id = p.formato_id
                  AND pl.id = p.plataforma_id;
                """);

            migrationBuilder.Sql("ALTER TABLE productos ALTER COLUMN format SET NOT NULL;");
            migrationBuilder.Sql("ALTER TABLE productos ALTER COLUMN platform SET NOT NULL;");

            // 3. Eliminar las relaciones y las tablas nuevas
            migrationBuilder.DropForeignKey(
                name: "fk_productos_formatos_formato_id",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "fk_productos_plataformas_plataforma_id",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "ix_productos_formato_id",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "ix_productos_plataforma_id",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "formato_id",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "plataforma_id",
                table: "productos");

            migrationBuilder.DropTable(
                name: "formatos");

            migrationBuilder.DropTable(
                name: "plataformas");
        }
    }
}