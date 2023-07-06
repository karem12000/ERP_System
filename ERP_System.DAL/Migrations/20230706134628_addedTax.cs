using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class addedTax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AddedTax",
                schema: "Guide",
                table: "SaleThrowbacks",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SaleInvoiceId",
                schema: "Guide",
                table: "SaleThrowbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AddedTax",
                schema: "Guide",
                table: "SaleInvoices",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedTax",
                schema: "Guide",
                table: "SaleThrowbacks");

            migrationBuilder.DropColumn(
                name: "SaleInvoiceId",
                schema: "Guide",
                table: "SaleThrowbacks");

            migrationBuilder.DropColumn(
                name: "AddedTax",
                schema: "Guide",
                table: "SaleInvoices");
        }
    }
}
