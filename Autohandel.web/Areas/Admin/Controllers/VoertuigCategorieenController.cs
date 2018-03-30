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
    public class VoertuigCategorieenController : Controller
    {
        private readonly AutohandelContext _context;

        public VoertuigCategorieenController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/VoertuigCategorieen
        public async Task<IActionResult> Index()
        {
            return View(await _context.VoertuigCategorieen.ToListAsync());
        }

        // GET: Admin/VoertuigCategorieen/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigCategorie = await _context.VoertuigCategorieen
                .SingleOrDefaultAsync(m => m.VoertuigCatId == id);
            if (voertuigCategorie == null)
            {
                return NotFound();
            }

            return View(voertuigCategorie);
        }

        // GET: Admin/VoertuigCategorieen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/VoertuigCategorieen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoertuigCatId,VoertuigCategorieNaam")] VoertuigCategorie voertuigCategorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voertuigCategorie);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"De voertuigencategorie <b>{voertuigCategorie.VoertuigCategorieNaam}</b> is succesvol toegevoegd.";
                return RedirectToAction(nameof(Index));
            }
            return View(voertuigCategorie);
        }

        // GET: Admin/VoertuigCategorieen/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var voertuigCategorie = await _context.VoertuigCategorieen.Include(c => c.Voertuigen).SingleOrDefaultAsync(m => m.VoertuigCatId == id);
            if (voertuigCategorie == null)
            {
                return NotFound();
            }
            if (voertuigCategorie.Voertuigen.Count() != 0)
            {
                try
                {
                    TempData["AlertMessage"] = $"De voertuigencategorie <b>{voertuigCategorie.VoertuigCategorieNaam}</b> mag niet gewijzigd worden." +
                        $"De categorienaam is reeds verbonden met voertuigen.";
                    //TempData["msgClass"] = "alert alert-success";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }


            return View(voertuigCategorie);
        }

        // POST: Admin/VoertuigCategorieen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("VoertuigCatId,VoertuigCategorieNaam")] VoertuigCategorie voertuigCategorie)
        {
            if (id != voertuigCategorie.VoertuigCatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voertuigCategorie);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"De voertuigencategorie <b>{voertuigCategorie.VoertuigCategorieNaam}</b> is succesvol gewijzigd.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoertuigCategorieExists(voertuigCategorie.VoertuigCatId))
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
            return View(voertuigCategorie);
        }

        // GET: Admin/VoertuigCategorieen/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voertuigCategorie = await _context.VoertuigCategorieen.Include(c=>c.Voertuigen)
                .SingleOrDefaultAsync(m => m.VoertuigCatId == id);
            if (voertuigCategorie == null)
            {
                return NotFound();
            }
            if (voertuigCategorie.Voertuigen.Count() != 0)
            {
                try
                {
                    TempData["AlertMessage"] = $"De voertuigencategorie <b>{voertuigCategorie.VoertuigCategorieNaam}</b> mag niet verwijderd worden." +
                        $"De categorienaam is reeds verbonden met voertuigen.";
                    //TempData["msgClass"] = "alert alert-success";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }

            return View(voertuigCategorie);
        }

        // POST: Admin/VoertuigCategorieen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var voertuigCategorie = await _context.VoertuigCategorieen.Include(c => c.Voertuigen).SingleOrDefaultAsync(m => m.VoertuigCatId == id);

            if (voertuigCategorie.Voertuigen.Count() == 0)
            {
                try
                {
                    _context.VoertuigCategorieen.Remove(voertuigCategorie);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"De voertuigencategorie <b>{voertuigCategorie.VoertuigCategorieNaam}</b> is succesvol verwijderd.";
                    //TempData["msgClass"] = "alert alert-success";
                }
                catch
                {
                    TempData["AlertMessage"] = $"De voertuigencategorie <b>{voertuigCategorie.VoertuigCategorieNaam}</b> kon niet verwijderd worden.";
                    //TempData["msgClass"] = "alert alert-danger";
                }
            }
            else
            {
                TempData["AlertMessage"] = $"De voertuigencategorie <b>{voertuigCategorie.VoertuigCategorieNaam}</b> kon niet verwijderd worden. Er zijn reeds voertuigen aan verbonden!";
                //TempData["msgClass"] = "alert alert-danger";<b>{categorie.Categorienaam}</b>

            }
        
   

            return RedirectToAction(nameof(Index));
        }

        private bool VoertuigCategorieExists(long id)
        {
            return _context.VoertuigCategorieen.Any(e => e.VoertuigCatId == id);
        }
    }
}
