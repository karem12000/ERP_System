using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class addPaidTpPurchase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaid",
                schema: "Guide",
                table: "SaleThrowbacks",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPaid",
                schema: "Guide",
                table: "PurchaseInvoices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                schema: "Guide",
                table: "PurchaseInvoices",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPaid",
                schema: "Guide",
                table: "SaleThrowbacks");

            migrationBuilder.DropColumn(
                name: "TotalPaid",
                schema: "Guide",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "TransactionType",
                schema: "Guide",
                table: "PurchaseInvoices");
        }
    }
}
