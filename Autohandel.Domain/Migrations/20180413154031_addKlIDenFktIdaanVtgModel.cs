using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autohandel.Domain.Migrations
{
    public partial class addKlIDenFktIdaanVtgModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voertuigen_Personen_KlantPersoonId",
                table: "Voertuigen");

            migrationBuilder.RenameColumn(
                name: "KlantPersoonId",
                table: "Voertuigen",
                newName: "KlantId");

            migrationBuilder.RenameIndex(
                name: "IX_Voertuigen_KlantPersoonId",
                table: "Voertuigen",
                newName: "IX_Voertuigen_KlantId");

            migrationBuilder.AddColumn<long>(
                name: "FaktuurNr",
                table: "Voertuigen",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Voertuigen_Personen_KlantId",
                table: "Voertuigen",
                column: "KlantId",
                principalTable: "Personen",
                principalColumn: "PersoonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voertuigen_Personen_KlantId",
                table: "Voertuigen");

            migrationBuilder.DropColumn(
                name: "FaktuurNr",
                table: "Voertuigen");

            migrationBuilder.RenameColumn(
                name: "KlantId",
                table: "Voertuigen",
                newName: "KlantPersoonId");

            migrationBuilder.RenameIndex(
                name: "IX_Voertuigen_KlantId",
                table: "Voertuigen",
                newName: "IX_Voertuigen_KlantPersoonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voertuigen_Personen_KlantPersoonId",
                table: "Voertuigen",
                column: "KlantPersoonId",
                principalTable: "Personen",
                principalColumn: "PersoonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
