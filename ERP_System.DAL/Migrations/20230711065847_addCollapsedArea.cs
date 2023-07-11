using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class addCollapsedArea : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CollapsedArea",
                schema: "Page",
                table: "Pages",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CollapsedArea",
                schema: "Page",
                table: "Pages");
        }
    }
}
