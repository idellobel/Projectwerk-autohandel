using System;

namespace Autohandel.Domain.Entities
{
    public class Garantie
    {
        public long GarantieId { get; set; }
        public DateTime Vervaldatum { get; set; }
        public Faktuur Faktuur { get; set; }
        public long FaktuurId { get; set; }


    }
}