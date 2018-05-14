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
    public class MerkenController : Controller
    {
        private readonly AutohandelContext _context;

        public MerkenController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/Merken
        [Route("Admin/Merken/Index")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merken.ToListAsync());
        }

        // GET: Admin/Merken/Details/5
        [Route("Admin/Merken/Details/{id}")]
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken
                .SingleOrDefaultAsync(m => m.MerkId == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // GET: Admin/Merken/Create
        [Route("Admin/Merken/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Admin/Merken/Create")]
        // POST: Admin/Merken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerkId,MerkNaam")] Merk merk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merk);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Het merk <b>{merk.MerkNaam}</b> is succesvol toegevoegd.";
                return RedirectToAction(nameof(Index));
            }
            return View(merk);
        }

        // GET: Admin/Merken/Edit/5
        [Route("Admin/Merken/Edit/{id}")]
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken.Include(m=>m.Voertuigen).Include(m => m.MerkTypes).SingleOrDefaultAsync(m => m.MerkId == id);
            if (merk == null)
            {
                return NotFound();
            }
            if (merk.Voertuigen.Count() != 0)
            {
                try
                {
                    TempData["AlertMessage"] = $"Het merk <b>{merk.MerkNaam}</b> mag niet gewijzigd worden." +
                        $"Het merk is reeds verbonden met voertuigen.";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }
            if (merk.MerkTypes.Count() != 0)
            {
                try
                {
                    TempData["AlertMessage"] = $"Het merk <b>{merk.MerkNaam}</b> mag niet gewijzigd worden." +
                        $"Het merk is reeds verbonden met een model.";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }

            return View(merk);
        }

        [Route("Admin/Merken/Edit/{id}")]
        // POST: Admin/Merken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("MerkId,MerkNaam")] Merk merk)
        {
            if (id != merk.MerkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merk);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = $"Het merk <b>{merk.MerkNaam}</b> is succesvol gewijzigd.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerkExists(merk.MerkId))
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
            return View(merk);
        }

        // GET: Admin/Merken/Delete/5
        [Route("Admin/Merken/Delete/{id}")]
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken
                .Include(m => m.Voertuigen).Include(m => m.MerkTypes)
                .SingleOrDefaultAsync(m => m.MerkId == id);
            if (merk == null)
            {
                return NotFound();
            }
            if ((merk.Voertuigen.Count() != 0)||(merk.MerkTypes.Count() !=0))
            {
                try
                {
                    TempData["AlertMessage"] = $"Het merk <b>{merk.MerkNaam}</b> mag niet verwijderd worden." +
                        $"Het merk is reeds verbonden met voertuigen of modellen.";
                    //TempData["msgClass"] = "alert alert-success";
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }

            return View(merk);
        }

        // POST: Admin/Merken/Delete/5
        [Route("Admin/Merken/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var merk = await _context.Merken
                .Include(m => m.Voertuigen).Include(m => m.MerkTypes)
                .SingleOrDefaultAsync(m => m.MerkId == id);
            if (merk.Voertuigen.Count() == 0)
            {
                try
                {
                    _context.Merken.Remove(merk);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"Het merk <b>{merk.MerkNaam}</b> is succesvol verwijderd.";
                }
                catch
                {
                    TempData["AlertMessage"] = $"Het merk <b>{merk.MerkNaam}</b> kon niet verwijderd worden.";
                }
            }
            else
            {
                TempData["AlertMessage"] = $"Het merk <b>{merk.MerkNaam}</b> kon niet verwijderd worden. Er zijn reeds voertuigen of modellen aan verbonden !";
     
            }


            return RedirectToAction(nameof(Index));
        }

        private bool MerkExists(long id)
        {
            return _context.Merken.Any(e => e.MerkId == id);
        }
    }
}
