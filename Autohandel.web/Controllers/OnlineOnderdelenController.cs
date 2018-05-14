using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.ViewModels.OnlineOnderdelen;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autohandel.web.Controllers
{
    public class OnlineOnderdelenController : Controller
    {
        private readonly AutohandelContext _context;
        private IHostingEnvironment _env;

        public OnlineOnderdelenController(AutohandelContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [Route("OnlineOnderdelen/Index")]
        public async Task<IActionResult> Index()
        {

            var categorieOnderdelen = _context.CategorieOnderdelen.Include(c => c.Parent).Where(hc => hc.ParentId == null); ;
            return View(await categorieOnderdelen.ToListAsync());
        }
        [Route("OnlineOnderdelen/SubCatOnderdelen/{id:int}")]
        public async Task<IActionResult> SubCatOnderdelen(int? id)
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

            if (categorieOnderdelen.Children.Count() == 0)
            {
               var catId = categorieOnderdelen.OnderdelenCategorieId;
                return RedirectToAction($"OnderdeelProduct/{catId.ToString()}", "OnlineOnderdelen");
            }

            return View(categorieOnderdelen);
        }
        [Route("OnlineOnderdelen/OnderdeelProduct/{id:int}")]
        public async Task<IActionResult>OnderdeelProduct(int id)
        {
            CategorieOnderdelen cat = await _context.CategorieOnderdelen
                .Include(c => c.Parent)
                .Include(c => c.Products)
                .FirstOrDefaultAsync(ct => ct.OnderdelenCategorieId == id);
            cat.Products = cat.Products
                           .OrderBy(p => p.Prijs).ToList();

            return View(cat);

        }



        public async Task<IActionResult> OnderdelenDetails(string id)
        {
            var webRoot = _env.WebRootPath;
            var odVM = new OnderdelenDetailViewModel();

            odVM.OnderdeelDetail = await _context.OnderdelenProducten
                                                       .Include(o => o.CategorieOnderdelen)
                                                       .Include(o => o.Specificatie)
                                                       //.OrderBy(v => v.VoertuigCategorie)
                                                       //.ThenBy(v => v.Merk.MerkNaam)
                                                       //.ThenBy(v => v.MerkType.MerkTypeNaam)
                                                       .FirstOrDefaultAsync(o => o.Artikelnummer == id);

            odVM.FilesName = $"images/onderdelen/reeks/{odVM.OnderdeelDetail.Artikelnummer }";


            string[] filesindirectory = Directory.GetFiles(Path.Combine(webRoot, odVM.FilesName));
            odVM.OnderdelenAfbeeldingen = new List<string>(filesindirectory.Count());
            foreach (string item in filesindirectory)
            {
                odVM.OnderdelenAfbeeldingen.Add(String.Format(odVM.FilesName + "/{0}", Path.GetFileName(item)));
            }

            return View(odVM);
           
        }

    }
}