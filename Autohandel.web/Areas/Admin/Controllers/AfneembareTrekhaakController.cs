﻿using System;
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
    public class AfneembareTrekhaakController : Controller
    {
        private readonly AutohandelContext _context;

        public AfneembareTrekhaakController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/AfneembareTrekhaak
        [Route("Admin/AfneembareTrekhaak/Index")]
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.OnderdelenProducten
                                    .Include(lv=>lv.Leverancier)
                                    .Include(o => o.CategorieOnderdelen)
                                    .Include(o => o.Specificatie)
                                    .Where(o => o.CategorieOnderdelen.OnderdelenCategorienaam == "Afneembare Trekhaak")
                                    .OrderBy(o => o.Artikelnummer.Substring(2).Length)
                                    .ThenBy(o => o.Artikelnummer);
            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/AfneembareTrekhaak/Details/5
        [Route("Admin/AfneembareTrekhaak/Details/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderdelenProducten = await _context.OnderdelenProducten
                                        .Include(o => o.Leverancier)
                                        .Include(o => o.CategorieOnderdelen)
                                        .Include(o => o.Specificatie)
                                        .SingleOrDefaultAsync(m => m.Artikelnummer == id);

            if (onderdelenProducten == null)
            {
                return NotFound();
            }

            return View(onderdelenProducten);
        }

        // GET: Admin/AfneembareTrekhaak/Create
        [Route("Admin/AfneembareTrekhaak/Create")]
        public IActionResult Create()
        {
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Afneembare Trekhaak"), "OnderdelenCategorieId", "OnderdelenCategorienaam");
            ViewData["LeveranciersLijst"] = new SelectList(_context.Leveranciers, "LeverancierID", "LeverancierNaam");
            //ViewBag.LeveranciersLijst = new SelectList(_context.Leveranciers, "LeverancierID", "LeverancierNaam");
            return View();
        }

        [Route("Admin/AfneembareTrekhaak/Create")]
        // POST: Admin/AfneembareTrekhaak/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Leverancier,LeverancierID, Artikelnummer,Artikelnaam,Artikelomschrijving,Prijs,FiguurURL,OpVoorraad,Specificatie,SpecificatieId,CategorieOnderdelen,OnderdelenCategorieId")] OnderdelenProducten onderdelenProductenCreate)
        {
            if (OnderdelenProductenExists(onderdelenProductenCreate.Artikelnummer))
            {
                ModelState.AddModelError("ArtikelValidatieError", "Artikelnummer bestaat reeds!");
            }

            if (ModelState.IsValid)
            {
                _context.Add(onderdelenProductenCreate);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"De afneembare trekhaak <b>{onderdelenProductenCreate.Artikelnummer}</b> werd toegevoegd!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Afneembare Trekhaak"), "OnderdelenCategorieId", "OnderdelenCategorienaam", onderdelenProductenCreate.OnderdelenCategorieId);
            ViewData["LeveranciersLijst"] = new SelectList(_context.Leveranciers, "LeverancierID", "LeverancierNaam", onderdelenProductenCreate.LeverancierID);
            return View(onderdelenProductenCreate);
        }

        // GET: Admin/AfneembareTrekhaak/Edit/5
        [Route("Admin/AfneembareTrekhaak/Edit/{id}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderdelenProducten = await _context.OnderdelenProducten 
                                                .Include(o => o.Leverancier)
                                                .Include(o => o.Specificatie)
                                                .Include(m => m.Specificatie)
                                                .SingleOrDefaultAsync(m => m.Artikelnummer == id);
            if (onderdelenProducten == null)
            {
                return NotFound();
            }
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Afneembare Trekhaak"), "OnderdelenCategorieId", "OnderdelenCategorienaam", onderdelenProducten.OnderdelenCategorieId);
            ViewData["LeveranciersLijst"] = new SelectList(_context.Leveranciers, "LeverancierID", "LeverancierNaam", onderdelenProducten.LeverancierID);
            return View(onderdelenProducten);
        }

        [Route("Admin/AfneembareTrekhaak/Edit/{id}")]
        // POST: Admin/AfneembareTrekhaak/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Leverancier,LeverancierID, Artikelnummer,Artikelnaam,Artikelomschrijving,Prijs,FiguurURL,OpVoorraad,Specificatie,SpecificatieId,CategorieOnderdelen,OnderdelenCategorieId")] OnderdelenProducten onderdelenProductenEdit)
        {
            if (id != onderdelenProductenEdit.Artikelnummer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(onderdelenProductenEdit);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"De afneembare trekhaak <b>{onderdelenProductenEdit.Artikelnummer}</b> werd gewijzigd!";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OnderdelenProductenExists(onderdelenProductenEdit.Artikelnummer))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Afneembare Trekhaak"), "OnderdelenCategorieId", "OnderdelenCategorienaam", onderdelenProductenEdit.OnderdelenCategorieId);
            ViewData["LeveranciersLijst"] = new SelectList(_context.Leveranciers, "LeverancierID", "LeverancierNaam", onderdelenProductenEdit.LeverancierID);
            return View(onderdelenProductenEdit);
        }

        // GET: Admin/AfneembareTrekhaak/Delete/5
        [Route("Admin/AfneembareTrekhaak/Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderdelenProducten = await _context.OnderdelenProducten
                                              .Include(o => o.Leverancier)
                                              .Include(o => o.Specificatie)
                                              .Include(o => o.CategorieOnderdelen)
                                              .SingleOrDefaultAsync(m => m.Artikelnummer == id);

            if (onderdelenProducten == null)
            {
                return NotFound();
            }

            return View(onderdelenProducten);
        }

        // POST: Admin/AfneembareTrekhaak/Delete/5
        [Route("Admin/AfneembareTrekhaak/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var onderdelenProducten = await _context.OnderdelenProducten
                                          .Include(o => o.Leverancier)  
                                          .Include(o => o.Specificatie)
                                          .Include(o => o.CategorieOnderdelen)
                                          .SingleOrDefaultAsync(m => m.Artikelnummer == id);
            _context.OnderdelenProducten.Remove(onderdelenProducten);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"De afneembare trekhaak <b>{onderdelenProducten.Artikelnummer}</b> werd verwijderd!";
            return RedirectToAction(nameof(Index));
        }

        private bool OnderdelenProductenExists(string id)
        {
            return _context.OnderdelenProducten.Any(e => e.Artikelnummer == id);
        }
    }
}
