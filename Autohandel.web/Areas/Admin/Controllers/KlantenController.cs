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
    public class KlantenController : Controller
    {
        private readonly AutohandelContext _context;

        public KlantenController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Klanten
        [Route("Admin/Klanten/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Klanten
               .Include(k => k.Faktuur)
               .OrderBy(k => k.KlantNaam)
               .ToListAsync());
        }

        // GET: Admin/Klanten/Details/5
        [Route("Admin/Klanten/Details/{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten
                 .Include(k => k.Faktuur)
                 .OrderBy(k => k.KlantNaam)
                 .SingleOrDefaultAsync(m => m.PersoonId == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // GET: Admin/Klanten/Create
        [Route("Admin/Klanten/Create")]
        public IActionResult Create()
        {
          
            return View();
        }

        // POST: Admin/Klanten/Create
        [Route("Admin/Klanten/Create")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KlantId,Klantdatum,KlantNaam,PersoonId,Naam,Voornaam,Telefoonnummer,Adres,Postcode,Gemeente,Email")] Klant klant)
        {
            if (KlantNaamExists(klant.KlantNaam) || KlantIdExists(klant.KlantId))
            {
                ModelState.AddModelError("KlantValidatieError", "KlantId of Klantnaam bestaan reeds!");
            }

            if (ModelState.IsValid)
            {
                _context.Add(klant);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Klant <b>{klant.KlantNaam}</b> werd toegevoegd!";
                return RedirectToAction(nameof(Index));
            }
          
            return View(klant);
        }

        // GET: Admin/Klanten/Edit/5
        [Route("Admin/Klanten/Edit/{id}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten.SingleOrDefaultAsync(m => m.PersoonId == id);
           
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Admin/Klanten/Edit/5
        [Route("Admin/Klanten/Edit/{id}")]
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("UserId,KlantId,Klantdatum,KlantNaam,PersoonId,Naam,Voornaam,Telefoonnummer,Adres,Postcode,Gemeente,Email")] Klant klant)
        {
            if (id != klant.PersoonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(klant);
                    TempData["SuccessMessage"] = $"Klant <b>{klant.KlantNaam}</b> werd gewijzigd!";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.PersoonId))
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
       
            return View(klant);
        }

        // GET: Admin/Klanten/Delete/5
        [Route("Admin/Klanten/Delete/{id}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten
                .Include(v=>v.Faktuur)
                .SingleOrDefaultAsync(m => m.PersoonId == id);
            if (klant == null)
            {
                return NotFound();
            }

            if (klant.Faktuur.Count() != 0)
            {
                try
                {
                    TempData["AlertMessage"] = $"De klant <b>{klant.KlantNaam}</b> mag niet verwijderd worden." +
                        $"De klant is reeds verbonden met een verkocht voertuig of onderdeel .";
                    //TempData["msgClass"] = "alert alert-success";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }

            return View(klant);
        }

        // POST: Admin/Klanten/Delete/5
        [Route("Admin/Klanten/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var klant = await _context.Klanten.Include(k=>k.Faktuur).SingleOrDefaultAsync(m => m.PersoonId == id);
            if (klant.Faktuur.Count() == 0)
            {
                try
                {
                    _context.Klanten.Remove(klant);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"De klant <b>{klant.KlantNaam}</b> is succesvol verwijderd.";
                  
                }
                catch
                {
                    TempData["AlertMessage"] = $"De klant <b>{klant.KlantNaam}</b> kon niet verwijderd worden.";
                   
                }
            }
            else
            {
                TempData["AlertMessage"] = $"De klant <b>{klant.KlantNaam}</b> kon niet verwijderd worden. Er zijn reeds verkochte goederen aan verbonden!";
               

            }
            return RedirectToAction(nameof(Index));
        }

        private bool KlantExists(long id)
        {
            return _context.Klanten.Any(e => e.PersoonId == id);
        }
        private bool KlantIdExists(long id)
        {
            return _context.Klanten.Any(e => e.KlantId == id);
        }

        private bool KlantNaamExists(string naam)
        {
            return _context.Klanten.Any(e => e.KlantNaam == naam);
        }
    }
}
