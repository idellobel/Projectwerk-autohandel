using System;

namespace Autohandel.Domain.Entities
{
    public class Onderhoud
    {
        public long OnderhoudId { get; set; }
        public Voertuig Voertuig { get; set; }
        public long VoertuigId { get; set; }
        public DateTime Datum { get; set; }
        public int Kilometerstand { get; set; }
        public Klant Klant { get; set; }
        public long KlantId { get; set; }

    }
}