using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class Leverancier : Persoon
    {
        [Display(Name = "Leverancier")]
        [Required(ErrorMessage = "Het veld {0} is vereist")]
        public long LeverancierID { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Leverancier sedert")]
        public DateTime LeverancierDatum { get; set; }

        
        [Required]
        [StringLength(50, ErrorMessage = "Het veld LeverancierNaam mag niet langer zijn dan than 50 karakters.")]
        [Display(Name = "LeverancierNaam")]
        public string LeverancierNaam { get; set; }

        public virtual ICollection<OnderdelenProducten> OnderdelenProducten { get; set; }   
    }
}
