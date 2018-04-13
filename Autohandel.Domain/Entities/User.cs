using Autohandel.Domain.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Autohandel.Domain.Entities
{
    public class User : Persoon
    {
        [Display(Name = "GebruikersId")]
        public long UserId { get; set; }

        [StringLength(100, ErrorMessage = "De {0} mag niet langer zijn dan 100 karakters")]
        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [Display(Name = "Gebruikersnaam")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Gelieve je {0} in te geven")]
        [StringLength(500, ErrorMessage = "Het {0} mag niet langer zijn dan 500 karakters")]
        [Display(Name = "Paswoord")]
        public string PaswoordHash { get; set; } //wachtwoord bewaren als een versleutelde MD5 hash 

        public bool RememberMe { get; set; }

       
        public virtual ICollection<RoleUsers> RoleUsers { get; set; }
    }
}