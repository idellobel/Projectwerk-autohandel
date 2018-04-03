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
    public class TapijtRubberController : Controller
    {
        private readonly AutohandelContext _context;

        public TapijtRubberController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/TapijtRubber
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.OnderdelenProducten
                                    .Include(o => o.CategorieOnderdelen)
                                    .Include(o => o.Specificatie)
                                    .Where(o => o.CategorieOnderdelen.OnderdelenCategorienaam == "Tapijt Rubber")
                                    .OrderBy(o => o.Artikelnummer.Substring(2).Length)
                                    .ThenBy(o => o.Artikelnummer);

            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/TapijtRubber/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderdelenProducten = await _context.OnderdelenProducten
                                         .Include(o => o.CategorieOnderdelen)
                                         .Include(o => o.Specificatie)
                                         .SingleOrDefaultAsync(m => m.Artikelnummer == id);

            if (onderdelenProducten == null)
            {
                return NotFound();
            }

            return View(onderdelenProducten);
        }

        // GET: Admin/TapijtRubber/Create
        public IActionResult Create()
        {
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Tapijt Rubber"), "OnderdelenCategorieId", "OnderdelenCategorienaam");
            return View();
        }

        // POST: Admin/TapijtRubber/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Artikelnummer,Artikelnaam,Artikelomschrijving,Prijs,FiguurURL,OpVoorraad,Specificatie,SpecificatieId,CategorieOnderdelen,OnderdelenCategorieId")] OnderdelenProducten onderdelenProductenCreate)
        {
            if (OnderdelenProductenExists(onderdelenProductenCreate.Artikelnummer))
            {
                ModelState.AddModelError("ArtikelValidatieError", "Artikelnummer bestaat reeds!");
            }

            if (ModelState.IsValid)
            {
                _context.Add(onderdelenProductenCreate);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Het tapijt in rubber <b>{onderdelenProductenCreate.Artikelnummer}</b> werd toegevoegd!";
                return RedirectToAction(nameof(Index));
            }
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Tapijt Rubber"), "OnderdelenCategorieId", "OnderdelenCategorienaam", onderdelenProductenCreate.OnderdelenCategorieId);
            return View(onderdelenProductenCreate);
        }

        // GET: Admin/TapijtRubber/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderdelenProducten = await _context.OnderdelenProducten
                                                .Include(m => m.Specificatie)
                                                .SingleOrDefaultAsync(m => m.Artikelnummer == id);
            if (onderdelenProducten == null)
            {
                return NotFound();
            }
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Tapijt Rubber"), "OnderdelenCategorieId", "OnderdelenCategorienaam", onderdelenProducten.OnderdelenCategorieId);
            return View(onderdelenProducten);
        }

        // POST: Admin/TapijtRubber/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Artikelnummer,Artikelnaam,Artikelomschrijving,Prijs,FiguurURL,OpVoorraad,Specificatie,SpecificatieId,CategorieOnderdelen,OnderdelenCategorieId")] OnderdelenProducten onderdelenProductenEdit)
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
                    TempData["SuccessMessage"] = $"Het tapijt in rubber <b>{onderdelenProductenEdit.Artikelnummer}</b> werd gewijzigd!";
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
            ViewData["OnderdelenCategorieId"] = new SelectList(_context.CategorieOnderdelen.Where(o => o.OnderdelenCategorienaam == "Tapijt Rubber"), "OnderdelenCategorieId", "OnderdelenCategorienaam", onderdelenProductenEdit.OnderdelenCategorieId);
            return View(onderdelenProductenEdit);
        }

        // GET: Admin/TapijtRubber/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var onderdelenProducten = await _context.OnderdelenProducten
                                            .Include(o => o.Specificatie)
                                            .Include(o => o.CategorieOnderdelen)
                                            .SingleOrDefaultAsync(m => m.Artikelnummer == id);

            if (onderdelenProducten == null)
            {
                return NotFound();
            }

            return View(onderdelenProducten);
        }

        // POST: Admin/TapijtRubber/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var onderdelenProducten = await _context.OnderdelenProducten
                                             .Include(o => o.Specificatie)
                                             .Include(o => o.CategorieOnderdelen)
                                             .SingleOrDefaultAsync(m => m.Artikelnummer == id);
            _context.OnderdelenProducten.Remove(onderdelenProducten);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Het tapijt in rubber <b>{onderdelenProducten.Artikelnummer}</b> werd verwijderd!";
            return RedirectToAction(nameof(Index));
        }

        private bool OnderdelenProductenExists(string id)
        {
            return _context.OnderdelenProducten.Any(e => e.Artikelnummer == id);
        }
    }
}
