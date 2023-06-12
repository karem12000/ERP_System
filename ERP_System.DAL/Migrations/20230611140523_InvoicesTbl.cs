using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class InvoicesTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GroupId",
                schema: "Guide",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "GroupName",
                schema: "Guide",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "StockId",
                schema: "Guide",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "ResourceName",
                schema: "Guide",
                table: "Invoices",
                newName: "Supplier");

            migrationBuilder.RenameColumn(
                name: "BuyerName",
                schema: "Guide",
                table: "Invoices",
                newName: "StockName");

            migrationBuilder.RenameColumn(
                name: "StockName",
                schema: "Guide",
                table: "InvoiceDetails",
                newName: "ProductName");

            migrationBuilder.RenameColumn(
                name: "PricePerUnit",
                schema: "Guide",
                table: "InvoiceDetails",
                newName: "SalePrice");

            migrationBuilder.AddColumn<string>(
                name: "Buyer",
                schema: "Guide",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StockId",
                schema: "Guide",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "QtyPrice",
                schema: "Guide",
                table: "InvoiceDetails",
                type: "decimal(18,2)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Buyer",
                schema: "Guide",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "StockId",
                schema: "Guide",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "QtyPrice",
                schema: "Guide",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "Supplier",
                schema: "Guide",
                table: "Invoices",
                newName: "ResourceName");

            migrationBuilder.RenameColumn(
                name: "StockName",
                schema: "Guide",
                table: "Invoices",
                newName: "BuyerName");

            migrationBuilder.RenameColumn(
                name: "SalePrice",
                schema: "Guide",
                table: "InvoiceDetails",
                newName: "PricePerUnit");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                schema: "Guide",
                table: "InvoiceDetails",
                newName: "StockName");

            migrationBuilder.AddColumn<Guid>(
                name: "GroupId",
                schema: "Guide",
                table: "InvoiceDetails",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                schema: "Guide",
                table: "InvoiceDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StockId",
                schema: "Guide",
                table: "InvoiceDetails",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
