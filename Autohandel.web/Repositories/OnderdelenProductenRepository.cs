using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class OnderdelenProductenRepository : IOnderdelenProductenRepository
    {
        private readonly AutohandelContext _context;

        public OnderdelenProductenRepository(AutohandelContext context)
        {
            _context = context;
        }

        public IEnumerable<OnderdelenProducten> Producten => _context.OnderdelenProducten;
        public IEnumerable<OnderdelenProducten> ProductenMetKorting => _context.OnderdelenProducten.Where(p => p.Korting == true);

        public OnderdelenProducten GetProductenbyArtikelNummer(string artikelNummer) => _context.OnderdelenProducten.FirstOrDefault(p => p.Korting == true);
        
    }
}
