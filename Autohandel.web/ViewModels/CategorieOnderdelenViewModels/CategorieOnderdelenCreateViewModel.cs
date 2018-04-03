using Autohandel.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.CategorieOnderdelenViewModels
{
    public class CategorieOnderdelenCreateViewModel
    {

        [Required(ErrorMessage ="Vul een {0} in.")]
        [Display(Name = "Onderdelen Categorienaam")]
        public CategorieOnderdelen CategorieOnderdeel { get; set; }

        [Display(Name = "Hoofd-CategorieOnderdelen-lijst")]
        public IEnumerable<SelectListItem> HoofdcategorieOnderdelenlijst { get; set; }
    }
}
