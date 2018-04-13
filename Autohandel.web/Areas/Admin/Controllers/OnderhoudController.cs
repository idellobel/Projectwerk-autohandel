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
    public class OnderhoudController : Controller
    {
        private readonly AutohandelContext _context;

        public OnderhoudController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Onderhoud
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.Onderhoud
                                    .Include(o => o.Klant)
                                    .Include(o => o.Voertuig)
                                    .Include(o => o.Voertuig.Merk)
                                    .Include(o => o.Voertuig.MerkType)
                                    .Include(o => o.Voertuig.Klant);
            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/Onderhoud/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderhoud = await _context.Onderhoud
                .Include(o => o.Klant)
                .Include(o => o.Voertuig)
                .Include(o => o.Voertuig.Merk)
                .Include(o => o.Voertuig.MerkType)
                .Include(o=> o.Voertuig.Klant)
                .SingleOrDefaultAsync(m => m.OnderhoudId == id);
            if (onderhoud == null)
            {
                return NotFound();
            }

            return View(onderhoud);
        }

        // GET: Admin/Onderhoud/Create
        public IActionResult Create()
        {
            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres");
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen, "VoertuigId", "VoertuigArtikelNummer");
            return View();
        }

        // POST: Admin/Onderhoud/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnderhoudId,VoertuigId,Datum,Kilometerstand,Info,KlantId")] Onderhoud onderhoud)
        {
            if (onderhoud.Datum > DateTime.Now)
            {
                ModelState.AddModelError("OnderhoudDatumValidatieError", "Ongeldige invoerdatum");
            }

            if (ModelState.IsValid)
            {
                _context.Add(onderhoud);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Onderhoud <b>{onderhoud.OnderhoudId}</b> werd toegevoegd!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres", onderhoud.KlantId);
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen.OrderBy(v => v.VoertuigArtikelNummer.Length)
                                             .ThenBy(v => v.VoertuigArtikelNummer), "VoertuigId", "VoertuigArtikelNummer", onderhoud.VoertuigId);
            return View(onderhoud);
        }

        // GET: Admin/Onderhoud/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderhoud = await _context.Onderhoud.SingleOrDefaultAsync(m => m.OnderhoudId == id);
            if (onderhoud == null)
            {
                return NotFound();
            }
            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres", onderhoud.KlantId);
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen.OrderBy(v => v.VoertuigArtikelNummer.Length)
                                             .ThenBy(v => v.VoertuigArtikelNummer), "VoertuigId", "VoertuigArtikelNummer", onderhoud.VoertuigId);
            return View(onderhoud);
        }

        // POST: Admin/Onderhoud/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("OnderhoudId,VoertuigId,Datum,Kilometerstand,Info,KlantId")] Onderhoud onderhoud)
        {
            if (id != onderhoud.OnderhoudId)
            {
                return NotFound();
            }
            if (onderhoud.Datum > DateTime.Now)
            {
                ModelState.AddModelError("OnderhoudDatumValidatieError", "Ongeldige invoerdatum");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onderhoud);
                    TempData["SuccessMessage"] = $"Onderhoud <b>{onderhoud.OnderhoudId}</b> werd gewijzigd!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnderhoudExists(onderhoud.OnderhoudId))
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
            ViewData["KlantId"] = new SelectList(_context.Klanten, "PersoonId", "Adres", onderhoud.KlantId);
            ViewData["VoertuigId"] = new SelectList(_context.Voertuigen.OrderBy(v => v.VoertuigArtikelNummer.Length)
                                             .ThenBy(v => v.VoertuigArtikelNummer), "VoertuigId", "VoertuigArtikelNummer", onderhoud.VoertuigId);
            return View(onderhoud);
        }

        // GET: Admin/Onderhoud/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderhoud = await _context.Onderhoud
                .Include(o => o.Klant)
                .Include(o => o.Voertuig)
                .Include(o => o.Voertuig.Merk)
                .Include(o => o.Voertuig.MerkType)
                .Include(o => o.Voertuig.Klant)
                .SingleOrDefaultAsync(m => m.OnderhoudId == id);
            if (onderhoud == null)
            {
                return NotFound();
            }

            return View(onderhoud);
        }

        // POST: Admin/Onderhoud/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var onderhoud = await _context.Onderhoud.SingleOrDefaultAsync(m => m.OnderhoudId == id);
            _context.Onderhoud.Remove(onderhoud);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Onderhoud <b>{onderhoud.OnderhoudId}</b> werd verwijderd!";
            return RedirectToAction(nameof(Index));
        }

        private bool OnderhoudExists(long id)
        {
            return _context.Onderhoud.Any(e => e.OnderhoudId == id);
        }
    }
}
