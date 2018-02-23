using System;
using System.Collections.Generic;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public enum Brandstof { Benzine, Diesel, Hybride }

    public class Voertuig
    {
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

        public Klant Klant  { get; set; }
        public long  KlantId { get; set; }

        public Onderhoud Onderhoud { get; set; }
        public long OnderhoudId { get; set; }

        public Garantie Garantie { get; set; }
        public long GrantieId { get; set; }

        public Faktuur Faktuur { get; set; }
        public long FaktuurNr { get; set; }

    }
}
