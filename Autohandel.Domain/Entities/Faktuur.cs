using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Faktuur
    {
        [Key]
        //[Range(0, Int64.MaxValue, ErrorMessage = "Ongeldige invoer")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FaktuurNr { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Faktuurdatum { get; set; }

        public virtual Klant Klant { get; set; }
    
        [ForeignKey("Klant")]
        [Display(Name = "Klant")]
        public long  KlantId { get; set; }

        public virtual Voertuig Voertuig { get; set; }
     
        [ForeignKey("Voertuig")]
        [Display(Name = "Voertuig")]
        public long? VoertuigId { get; set; }


        public virtual OnderdelenProducten OnderdelenProducten { get; set; }
      
        [ForeignKey("OnderdelenProdukten")]
        [Display(Name = "OnderdeelProdukt")]
        public string Artikelnummer { get; set; }



    }
}