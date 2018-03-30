using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;

namespace Autohandel.web.Areas.Admin
{
    [Area("Admin")]
    public class AanbodVoertuigenController : Controller
    {
        private readonly AutohandelContext _context;

        public AanbodVoertuigenController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/AanbodVoertuigen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voertuigen.ToListAsync());
        }

        // GET: Admin/AanbodVoertuigen/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen
                .SingleOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }

            return View(voertuig);
        }

        // GET: Admin/AanbodVoertuigen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AanbodVoertuigen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoertuigId,VoertuigArtikelNummer,VoertuigTitel,Chassisnummer,Prijs,Kleur,Brandstof,Kilometerstand,Bouwjaar,FiguurURL,Registratie,GarantieTijd,COTwee,Versnelling,CC,Vermogen,Deuren,Zitplaatsen,Binnenbekleding,Binnenkleur,Koetswerk")] Voertuig voertuig)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voertuig);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voertuig);
        }

        // GET: Admin/AanbodVoertuigen/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen.SingleOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }
            return View(voertuig);
        }

        // POST: Admin/AanbodVoertuigen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("VoertuigId,VoertuigArtikelNummer,VoertuigTitel,Chassisnummer,Prijs,Kleur,Brandstof,Kilometerstand,Bouwjaar,FiguurURL,Registratie,GarantieTijd,COTwee,Versnelling,CC,Vermogen,Deuren,Zitplaatsen,Binnenbekleding,Binnenkleur,Koetswerk")] Voertuig voertuig)
        {
            if (id != voertuig.VoertuigId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voertuig);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoertuigExists(voertuig.VoertuigId))
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
            return View(voertuig);
        }

        // GET: Admin/AanbodVoertuigen/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuig = await _context.Voertuigen
                .SingleOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }

            return View(voertuig);
        }

        // POST: Admin/AanbodVoertuigen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var voertuig = await _context.Voertuigen.SingleOrDefaultAsync(m => m.VoertuigId == id);
            _context.Voertuigen.Remove(voertuig);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoertuigExists(long id)
        {
            return _context.Voertuigen.Any(e => e.VoertuigId == id);
        }
    }
}
