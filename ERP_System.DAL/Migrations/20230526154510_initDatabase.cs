using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class initDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Page");

            migrationBuilder.EnsureSchema(
                name: "People");

            migrationBuilder.EnsureSchema(
                name: "Guide");

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
                name: "Pages",
                schema: "Page",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ControllerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_ActionsPages_Pages_PageId",
                        column: x => x.PageId,
                        principalSchema: "Page",
                        principalTable: "Pages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                schema: "Page",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNo = table.Column<int>(type: "int", nullable: true),
                    IconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsLink = table.Column<bool>(type: "bit", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_Areas", x => x.ID);
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
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UseDefaultPassword = table.Column<bool>(type: "bit", nullable: false),
                    ResetPasswordDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CodeOfReset = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateIndex(
                name: "IX_Pages_AddedBy",
                schema: "Page",
                table: "Pages",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Pages_AreaId",
                schema: "Page",
                table: "Pages",
                column: "AreaId");

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
                name: "FK_Pages_Areas_AreaId",
                schema: "Page",
                table: "Pages",
                column: "AreaId",
                principalSchema: "Page",
                principalTable: "Areas",
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
                name: "FK_Areas_Users_AddedBy",
                schema: "Page",
                table: "Areas",
                column: "AddedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Users_DeletedBy",
                schema: "Page",
                table: "Areas",
                column: "DeletedBy",
                principalSchema: "People",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Users_ModifiedBy",
                schema: "Page",
                table: "Areas",
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
                name: "UserPermissions",
                schema: "People");

            migrationBuilder.DropTable(
                name: "ActionsPages",
                schema: "Page");

            migrationBuilder.DropTable(
                name: "Pages",
                schema: "Page");

            migrationBuilder.DropTable(
                name: "Areas",
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
