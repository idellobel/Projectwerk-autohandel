using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Faktuur
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FaktuurNr { get; set; }

        [Required]
        public DateTime Faktuurdatum { get; set; }

        //public Klant Klant { get; set; }
        public ICollection<Klant> Klanten { get; set; }

        [ForeignKey("Klant")]
        public long  KlantId { get; set; }

        //public Voertuig Voertuig { get; set; }
        public ICollection<Voertuig> Voertuigen { get; set; }
        [ForeignKey("Voertuig")]
        public long VoertuigId { get; set; }


        //public OnderdelenProducten OnderdelenProducten  { get; set; }
        public ICollection<OnderdelenProducten> OnderdelenProducten { get; set; }
        [ForeignKey("OnderdelenProdukten")]
        public long ArtikelId { get; set; }



    }
}