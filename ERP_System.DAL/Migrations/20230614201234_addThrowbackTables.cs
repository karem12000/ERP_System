using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class addThrowbackTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PurchaseThrowbacks",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_PurchaseThrowbacks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseThrowbacks_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseThrowbacks_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseThrowbacks_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleThrowbacks",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Buyer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceTotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_SaleThrowbacks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaleThrowbacks_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleThrowbacks_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleThrowbacks_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseThrowbackDetails",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductBarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConversionFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchasingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalQtyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchaseThrowbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_PurchaseThrowbackDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PurchaseThrowbackDetails_PurchaseThrowbacks_PurchaseThrowbackId",
                        column: x => x.PurchaseThrowbackId,
                        principalSchema: "Guide",
                        principalTable: "PurchaseThrowbacks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseThrowbackDetails_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseThrowbackDetails_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PurchaseThrowbackDetails_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SaleThrowbackDetails",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductBarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConversionFactor = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ItemUnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SellingPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalQtyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SaleThrowbackId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_SaleThrowbackDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SaleThrowbackDetails_SaleThrowbacks_SaleThrowbackId",
                        column: x => x.SaleThrowbackId,
                        principalSchema: "Guide",
                        principalTable: "SaleThrowbacks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleThrowbackDetails_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleThrowbackDetails_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SaleThrowbackDetails_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseThrowbackDetails_AddedBy",
                schema: "Guide",
                table: "PurchaseThrowbackDetails",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseThrowbackDetails_DeletedBy",
                schema: "Guide",
                table: "PurchaseThrowbackDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseThrowbackDetails_ModifiedBy",
                schema: "Guide",
                table: "PurchaseThrowbackDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseThrowbackDetails_PurchaseThrowbackId",
                schema: "Guide",
                table: "PurchaseThrowbackDetails",
                column: "PurchaseThrowbackId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseThrowbacks_AddedBy",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseThrowbacks_DeletedBy",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseThrowbacks_ModifiedBy",
                schema: "Guide",
                table: "PurchaseThrowbacks",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleThrowbackDetails_AddedBy",
                schema: "Guide",
                table: "SaleThrowbackDetails",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleThrowbackDetails_DeletedBy",
                schema: "Guide",
                table: "SaleThrowbackDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleThrowbackDetails_ModifiedBy",
                schema: "Guide",
                table: "SaleThrowbackDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleThrowbackDetails_SaleThrowbackId",
                schema: "Guide",
                table: "SaleThrowbackDetails",
                column: "SaleThrowbackId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleThrowbacks_AddedBy",
                schema: "Guide",
                table: "SaleThrowbacks",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleThrowbacks_DeletedBy",
                schema: "Guide",
                table: "SaleThrowbacks",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SaleThrowbacks_ModifiedBy",
                schema: "Guide",
                table: "SaleThrowbacks",
                column: "ModifiedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseThrowbackDetails",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "SaleThrowbackDetails",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "PurchaseThrowbacks",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "SaleThrowbacks",
                schema: "Guide");
        }
    }
}
