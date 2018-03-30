using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public enum Brandstof { Benzine, Diesel, Hybride }

    public class Voertuig
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long VoertuigId { get; set; }

        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Nr")]
        public string VoertuigArtikelNummer { get; set; }

        [Display(Name = "Specifiek")]
        [StringLength(250, ErrorMessage = "{0} dient een maximale lengte te hebben van 250 karakters")]
        public string VoertuigTitel { get; set; }

        [StringLength(17, MinimumLength =17, ErrorMessage  = "{0} bestaat uit exact 17 tekens")]
        public string Chassisnummer { get; set; }

        public virtual Merk Merk { get; set; }

        //[ForeignKey("Merk")]
        public long MerkId { get; set; }

        public virtual MerkType MerkType { get; set; }

        //[ForeignKey("Merktype")]
        public long ModelId { get; set; } //Conflikeert!

        public virtual VoertuigCategorie VoertuigCategorie { get; set; }
        //[ForeignKey("VoertuigCategorie")]
        public long VoertuigCatId { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage ="De {0} is vereist")]
        [Range(500.00, 110000.00, ErrorMessage ="De {0} prijs dient gekozen tussen 500 € en 110.000€" )]
        [DisplayFormat(DataFormatString ="{0:c}")]
        public decimal Prijs { get; set; }

        public string Kleur { get; set; }

        public Brandstof Brandstof { get; set; }

        [Range(0, 150000, ErrorMessage = "{0} dient gekozen tussen 0 en 150.000 Km")]
        public int Kilometerstand { get; set; }

        [Range(2004, 2050, ErrorMessage = "{0} dient gekozen tussen 2004 en 2050")]
        public int Bouwjaar { get; set; }

        [StringLength(200, ErrorMessage = "Het veld {0} kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeelding")]
        public string FiguurURL { get; set; }

        [NotMapped]
        [StringLength(512, ErrorMessage = "Het veld FiguurURL kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeeldingen")]
        public string[] FiguurURLs { get; set; }

        public virtual Klant Klant  { get; set; }
  
        public virtual ICollection<Onderhoud> Onderhoudsbeurten { get; set; } 
        
        public virtual Garantie Garantie { get; set; }
        
        public virtual  Faktuur Faktuur { get; set; }

        [StringLength(50, ErrorMessage = "Het veld {0} kan niet langer zijn dan 50 karakters")]
        public string Registratie { get; set; }

        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        public string GarantieTijd { get; set; }

        [Display(Name = "CO2")]
        [StringLength(50, ErrorMessage = "Het veld {0} kan niet langer zijn dan 50 karakters")]
        public string COTwee { get; set; }

        public Versnelling Versnelling { get; set; }

        [Range(400,5000)]
        public int  CC { get; set; }

        [StringLength(75, ErrorMessage = "Het {0} kan niet langer zijn dan 75 karakters")]
        public string Vermogen { get; set; }

        [Range(1,10, ErrorMessage = "Het {0} kan niet hoger zijn dan 10 ")]
        public int Deuren { get; set; }

        [Range(2,25, ErrorMessage = "Het {0} kan niet hoger zijn dan 25 ")]
        public int Zitplaatsen { get; set; }

        public Binnenbekleding Binnenbekleding { get; set; }

        public Binnenkleur Binnenkleur { get; set; }

        public Koetswerk Koetswerk { get; set; }

    }

    
}
