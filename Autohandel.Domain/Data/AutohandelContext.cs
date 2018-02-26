using Autohandel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autohandel.Domain.Data
{
    public class AutohandelContext : DbContext
    {
        //Om straks met behulp van Dependency Injection de Context configureerbaar te maken moet je een speciale constructor definiëren.
        public AutohandelContext(DbContextOptions<AutohandelContext> options) : base(options)
        { }

        //Voeg de DbSet<T> collecties van de gewenste Entity klassen toe aan je Context.
        //    Dit worden in essentie de tabellen in de databank.
        public DbSet<CategorieOnderdelen> CategorieOnderdelen{ get; set; }
        public DbSet<Faktuur> Fakturen { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Garantie> GarantieTabel { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Leverancier> Leveranciers  { get; set; }
        public DbSet<Merk> Merken { get; set; }
        public DbSet<MerkType> Types { get; set; }
        public DbSet<OnderdelenProducten> OnderdelenProducten { get; set; }
        public DbSet<Onderhoud> Onderhoud { get; set; }
        public DbSet<Persoon> Personen { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Voertuig> Voertuigen { get; set; }
        public DbSet<VoertuigCategorie> VoertuigCategoriën { get; set; }
        public DbSet<Specificaties> Specificaties { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<CategorieOnderdelen>()
                .HasOne(x => x.Parent)
                    .WithMany(x => x.Children)
                    .HasForeignKey(x => x.ParentId);

            //configure a composite PK in RoleUsers, consisting of both FK's
            modelBuilder
                .Entity<RoleUsers>()
                .ToTable("RoleUsers")
                .HasKey(sc => new { sc.Role_RoleId, sc.User_UserId });

            modelBuilder.Entity<RoleUsers>()                //entity RoleUsers ...
                .HasOne(sc => sc.User)                      //... is associated with 1 User
                .WithMany(s => s.RoleUsers)                 //... which is in turn associated to many RoleUsers
                .HasForeignKey(sc => sc.User_UserId);       //... using User_UserId as the FK for this relationship.

            modelBuilder.Entity<RoleUsers>()                //entity RoleUsers ...
               .HasOne(sc => sc.Role)                       //... is associated with 1 Role
               .WithMany(s => s.RoleUsers)                  //... which is in turn associated to many RoleUsers
               .HasForeignKey(sc => sc.Role_RoleId);        //... using Role_RoleId as the FK for this relationship.

            //modelBuilder.Entity<Persoon>()
            //    .HasRequired(c => c.Stage)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<Persoon>()
            //    .HasOne(s => s.Naam)
            //    .WithOne()
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }

       

    }
}
