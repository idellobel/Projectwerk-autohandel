using Autohandel.Domain.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class CategorieRepository
    {
        private readonly AutohandelContext _context;

        
        public CategorieRepository(AutohandelContext context)   
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetCategorieen()
        {

            {
                List<SelectListItem> categorieen = _context.VoertuigCategorieen.AsNoTracking()
                    .OrderBy(m => m.VoertuigCategorieNaam)
                        .Select(m =>
                        new SelectListItem
                        {
                            Value = m.VoertuigCatId.ToString(),
                            Text = m.VoertuigCategorieNaam
                        }).ToList();
                var merktip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- kies categorie ---"
                };
                categorieen.Insert(0, merktip);
                return new SelectList(categorieen, "Value", "Text");
            }
        }
    }
}
