using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace B4.EE.DellobelI.Domain.Models
{
    public enum KlantStatus
    {
        Koper, Verkoper
    }
    public class Klant
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [NotNull, MaxLength(100)]
        public string  Naam { get; set; }
        [NotNull]
        public string Telefoonnummer { get; set; }

        public string Email { get; set; }
        public string Adres { get; set; }
        public int Postnummer { get; set; }
        public string Woonplaats { get; set; }
        public KlantStatus KlantStatus{ get; set; }

        [ForeignKey(typeof(Auto))]
        public int AutoId { get; set; }

        [ManyToOne(nameof(AutoId))]
        public Auto Auto { get; set; }
    }
}
