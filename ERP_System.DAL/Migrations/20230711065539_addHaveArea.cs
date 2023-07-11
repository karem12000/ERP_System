using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class addHaveArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArea",
                schema: "Page",
                table: "Pages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "haveArea",
                schema: "Page",
                table: "Pages",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArea",
                schema: "Page",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "haveArea",
                schema: "Page",
                table: "Pages");
        }
    }
}
