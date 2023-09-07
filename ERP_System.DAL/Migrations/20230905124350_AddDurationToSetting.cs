using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class AddDurationToSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Duration",
                schema: "Setting",
                table: "Settings",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duration",
                schema: "Setting",
                table: "Settings");
        }
    }
}
