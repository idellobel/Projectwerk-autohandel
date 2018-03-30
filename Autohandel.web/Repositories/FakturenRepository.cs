using Autohandel.Domain.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class FakturenRepository
    {
        private readonly AutohandelContext _context;

        public FakturenRepository(AutohandelContext context)
        {
            _context = context;
        }
        public IEnumerable<SelectListItem> GetFakturen()
        {

            {
                List<SelectListItem> fakturen = _context.Fakturen.AsNoTracking()
                    .OrderBy(m => m.FaktuurNr)
                        .Select(m =>
                        new SelectListItem
                        {
                            Value = m.FaktuurNr.ToString(),
                            Text = m.FaktuurNr.ToString()
                        }).ToList();
                var merktip = new SelectListItem()
                {
                    Value = null,
                    Text = "--- kies faktuurNr ---"
                };
                fakturen.Insert(0, merktip);
                return new SelectList(fakturen, "Value", "Text");
            }
        }
    }
}
