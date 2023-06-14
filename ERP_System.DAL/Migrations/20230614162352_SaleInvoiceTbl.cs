using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class SaleInvoiceTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SaleInvoiceDetails_Products_ProductId",
                schema: "Guide",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_SaleInvoiceDetails_ProductId",
                schema: "Guide",
                table: "SaleInvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                schema: "Guide",
                table: "SaleInvoices",
                newName: "InvoiceTotalPrice");

            migrationBuilder.RenameColumn(
                name: "UnitName",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                newName: "ProductBarCode");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                newName: "TotalQtyPrice");

            migrationBuilder.RenameColumn(
                name: "QtyPrice",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                newName: "SellingPrice");

            migrationBuilder.AddColumn<decimal>(
                name: "ConversionFactor",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ItemUnitPrice",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversionFactor",
                schema: "Guide",
                table: "SaleInvoiceDetails");

            migrationBuilder.DropColumn(
                name: "ItemUnitPrice",
                schema: "Guide",
                table: "SaleInvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "InvoiceTotalPrice",
                schema: "Guide",
                table: "SaleInvoices",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "TotalQtyPrice",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                newName: "SalePrice");

            migrationBuilder.RenameColumn(
                name: "SellingPrice",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                newName: "QtyPrice");

            migrationBuilder.RenameColumn(
                name: "ProductBarCode",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                newName: "UnitName");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_ProductId",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SaleInvoiceDetails_Products_ProductId",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                column: "ProductId",
                principalSchema: "Guide",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
