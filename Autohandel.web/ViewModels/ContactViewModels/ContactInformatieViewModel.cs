using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.ContactViewModels
{
    public class ContactInformatieViewModel
    {
        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 200 karakters")]
        [Display(Name = "Naam:")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 300 karakters")]
        [Display(Name = "Voornaam:")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 300 karakters")]
        [Display(Name = "Land:")]
        public string Land { get; set; }

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(1000, ErrorMessage = "Het {0} mag niet langer zijn dan 1500 karakters")]
        [Display(Name = "Onderwerp:")]
        public string Onderwerp { get; set; }
    }
}
