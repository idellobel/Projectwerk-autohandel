using System;
using System.Collections.Generic;
using System.Text;

namespace Autohandel.Domain.DTO_klassen
{
    public class VoertuigDTO
    {
        public long VoertuigId { get; set; }
        public string VoertuigArtikelNummer { get; set; }
        public string Prijs { get; set; }
        public string FiguurURL { get; set; }

        public string VoertuigTitel { get; set; }
        public string MerkNaam { get; set; }
        public string MerkTypeNaam { get; set; }

        public long VoertuigCatId { get; set; }
        public long? FaktuurNr { get; set; }
        public long? KlantId { get; set; }
        public string KlantNaam { get; set; }
    }
}
