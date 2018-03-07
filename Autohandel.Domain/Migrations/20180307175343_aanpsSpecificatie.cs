using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autohandel.Domain.Migrations
{
    public partial class aanpsSpecificatie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Fietstypes",
                table: "Specificaties",
                maxLength: 75,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StekkerAansluiting",
                table: "Specificaties",
                maxLength: 75,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fietstypes",
                table: "Specificaties");

            migrationBuilder.DropColumn(
                name: "StekkerAansluiting",
                table: "Specificaties");
        }
    }
}
