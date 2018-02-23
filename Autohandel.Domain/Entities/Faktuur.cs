using System;

namespace Autohandel.Domain.Entities
{
    public class Faktuur
    {
        public long FaktuurNr { get; set; }

        public DateTime Faktuurdatum { get; set; }

        public Klant Klant { get; set; }
        public long  KlantId { get; set; }

        public Voertuig Voertuig { get; set; }
        public long VoertuigId { get; set; }

        public OnderdelenProducten OnderdelenProducten  { get; set; }
        public long ArtikelId { get; set; }



    }
}