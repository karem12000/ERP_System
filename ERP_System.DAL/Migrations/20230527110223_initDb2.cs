using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class initDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Areas_AreaId",
                schema: "Page",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "Areas",
                schema: "Page");

            migrationBuilder.DropIndex(
                name: "IX_Pages_AreaId",
                schema: "Page",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "AreaId",
                schema: "Page",
                table: "Pages");

            migrationBuilder.EnsureSchema(
                name: "Setting");

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                schema: "People",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                schema: "Page",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PricePerUnit = table.Column<double>(type: "float", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Qty = table.Column<double>(type: "float", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: false),
                    ResourceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BuyerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Invoices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemGrpoups",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ItemGrpoups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ItemGrpoups_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGrpoups_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemGrpoups_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                schema: "Setting",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SiteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Settings", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Settings_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settings_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Settings_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Stocks",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManagerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Stocks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Stocks_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Units", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Units_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Units_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtyInStock = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Products_ItemGrpoups_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Guide",
                        principalTable: "ItemGrpoups",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitId",
                        column: x => x.UnitId,
                        principalSchema: "Guide",
                        principalTable: "Units",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceProducts",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_InvoiceProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalSchema: "Guide",
                        principalTable: "Invoices",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Guide",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceProducts_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockProducts",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_StockProducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Guide",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockProducts_Stocks_StockId",
                        column: x => x.StockId,
                        principalSchema: "Guide",
                        principalTable: "Stocks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockProducts_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockProducts_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StockProducts_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_AddedBy",
                schema: "Guide",
                table: "InvoiceProducts",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_DeletedBy",
                schema: "Guide",
                table: "InvoiceProducts",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_InvoiceId",
                schema: "Guide",
                table: "InvoiceProducts",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_ModifiedBy",
                schema: "Guide",
                table: "InvoiceProducts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceProducts_ProductId",
                schema: "Guide",
                table: "InvoiceProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_AddedBy",
                schema: "Guide",
                table: "Invoices",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_DeletedBy",
                schema: "Guide",
                table: "Invoices",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ModifiedBy",
                schema: "Guide",
                table: "Invoices",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGrpoups_AddedBy",
                schema: "Guide",
                table: "ItemGrpoups",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGrpoups_DeletedBy",
                schema: "Guide",
                table: "ItemGrpoups",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ItemGrpoups_ModifiedBy",
                schema: "Guide",
                table: "ItemGrpoups",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AddedBy",
                schema: "Guide",
                table: "Products",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_DeletedBy",
                schema: "Guide",
                table: "Products",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_GroupId",
                schema: "Guide",
                table: "Products",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ModifiedBy",
                schema: "Guide",
                table: "Products",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitId",
                schema: "Guide",
                table: "Products",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_AddedBy",
                schema: "Setting",
                table: "Settings",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_DeletedBy",
                schema: "Setting",
                table: "Settings",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_ModifiedBy",
                schema: "Setting",
                table: "Settings",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_AddedBy",
                schema: "Guide",
                table: "StockProducts",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_DeletedBy",
                schema: "Guide",
                table: "StockProducts",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_ModifiedBy",
                schema: "Guide",
                table: "StockProducts",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_ProductId",
                schema: "Guide",
                table: "StockProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_StockProducts_StockId",
                schema: "Guide",
                table: "StockProducts",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_AddedBy",
                schema: "Guide",
                table: "Stocks",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_DeletedBy",
                schema: "Guide",
                table: "Stocks",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ModifiedBy",
                schema: "Guide",
                table: "Stocks",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_UserId",
                schema: "Guide",
                table: "Stocks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Units_AddedBy",
                schema: "Guide",
                table: "Units",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Units_DeletedBy",
                schema: "Guide",
                table: "Units",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Units_ModifiedBy",
                schema: "Guide",
                table: "Units",
                column: "ModifiedBy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceProducts",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "StockProducts",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "ItemGrpoups",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "Guide");

            migrationBuilder.DropColumn(
                name: "UserImage",
                schema: "People",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "AreaName",
                schema: "Page",
                table: "Pages");

            migrationBuilder.AddColumn<Guid>(
                name: "AreaId",
                schema: "Page",
                table: "Pages",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "Page",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsLink = table.Column<bool>(type: "bit", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Areas_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Areas_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Areas_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_AreaId",
                schema: "Page",
                table: "Pages",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_AddedBy",
                schema: "Page",
                table: "Areas",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_DeletedBy",
                schema: "Page",
                table: "Areas",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_ModifiedBy",
                schema: "Page",
                table: "Areas",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Areas_AreaId",
                schema: "Page",
                table: "Pages",
                column: "AreaId",
                principalSchema: "Page",
                principalTable: "Areas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
