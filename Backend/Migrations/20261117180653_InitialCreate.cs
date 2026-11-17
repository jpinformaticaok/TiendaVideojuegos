using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "tipos_producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tipos_producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "provincias",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    pais_id = table.Column<int>(type: "integer", nullable: false),
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
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    stock = table.Column<int>(type: "integer", nullable: false),
                    image_url = table.Column<string>(type: "text", nullable: false),
                    tipo_producto_id = table.Column<int>(type: "integer", nullable: false),
                    format = table.Column<string>(type: "text", nullable: false),
                    platform = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productos", x => x.id);
                    table.ForeignKey(
                        name: "fk_productos_tipos_producto_tipo_producto_id",
                        column: x => x.tipo_producto_id,
                        principalTable: "tipos_producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "localidades",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    provincia_id = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    created_at = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true, defaultValueSql: "NOW()"),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    dni = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    localidad_id = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clientes", x => x.id);
                    table.ForeignKey(
                        name: "fk_clientes_localidades_localidad_id",
                        column: x => x.localidad_id,
                        principalTable: "localidades",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number = table.Column<string>(type: "text", nullable: false),
                    date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()"),
                    cliente_id = table.Column<int>(type: "integer", nullable: true),
                    total = table.Column<decimal>(type: "numeric", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ventas", x => x.id);
                    table.ForeignKey(
                        name: "fk_ventas_clientes_cliente_id",
                        column: x => x.cliente_id,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalles_venta",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    venta_id = table.Column<int>(type: "integer", nullable: false),
                    producto_id = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price = table.Column<decimal>(type: "numeric", nullable: false),
                    subtotal = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_detalles_venta", x => x.id);
                    table.ForeignKey(
                        name: "fk_detalles_venta_productos_producto_id",
                        column: x => x.producto_id,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_detalles_venta_ventas_venta_id",
                        column: x => x.venta_id,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "paises",
                columns: new[] { "id", "name", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Argentina", false },
                    { 2, "Brasil", false },
                    { 3, "Chile", false }
                });

            migrationBuilder.InsertData(
                table: "tipos_producto",
                columns: new[] { "id", "name", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Consola", false },
                    { 2, "Juego", false },
                    { 3, "Suscripción", false }
                });

            migrationBuilder.InsertData(
                table: "provincias",
                columns: new[] { "id", "name", "pais_id", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Buenos Aires", 1, false },
                    { 2, "Córdoba", 1, false },
                    { 3, "Santa Fe", 1, false }
                });

            migrationBuilder.InsertData(
                table: "localidades",
                columns: new[] { "id", "name", "provincia_id", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Buenos Aires", 1, false },
                    { 2, "Córdoba", 2, false },
                    { 3, "Santa Fe", 3, false },
                    { 4, "Rosario", 3, false },
                    { 5, "San Justo", 3, false }
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "id", "address", "created_at", "dni", "firstname", "lastname", "localidad_id", "is_deleted" },
                values: new object[,]
                {
                    { 1, "Calle Falsa 123", new DateTimeOffset(new DateTime(2026, 11, 17, 18, 6, 52, 558, DateTimeKind.Unspecified).AddTicks(2851), new TimeSpan(0, 0, 0, 0, 0)), "29720301", "Juan Pablo", "Aguero", 4, false },
                    { 2, "Avenida Siempre Viva 456", new DateTimeOffset(new DateTime(2026, 11, 17, 18, 6, 52, 558, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 0, 0, 0, 0)), "87654321", "María", "González", 4, false },
                    { 3, "Callejón del Beso 789", new DateTimeOffset(new DateTime(2026, 11, 17, 18, 6, 52, 558, DateTimeKind.Unspecified).AddTicks(2857), new TimeSpan(0, 0, 0, 0, 0)), "11223344", "Pedro", "López", 4, false }
                });

            migrationBuilder.CreateIndex(
                name: "ix_clientes_localidad_id",
                table: "clientes",
                column: "localidad_id");

            migrationBuilder.CreateIndex(
                name: "ix_detalles_venta_producto_id",
                table: "detalles_venta",
                column: "producto_id");

            migrationBuilder.CreateIndex(
                name: "ix_detalles_venta_venta_id",
                table: "detalles_venta",
                column: "venta_id");

            migrationBuilder.CreateIndex(
                name: "ix_localidades_provincia_id",
                table: "localidades",
                column: "provincia_id");

            migrationBuilder.CreateIndex(
                name: "ix_productos_tipo_producto_id",
                table: "productos",
                column: "tipo_producto_id");

            migrationBuilder.CreateIndex(
                name: "ix_provincias_pais_id",
                table: "provincias",
                column: "pais_id");

            migrationBuilder.CreateIndex(
                name: "ix_ventas_cliente_id",
                table: "ventas",
                column: "cliente_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalles_venta");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "tipos_producto");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "localidades");

            migrationBuilder.DropTable(
                name: "provincias");

            migrationBuilder.DropTable(
                name: "paises");
        }
    }
}
