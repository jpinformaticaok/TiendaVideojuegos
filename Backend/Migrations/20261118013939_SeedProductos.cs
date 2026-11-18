using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "id", "created_at", "description", "format", "image_url", "name", "platform", "price", "stock", "tipo_producto_id", "is_deleted" },
                values: new object[,]
                {
                    { 1, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Consola PlayStation 5 Slim 1TB", "Físico", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/ps5.png", "PlayStation 5 Slim", "PlayStation", 1250000m, 8, 1, false },
                    { 2, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Consola Xbox Series X 1TB", "Físico", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/xbox.png", "Xbox Series X", "Xbox", 1150000m, 6, 1, false },
                    { 3, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Consola Nintendo Switch OLED 64GB", "Físico", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/switch.png", "Nintendo Switch OLED", "Nintendo", 780000m, 10, 1, false },
                    { 4, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Juego de fútbol para PlayStation 5", "Físico", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/fc25.png", "EA Sports FC 25", "PlayStation", 95000m, 25, 2, false },
                    { 5, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Shooter para Xbox Series X", "Físico", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/cod.png", "Call of Duty: Black Ops 6", "Xbox", 105000m, 20, 2, false },
                    { 6, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Aventura para Nintendo Switch", "Físico", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/zelda.png", "Zelda: Tears of the Kingdom", "Nintendo", 88000m, 15, 2, false },
                    { 7, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Juego digital para PC", "Digital", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/minecraft.png", "Minecraft Java Edition", "PC", 25000m, 999, 2, false },
                    { 8, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Suscripción PlayStation Plus 3 meses", "Digital", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/psplus.png", "PlayStation Plus Essential", "PlayStation", 45000m, 100, 3, false },
                    { 9, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Suscripción Game Pass Ultimate 1 mes", "Digital", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/gamepass.png", "Xbox Game Pass Ultimate", "Xbox", 30000m, 100, 3, false },
                    { 10, new DateTimeOffset(new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Suscripción Switch Online 12 meses", "Digital", "https://sukjueyvigrcyafzppjx.supabase.co/storage/v1/object/public/productos/nso.png", "Nintendo Switch Online", "Nintendo", 35000m, 100, 3, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "productos",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 1,
                column: "created_at",
                value: new DateTimeOffset(new DateTime(2026, 11, 17, 18, 6, 52, 558, DateTimeKind.Unspecified).AddTicks(2851), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 2,
                column: "created_at",
                value: new DateTimeOffset(new DateTime(2026, 11, 17, 18, 6, 52, 558, DateTimeKind.Unspecified).AddTicks(2854), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 3,
                column: "created_at",
                value: new DateTimeOffset(new DateTime(2026, 11, 17, 18, 6, 52, 558, DateTimeKind.Unspecified).AddTicks(2857), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}
