using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaneForce.Services.ProductAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderDetailsToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderDetailsMaster",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Qty = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    TaxPercentage = table.Column<double>(type: "float", nullable: false),
                    TaxAmount = table.Column<double>(type: "float", nullable: false),
                    GrossTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetailsMaster", x => x.Code);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetailsMaster");
        }
    }
}
