using Autohandel.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.VoertuigenViewModels
{
    public class VoertuigEditViewModel
    {
        public long? VoertuigId { get; set; }
        public bool Nieuw { get; set; } = true;

        public string MaxLVNr { get; set; }

        public string MaxPWNr { get; set; }

        public string Info { get; set; }
      
        [Display(Name = "Nr")]
        public string VoertuigArtikelNummer { get; set; }

        //[Required(ErrorMessage = " {0} is vereist")]
        [Display(Name = "Specifiek")]
        [StringLength(75)]
        public string VoertuigTitel { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [Display(Name ="Merken")]
        public string SelectedMerk { get; set; }

        public IEnumerable<SelectListItem> Merken { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [Display(Name = "Modellen")]
        public string SelectedModel { get; set; }

        public IEnumerable<SelectListItem> Modellen { get; set; }

        [Required(ErrorMessage = "{0} is vereist")]
        [Display(Name = "Categorie")]
        public string SelectedCategorie { get; set; }

        public IEnumerable<SelectListItem> Categorieen { get; set; }

        
        [Display(Name = "FaktuurNr")]
        public string SelectedFaktuur { get; set; }

        public IEnumerable<SelectListItem> Fakturen { get; set; }

        
        [Display(Name = "KlantNaam")]
        public string SelectedKlant { get; set; }

        public IEnumerable<SelectListItem> Klanten { get; set; }

        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "De {0} is vereist")]
        [Range(500.00, 110000.00, ErrorMessage = "De {0} prijs dient gekozen tussen 500 € en 110.000€")]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public decimal Prijs { get; set; }

        public string Kleur { get; set; }

        [StringLength(17, MinimumLength = 17, ErrorMessage = "{0} bestaat uit exact 17 tekens")]
        public string Chassisnummer { get; set; }

        public Brandstof Brandstof { get; set; }

        [Range(0, 150000, ErrorMessage = "{0} dient gekozen tussen 0 en 150.000 Km")]
        public int Kilometerstand { get; set; }

        [Range(2004, 2050, ErrorMessage = "{0} dient gekozen tussen 2004 en 2050")]
        public int Bouwjaar { get; set; }

        [StringLength(200, ErrorMessage = "Het veld {0} kan niet langer zijn dan 512 karakters")]
        [Display(Name = "Afbeelding")]
        public string FiguurURL { get; set; }

        public virtual Klant Klant { get; set; }

        public virtual ICollection<Onderhoud> Onderhoudsbeurten { get; set; }

        public virtual Garantie Garantie { get; set; }

        public virtual Faktuur Faktuur { get; set; }

        [StringLength(50, ErrorMessage = "Het veld {0} kan niet langer zijn dan 50 karakters")]
        public string Registratie { get; set; }

        [StringLength(75, ErrorMessage = "Het veld {0} kan niet langer zijn dan 75 karakters")]
        public string GarantieTijd { get; set; }

        [Display(Name = "CO2")]
        [StringLength(50, ErrorMessage = "Het veld {0} kan niet langer zijn dan 50 karakters")]
        public string COTwee { get; set; }

        public Versnelling Versnelling { get; set; }

        [Range(400, 5000)]
        public int CC { get; set; }

        [StringLength(75, ErrorMessage = "Het {0} kan niet langer zijn dan 75 karakters")]
        public string Vermogen { get; set; }

        [Range(1, 10, ErrorMessage = "Het {0} kan niet hoger zijn dan 10 ")]
        public int Deuren { get; set; }

        [Range(2, 25, ErrorMessage = "Het {0} kan niet hoger zijn dan 25 ")]
        public int Zitplaatsen { get; set; }

        public Binnenbekleding Binnenbekleding { get; set; }

        public Binnenkleur Binnenkleur { get; set; }

        public Koetswerk Koetswerk { get; set; }
    }
}
