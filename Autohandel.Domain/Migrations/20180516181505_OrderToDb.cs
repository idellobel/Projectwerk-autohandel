using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autohandel.Domain.Migrations
{
    public partial class OrderToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adres = table.Column<string>(maxLength: 75, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Gemeente = table.Column<string>(maxLength: 75, nullable: false),
                    Land = table.Column<string>(maxLength: 75, nullable: false),
                    Naam = table.Column<string>(maxLength: 75, nullable: false),
                    OrderGeplaatst = table.Column<DateTime>(nullable: false),
                    OrderTotaal = table.Column<decimal>(nullable: false),
                    Postcode = table.Column<string>(nullable: false),
                    Telefoonnummer = table.Column<string>(nullable: false),
                    Voornaam = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aantal = table.Column<int>(nullable: false),
                    ArtikelNummer = table.Column<string>(nullable: true),
                    FaktuurNr = table.Column<long>(nullable: true),
                    OrderId = table.Column<int>(nullable: false),
                    Prijs = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_OnderdelenProducten_ArtikelNummer",
                        column: x => x.ArtikelNummer,
                        principalTable: "OnderdelenProducten",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Fakturen_FaktuurNr",
                        column: x => x.FaktuurNr,
                        principalTable: "Fakturen",
                        principalColumn: "FaktuurNr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ArtikelNummer",
                table: "OrderDetails",
                column: "ArtikelNummer");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_FaktuurNr",
                table: "OrderDetails",
                column: "FaktuurNr");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
