using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;

namespace Autohandel.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FakturenController : Controller
    {
        private readonly AutohandelContext _context;

        public FakturenController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Fakturen
        [Route("Admin/Fakturen/Index")]
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.Fakturen
                                    .Include(f => f.Klant)
                                    .Include(f => f.OnderdelenProducten)
                                    .Include(f => f.Voertuig)
                                    .Include(f => f.Voertuig.Merk)
                                    .Include(f => f.Voertuig.MerkType)
                                    ;
            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/Fakturen/Details/5
        [Route("Admin/Fakturen/Details/{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktuur = await _context.Fakturen
                .Include(f => f.Klant)
                .Include(f => f.OnderdelenProducten)
                .Include(f => f.Voertuig)
                .Include(f => f.Voertuig.Merk)
                .Include(f => f.Voertuig.MerkType)
                .SingleOrDefaultAsync(m => m.FaktuurNr == id);
            if (faktuur == null)
            {
                return NotFound();
            }

            return View(faktuur);
        }

        // GET: Admin/Fakturen/Create
        [Route("Admin/Fakturen/Create")]
        public IActionResult Create()
        {


            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres");
            ViewData["Artikelnummer"] = new SelectList(_context.OnderdelenProducten, "Artikelnummer", "Artikelnummer");
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen.OrderBy(v => v.VoertuigArtikelNummer.Length)
                                             .ThenBy(v => v.VoertuigArtikelNummer), "VoertuigId", "VoertuigArtikelNummer");

            if ((_context.Klanten.Count() == 0) || (_context.OnderdelenProducten.Count() == 0) || (_context.Voertuigen.Count() == 0))
            {
                try
                {
                    TempData["AlertMessage"] = $"Er kan nog geen faktuur gemaakt worden." +
                        $"Vermoedelijk is één van de lijsten 'klant', 'voertuig' of 'onderdelenproducten' onbestaande !";

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["AlertMessage"] = $"Systeemfout in categorieënbeheer!";

                    return RedirectToAction(nameof(Index));
                }
            }

            return View();
        }

        // POST: Admin/Fakturen/Create
        [Route("Admin/Fakturen/Create")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FaktuurNr,Faktuurdatum,KlantId,VoertuigId,Artikelnummer")] Faktuur faktuur)
        {
            if ((faktuur.VoertuigId == null) && (faktuur.Artikelnummer == null))
            {
                ModelState.AddModelError("FaktuurValidatieError", "Ongeldige invoer voor 1 faktuur");
            }
            if (faktuur.Faktuurdatum > DateTime.Now) 
            {
                ModelState.AddModelError("FaktuurDatumValidatieError", "Ongeldige invoerdatum");
            }

            if (ModelState.IsValid)
            {
                _context.Add(faktuur);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"De faktuur <b>{faktuur.FaktuurNr}</b> werd toegevoegd!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres", faktuur.KlantId);
            ViewData["Artikelnummer"] = new SelectList(_context.OnderdelenProducten, "Artikelnummer", "Artikelnummer", faktuur.Artikelnummer);
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen.OrderBy(v => v.VoertuigArtikelNummer.Length)
                                             .ThenBy(v => v.VoertuigArtikelNummer), "VoertuigId", "VoertuigArtikelNummer", faktuur.VoertuigId);
            return View(faktuur);
        }

        // GET: Admin/Fakturen/Edit/5
        [Route("Admin/Fakturen/Edit/{id}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktuur = await _context.Fakturen.SingleOrDefaultAsync(m => m.FaktuurNr == id);
            if (faktuur == null)
            {
                return NotFound();
            }
            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres", faktuur.KlantId);
            ViewData["Artikelnummer"] = new SelectList(_context.OnderdelenProducten, "Artikelnummer", "Artikelnummer", faktuur.Artikelnummer);
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen.OrderBy(v => v.VoertuigArtikelNummer.Length)
                                             .ThenBy(v => v.VoertuigArtikelNummer), "VoertuigId", "VoertuigArtikelNummer", faktuur.VoertuigId);
            return View(faktuur);
        }

        // POST: Admin/Fakturen/Edit/5
        [Route("Admin/Fakturen/Edit/{id}")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("FaktuurNr,Faktuurdatum,KlantId,VoertuigId,Artikelnummer")] Faktuur faktuur)
        {
            if (id != faktuur.FaktuurNr)
            {
                return NotFound();
            }
            if ((faktuur.VoertuigId == null) && (faktuur.Artikelnummer == null))
            {
                ModelState.AddModelError("FaktuurValidatieError", "Ongeldige invoer voor 1 faktuur");
            }
            if (faktuur.Faktuurdatum > DateTime.Now)
            {
                ModelState.AddModelError("FaktuurDatumValidatieError", "Ongeldige invoerdatum");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(faktuur);
                    TempData["SuccessMessage"] = $"De faktuur <b>{faktuur.FaktuurNr}</b> werd gewijzigd!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaktuurExists(faktuur.FaktuurNr))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres", faktuur.KlantId);
            ViewData["Artikelnummer"] = new SelectList(_context.OnderdelenProducten, "Artikelnummer", "Artikelnummer", faktuur.Artikelnummer);
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen.OrderBy(v => v.VoertuigArtikelNummer.Length)
                                             .ThenBy(v => v.VoertuigArtikelNummer), "VoertuigId", "VoertuigArtikelNummer", faktuur.VoertuigId);
            return View(faktuur);
        }

        // GET: Admin/Fakturen/Delete/5
        [Route("Admin/Fakturen/Delete/{id}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var faktuur = await _context.Fakturen
                .Include(f => f.Klant)
                .Include(f => f.OnderdelenProducten)
                .Include(f => f.Voertuig)
                .Include(f => f.Voertuig.Merk)
                .Include(f => f.Voertuig.MerkType)
                .SingleOrDefaultAsync(m => m.FaktuurNr == id);
            if (faktuur == null)
            {
                return NotFound();
            }

            return View(faktuur);
        }

        // POST: Admin/Fakturen/Delete/5
        [Route("Admin/Fakturen/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var faktuur = await _context.Fakturen.SingleOrDefaultAsync(m => m.FaktuurNr == id);
            _context.Fakturen.Remove(faktuur);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"De faktuur <b>{faktuur.FaktuurNr}</b> werd verwijderd!";
            return RedirectToAction(nameof(Index));
        }

        private bool FaktuurExists(long id)
        {
            return _context.Fakturen.Any(e => e.FaktuurNr == id);
        }
    }
}
