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
    public class SpecificatiesController : Controller
    {
        private readonly AutohandelContext _context;

        public SpecificatiesController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Specificaties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Specificaties.ToListAsync());
        }

        // GET: Admin/Specificaties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificaties = await _context.Specificaties
                .SingleOrDefaultAsync(m => m.SpecificatieId == id);
            if (specificaties == null)
            {
                return NotFound();
            }

            return View(specificaties);
        }

        // GET: Admin/Specificaties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Specificaties/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SpecificatieId,Materie,Kleur,GarantieTermijn,Goedkeuring,Breedte,MaxBelading,Inhoud,Lengte,Opening,Hoogte,Gewicht,Vergrendeling,Montageset,CityCrash,AantalFietsen,Fietstypes,StekkerAansluiting,WaaromKeuze,Mistlicht,Kantelfunctie,Inklapbaar,Dikte,Buitendiameter,Binnendiameter,Schroefdraad,Type,Mengbaar,Geur,MinimaleTemperatuur,Mat,Flappen,MaxVertikaleLast,Aanhangwagengewicht,Formaat,Draagvermogen,SnelheidIndex,Rolgeluid")] Specificaties specificaties)
        {
            if (ModelState.IsValid)
            {
                _context.Add(specificaties);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specificaties);
        }

        // GET: Admin/Specificaties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificaties = await _context.Specificaties.SingleOrDefaultAsync(m => m.SpecificatieId == id);
            if (specificaties == null)
            {
                return NotFound();
            }

            
            return View(specificaties);
        }

        // POST: Admin/Specificaties/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SpecificatieId,Materie,Kleur,GarantieTermijn,Goedkeuring,Breedte,MaxBelading,Inhoud,Lengte,Opening,Hoogte,Gewicht,Vergrendeling,Montageset,CityCrash,AantalFietsen,Fietstypes,StekkerAansluiting,WaaromKeuze,Mistlicht,Kantelfunctie,Inklapbaar,Dikte,Buitendiameter,Binnendiameter,Schroefdraad,Type,Mengbaar,Geur,MinimaleTemperatuur,Mat,Flappen,MaxVertikaleLast,Aanhangwagengewicht,Formaat,Draagvermogen,SnelheidIndex,Rolgeluid")] Specificaties specificaties)
        {
            if (id != specificaties.SpecificatieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(specificaties);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificatiesExists(specificaties.SpecificatieId))
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
            return View(specificaties);
        }

        // GET: Admin/Specificaties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specificaties = await _context.Specificaties
                .SingleOrDefaultAsync(m => m.SpecificatieId == id);
            if (specificaties == null)
            {
                return NotFound();
            }

            return View(specificaties);
        }

        // POST: Admin/Specificaties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var specificaties = await _context.Specificaties.SingleOrDefaultAsync(m => m.SpecificatieId == id);
            _context.Specificaties.Remove(specificaties);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpecificatiesExists(int id)
        {
            return _context.Specificaties.Any(e => e.SpecificatieId == id);
        }
    }
}
