using Autohandel.Domain.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class KlantenRepository
    {
        private readonly AutohandelContext _context;

        public KlantenRepository(AutohandelContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetKlanten()
        {

            {
                List<SelectListItem> klanten = _context.Klanten.AsNoTracking()
                    .OrderBy(m => m.KlantNaam)
                        .Select(m =>
                        new SelectListItem
                        {
                            Value = m.KlantId.ToString(),
                            Text = m.KlantNaam
                        }).ToList();
                var merktip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- kies klantNaam ---"
                };
                klanten.Insert(0, merktip);
                return new SelectList(klanten, "Value", "Text");
            }
        }
    }
}
