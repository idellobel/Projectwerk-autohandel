using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.DellobelI.Domain.Models
{
    public enum Brandstof { Benzine, Diesel, Hybride}
    public enum AutoStatus { Aanbod, Gekocht, Verkocht, Vraag  }
    


    public class Auto
    {
        [PrimaryKey]
        public int Id { get; set; }

        [ManyToOne(nameof(KlantId))]
        public Klant Klant { get; set; }

        [ForeignKey(typeof(Klant))]
        public Guid KlantId { get; set; }

        public string KlantNaam { get; set; }

        public AutoStatus AutoStatus { get; set; }
        public DateTime Aankoop { get; set; }
        public DateTime Verkoop { get; set; }
        public DateTime AanBod { get; set; }
        public DateTime Vraag { get; set; }

        [NotNull, MaxLength(75)]
        public string Merk { get; set; }

        [NotNull, MaxLength(75)]
        public string Model { get; set; }

        [NotNull]
        public int Bouwjaar { get; set; }
        public Brandstof Brandstof { get; set; }

        [NotNull]
        public decimal Prijs { get; set; }

        public int KMstand { get; set; }
        public string Foto { get; set; }
        public string EersteEigenaar { get; set; }

        [ForeignKey(typeof(Voertuigen))]
        public int VoertuigenId { get; set; }

        [ManyToOne(nameof(VoertuigenId))]
        public Voertuigen Voertuigen { get; set; }
    }

   
}
