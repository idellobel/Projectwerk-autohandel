using System;
using System.Collections.Generic;
using System.Text;

namespace Autohandel.Domain.DTO_klassen
{
    public class VoertuigDetailDTO
    {
        public long VoertuigId { get; set; }
        public string VoertuigTitel { get; set; }
        
        public decimal Prijs { get; set; }
        public long MerkId { get; set; }
        public string MerkNaam { get; set; }
    }
}
