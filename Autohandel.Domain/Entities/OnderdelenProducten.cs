using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class OnderdelenProducten
    {
        [Key]
        [StringLength(20)]
        [Required]
        public string Artikelnummer { get; set; }

        [StringLength(512, ErrorMessage = "Het veld Artikelnaam kan niet langer zijn dan 512 karakters")]
        [Required(ErrorMessage = "Het veld Artikelnaam is vereist")]
        public string Artikelnaam { get; set; }

        [Required(ErrorMessage = "Het veld Artikelomschrijving is vereist")]
        public string Artikelomschrijving { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Het veld Prijs is vereist")]
        [Display(Name = "Vkp Kleinh")]
        public decimal Prijs { get; set; }

        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeelding")]
        public string FiguurURL { get; set; }

        [NotMapped]
        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeeldingen")]
        public string[] FiguurURLs { get; set; }

        public int? OpVoorraad { get; set; }

        public Specificaties Specificatie { get; set; }

        public CategorieOnderdelen CategorieOnderdelen  { get; set; }   

        public virtual ICollection<File> Files { get; set; }





    }

    


}