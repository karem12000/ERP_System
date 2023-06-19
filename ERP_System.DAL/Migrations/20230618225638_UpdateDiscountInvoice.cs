using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class UpdateDiscountInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "InvoiceTotalDiscount",
                schema: "Guide",
                table: "SaleInvoices",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPProduct",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceTotalDiscount",
                schema: "Guide",
                table: "SaleInvoices");

            migrationBuilder.DropColumn(
                name: "DiscountPProduct",
                schema: "Guide",
                table: "SaleInvoiceDetails");
        }
    }
}
