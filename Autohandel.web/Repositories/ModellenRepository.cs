using Autohandel.Domain.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class ModellenRepository
    {
        private readonly AutohandelContext _context;

        public ModellenRepository()
        {
        }

        public ModellenRepository(AutohandelContext context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetModellen()
        {
            List<SelectListItem> modellen = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = " "
                }
            };
            var modeltip = new SelectListItem()
            {
                Value = null,
                Text = "--- kies eerst een merk! ---"
            };
            modellen.Insert(0, modeltip);
            return new SelectList(modellen, "Value", "Text");
            //return modellen;
        }

        public IEnumerable<SelectListItem> GetModellen(string merkId)
        {
            if (!String.IsNullOrWhiteSpace(merkId))
            {
               
                {
                    IEnumerable<SelectListItem> modellen = _context.Types.AsNoTracking()
                        .OrderBy(m => m.MerkTypeNaam)
                        .Where(m => m.MerkId == Convert.ToInt64( merkId))
                        .Select(m =>
                           new SelectListItem
                           {
                               Value = m.MerkTypeId.ToString(),
                               Text = m.MerkTypeNaam
                           }).ToList();
                    return new SelectList(modellen, "Value", "Text");
                }
            }
            return null;
        }
    }
}

