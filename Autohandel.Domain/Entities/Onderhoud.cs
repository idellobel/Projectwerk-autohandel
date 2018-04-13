using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Onderhoud
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Nr")]
        public long OnderhoudId { get; set; }

        public virtual Voertuig Voertuig { get; set; }
        [Display(Name = "Voertuig")]
        public long? VoertuigId { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        public int Kilometerstand { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        public string Info { get; set; }

        public virtual Klant Klant { get; set; }
        [ForeignKey("Klant")]
        [Display(Name = "Klant")]
        public long KlantId { get; set; }

    }
}