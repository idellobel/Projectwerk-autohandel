using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autohandel.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategorieOnderdelen",
                columns: table => new
                {
                    OnderdelenCategorieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FiguurURL = table.Column<string>(maxLength: 512, nullable: true),
                    OnderdelenCategorienaam = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorieOnderdelen", x => x.OnderdelenCategorieId);
                    table.ForeignKey(
                        name: "FK_CategorieOnderdelen_CategorieOnderdelen_ParentId",
                        column: x => x.ParentId,
                        principalTable: "CategorieOnderdelen",
                        principalColumn: "OnderdelenCategorieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fakturen",
                columns: table => new
                {
                    FaktuurNr = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ArtikelId = table.Column<long>(nullable: false),
                    Faktuurdatum = table.Column<DateTime>(nullable: false),
                    KlantId = table.Column<long>(nullable: false),
                    VoertuigId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fakturen", x => x.FaktuurNr);
                });

            migrationBuilder.CreateTable(
                name: "Merken",
                columns: table => new
                {
                    MerkId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MerkNaam = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Merken", x => x.MerkId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Specificaties",
                columns: table => new
                {
                    SpecificatieId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Aanhangwagengewicht = table.Column<int>(nullable: false),
                    AantalFietsen = table.Column<int>(nullable: false),
                    Binnendiameter = table.Column<int>(nullable: false),
                    Breedte = table.Column<int>(nullable: false),
                    Buitendiameter = table.Column<int>(nullable: false),
                    CityCrash = table.Column<bool>(nullable: false),
                    Dikte = table.Column<int>(nullable: false),
                    Draagvermogen = table.Column<string>(nullable: true),
                    Fietstypes = table.Column<string>(maxLength: 75, nullable: true),
                    Flappen = table.Column<string>(maxLength: 75, nullable: true),
                    Formaat = table.Column<string>(nullable: true),
                    GarantieTermijn = table.Column<string>(maxLength: 75, nullable: true),
                    Geur = table.Column<string>(maxLength: 50, nullable: true),
                    Gewicht = table.Column<int>(nullable: false),
                    Goedkeuring = table.Column<string>(maxLength: 75, nullable: true),
                    Hoogte = table.Column<int>(nullable: false),
                    Inhoud = table.Column<int>(nullable: false),
                    Inklapbaar = table.Column<bool>(nullable: false),
                    Kantelfunctie = table.Column<int>(nullable: false),
                    Kleur = table.Column<int>(nullable: false),
                    Lengte = table.Column<int>(nullable: false),
                    Mat = table.Column<string>(maxLength: 75, nullable: true),
                    Materie = table.Column<string>(maxLength: 75, nullable: true),
                    MaxBelading = table.Column<int>(nullable: false),
                    MaxVertikaleLast = table.Column<int>(nullable: false),
                    Mengbaar = table.Column<string>(nullable: true),
                    MinimaleTemperatuur = table.Column<string>(maxLength: 150, nullable: true),
                    Mistlicht = table.Column<bool>(nullable: false),
                    Montageset = table.Column<string>(nullable: true),
                    Opening = table.Column<string>(nullable: true),
                    Rolgeluid = table.Column<string>(nullable: true),
                    Schroefdraad = table.Column<string>(maxLength: 75, nullable: true),
                    SnelheidIndex = table.Column<string>(nullable: true),
                    StekkerAansluiting = table.Column<string>(maxLength: 75, nullable: true),
                    Type = table.Column<string>(maxLength: 75, nullable: true),
                    Vergrendeling = table.Column<string>(nullable: true),
                    WaaromKeuze = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specificaties", x => x.SpecificatieId);
                });

            migrationBuilder.CreateTable(
                name: "VoertuigCategorieen",
                columns: table => new
                {
                    VoertuigCatId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VoertuigCategorieNaam = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoertuigCategorieen", x => x.VoertuigCatId);
                });

            migrationBuilder.CreateTable(
                name: "GarantieTabel",
                columns: table => new
                {
                    GarantieId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FaktuurId = table.Column<long>(nullable: false),
                    Vervaldatum = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GarantieTabel", x => x.GarantieId);
                    table.ForeignKey(
                        name: "FK_GarantieTabel_Fakturen_FaktuurId",
                        column: x => x.FaktuurId,
                        principalTable: "Fakturen",
                        principalColumn: "FaktuurNr",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    FaktuurNr = table.Column<long>(nullable: true),
                    KlantId = table.Column<long>(nullable: true),
                    KlantNaam = table.Column<string>(maxLength: 150, nullable: true),
                    Klantdatum = table.Column<DateTime>(nullable: true),
                    LeverancierDatum = table.Column<DateTime>(nullable: true),
                    LeverancierID = table.Column<long>(nullable: true),
                    LeverancierNaam = table.Column<string>(maxLength: 50, nullable: true),
                    PersoonId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Adres = table.Column<string>(maxLength: 70, nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Gemeente = table.Column<string>(maxLength: 30, nullable: false),
                    Naam = table.Column<string>(maxLength: 150, nullable: false),
                    Postcode = table.Column<int>(nullable: false),
                    Telefoonnummer = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(maxLength: 150, nullable: false),
                    PaswoordHash = table.Column<string>(nullable: true),
                    RememberMe = table.Column<bool>(nullable: true),
                    UserId = table.Column<long>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.PersoonId);
                    table.ForeignKey(
                        name: "FK_Personen_Fakturen_FaktuurNr",
                        column: x => x.FaktuurNr,
                        principalTable: "Fakturen",
                        principalColumn: "FaktuurNr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    MerkTypeId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MerkId = table.Column<long>(nullable: false),
                    MerkTypeNaam = table.Column<string>(maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.MerkTypeId);
                    table.ForeignKey(
                        name: "FK_Types_Merken_MerkId",
                        column: x => x.MerkId,
                        principalTable: "Merken",
                        principalColumn: "MerkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OnderdelenProducten",
                columns: table => new
                {
                    Artikelnummer = table.Column<string>(maxLength: 20, nullable: false),
                    Artikelnaam = table.Column<string>(maxLength: 512, nullable: false),
                    Artikelomschrijving = table.Column<string>(nullable: false),
                    FaktuurNr = table.Column<long>(nullable: true),
                    FiguurURL = table.Column<string>(maxLength: 512, nullable: true),
                    LeverancierPersoonId = table.Column<long>(nullable: true),
                    OnderdelenCategorieId = table.Column<int>(nullable: false),
                    OpVoorraad = table.Column<int>(nullable: true),
                    Prijs = table.Column<decimal>(nullable: false),
                    SpecificatieId = table.Column<long>(nullable: true),
                    SpecificatieId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnderdelenProducten", x => x.Artikelnummer);
                    table.ForeignKey(
                        name: "FK_OnderdelenProducten_Fakturen_FaktuurNr",
                        column: x => x.FaktuurNr,
                        principalTable: "Fakturen",
                        principalColumn: "FaktuurNr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnderdelenProducten_Personen_LeverancierPersoonId",
                        column: x => x.LeverancierPersoonId,
                        principalTable: "Personen",
                        principalColumn: "PersoonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnderdelenProducten_CategorieOnderdelen_OnderdelenCategorieId",
                        column: x => x.OnderdelenCategorieId,
                        principalTable: "CategorieOnderdelen",
                        principalColumn: "OnderdelenCategorieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnderdelenProducten_Specificaties_SpecificatieId1",
                        column: x => x.SpecificatieId1,
                        principalTable: "Specificaties",
                        principalColumn: "SpecificatieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleUsers",
                columns: table => new
                {
                    Role_RoleId = table.Column<long>(nullable: false),
                    User_UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUsers", x => new { x.Role_RoleId, x.User_UserId });
                    table.ForeignKey(
                        name: "FK_RoleUsers_Roles_Role_RoleId",
                        column: x => x.Role_RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUsers_Personen_User_UserId",
                        column: x => x.User_UserId,
                        principalTable: "Personen",
                        principalColumn: "PersoonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Voertuigen",
                columns: table => new
                {
                    VoertuigId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Binnenbekleding = table.Column<int>(nullable: false),
                    Binnenkleur = table.Column<int>(nullable: false),
                    Bouwjaar = table.Column<int>(nullable: false),
                    Brandstof = table.Column<int>(nullable: false),
                    CC = table.Column<int>(nullable: false),
                    COTwee = table.Column<string>(maxLength: 50, nullable: true),
                    Chassisnummer = table.Column<string>(maxLength: 17, nullable: true),
                    Deuren = table.Column<int>(nullable: false),
                    FaktuurNr = table.Column<long>(nullable: true),
                    FiguurURL = table.Column<string>(maxLength: 200, nullable: true),
                    GarantieId = table.Column<long>(nullable: true),
                    GarantieTijd = table.Column<string>(maxLength: 75, nullable: true),
                    Kilometerstand = table.Column<int>(nullable: false),
                    KlantPersoonId = table.Column<long>(nullable: true),
                    Kleur = table.Column<string>(nullable: true),
                    Koetswerk = table.Column<int>(nullable: false),
                    MerkId = table.Column<long>(nullable: false),
                    MerkTypeId = table.Column<long>(nullable: true),
                    ModelId = table.Column<long>(nullable: false),
                    Prijs = table.Column<decimal>(nullable: false),
                    Registratie = table.Column<string>(maxLength: 50, nullable: true),
                    Vermogen = table.Column<string>(maxLength: 75, nullable: true),
                    Versnelling = table.Column<int>(nullable: false),
                    VoertuigArtikelNummer = table.Column<string>(nullable: false),
                    VoertuigCatId = table.Column<long>(nullable: false),
                    VoertuigTitel = table.Column<string>(maxLength: 250, nullable: true),
                    Zitplaatsen = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voertuigen", x => x.VoertuigId);
                    table.ForeignKey(
                        name: "FK_Voertuigen_Fakturen_FaktuurNr",
                        column: x => x.FaktuurNr,
                        principalTable: "Fakturen",
                        principalColumn: "FaktuurNr",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voertuigen_GarantieTabel_GarantieId",
                        column: x => x.GarantieId,
                        principalTable: "GarantieTabel",
                        principalColumn: "GarantieId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voertuigen_Personen_KlantPersoonId",
                        column: x => x.KlantPersoonId,
                        principalTable: "Personen",
                        principalColumn: "PersoonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voertuigen_Merken_MerkId",
                        column: x => x.MerkId,
                        principalTable: "Merken",
                        principalColumn: "MerkId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voertuigen_Types_MerkTypeId",
                        column: x => x.MerkTypeId,
                        principalTable: "Types",
                        principalColumn: "MerkTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Voertuigen_VoertuigCategorieen_VoertuigCatId",
                        column: x => x.VoertuigCatId,
                        principalTable: "VoertuigCategorieen",
                        principalColumn: "VoertuigCatId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Artikelnummer = table.Column<string>(nullable: true),
                    Content = table.Column<byte[]>(nullable: true),
                    ContentType = table.Column<string>(maxLength: 100, nullable: true),
                    FileName = table.Column<string>(maxLength: 255, nullable: true),
                    FileType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_OnderdelenProducten_Artikelnummer",
                        column: x => x.Artikelnummer,
                        principalTable: "OnderdelenProducten",
                        principalColumn: "Artikelnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Onderhoud",
                columns: table => new
                {
                    OnderhoudId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Kilometerstand = table.Column<int>(nullable: false),
                    KlantId = table.Column<long>(nullable: false),
                    VoertuigId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onderhoud", x => x.OnderhoudId);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Personen_KlantId",
                        column: x => x.KlantId,
                        principalTable: "Personen",
                        principalColumn: "PersoonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Onderhoud_Voertuigen_VoertuigId",
                        column: x => x.VoertuigId,
                        principalTable: "Voertuigen",
                        principalColumn: "VoertuigId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategorieOnderdelen_ParentId",
                table: "CategorieOnderdelen",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_Artikelnummer",
                table: "Files",
                column: "Artikelnummer");

            migrationBuilder.CreateIndex(
                name: "IX_GarantieTabel_FaktuurId",
                table: "GarantieTabel",
                column: "FaktuurId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderdelenProducten_FaktuurNr",
                table: "OnderdelenProducten",
                column: "FaktuurNr");

            migrationBuilder.CreateIndex(
                name: "IX_OnderdelenProducten_LeverancierPersoonId",
                table: "OnderdelenProducten",
                column: "LeverancierPersoonId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderdelenProducten_OnderdelenCategorieId",
                table: "OnderdelenProducten",
                column: "OnderdelenCategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_OnderdelenProducten_SpecificatieId1",
                table: "OnderdelenProducten",
                column: "SpecificatieId1");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_KlantId",
                table: "Onderhoud",
                column: "KlantId");

            migrationBuilder.CreateIndex(
                name: "IX_Onderhoud_VoertuigId",
                table: "Onderhoud",
                column: "VoertuigId");

            migrationBuilder.CreateIndex(
                name: "IX_Personen_FaktuurNr",
                table: "Personen",
                column: "FaktuurNr");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUsers_User_UserId",
                table: "RoleUsers",
                column: "User_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_MerkId",
                table: "Types",
                column: "MerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_FaktuurNr",
                table: "Voertuigen",
                column: "FaktuurNr");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_GarantieId",
                table: "Voertuigen",
                column: "GarantieId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_KlantPersoonId",
                table: "Voertuigen",
                column: "KlantPersoonId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_MerkId",
                table: "Voertuigen",
                column: "MerkId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_MerkTypeId",
                table: "Voertuigen",
                column: "MerkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Voertuigen_VoertuigCatId",
                table: "Voertuigen",
                column: "VoertuigCatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Onderhoud");

            migrationBuilder.DropTable(
                name: "RoleUsers");

            migrationBuilder.DropTable(
                name: "OnderdelenProducten");

            migrationBuilder.DropTable(
                name: "Voertuigen");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "CategorieOnderdelen");

            migrationBuilder.DropTable(
                name: "Specificaties");

            migrationBuilder.DropTable(
                name: "GarantieTabel");

            migrationBuilder.DropTable(
                name: "Personen");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "VoertuigCategorieen");

            migrationBuilder.DropTable(
                name: "Fakturen");

            migrationBuilder.DropTable(
                name: "Merken");
        }
    }
}
