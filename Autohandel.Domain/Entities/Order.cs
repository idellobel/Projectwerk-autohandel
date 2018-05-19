using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        public virtual List<OrderDetail> OrderDetails { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Display(Name = "FamilieNaam")]
        public string Naam { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        public string Voornaam { get; set; }

        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Required(ErrorMessage = "{0} is vereist")]
        public string Adres { get; set; }


        [Required(ErrorMessage = "{0} is vereist")]
        public string Postcode { get; set; }

        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Required(ErrorMessage = "{0} is vereist")]
        public string Gemeente { get; set; }

        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        [Required(ErrorMessage = "{0} is vereist")]
        public string Land { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Geen geldig telefoonnummer")]
        [DataType(DataType.PhoneNumber)]
        public string Telefoonnummer { get; set; }

        [Required(ErrorMessage = "Het veld Email is vereist")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Gelieve een correcte mail in te geven")]
        [EmailAddress(ErrorMessage = "Gelieve een correcte mail in te geven")]
        public string Email { get; set; }


        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "De {0} is vereist")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal OrderTotaal { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OrderGeplaatst { get; set; }

    }
}
