using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegApp.Migrations
{
    public partial class AddUserIdForEatenProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VegAppUserId",
                table: "EatenProducts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VegAppUserId",
                table: "EatenProducts");
        }
    }
}
