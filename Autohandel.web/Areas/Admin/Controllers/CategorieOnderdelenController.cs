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
    public class CategorieOnderdelenController : Controller
    {
        private readonly AutohandelContext _context;

        public CategorieOnderdelenController(AutohandelContext context)
        {
            _context = context;
        }

        // GET: Admin/CategorieOnderdelen
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.CategorieOnderdelen.Include(c => c.Parent);
            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/CategorieOnderdelen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieOnderdelen = await _context.CategorieOnderdelen
                .Include(c => c.Parent)
                .SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
            if (categorieOnderdelen == null)
            {
                return NotFound();
            }

            return View(categorieOnderdelen);
        }

        // GET: Admin/CategorieOnderdelen/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen, "OnderdelenCategorieId", "OnderdelenCategorienaam");
            return View();
        }

        // POST: Admin/CategorieOnderdelen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnderdelenCategorieId,OnderdelenCategorienaam,ParentId")] CategorieOnderdelen categorieOnderdelen)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorieOnderdelen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen, "OnderdelenCategorieId", "OnderdelenCategorienaam", categorieOnderdelen.ParentId);
            return View(categorieOnderdelen);
        }

        // GET: Admin/CategorieOnderdelen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieOnderdelen = await _context.CategorieOnderdelen.SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
            if (categorieOnderdelen == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen.Where(hc => hc.ParentId == null), "OnderdelenCategorieId", "OnderdelenCategorienaam", categorieOnderdelen.ParentId);
            return View(categorieOnderdelen);
        }

        // POST: Admin/CategorieOnderdelen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnderdelenCategorieId,OnderdelenCategorienaam,ParentId")] CategorieOnderdelen categorieOnderdelen)
        {
            if (id != categorieOnderdelen.OnderdelenCategorieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorieOnderdelen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieOnderdelenExists(categorieOnderdelen.OnderdelenCategorieId))
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
            ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen, "OnderdelenCategorieId", "OnderdelenCategorienaam", categorieOnderdelen.ParentId);
            return View(categorieOnderdelen);
        }

        // GET: Admin/CategorieOnderdelen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieOnderdelen = await _context.CategorieOnderdelen
                .Include(c => c.Parent)
                .SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
            if (categorieOnderdelen == null)
            {
                return NotFound();
            }

            return View(categorieOnderdelen);
        }

        // POST: Admin/CategorieOnderdelen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorieOnderdelen = await _context.CategorieOnderdelen.SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
            _context.CategorieOnderdelen.Remove(categorieOnderdelen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategorieOnderdelenExists(int id)
        {
            return _context.CategorieOnderdelen.Any(e => e.OnderdelenCategorieId == id);
        }
    }
}
