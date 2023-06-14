using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class EditPurchaseInvoiceTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemUnitPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "PurchasingPrice");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PurchasingPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "SellingPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ItemUnitPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
