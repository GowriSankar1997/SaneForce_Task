using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaneForce.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProductTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductMaster",
                columns: new[] { "Code", "Name", "Rate" },
                values: new object[] { 1, "xxx", 1m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductMaster",
                keyColumn: "Code",
                keyValue: 1);
        }
    }
}
