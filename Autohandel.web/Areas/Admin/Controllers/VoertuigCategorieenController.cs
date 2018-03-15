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

            var voertuigCategorie = await _context.VoertuigCategorieen.SingleOrDefaultAsync(m => m.VoertuigCatId == id);
            if (voertuigCategorie == null)
            {
                return NotFound();
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

            var voertuigCategorie = await _context.VoertuigCategorieen
                .SingleOrDefaultAsync(m => m.VoertuigCatId == id);
            if (voertuigCategorie == null)
            {
                return NotFound();
            }

            return View(voertuigCategorie);
        }

        // POST: Admin/VoertuigCategorieen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var voertuigCategorie = await _context.VoertuigCategorieen.SingleOrDefaultAsync(m => m.VoertuigCatId == id);
            _context.VoertuigCategorieen.Remove(voertuigCategorie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoertuigCategorieExists(long id)
        {
            return _context.VoertuigCategorieen.Any(e => e.VoertuigCatId == id);
        }
    }
}
