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
    public class GarantiesController : Controller
    {
        private readonly AutohandelContext _context;

        public GarantiesController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Garanties
        [Route("Admin/Garanties/Index")]
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.GarantieTabel
                                .Include(g => g.Faktuur)
                                .Include(g => g.Faktuur.Voertuig.Merk)
                                .Include(g => g.Faktuur.Voertuig.MerkType)
                                .Include(g => g.Faktuur.OnderdelenProducten)
                                .Include(g => g.Faktuur.Klant)
                                .OrderByDescending(g => g.FaktuurId);
            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/Garanties/Details/5
        [Route("Admin/Garanties/Details/{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantie = await _context.GarantieTabel
                .Include(g => g.Faktuur)
                .Include(g => g.Faktuur.Voertuig.Merk)
                .Include(g => g.Faktuur.Voertuig.MerkType)
                .Include(g => g.Faktuur.OnderdelenProducten)
                .Include(g => g.Faktuur.Klant)
                .SingleOrDefaultAsync(m => m.GarantieId == id);
            if (garantie == null)
            {
                return NotFound();
            }

            return View(garantie);
        }

        // GET: Admin/Garanties/Create
        [Route("Admin/Garanties/Create")]
        public IActionResult Create()
        {
            ViewData["FaktuurId"] = new SelectList(_context.Fakturen.OrderByDescending(f=>f.FaktuurNr), "FaktuurNr", "FaktuurNr");
            return View();
        }

        // POST: Admin/Garanties/Create
        [Route("Admin/Garanties/Create")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GarantieId,Vervaldatum,FaktuurId")] Garantie garantie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(garantie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"De garantie <b>{garantie.FaktuurId}</b> werd toegevoegd!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["FaktuurId"] = new SelectList(_context.Fakturen.OrderByDescending(f => f.FaktuurNr), "FaktuurNr", "FaktuurNr", garantie.FaktuurId);
            return View(garantie);
        }

        // GET: Admin/Garanties/Edit/5
        [Route("Admin/Garanties/Edit/{id}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantie = await _context.GarantieTabel.SingleOrDefaultAsync(m => m.GarantieId == id);
            if (garantie == null)
            {
                return NotFound();
            }
            ViewData["FaktuurId"] = new SelectList(_context.Fakturen.OrderByDescending(f => f.FaktuurNr), "FaktuurNr", "FaktuurNr", garantie.FaktuurId);
            return View(garantie);
        }

        // POST: Admin/Garanties/Edit/5
        [Route("Admin/Garanties/Edit/{id}")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("GarantieId,Vervaldatum,FaktuurId")] Garantie garantie)
        {
            if (id != garantie.GarantieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(garantie);
                    TempData["SuccessMessage"] = $"De garantie <b>{garantie.FaktuurId}</b> werd gewijzigd!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GarantieExists(garantie.GarantieId))
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
            ViewData["FaktuurId"] = new SelectList(_context.Fakturen.OrderByDescending(f => f.FaktuurNr), "FaktuurNr", "FaktuurNr", garantie.FaktuurId);
            return View(garantie);
        }

        // GET: Admin/Garanties/Delete/5
        [Route("Admin/Garanties/Delete/{id}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var garantie = await _context.GarantieTabel
                .Include(g => g.Faktuur)
                .Include(g => g.Faktuur.Voertuig.Merk)
                .Include(g => g.Faktuur.Voertuig.MerkType)
                .Include(g => g.Faktuur.OnderdelenProducten)
                .Include(g => g.Faktuur.Klant)
                .SingleOrDefaultAsync(m => m.GarantieId == id);
            if (garantie == null)
            {
                return NotFound();
            }

            return View(garantie);
        }

        // POST: Admin/Garanties/Delete/5
        [Route("Admin/Garanties/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var garantie = await _context.GarantieTabel.SingleOrDefaultAsync(m => m.GarantieId == id);
            _context.GarantieTabel.Remove(garantie);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"De garantie <b>{garantie.FaktuurId}</b> werd verwijderd!";
            return RedirectToAction(nameof(Index));
        }

        private bool GarantieExists(long id)
        {
            return _context.GarantieTabel.Any(e => e.GarantieId == id);
        }
    }
}
