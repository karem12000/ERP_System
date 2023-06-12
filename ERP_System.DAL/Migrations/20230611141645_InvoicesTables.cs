using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class InvoicesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseInvoices",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoices_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoices",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Buyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoices_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseInvoiceDetails",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QtyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PurchaseInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseInvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Guide",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_PurchaseInvoices_PurchaseInvoiceId",
                        column: x => x.PurchaseInvoiceId,
                        principalSchema: "Guide",
                        principalTable: "PurchaseInvoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseInvoiceDetails_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleInvoiceDetails",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QtyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SaleInvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleInvoiceDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaleInvoiceDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Guide",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoiceDetails_SaleInvoices_SaleInvoiceId",
                        column: x => x.SaleInvoiceId,
                        principalSchema: "Guide",
                        principalTable: "SaleInvoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoiceDetails_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoiceDetails_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleInvoiceDetails_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_AddedBy",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_DeletedBy",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_ModifiedBy",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_ProductId",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoiceDetails_PurchaseInvoiceId",
                schema: "Guide",
                table: "PurchaseInvoiceDetails",
                column: "PurchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_AddedBy",
                schema: "Guide",
                table: "PurchaseInvoices",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_DeletedBy",
                schema: "Guide",
                table: "PurchaseInvoices",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_ModifiedBy",
                schema: "Guide",
                table: "PurchaseInvoices",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_AddedBy",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_DeletedBy",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_ModifiedBy",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_ProductId",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoiceDetails_SaleInvoiceId",
                schema: "Guide",
                table: "SaleInvoiceDetails",
                column: "SaleInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_AddedBy",
                schema: "Guide",
                table: "SaleInvoices",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_DeletedBy",
                schema: "Guide",
                table: "SaleInvoices",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleInvoices_ModifiedBy",
                schema: "Guide",
                table: "SaleInvoices",
                column: "ModifiedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseInvoiceDetails",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "SaleInvoiceDetails",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "PurchaseInvoices",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "SaleInvoices",
                schema: "Guide");
        }
    }
}
