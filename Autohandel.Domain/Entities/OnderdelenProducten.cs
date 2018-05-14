using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autohandel.Domain.Entities
{
    public class OnderdelenProducten
    {
        [Key]
        [StringLength(20)]
        [Required(ErrorMessage ="Het veld Artikelnummer is verplicht")]
        [Display(Name ="Nr")]
        public string Artikelnummer { get; set; }

        [StringLength(512, ErrorMessage = "Het veld Artikelnaam kan niet langer zijn dan 512 karakters")]
        [Required(ErrorMessage = "Het veld Artikelnaam is vereist")]
        [Display(Name ="Naam")]
        public string Artikelnaam { get; set; }

        [Required(ErrorMessage = "Het veld Artikelomschrijving is vereist")]
        [Display(Name ="Omschrijving")]
        public string Artikelomschrijving { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "{0} is in ongeldig formaat")]
        [Required(ErrorMessage = "Het veld Prijs is vereist")]

        [Display(Name = "Prijs")]
        public decimal Prijs { get; set; }
        //[Column(TypeName = "money")] //foutmelding in database.

        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeelding")]
        public string FiguurURL { get; set; }

        [NotMapped]
        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeeldingen")]
        public string[] FiguurURLs { get; set; }

        [Display(Name ="Voorraad")]
        public int? OpVoorraad { get; set; }

        public virtual Specificaties Specificatie { get; set; }

        [ForeignKey("SpecificatieId")]
        public long? SpecificatieId { get; set; }


        public virtual CategorieOnderdelen CategorieOnderdelen  { get; set; }
        [ForeignKey("Categorie")]
        public int OnderdelenCategorieId { get; set; } 

        public virtual ICollection<File> Files { get; set; }

        public virtual Leverancier Leverancier { get; set; }

        public long? LeverancierID { get; set; }

        public bool Korting { get; set; } = true;
      



            
    }

    


}