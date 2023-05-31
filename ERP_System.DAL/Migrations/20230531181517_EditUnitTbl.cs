using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP_System.DAL.Migrations
{
    public partial class EditUnitTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                schema: "Guide",
                table: "Units",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                schema: "Guide",
                table: "Units",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UnitType",
                schema: "Guide",
                table: "Units",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                schema: "Guide",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "Rate",
                schema: "Guide",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "UnitType",
                schema: "Guide",
                table: "Units");
        }
    }
}
