using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SaneForce.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Code",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "ProductMaster",
                columns: new[] { "Code", "Name", "Rate" },
                values: new object[,]
                {
                    { 111, "mango", 12m },
                    { 222, "apple", 10m },
                    { 333, "banana", 13m },
                    { 444, "pine apple", 14m },
                    { 555, "grapes", 16m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Code",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Code",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Code",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Code",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Code",
                keyValue: 555);

            migrationBuilder.InsertData(
                table: "ProductMaster",
                columns: new[] { "Code", "Name", "Rate" },
                values: new object[] { 1, "xxx", 1m });
        }
    }
}
