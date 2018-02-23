using System.Collections.Generic;

namespace Autohandel.Domain.Entities
{
    public class Merk
    {
        public long MerkId { get; set; }
        public string MerkNaam { get; set; }

        public List<MerkType> MerkTypes { get; set; }

    }
}