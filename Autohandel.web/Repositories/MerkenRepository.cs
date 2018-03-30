using Autohandel.Domain.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class MerkenRepository
    {
        private readonly AutohandelContext _context;

      
        public MerkenRepository(AutohandelContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetMerken()
        {
            
            {
                List<SelectListItem> merken = _context.Merken.AsNoTracking()
                    .OrderBy(m => m.MerkNaam)
                        .Select(m =>
                        new SelectListItem
                        {
                            Value = m.MerkId.ToString() ,
                            Text = m.MerkNaam
                        }).ToList();
                var merktip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- kies merk ---"
                };
                merken.Insert(0, merktip);
                return new SelectList(merken, "Value", "Text");
            }
        }
    }
}
