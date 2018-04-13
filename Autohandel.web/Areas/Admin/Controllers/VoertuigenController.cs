using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.Repositories;
using Autohandel.web.ViewModels.VoertuigenViewModels;
using Microsoft.AspNetCore.Http;

namespace Autohandel.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VoertuigenController : Controller
    {
        private readonly AutohandelContext _context;

        public VoertuigenController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Voertuigen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voertuigen
                .Include(v=>v.Merk)
                .Include(v=>v.MerkType)
                .Include(v=>v.Klant)
                .Include(v=>v.Faktuur)
                .OrderBy(v=>v.VoertuigArtikelNummer.Length)
                .ThenBy(v=>v.VoertuigArtikelNummer)
                .ToListAsync() );
        }

        // GET: Admin/Voertuigen/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen
                .Include(v => v.Merk)
                .Include(v => v.MerkType)
                .Include(v => v.VoertuigCategorie)
                .Include(v => v.Klant)
                .Include(v => v.Faktuur)
                .OrderBy(v => v.VoertuigArtikelNummer.Length)
                .ThenBy(v => v.VoertuigArtikelNummer)
                .SingleOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }

            return View(voertuig);
        }

        [HttpGet] //Get /Admin/Voertuigen/GetModellen)
        public IActionResult GetModellen(string merkId)
        {
            if (!string.IsNullOrWhiteSpace(merkId))
            {
                var repo = new ModellenRepository(_context);

                IEnumerable<SelectListItem> modellen = repo.GetModellen(merkId);
                return Json(modellen);
                //JsonRequestBehavior has been deprecated in ASP.NET Core 1.0.
            }
            return null;
        }

        // GET: Admin/Voertuigen/Create
        public IActionResult Create()
        {
           
            var repo = new VoertuigenRepository(_context);
            var voertuig = repo.CreateVoertuig();
            voertuig.Info = $"--BestelWag.= {voertuig.MaxLVNr}-- PW.= {voertuig.MaxPWNr} !--";
            

            return View(voertuig);
            //return View();
        }

        // POST: Admin/Voertuigen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("VoertuigArtikelNummer,VoertuigTitel,Chassisnummer,Prijs,Kleur,Brandstof,Kilometerstand," +
            "Bouwjaar,FiguurURL,Registratie,GarantieTijd,COTwee,Versnelling,CC,Vermogen,Deuren,Zitplaatsen," +
            "Binnenbekleding,Binnenkleur,Koetswerk, SelectedMerk, SelectedModel, SelectedCategorie, SelectedFaktuur, SelectedKlant")]  VoertuigEditViewModel voertuigCreated)
        {
;
            string VolRegistratie = voertuigCreated.Registratie;
            string last4Char = VolRegistratie.Substring(VolRegistratie.Length - 4, 4);

            if (last4Char != voertuigCreated.Bouwjaar.ToString())
            {
                ModelState.AddModelError("bouwjaarValidationError",
                    "Bouwjaar verschilt met Registratie");
            }

                VoertuigenRepository repo;
                

                if (ModelState.IsValid)
                {
                   

                    repo = new VoertuigenRepository(_context);
                    bool saved = repo.SaveVoertuig(voertuigCreated);
                    if (saved)
                    {
                        TempData["SuccessMessage"] = $"Het voertuig {voertuigCreated.VoertuigArtikelNummer} is succesvol toegevoegd.";
                        return RedirectToAction(nameof(Index));
                    }
                }
                repo = new VoertuigenRepository(_context);
                voertuigCreated = repo.CreateVoertuig();

                return View(voertuigCreated);
          
        }

        // GET: Admin/Voertuigen/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            //var voertuigMod = _context.Voertuigen
            //    .Include(v => v.Merk)
            //    .Include(v => v.MerkType)
            //    .Include(v => v.VoertuigCategorie)
            //    //.Include(v => v.Klant)
            //    //.Include(v => v.Faktuur)
            //    //.OrderBy(v => v.VoertuigArtikelNummer.Length)
            //    //.ThenBy(v => v.VoertuigArtikelNummer)
            //    .SingleOrDefault(m => m.VoertuigId == id);
            //if (voertuigMod == null)
            //{
            //    return NotFound();
            //}
            //ViewData["MerkId"] = new SelectList(_context.Merken, "MerkId", "MerkNaam");
            //ViewData["MerkTypeId"] = new SelectList(_context.Types, "MerkTypeId", "MerkTypeNaam");
            //ViewData["VoertuigCatId"] = new SelectList(_context.VoertuigCategorieen,"VoertuigCatId", "VoertuigCategorieNaam",voertuig.VoertuigCategorie);

            //return View(voertuig);

            var repo = new VoertuigenRepository(_context);
            var voertuigED = repo.EditVoertuig(id);

            return View(voertuigED);
        }

        // POST: Admin/Voertuigen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(long id, [Bind("VoertuigId,VoertuigArtikelNummer,VoertuigTitel,Chassisnummer,Prijs,Kleur," +
            "Brandstof,Kilometerstand,Bouwjaar,FiguurURL,Registratie,GarantieTijd,COTwee,Versnelling,CC,Vermogen,Deuren,Zitplaatsen," +
            "Binnenbekleding,Binnenkleur,Koetswerk, SelectedMerk, SelectedModel, SelectedCategorie, SelectedFaktuur, SelectedKlant")]  VoertuigEditViewModel voertuigModified)
        {
            string VolRegistratie = voertuigModified.Registratie;
            string last4Char = VolRegistratie.Substring(VolRegistratie.Length - 4, 4);

            if (last4Char != voertuigModified.Bouwjaar.ToString())
            {
                ModelState.AddModelError("bouwjaarValidationError",
                    "Bouwjaar verschilt met Registratie");
            }
            VoertuigenRepository repo;

            if (id != voertuigModified.VoertuigId)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        _context.Update(voertuig);
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //if (!VoertuigExists(voertuig.VoertuigId))
            //        {
            //            return NotFound();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }
            //    return RedirectToAction(nameof(Index));


            if (ModelState.IsValid)
            {

                //try
                //{
                repo = new VoertuigenRepository(_context);
                bool saved = repo.SaveEditVoertuig(id,voertuigModified);
                if (saved)
                {
                    TempData["SuccessMessage"] = $"Het voertuig {voertuigModified.VoertuigArtikelNummer} is succesvol gewijzigd.";
                    return RedirectToAction(nameof(Index));
                }
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!VoertuigExists(voertuigModified.VoertuigId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
            }
                return RedirectToAction(nameof(Index));


            }
        //        repo = new VoertuigenRepository(_context);
        //    voertuigCreated = repo.CreateVoertuig();

        //    return View(voertuigCreated);

        //}
        //    return View(voertuig);
        //}

        // GET: Admin/Voertuigen/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen
                .Include(v => v.Merk)
                .Include(v => v.MerkType)
                .Include(v => v.VoertuigCategorie)
                .Include(v => v.Klant)
                .Include(v => v.Faktuur)
                .SingleOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }

            return View(voertuig);
        }

        // POST: Admin/Voertuigen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var voertuig = await _context.Voertuigen
                .Include(v => v.Merk)
                .Include(v => v.MerkType)
                .Include(v => v.VoertuigCategorie)
                .Include(v => v.Klant)
                .Include(v => v.Faktuur)
                .SingleOrDefaultAsync(m => m.VoertuigId == id);
                if ((voertuig.Klant == null) || (voertuig.Faktuur == null))
                {
                    try
                    {
                        _context.Voertuigen.Remove(voertuig);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = $"Het voertuig met nummer <b>{voertuig.VoertuigArtikelNummer}</b> is succesvol verwijderd.";
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        TempData["AlertMessage"] = $"Het voertuig met nummer <b>{voertuig.VoertuigArtikelNummer}</b> kon niet verwijderd worden.";
                    }

                }
                else
                {
                    TempData["AlertMessage"] = $"Het voertuig met nummer <b>{voertuig.VoertuigArtikelNummer}</b> kon niet verwijderd worden. Er bestaat reeds een faktuur of klant!";

                }
                return RedirectToAction(nameof(Index));

        }

        private bool VoertuigExists(long id)
        {
            return _context.Voertuigen.Any(e => e.VoertuigId == id);
        }


    }
}
