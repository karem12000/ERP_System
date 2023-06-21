using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class addPaidTpPurchaseThrowback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaid",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPaid",
                schema: "Guide",
                table: "PurchaseThrowbacks");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "Guide",
                table: "PurchaseThrowbacks");
        }
    }
}
