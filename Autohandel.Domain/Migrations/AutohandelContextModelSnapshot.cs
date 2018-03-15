﻿// <auto-generated />
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace Autohandel.Domain.Migrations
{
    [DbContext(typeof(AutohandelContext))]
    partial class AutohandelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Autohandel.Domain.Entities.CategorieOnderdelen", b =>
                {
                    b.Property<int>("OnderdelenCategorieId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OnderdelenCategorienaam")
                        .IsRequired();

                    b.Property<int?>("ParentId");

                    b.HasKey("OnderdelenCategorieId");

                    b.HasIndex("ParentId");

                    b.ToTable("CategorieOnderdelen");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Faktuur", b =>
                {
                    b.Property<long>("FaktuurNr")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("ArtikelId");

                    b.Property<DateTime>("Faktuurdatum");

                    b.Property<long>("KlantId");

                    b.Property<long>("VoertuigId");

                    b.HasKey("FaktuurNr");

                    b.ToTable("Fakturen");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.File", b =>
                {
                    b.Property<int>("FileId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Artikelnummer");

                    b.Property<byte[]>("Content");

                    b.Property<string>("ContentType")
                        .HasMaxLength(100);

                    b.Property<string>("FileName")
                        .HasMaxLength(255);

                    b.Property<int>("FileType");

                    b.HasKey("FileId");

                    b.HasIndex("Artikelnummer");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Garantie", b =>
                {
                    b.Property<long>("GarantieId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("FaktuurId");

                    b.Property<DateTime>("Vervaldatum");

                    b.HasKey("GarantieId");

                    b.HasIndex("FaktuurId");

                    b.ToTable("GarantieTabel");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Merk", b =>
                {
                    b.Property<long>("MerkId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MerkNaam")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("MerkId");

                    b.ToTable("Merken");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.MerkType", b =>
                {
                    b.Property<long>("MerkTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("MerkId");

                    b.Property<string>("MerkTypeNaam")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("MerkTypeId");

                    b.HasIndex("MerkId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.OnderdelenProducten", b =>
                {
                    b.Property<string>("Artikelnummer")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20);

                    b.Property<string>("Artikelnaam")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<string>("Artikelomschrijving")
                        .IsRequired();

                    b.Property<long?>("FaktuurNr");

                    b.Property<string>("FiguurURL")
                        .HasMaxLength(512);

                    b.Property<long?>("LeverancierPersoonId");

                    b.Property<int>("OnderdelenCategorieId");

                    b.Property<int?>("OpVoorraad");

                    b.Property<decimal>("Prijs");

                    b.Property<long?>("SpecificatieId");

                    b.Property<int?>("SpecificatieId1");

                    b.HasKey("Artikelnummer");

                    b.HasIndex("FaktuurNr");

                    b.HasIndex("LeverancierPersoonId");

                    b.HasIndex("OnderdelenCategorieId");

                    b.HasIndex("SpecificatieId1");

                    b.ToTable("OnderdelenProducten");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Onderhoud", b =>
                {
                    b.Property<long>("OnderhoudId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Datum");

                    b.Property<int>("Kilometerstand");

                    b.Property<long>("KlantId");

                    b.Property<long?>("VoertuigId");

                    b.HasKey("OnderhoudId");

                    b.HasIndex("KlantId");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Onderhoud");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Persoon", b =>
                {
                    b.Property<long>("PersoonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Gemeente")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("Postcode");

                    b.Property<string>("Telefoonnummer");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("PersoonId");

                    b.ToTable("Personen");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persoon");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.RoleUsers", b =>
                {
                    b.Property<long>("Role_RoleId");

                    b.Property<long>("User_UserId");

                    b.HasKey("Role_RoleId", "User_UserId");

                    b.HasIndex("User_UserId");

                    b.ToTable("RoleUsers");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Specificaties", b =>
                {
                    b.Property<int>("SpecificatieId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Aanhangwagengewicht");

                    b.Property<int>("AantalFietsen");

                    b.Property<int>("Binnendiameter");

                    b.Property<int>("Breedte");

                    b.Property<int>("Buitendiameter");

                    b.Property<bool>("CityCrash");

                    b.Property<int>("Dikte");

                    b.Property<string>("Draagvermogen");

                    b.Property<string>("Fietstypes")
                        .HasMaxLength(75);

                    b.Property<string>("Flappen")
                        .HasMaxLength(75);

                    b.Property<string>("Formaat");

                    b.Property<string>("GarantieTermijn")
                        .HasMaxLength(75);

                    b.Property<string>("Geur")
                        .HasMaxLength(50);

                    b.Property<int>("Gewicht");

                    b.Property<string>("Goedkeuring")
                        .HasMaxLength(75);

                    b.Property<int>("Hoogte");

                    b.Property<int>("Inhoud");

                    b.Property<bool>("Inklapbaar");

                    b.Property<int>("Kantelfunctie");

                    b.Property<int>("Kleur");

                    b.Property<int>("Lengte");

                    b.Property<string>("Mat")
                        .HasMaxLength(75);

                    b.Property<string>("Materie")
                        .HasMaxLength(75);

                    b.Property<int>("MaxBelading");

                    b.Property<int>("MaxVertikaleLast");

                    b.Property<string>("Mengbaar");

                    b.Property<string>("MinimaleTemperatuur")
                        .HasMaxLength(150);

                    b.Property<bool>("Mistlicht");

                    b.Property<string>("Montageset");

                    b.Property<string>("Opening");

                    b.Property<string>("Rolgeluid");

                    b.Property<string>("Schroefdraad")
                        .HasMaxLength(75);

                    b.Property<string>("SnelheidIndex");

                    b.Property<string>("StekkerAansluiting")
                        .HasMaxLength(75);

                    b.Property<string>("Type")
                        .HasMaxLength(75);

                    b.Property<string>("Vergrendeling");

                    b.Property<string>("WaaromKeuze");

                    b.HasKey("SpecificatieId");

                    b.ToTable("Specificaties");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Voertuig", b =>
                {
                    b.Property<long>("VoertuigId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Binnenbekleding");

                    b.Property<int>("Binnenkleur");

                    b.Property<int>("Bouwjaar");

                    b.Property<int>("Brandstof");

                    b.Property<int>("CC");

                    b.Property<string>("COTwee");

                    b.Property<long>("Chassisnummer");

                    b.Property<int>("Deuren");

                    b.Property<long?>("FaktuurNr");

                    b.Property<string>("FiguurURL")
                        .HasMaxLength(512);

                    b.Property<long?>("GarantieId");

                    b.Property<string>("GarantieTijd");

                    b.Property<int>("Kilometerstand");

                    b.Property<long?>("KlantPersoonId");

                    b.Property<string>("Kleur");

                    b.Property<int>("Koetswerk");

                    b.Property<long?>("MerkId");

                    b.Property<long?>("MerkTypeId");

                    b.Property<decimal>("Prijs");

                    b.Property<string>("Registratie");

                    b.Property<string>("Vermogen");

                    b.Property<int>("Versnelling");

                    b.Property<string>("VoertuigArtikelNummer")
                        .IsRequired();

                    b.Property<long?>("VoertuigCategorieVoertuigCatId");

                    b.Property<string>("VoertuigTitel");

                    b.Property<int>("Zitplaatsen");

                    b.HasKey("VoertuigId");

                    b.HasIndex("FaktuurNr");

                    b.HasIndex("GarantieId");

                    b.HasIndex("KlantPersoonId");

                    b.HasIndex("MerkId");

                    b.HasIndex("MerkTypeId");

                    b.HasIndex("VoertuigCategorieVoertuigCatId");

                    b.ToTable("Voertuigen");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.VoertuigCategorie", b =>
                {
                    b.Property<long>("VoertuigCatId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("VoertuigCategorieNaam")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.HasKey("VoertuigCatId");

                    b.ToTable("VoertuigCategorieen");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Klant", b =>
                {
                    b.HasBaseType("Autohandel.Domain.Entities.Persoon");

                    b.Property<long?>("FaktuurNr");

                    b.Property<long>("KlantId");

                    b.Property<string>("KlantNaam")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<DateTime>("Klantdatum");

                    b.HasIndex("FaktuurNr");

                    b.ToTable("Klant");

                    b.HasDiscriminator().HasValue("Klant");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Leverancier", b =>
                {
                    b.HasBaseType("Autohandel.Domain.Entities.Persoon");

                    b.Property<DateTime>("LeverancierDatum");

                    b.Property<long>("LeverancierID");

                    b.Property<string>("LeverancierNaam")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.ToTable("Leverancier");

                    b.HasDiscriminator().HasValue("Leverancier");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.User", b =>
                {
                    b.HasBaseType("Autohandel.Domain.Entities.Persoon");

                    b.Property<string>("PaswoordHash")
                        .IsRequired();

                    b.Property<bool>("RememberMe");

                    b.Property<long>("UserId");

                    b.Property<string>("UserName");

                    b.ToTable("User");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.CategorieOnderdelen", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.CategorieOnderdelen", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.File", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.OnderdelenProducten", "OnderdelenProducten")
                        .WithMany("Files")
                        .HasForeignKey("Artikelnummer");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Garantie", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.Faktuur", "Faktuur")
                        .WithMany()
                        .HasForeignKey("FaktuurId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.MerkType", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.Merk", "VoertuigMerk")
                        .WithMany("MerkTypes")
                        .HasForeignKey("MerkId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.OnderdelenProducten", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.Faktuur")
                        .WithMany("OnderdelenProducten")
                        .HasForeignKey("FaktuurNr");

                    b.HasOne("Autohandel.Domain.Entities.Leverancier")
                        .WithMany("OnderdelenProducten")
                        .HasForeignKey("LeverancierPersoonId");

                    b.HasOne("Autohandel.Domain.Entities.CategorieOnderdelen", "CategorieOnderdelen")
                        .WithMany("Products")
                        .HasForeignKey("OnderdelenCategorieId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Autohandel.Domain.Entities.Specificaties", "Specificatie")
                        .WithMany()
                        .HasForeignKey("SpecificatieId1");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Onderhoud", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.Klant", "Klant")
                        .WithMany()
                        .HasForeignKey("KlantId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Autohandel.Domain.Entities.Voertuig", "Voertuig")
                        .WithMany("Onderhoudsbeurten")
                        .HasForeignKey("VoertuigId");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.RoleUsers", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("Role_RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Autohandel.Domain.Entities.User", "User")
                        .WithMany("RoleUsers")
                        .HasForeignKey("User_UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Voertuig", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.Faktuur", "Faktuur")
                        .WithMany("Voertuigen")
                        .HasForeignKey("FaktuurNr");

                    b.HasOne("Autohandel.Domain.Entities.Garantie", "Garantie")
                        .WithMany()
                        .HasForeignKey("GarantieId");

                    b.HasOne("Autohandel.Domain.Entities.Klant", "Klant")
                        .WithMany()
                        .HasForeignKey("KlantPersoonId");

                    b.HasOne("Autohandel.Domain.Entities.Merk", "Merk")
                        .WithMany()
                        .HasForeignKey("MerkId");

                    b.HasOne("Autohandel.Domain.Entities.MerkType", "MerkType")
                        .WithMany()
                        .HasForeignKey("MerkTypeId");

                    b.HasOne("Autohandel.Domain.Entities.VoertuigCategorie", "VoertuigCategorie")
                        .WithMany()
                        .HasForeignKey("VoertuigCategorieVoertuigCatId");
                });

            modelBuilder.Entity("Autohandel.Domain.Entities.Klant", b =>
                {
                    b.HasOne("Autohandel.Domain.Entities.Faktuur")
                        .WithMany("Klanten")
                        .HasForeignKey("FaktuurNr");
                });
#pragma warning restore 612, 618
        }
    }
}
