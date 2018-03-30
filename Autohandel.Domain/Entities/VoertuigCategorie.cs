using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class VoertuigCategorie
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VoertuigCatId { get; set; }

        [Required(ErrorMessage ="{0} is verplicht")]
        [StringLength(150, MinimumLength =5, ErrorMessage ="{0} dient een lengte te hebben van 5 tot 200 karakters")]
        public string VoertuigCategorieNaam { get; set; }

        public virtual ICollection<Voertuig> Voertuigen { get; set; }

    }
}
