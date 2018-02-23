using System.ComponentModel.DataAnnotations;

namespace Autohandel.Domain.Entities
{
    public abstract class Persoon
    {
        [Key]
        public long PersoonId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }

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