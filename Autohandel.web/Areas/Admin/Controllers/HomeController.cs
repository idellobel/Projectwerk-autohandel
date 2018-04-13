using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autohandel.Domain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autohandel.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AutohandelContext _context;

        public HomeController(AutohandelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Voertuigen()
        {
            return View();
        }

        public IActionResult VoertuigOnderdelen()
        {
            return View();
        }

        public async Task<IActionResult> CategorieOnderdelen()
        {
            var autohandelContext = _context.CategorieOnderdelen.Include(c =>c.Parent).Where(hc => hc.ParentId == null); ;
            return View(await autohandelContext.ToListAsync());
           
        }

        public async Task<IActionResult> SubCategorieOnderdelen(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieOnderdelen = await _context.CategorieOnderdelen
                .Include(c => c.Children)
                .Where(hc => hc.ParentId == null)
                .SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
            if (categorieOnderdelen == null)
            {
                return NotFound();
            }


            return View(categorieOnderdelen);
        }
        public IActionResult Personen()
        {
            return View();
        }

        public IActionResult Adminstratie()
        {
            return View();
        }   

    }
}