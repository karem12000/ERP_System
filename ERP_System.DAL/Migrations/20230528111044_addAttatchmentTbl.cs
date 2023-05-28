using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class addAttatchmentTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                schema: "Guide",
                table: "Products");

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
                    table.ForeignKey(
                        name: "FK_Attachments_Users_AddedBy",
                        column: x => x.AddedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Users_DeletedBy",
                        column: x => x.DeletedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attachments_Users_ModifiedBy",
                        column: x => x.ModifiedBy,
                        principalSchema: "People",
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachments",
                schema: "Guide");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                schema: "Guide",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
