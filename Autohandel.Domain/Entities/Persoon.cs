using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public abstract class Persoon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersoonId { get; set; }

        [Required]
        [MaxLength(150)]
        public string Naam { get; set; }

        [Required]
        [MaxLength(150)]
        public string Voornaam { get; set; }

        [Display(Name = "VolledigeNaam")]
        public string FullName
        {
            get { return Naam + ", " + Voornaam; }
        }

        //[Required(ErrorMessage = "Het veld Telefoon is vereist")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Geen geldig telefoonnummer")]
        public string Telefoonnummer { get; set; }

        [StringLength(70)]
        [Required]
        public string Adres { get; set; }


        [Required]
        public int Postcode { get; set; }

        [StringLength(30)]
        [Required]
        public string Gemeente { get; set; }

        [Required(ErrorMessage = "Het veld Email is vereist")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }


    }
}