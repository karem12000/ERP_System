using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class UpdatePInvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Supplier",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                newName: "SupplierName");

            migrationBuilder.RenameColumn(
                name: "Supplier",
                schema: "Guide",
                table: "PurchaseInvoices",
                newName: "SupplierName");

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SupplierId",
                schema: "Guide",
                table: "PurchaseInvoices",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Guide",
                table: "PurchaseThrowbacks");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                schema: "Guide",
                table: "PurchaseInvoices");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                newName: "Supplier");

            migrationBuilder.RenameColumn(
                name: "SupplierName",
                schema: "Guide",
                table: "PurchaseInvoices",
                newName: "Supplier");
        }
    }
}
