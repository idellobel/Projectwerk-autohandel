using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class Klant : Persoon
    {
       
        [Required(ErrorMessage = "{0} is verplicht")]
        public long KlantId { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Klantdatum { get; set; }

        //public DateTime? Effectivedate
        //{
        //    get { return EffectivedateEdit; }
        //    set { EffectivedateEdit = value; EffectivedateEdit = value; }
        //}


        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //public DateTime? EffectivedateEdit { get; set; }


        [Required(ErrorMessage = "{0} is verplicht")]
        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Display(Name = "KlantNaam")]
        public string KlantNaam { get; set; }

        public virtual ICollection<Faktuur> Faktuur { get; set; }
  
    }
}