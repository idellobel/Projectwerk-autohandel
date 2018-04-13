using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autohandel.Domain.Migrations
{
    public partial class modelFaktuurIsChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakturen_OnderdelenProducten_OnderdelenProductenArtikelnummer",
                table: "Fakturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Fakturen_Voertuigen_VoertuigId",
                table: "Fakturen");

            migrationBuilder.DropIndex(
                name: "IX_Fakturen_VoertuigId",
                table: "Fakturen");

            migrationBuilder.DropColumn(
                name: "ArtikelId",
                table: "Fakturen");

            migrationBuilder.RenameColumn(
                name: "OnderdelenProductenArtikelnummer",
                table: "Fakturen",
                newName: "Artikelnummer");

            migrationBuilder.RenameIndex(
                name: "IX_Fakturen_OnderdelenProductenArtikelnummer",
                table: "Fakturen",
                newName: "IX_Fakturen_Artikelnummer");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Personen",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaswoordHash",
                table: "Personen",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VoertuigId",
                table: "Fakturen",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateIndex(
                name: "IX_Fakturen_VoertuigId",
                table: "Fakturen",
                column: "VoertuigId",
                unique: true,
                filter: "[VoertuigId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Fakturen_OnderdelenProducten_Artikelnummer",
                table: "Fakturen",
                column: "Artikelnummer",
                principalTable: "OnderdelenProducten",
                principalColumn: "Artikelnummer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fakturen_Voertuigen_VoertuigId",
                table: "Fakturen",
                column: "VoertuigId",
                principalTable: "Voertuigen",
                principalColumn: "VoertuigId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fakturen_OnderdelenProducten_Artikelnummer",
                table: "Fakturen");

            migrationBuilder.DropForeignKey(
                name: "FK_Fakturen_Voertuigen_VoertuigId",
                table: "Fakturen");

            migrationBuilder.DropIndex(
                name: "IX_Fakturen_VoertuigId",
                table: "Fakturen");

            migrationBuilder.RenameColumn(
                name: "Artikelnummer",
                table: "Fakturen",
                newName: "OnderdelenProductenArtikelnummer");

            migrationBuilder.RenameIndex(
                name: "IX_Fakturen_Artikelnummer",
                table: "Fakturen",
                newName: "IX_Fakturen_OnderdelenProductenArtikelnummer");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Personen",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PaswoordHash",
                table: "Personen",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "VoertuigId",
                table: "Fakturen",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ArtikelId",
                table: "Fakturen",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Fakturen_VoertuigId",
                table: "Fakturen",
                column: "VoertuigId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fakturen_OnderdelenProducten_OnderdelenProductenArtikelnummer",
                table: "Fakturen",
                column: "OnderdelenProductenArtikelnummer",
                principalTable: "OnderdelenProducten",
                principalColumn: "Artikelnummer",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Fakturen_Voertuigen_VoertuigId",
                table: "Fakturen",
                column: "VoertuigId",
                principalTable: "Voertuigen",
                principalColumn: "VoertuigId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
