using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class updateSaleInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceTotalDiscount",
                schema: "Guide",
                table: "SaleThrowbacks",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceTotalDiscountType",
                schema: "Guide",
                table: "SaleThrowbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPProduct",
                schema: "Guide",
                table: "SaleThrowbackDetails",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountTypePProduct",
                schema: "Guide",
                table: "SaleThrowbackDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceTotalDiscountType",
                schema: "Guide",
                table: "SaleInvoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DiscountTypePProduct",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTotalDiscount",
                schema: "Guide",
                table: "SaleThrowbacks");

            migrationBuilder.DropColumn(
                name: "InvoiceTotalDiscountType",
                schema: "Guide",
                table: "SaleThrowbacks");

            migrationBuilder.DropColumn(
                name: "DiscountPProduct",
                schema: "Guide",
                table: "SaleThrowbackDetails");

            migrationBuilder.DropColumn(
                name: "DiscountTypePProduct",
                schema: "Guide",
                table: "SaleThrowbackDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceTotalDiscountType",
                schema: "Guide",
                table: "SaleInvoices");

            migrationBuilder.DropColumn(
                name: "DiscountTypePProduct",
                schema: "Guide",
                table: "SaleInvoiceDetails");
        }
    }
}
