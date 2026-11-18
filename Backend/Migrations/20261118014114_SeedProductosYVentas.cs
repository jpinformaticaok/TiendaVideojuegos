using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductosYVentas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ventas",
                columns: new[] { "id", "cliente_id", "date", "number", "total", "is_deleted" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2026, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "FAC-00001", 1345000m, false },
                    { 2, 2, new DateTimeOffset(new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "FAC-00002", 1255000m, false },
                    { 3, 3, new DateTimeOffset(new DateTime(2026, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "FAC-00003", 913000m, false }
                });

            migrationBuilder.InsertData(
                table: "detalles_venta",
                columns: new[] { "id", "producto_id", "quantity", "subtotal", "unit_price", "venta_id" },
                values: new object[,]
                {
                    { 1, 1, 1, 1250000m, 1250000m, 1 },
                    { 2, 4, 1, 95000m, 95000m, 1 },
                    { 3, 2, 1, 1150000m, 1150000m, 2 },
                    { 4, 5, 1, 105000m, 105000m, 2 },
                    { 5, 3, 1, 780000m, 780000m, 3 },
                    { 6, 6, 1, 88000m, 88000m, 3 },
                    { 7, 8, 1, 45000m, 45000m, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "detalles_venta",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "detalles_venta",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "detalles_venta",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "detalles_venta",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "detalles_venta",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "detalles_venta",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "detalles_venta",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ventas",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ventas",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ventas",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
