using System;
using System.Collections.Generic;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class MerkType
    {
        public long MerkTypeId { get; set; }
        public string MerkTypeNaam { get; set; }

        public Merk VoertuigMerk { get; set; }
    }
}
