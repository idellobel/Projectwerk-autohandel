using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Garantie
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long GarantieId { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Vervaldatum { get; set; }

        
        public virtual Faktuur Faktuur { get; set; }
     
        [ForeignKey("Faktuur")]
        [Display(Name = "Faktuur")]
        public long FaktuurId { get; set; }


    }
}