using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegApp.Migrations
{
    public partial class ProductsToAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProteinsIn100g = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CarbsIn100g = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FatsIn100g = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CaloriesIn100g = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VegAppUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_AspNetUsers_VegAppUserId",
                        column: x => x.VegAppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_VegAppUserId",
                table: "Products",
                column: "VegAppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
