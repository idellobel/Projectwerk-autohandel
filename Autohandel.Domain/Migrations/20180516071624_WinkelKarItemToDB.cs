using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autohandel.Domain.Migrations
{
    public partial class WinkelKarItemToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WinkelkarItems",
                columns: table => new
                {
                    WinkelkarItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    ProductArtikelnummer = table.Column<string>(nullable: true),
                    WinkelkarId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WinkelkarItems", x => x.WinkelkarItemId);
                    table.ForeignKey(
                        name: "FK_WinkelkarItems_OnderdelenProducten_ProductArtikelnummer",
                        column: x => x.ProductArtikelnummer,
                        principalTable: "OnderdelenProducten",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WinkelkarItems_ProductArtikelnummer",
                table: "WinkelkarItems",
                column: "ProductArtikelnummer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WinkelkarItems");
        }
    }
}
