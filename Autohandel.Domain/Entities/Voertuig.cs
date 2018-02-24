using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public enum Brandstof { Benzine, Diesel, Hybride }

    public class Voertuig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VoertuigId { get; set; }

        public long Chassisnummer { get; set; }

        public Merk Merk { get; set; }
        public long MerkId { get; set; }

        public MerkType MerkType { get; set; }
        public long MerkTypeId { get; set; }

        public VoertuigCategorie VoertuigCategorie { get; set; }
        public long VoertuigCatId { get; set; }

        public decimal Prijs { get; set; }

        public string Kleur { get; set; }

        public Brandstof Brandstof { get; set; }

        public int Kilometerstand { get; set; }

        public int Bouwjaar { get; set; }

        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeelding")]
        public string FiguurURL { get; set; }

        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeeldingen")]
        public string[] FiguurURLs { get; set; }

        public Klant Klant  { get; set; }
        public long  KlantId { get; set; }

        public Onderhoud Onderhoud { get; set; }
        public long OnderhoudId { get; set; }

        public Garantie Garantie { get; set; }
        public long GrantieId { get; set; }

        public Faktuur Faktuur { get; set; }
        public long FaktuurNr { get; set; }

        public string Registratie { get; set; }

        public Versnelling Versnelling { get; set; }

        public int  CC { get; set; }

        public int? Vermogen { get; set; }

        public int Deuren { get; set; }

        public int Zitplaatsen { get; set; }

        public Binnenbekleding Binnenbekleding { get; set; }

        public Binnenkleur Binnenkleur { get; set; }

        public Koetswerk Koetswerk { get; set; }

    }

    public enum Versnelling
    {
        Manueel, Automaat
    }

    public enum Binnenbekleding
    {
        Stof, Leder
    }

    public enum Binnenkleur
    {
        Zawrt, Grijs, Donkergrijs, Donkerblauw
    }
    public enum Koetswerk
    {
        Berline, Monovolume, Coupé, Hatchback, Break, Bestelwagen, Cabriolet, Limousine, Coach
    }
    
    
}
