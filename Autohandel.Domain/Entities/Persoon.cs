using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public abstract class Persoon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersoonId { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Display(Name = "FamilieNaam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        public string Voornaam { get; set; }

        [Display(Name = "VolledigeNaam")]
        public string FullName
        {
            get { return Naam + ", " + Voornaam; }
        }

        [Required(ErrorMessage = "{0} is vereist")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Geen geldig telefoonnummer")]
        [DataType(DataType.PhoneNumber)]
        public string Telefoonnummer { get; set; }

        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Required(ErrorMessage = "{0} is vereist")]
        public string Adres { get; set; }


        [Required(ErrorMessage = "{0} is vereist")]
        public int Postcode { get; set; }

        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Required(ErrorMessage = "{0} is vereist")]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Het veld Email is vereist")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


    }
}