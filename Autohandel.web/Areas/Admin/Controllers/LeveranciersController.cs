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
    public class LeveranciersController : Controller
    {
        private readonly AutohandelContext _context;

        public LeveranciersController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Leveranciers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Leveranciers.ToListAsync());
        }

        // GET: Admin/Leveranciers/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leverancier = await _context.Leveranciers
                .SingleOrDefaultAsync(m => m.PersoonId == id);
            if (leverancier == null)
            {
                return NotFound();
            }

            return View(leverancier);
        }

        // GET: Admin/Leveranciers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Leveranciers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeverancierID,LeverancierDatum,LeverancierNaam,PersoonId,Naam,Voornaam,Telefoonnummer,Adres,Postcode,Gemeente,Email")] Leverancier leverancier)
        {
            if (LeverancierNaamExists(leverancier.LeverancierNaam) || LeverancierIdExists(leverancier.LeverancierID))
            {
                ModelState.AddModelError("LeverancierValidatieError", "LeverancierId of Leveranciernaam bestaan reeds!");
            }

            if (ModelState.IsValid)
            {
                _context.Add(leverancier);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"De leverancier met naam <b>{leverancier.FullName}</b> werd toegevoegd!";
                return RedirectToAction(nameof(Index));
            }
            return View(leverancier);
        }

        // GET: Admin/Leveranciers/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leverancier = await _context.Leveranciers.SingleOrDefaultAsync(m => m.PersoonId == id);
            if (leverancier == null)
            {
                return NotFound();
            }
            return View(leverancier);
        }

        // POST: Admin/Leveranciers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LeverancierID,LeverancierDatum,LeverancierNaam,PersoonId,Naam,Voornaam,Telefoonnummer,Adres,Postcode,Gemeente,Email")] Leverancier leverancier)
        {
            if (id != leverancier.PersoonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leverancier);
                    TempData["SuccessMessage"] = $"De leverancier met naam <b>{leverancier.FullName}</b> werd gewijzigd!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeverancierExists(leverancier.PersoonId))
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
            return View(leverancier);
        }

        // GET: Admin/Leveranciers/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leverancier = await _context.Leveranciers
                .Include(l=>l.OnderdelenProducten)
                .SingleOrDefaultAsync(m => m.PersoonId == id);
            if (leverancier == null)
            {
                return NotFound();
            }

            if ((leverancier.OnderdelenProducten.Count() != 0) )
            {
                try
                {
                    TempData["AlertMessage"] = $"De leverancier <b>{leverancier.FullName}</b> mag niet verwijderd worden." +
                        $"De leverancier is reeds verbonden met onderdelenproducten.";

                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }

            return View(leverancier);
        }

        // POST: Admin/Leveranciers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var leverancier = await _context.Leveranciers
                .Include(l=>l.OnderdelenProducten)
                .SingleOrDefaultAsync(m => m.PersoonId == id);
     
            if (leverancier.OnderdelenProducten.Count() == 0)
            {
                try
                {
                    _context.Leveranciers.Remove(leverancier);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"De leverancier <b>{leverancier.FullName}</b> werd verwijderd!";

                }
                catch
                {
                    TempData["AlertMessage"] = $"De leverancier <b>{leverancier.FullName}</b> kon niet verwijderd worden.";

                }
            }
            else
            {
                TempData["AlertMessage"] = $"De leverancier <b>{leverancier.FullName}</b> kon niet verwijderd worden. Er zijn reeds producten aan verbonden!";


            }
            return RedirectToAction(nameof(Index));

        }

        private bool LeverancierExists(long id)
        {
            return _context.Leveranciers.Any(e => e.PersoonId == id);
        }

        private bool LeverancierIdExists(long id)
        {
            return _context.Leveranciers.Any(e => e.LeverancierID == id);
        }
        private bool LeverancierNaamExists(string naam)
        {
            return _context.Leveranciers.Any(e => e.LeverancierNaam == naam);
        }
    }
}
