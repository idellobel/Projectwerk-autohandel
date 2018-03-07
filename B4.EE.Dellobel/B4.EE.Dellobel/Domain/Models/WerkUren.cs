using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.DellobelI.Domain.Models
{
    public class WerkUren
    {
        [PrimaryKey]
        public int WerkId { get; set; }

        [NotNull]
        public DateTime  Datum { get; set; }
        [NotNull]
        public TimeSpan BeginTijd { get; set; }
        [NotNull]
        public TimeSpan  EindTijd { get; set; }
        public string Toelichting { get; set; }
        public decimal Verkoop { get; set; }
        public decimal Aankoop { get; set; }

        public TimeSpan GewerkteTijd { get; set; }
        public decimal Waarde { get; set; }

        [OneToOne(nameof(AutoId))]
        public Auto Auto { get; set; }

        
        public int AutoId { get; set; }

        [OneToOne(nameof(KlantId))]
        public Klant Klant { get; set; }

        [ForeignKey(typeof(Klant))]
        public Guid KlantId { get; set; }
    }
}

