using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Onderhoud
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OnderhoudId { get; set; }

        public Voertuig Voertuig { get; set; }
        public long VoertuigId { get; set; }

        public DateTime Datum { get; set; }
        public int Kilometerstand { get; set; }

        public Klant Klant { get; set; }
        public long KlantId { get; set; }

    }
}