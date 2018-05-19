using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autohandel.Domain.Migrations
{
    public partial class amounttoaantal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "WinkelkarItems",
                newName: "Aantal");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aantal",
                table: "WinkelkarItems",
                newName: "Amount");
        }
    }
}
