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
    public class MerkTypesController : Controller
    {
        private readonly AutohandelContext _context;

        public MerkTypesController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/MerkTypes
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.Types.Include(m => m.VoertuigMerk);
            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/MerkTypes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merkType = await _context.Types
                .Include(m => m.VoertuigMerk)
                .SingleOrDefaultAsync(m => m.MerkTypeId == id);
            if (merkType == null)
            {
                return NotFound();
            }

            return View(merkType);
        }

        // GET: Admin/MerkTypes/Create
        public IActionResult Create()
        {
            ViewData["MerkId"] = new SelectList(_context.Merken, "MerkId", "MerkNaam");
            return View();
        }

        // POST: Admin/MerkTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerkTypeId,MerkTypeNaam,MerkId")] MerkType merkType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merkType);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Het model <b>{merkType.MerkTypeNaam}</b> is succesvol toegevoegd.";
                return RedirectToAction(nameof(Index));
            }
            ViewData["MerkId"] = new SelectList(_context.Merken, "MerkId", "MerkNaam", merkType.MerkId);
            return View(merkType);
        }

        // GET: Admin/MerkTypes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merkType = await _context.Types
                .Include(m => m.Voertuigen)
                .SingleOrDefaultAsync(m => m.MerkTypeId == id);
            if (merkType == null)
            {
                return NotFound();
            }
            if (merkType.Voertuigen.Count() != 0)
            {
                try
                {
                    TempData["AlertMessage"] = $"Het model <b>{merkType.MerkTypeNaam}</b> mag niet gewijzigd worden." +
                        $"Het merk en model zijn reeds verbonden met voertuigen.";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }
            ViewData["MerkId"] = new SelectList(_context.Merken, "MerkId", "MerkNaam", merkType.MerkId);
            return View(merkType);
        }

        // POST: Admin/MerkTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MerkTypeId,MerkTypeNaam,MerkId")] MerkType merkType)
        {
            if (id != merkType.MerkTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merkType);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Het model <b>{merkType.MerkTypeNaam}</b> is succesvol gewijzigd.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerkTypeExists(merkType.MerkTypeId))
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
            ViewData["MerkId"] = new SelectList(_context.Merken, "MerkId", "MerkNaam", merkType.MerkId);
            return View(merkType);
        }

        // GET: Admin/MerkTypes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merkType = await _context.Types
                .Include(m => m.Voertuigen)
                .Include(m => m.VoertuigMerk)
                .SingleOrDefaultAsync(m => m.MerkTypeId == id);
            if (merkType == null)
            {
                return NotFound();
            }
            if (merkType.Voertuigen.Count() != 0) 
            {
                try
                {
                    TempData["AlertMessage"] = $"Het model <b>{merkType.MerkTypeNaam}</b> mag niet verwijderd worden." +
                        $"Het model is reeds verbonden met voertuigen en merken.";
                    //TempData["msgClass"] = "alert alert-success";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }

            return View(merkType);
        }

        // POST: Admin/MerkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var merkType = await _context.Types
                .Include(m => m.Voertuigen).Include(m => m.VoertuigMerk)
                .SingleOrDefaultAsync(m => m.MerkTypeId == id);
            if (merkType.Voertuigen.Count() == 0)
            {
                try
                {
                    _context.Types.Remove(merkType);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"Het model <b>{merkType.MerkTypeNaam}</b> is succesvol verwijderd.";
                }
                catch
                {
                    TempData["AlertMessage"] = $"Het model <b>{merkType.MerkTypeNaam}</b> kon niet verwijderd worden.";
                }
            }
            else
            {
                TempData["AlertMessage"] = $"Het model <b>{merkType.MerkTypeNaam}</b> kon niet verwijderd worden. Er zijn reeds voertuigen of modellen aan verbonden !";

            }
            return RedirectToAction(nameof(Index));
        }

        private bool MerkTypeExists(long id)
        {
            return _context.Types.Any(e => e.MerkTypeId == id);
        }
    }
}
