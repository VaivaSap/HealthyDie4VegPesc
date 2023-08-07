using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegApp.Migrations
{
    public partial class UserNamePossibleNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_VegAppUserId",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "VegAppUserId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_VegAppUserId",
                table: "Products",
                column: "VegAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_VegAppUserId",
                table: "Products");

            migrationBuilder.AlterColumn<Guid>(
                name: "VegAppUserId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_VegAppUserId",
                table: "Products",
                column: "VegAppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
