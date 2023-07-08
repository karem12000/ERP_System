using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class AddPurchaseDetailId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AddedTax",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseInvoiceDate",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseInvoiceId",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PurchaseDetailId",
                schema: "Guide",
                table: "PurchaseThrowbackDetails",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedTax",
                schema: "Guide",
                table: "PurchaseThrowbacks");

            migrationBuilder.DropColumn(
                name: "PurchaseInvoiceDate",
                schema: "Guide",
                table: "PurchaseThrowbacks");

            migrationBuilder.DropColumn(
                name: "PurchaseInvoiceId",
                schema: "Guide",
                table: "PurchaseThrowbacks");

            migrationBuilder.DropColumn(
                name: "PurchaseDetailId",
                schema: "Guide",
                table: "PurchaseThrowbackDetails");
        }
    }
}
