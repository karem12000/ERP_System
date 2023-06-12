using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class EditPurchaseTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceDetails_Products_ProductId",
                schema: "Guide",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoiceDetails_ProductId",
                schema: "Guide",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Supplier",
                schema: "Guide",
                table: "SaleInvoices");

            migrationBuilder.DropColumn(
                name: "Buyer",
                schema: "Guide",
                table: "PurchaseInvoices");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "Guide",
                table: "PurchaseInvoices",
                newName: "InvoiceTotalPrice");

            migrationBuilder.RenameColumn(
                name: "UnitName",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "ProductBarCode");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "TotalQtyPrice");

            migrationBuilder.RenameColumn(
                name: "QtyPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "SellingPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ConversionFactor",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemUnitPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversionFactor",
                schema: "Guide",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "ItemUnitPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "InvoiceTotalPrice",
                schema: "Guide",
                table: "PurchaseInvoices",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalQtyPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "SalePrice");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "QtyPrice");

            migrationBuilder.RenameColumn(
                name: "ProductBarCode",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                newName: "UnitName");

            migrationBuilder.AddColumn<string>(
                name: "Supplier",
                schema: "Guide",
                table: "SaleInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                schema: "Guide",
                table: "PurchaseInvoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_ProductId",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceDetails_Products_ProductId",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                column: "ProductId",
                principalSchema: "Guide",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
