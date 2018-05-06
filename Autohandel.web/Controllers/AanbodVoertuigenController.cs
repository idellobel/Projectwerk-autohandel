using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.ViewModels.AanbodVoertuigenViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autohandel.web.Controllers
{
    public class AanbodVoertuigenController : Controller
    {
        private readonly AutohandelContext _context;
        private IHostingEnvironment _env;

        public AanbodVoertuigenController(AutohandelContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }
       
       

        // GET: AanbodVoertuigen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voertuigen
               .Include(v => v.Merk)
               .Include(v => v.MerkType)
               .Include(v=>v.Klant)
               .Include(v=>v.Faktuur)
               .Where(v=> v.Faktuur == null)
               .OrderBy(v => v.VoertuigCategorie)
               //.ThenBy(v => v.VoertuigArtikelNummer)
               .ThenBy(v => v.Merk.MerkNaam)
               .ThenBy(v=> v.MerkType.MerkTypeNaam)


               .ToListAsync());
        }
        // GET: AanbodVoertuigen/VoertuigDetails/50
        public async Task<IActionResult> VoertuigDetails(string id)
        {
            var webRoot = _env.WebRootPath;
            var vdVM = new VoertuigDetailsViewModel();

            vdVM.VoertuigDetail = await _context.Voertuigen
                                                       .Include(v => v.Merk)
                                                       .Include(v => v.MerkType)
                                                       .Include(v => v.VoertuigCategorie)
                                                       .Include(v => v.Klant)
                                                       .Include(v => v.Faktuur)
                                                       .Where(v => v.Faktuur == null)
                                                       .OrderBy(v => v.VoertuigCategorie)
                                                       .ThenBy(v => v.Merk.MerkNaam)
                                                       .ThenBy(v => v.MerkType.MerkTypeNaam)
                                                       .FirstOrDefaultAsync(v => v.VoertuigArtikelNummer == id);

            vdVM.FilesName = $"images/vtgn/reeks/{vdVM.VoertuigDetail.VoertuigArtikelNummer}";


            string[] filesindirectory = Directory.GetFiles(Path.Combine(webRoot, vdVM.FilesName));
            vdVM.VoertuigAfbeeldingen = new List<string>(filesindirectory.Count());
            foreach (string item in filesindirectory)
            {
                vdVM.VoertuigAfbeeldingen.Add(String.Format(vdVM.FilesName + "/{0}", Path.GetFileName(item)));
            }

            return View(vdVM);
        }

        //public IActionResult GetVtgnOpMerk(string merk)
        //{

        //    var vtgnMerk = _context.Voertuigen
        //     .Include(v => v.Merk)
        //     .Include(v => v.MerkType)
        //     .Include(v => v.Klant)
        //     .Include(v => v.Faktuur)
        //     .Where(v => v.Faktuur == null)
        //     .OrderBy(v => v.VoertuigCategorie)
        //     //.ThenBy(v => v.VoertuigArtikelNummer)
        //     .ThenBy(v => v.Merk.MerkNaam)
        //     .ThenBy(v => v.MerkType.MerkTypeNaam)
        //     .FirstOrDefault((v) => v.Merk.MerkNaam == merk);

        //    return View(vtgnMerk);
        //}
    }
}