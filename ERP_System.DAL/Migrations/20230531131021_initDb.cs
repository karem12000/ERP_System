using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class initDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Page");

            migrationBuilder.EnsureSchema(
                name: "Guide");

            migrationBuilder.EnsureSchema(
                name: "Setting");

            migrationBuilder.EnsureSchema(
                name: "People");

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                schema: "People",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PageActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_UserPermissions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Qty = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PricePerUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
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
                    table.PrimaryKey("PK_InvoiceDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    BarCodeText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BarCodePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "ActionsPages",
                schema: "Page",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActionName = table.Column<int>(type: "int", nullable: false),
                    PageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_ActionsPages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Attachments",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Attachments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Attachments_Products_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "Guide",
                        principalTable: "Products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                });

            migrationBuilder.CreateTable(
                name: "UserStocks",
                schema: "People",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StockId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_UserStocks", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "Guide",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InvoiceType = table.Column<int>(type: "int", nullable: true),
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
                });

            migrationBuilder.CreateTable(
                name: "Pages",
                schema: "Page",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Pages", x => x.ID);
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
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
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
                    table.PrimaryKey("PK_UserTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "People",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UseDefaultPassword = table.Column<bool>(type: "bit", nullable: false),
                    ResetPasswordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodeOfReset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserClassification = table.Column<int>(type: "int", nullable: true),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Users_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_UserTypes_UserTypeId",
                        column: x => x.UserTypeId,
                        principalSchema: "Guide",
                        principalTable: "UserTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionsPages_AddedBy",
                schema: "Page",
                table: "ActionsPages",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActionsPages_DeletedBy",
                schema: "Page",
                table: "ActionsPages",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActionsPages_ModifiedBy",
                schema: "Page",
                table: "ActionsPages",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_ActionsPages_PageId",
                schema: "Page",
                table: "ActionsPages",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_AddedBy",
                schema: "Guide",
                table: "Attachments",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_DeletedBy",
                schema: "Guide",
                table: "Attachments",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ModifiedBy",
                schema: "Guide",
                table: "Attachments",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Attachments_ProductId",
                schema: "Guide",
                table: "Attachments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_AddedBy",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_DeletedBy",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceId",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ModifiedBy",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_ProductId",
                schema: "Guide",
                table: "InvoiceDetails",
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
                name: "IX_Pages_AddedBy",
                schema: "Page",
                table: "Pages",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_DeletedBy",
                schema: "Page",
                table: "Pages",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_ModifiedBy",
                schema: "Page",
                table: "Pages",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_AddedBy",
                schema: "People",
                table: "UserPermissions",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_DeletedBy",
                schema: "People",
                table: "UserPermissions",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_ModifiedBy",
                schema: "People",
                table: "UserPermissions",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_PageActionId",
                schema: "People",
                table: "UserPermissions",
                column: "PageActionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserTypeId",
                schema: "People",
                table: "UserPermissions",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AddedBy",
                schema: "People",
                table: "Users",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_DeletedBy",
                schema: "People",
                table: "Users",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ModifiedBy",
                schema: "People",
                table: "Users",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserTypeId",
                schema: "People",
                table: "Users",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStocks_AddedBy",
                schema: "People",
                table: "UserStocks",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserStocks_DeletedBy",
                schema: "People",
                table: "UserStocks",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserStocks_ModifiedBy",
                schema: "People",
                table: "UserStocks",
                column: "ModifiedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserStocks_StockId",
                schema: "People",
                table: "UserStocks",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_UserStocks_UserId",
                schema: "People",
                table: "UserStocks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_AddedBy",
                schema: "Guide",
                table: "UserTypes",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_DeletedBy",
                schema: "Guide",
                table: "UserTypes",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_UserTypes_ModifiedBy",
                schema: "Guide",
                table: "UserTypes",
                column: "ModifiedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_ActionsPages_PageActionId",
                schema: "People",
                table: "UserPermissions",
                column: "PageActionId",
                principalSchema: "Page",
                principalTable: "ActionsPages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Users_AddedBy",
                schema: "People",
                table: "UserPermissions",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Users_DeletedBy",
                schema: "People",
                table: "UserPermissions",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_Users_ModifiedBy",
                schema: "People",
                table: "UserPermissions",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermissions_UserTypes_UserTypeId",
                schema: "People",
                table: "UserPermissions",
                column: "UserTypeId",
                principalSchema: "Guide",
                principalTable: "UserTypes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Invoices_InvoiceId",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "InvoiceId",
                principalSchema: "Guide",
                principalTable: "Invoices",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Products_ProductId",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "ProductId",
                principalSchema: "Guide",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Users_AddedBy",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Users_DeletedBy",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_Users_ModifiedBy",
                schema: "Guide",
                table: "InvoiceDetails",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ItemGrpoups_GroupId",
                schema: "Guide",
                table: "Products",
                column: "GroupId",
                principalSchema: "Guide",
                principalTable: "ItemGrpoups",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Units_UnitId",
                schema: "Guide",
                table: "Products",
                column: "UnitId",
                principalSchema: "Guide",
                principalTable: "Units",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_AddedBy",
                schema: "Guide",
                table: "Products",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_DeletedBy",
                schema: "Guide",
                table: "Products",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_ModifiedBy",
                schema: "Guide",
                table: "Products",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionsPages_Pages_PageId",
                schema: "Page",
                table: "ActionsPages",
                column: "PageId",
                principalSchema: "Page",
                principalTable: "Pages",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionsPages_Users_AddedBy",
                schema: "Page",
                table: "ActionsPages",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionsPages_Users_DeletedBy",
                schema: "Page",
                table: "ActionsPages",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionsPages_Users_ModifiedBy",
                schema: "Page",
                table: "ActionsPages",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Users_AddedBy",
                schema: "Guide",
                table: "Attachments",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Users_DeletedBy",
                schema: "Guide",
                table: "Attachments",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachments_Users_ModifiedBy",
                schema: "Guide",
                table: "Attachments",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Stocks_StockId",
                schema: "Guide",
                table: "StockProducts",
                column: "StockId",
                principalSchema: "Guide",
                principalTable: "Stocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Users_AddedBy",
                schema: "Guide",
                table: "StockProducts",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Users_DeletedBy",
                schema: "Guide",
                table: "StockProducts",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockProducts_Users_ModifiedBy",
                schema: "Guide",
                table: "StockProducts",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStocks_Stocks_StockId",
                schema: "People",
                table: "UserStocks",
                column: "StockId",
                principalSchema: "Guide",
                principalTable: "Stocks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStocks_Users_AddedBy",
                schema: "People",
                table: "UserStocks",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStocks_Users_DeletedBy",
                schema: "People",
                table: "UserStocks",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStocks_Users_ModifiedBy",
                schema: "People",
                table: "UserStocks",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserStocks_Users_UserId",
                schema: "People",
                table: "UserStocks",
                column: "UserId",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_AddedBy",
                schema: "Guide",
                table: "Invoices",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_DeletedBy",
                schema: "Guide",
                table: "Invoices",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_ModifiedBy",
                schema: "Guide",
                table: "Invoices",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGrpoups_Users_AddedBy",
                schema: "Guide",
                table: "ItemGrpoups",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGrpoups_Users_DeletedBy",
                schema: "Guide",
                table: "ItemGrpoups",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemGrpoups_Users_ModifiedBy",
                schema: "Guide",
                table: "ItemGrpoups",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_AddedBy",
                schema: "Page",
                table: "Pages",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_DeletedBy",
                schema: "Page",
                table: "Pages",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Users_ModifiedBy",
                schema: "Page",
                table: "Pages",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_AddedBy",
                schema: "Setting",
                table: "Settings",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_DeletedBy",
                schema: "Setting",
                table: "Settings",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_ModifiedBy",
                schema: "Setting",
                table: "Settings",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_AddedBy",
                schema: "Guide",
                table: "Stocks",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_DeletedBy",
                schema: "Guide",
                table: "Stocks",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Users_ModifiedBy",
                schema: "Guide",
                table: "Stocks",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_AddedBy",
                schema: "Guide",
                table: "Units",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_DeletedBy",
                schema: "Guide",
                table: "Units",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Users_ModifiedBy",
                schema: "Guide",
                table: "Units",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Users_AddedBy",
                schema: "Guide",
                table: "UserTypes",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Users_DeletedBy",
                schema: "Guide",
                table: "UserTypes",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTypes_Users_ModifiedBy",
                schema: "Guide",
                table: "UserTypes",
                column: "ModifiedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Users_AddedBy",
                schema: "Guide",
                table: "UserTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Users_DeletedBy",
                schema: "Guide",
                table: "UserTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTypes_Users_ModifiedBy",
                schema: "Guide",
                table: "UserTypes");

            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "InvoiceDetails",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Settings",
                schema: "Setting");

            migrationBuilder.DropTable(
                name: "StockProducts",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "UserPermissions",
                schema: "People");

            migrationBuilder.DropTable(
                name: "UserStocks",
                schema: "People");

            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Products",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "ActionsPages",
                schema: "Page");

            migrationBuilder.DropTable(
                name: "Stocks",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "ItemGrpoups",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Units",
                schema: "Guide");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "Page");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "People");

            migrationBuilder.DropTable(
                name: "UserTypes",
                schema: "Guide");
        }
    }
}
