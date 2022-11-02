using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegApp.Migrations
{
    public partial class EatenProductEntityIncorporated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EatenProducts",
                columns: table => new
                {
                    EatenProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateWhenEaten = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EatenProducts", x => x.EatenProductId);
                    table.ForeignKey(
                        name: "FK_EatenProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EatenProducts_ProductId",
                table: "EatenProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EatenProducts");
        }
    }
}
