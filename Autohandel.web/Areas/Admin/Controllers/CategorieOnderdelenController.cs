using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.ViewModels.CategorieOnderdelenViewModels;

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
        [Route("Admin/CategorieOnderdelen/Index")]
        public async Task<IActionResult> Index()
        {
            var autohandelContext = _context.CategorieOnderdelen
                                    .Include(c => c.Parent)
                                    .Include(p => p.Products)
                                    .OrderBy(c => c.Parent.OnderdelenCategorienaam)
                                    .ThenBy(ch => ch.OnderdelenCategorienaam)
                ;
            return View(await autohandelContext.ToListAsync());
        }

        // GET: Admin/CategorieOnderdelen/Details/5
        [Route("Admin/CategorieOnderdelen/Details/{id}")]
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

        private List<SelectListItem> hoofdcategorieOnderdelenlijst()
        {
            var list =
            //return
                    _context.CategorieOnderdelen
                     .Include(c => c.Parent)
                     .Where(hc => hc.ParentId == null)
                .Select(hc => new SelectListItem
                { //transformeer elke hoofdcategorie naar een SelectListItem
                    Value = hc.OnderdelenCategorieId.ToString(),
                    Text = hc.OnderdelenCategorienaam

                })
                .ToList();
            list.Add(new SelectListItem { Value = null, Text = "", Selected = true });
            return list;
        }


        // GET: Admin/CategorieOnderdelen/Create
        [Route("Admin/CategorieOnderdelen/Create")]
        public IActionResult Create()
        {
            //ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen, "OnderdelenCategorieId", "OnderdelenCategorienaam");
            
            var vm = new CategorieOnderdelenCreateViewModel()
            {

                CategorieOnderdeel = null,
                HoofdcategorieOnderdelenlijst = hoofdcategorieOnderdelenlijst()
            };


            return View(vm);

        }

        [Route("Admin/CategorieOnderdelen/Create")]
        // POST: Admin/CategorieOnderdelen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OnderdelenCategorieId,OnderdelenCategorienaam,ParentId, CategorieOnderdeel, HoofdcategorieOnderdelenlijst ")] CategorieOnderdelenCreateViewModel inputCatOndCreateVm)
        {
                      
            if (CategorieNaamOnderdelenExists(inputCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorienaam))
            {
                ModelState.AddModelError("NaamValidatieError", "Deze categorie is reeds aangemaakt!");
            }

            if (ModelState.IsValid)
            {
                //    _context.Add(categorieOnderdelen);
                //    await _context.SaveChangesAsync();
                //    return RedirectToAction(nameof(Index));
                //}
                //ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen, "OnderdelenCategorieId", "OnderdelenCategorienaam", categorieOnderdelen.ParentId);
                //return View(categorieOnderdelen);



                if (inputCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorienaam != null) //zo ja,
                {
                    //nieuwe categorie maken
                    var categorieOnderdeelToAdd = new CategorieOnderdelen
                    {
                        OnderdelenCategorienaam = inputCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorienaam,
                        ParentId = inputCatOndCreateVm.CategorieOnderdeel.ParentId,

                    };

                    //categorie tovoegen aan de dbSet (tabel)
                    _context.CategorieOnderdelen.Add(categorieOnderdeelToAdd);

                    //context wijzigingen doorvoeren naar de Database
                    await _context.SaveChangesAsync();
                    //actie voor response ondernemen
                    TempData["SuccessMessage"] = $"De categorie <b>{categorieOnderdeelToAdd.OnderdelenCategorienaam}</b> werd toegevoegd!";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                //de existing categorie bestaat niet
                ModelState.AddModelError("CategorieOnderdeel.ParentId",
                    $"Input is niet correct!");


            }
            //model not valid

            //input model wordt nu het view model, dus moet nog vervolledigd worden
            inputCatOndCreateVm = new CategorieOnderdelenCreateViewModel()
            {
                CategorieOnderdeel = null,
                HoofdcategorieOnderdelenlijst = hoofdcategorieOnderdelenlijst()
            };

            return View(inputCatOndCreateVm);
        }

        // GET: Admin/CategorieOnderdelen/Edit/5
        [Route("Admin/CategorieOnderdelen/Edit/{id}")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           

            var categorieOnderdelen = await _context.CategorieOnderdelen
                                            .Include(c => c.Children)
                                            .Include(p => p.Products)
                                            .SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
            
            if (categorieOnderdelen == null)
            {
                return NotFound();
            }
            if ((categorieOnderdelen.Products.Count() != 0) || (categorieOnderdelen.Children.Count() != 0))
            {
                try
                {
                    TempData["AlertMessage"] = $"De categorie <b>{categorieOnderdelen.OnderdelenCategorienaam}</b> mag niet gewijzigd worden." +
                        $"De categorienaam is reeds gekoppeld aan een (sub)categorie of is een categorie waaronder reeds producten zijn opgeslagen!";

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["AlertMessage"] = $"Systeemfout in categorieënbeheer!";

                    return RedirectToAction(nameof(Index));
                }
            }
            CategorieOnderdelenCreateViewModel vm;
            if (categorieOnderdelen.ParentId == null)
            {
                 vm = new CategorieOnderdelenCreateViewModel()

                {
                    CategorieOnderdeel = categorieOnderdelen,
                    HoofdcategorieOnderdelenlijst = null
                };
            }
            else
            {
                 vm = new CategorieOnderdelenCreateViewModel()

                {
                    CategorieOnderdeel = categorieOnderdelen,
                    HoofdcategorieOnderdelenlijst = hoofdcategorieOnderdelenlijst()
                };
            }

            
            //ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen.Where(hc => hc.ParentId == null), "OnderdelenCategorieId", "OnderdelenCategorienaam", categorieOnderdelen.ParentId);
            return View(vm);
        }

        [Route("Admin/CategorieOnderdelen/Edit/{id}")]
        // POST: Admin/CategorieOnderdelen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OnderdelenCategorieId,OnderdelenCategorienaam,ParentId,CategorieOnderdeel, HoofdcategorieOnderdelenlijst")] CategorieOnderdelenCreateViewModel editCatOndCreateVm)
        {
            if (CategorieNaamOnderdelenMoreExists(id, editCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorienaam))
            {
                ModelState.AddModelError("NaamValidatieError", "Dit is de naam van een bestaande categorie!");
            }

            if (id != editCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (editCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorienaam != null) //zo ja,
                    {
                        //bestaande categorie wijzigen
                        var categorieOnderdeelToUpdate = await _context.CategorieOnderdelen.SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
                        if (categorieOnderdeelToUpdate == null)
                        {
                            return NotFound();
                        }
                        categorieOnderdeelToUpdate.OnderdelenCategorienaam = editCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorienaam;
                        categorieOnderdeelToUpdate.ParentId = editCatOndCreateVm.CategorieOnderdeel.ParentId;
                      
                        //categorie updaten
                        _context.CategorieOnderdelen.Update(categorieOnderdeelToUpdate);

                        //context wijzigingen doorvoeren naar de Database
                        await _context.SaveChangesAsync();
                        //actie voor response ondernemen
                        TempData["SuccessMessage"] = $"De categorie <b>{categorieOnderdeelToUpdate.OnderdelenCategorienaam}</b> werd gewijzigd!";
                        return RedirectToAction(nameof(Index));
                    }
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieOnderdelenExists(editCatOndCreateVm.CategorieOnderdeel.OnderdelenCategorieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("CategorieOnderdeel.ParentId",
                        $"Input is niet correct!");
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ParentId"] = new SelectList(_context.CategorieOnderdelen, "OnderdelenCategorieId", "OnderdelenCategorienaam", categorieOnderdelen.ParentId);
            return View(editCatOndCreateVm);
        }

        // GET: Admin/CategorieOnderdelen/Delete/5
        [Route("Admin/CategorieOnderdelen/Delete/{id}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorieOnderdelen = await _context.CategorieOnderdelen
                .Include(c => c.Children)
                .Include(p => p.Products)
                .SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
            if (categorieOnderdelen == null)
            {
                return NotFound();
            }

            if ((categorieOnderdelen.Children.Count() != 0)||(categorieOnderdelen.Products.Count() != 0))
            {
                try
                {
                    TempData["AlertMessage"] = $"De categorie <b>{categorieOnderdelen.OnderdelenCategorienaam}</b> mag niet verwijderd worden." +
                        $"De categorienaam is reeds verbonden met subcategorie of producten.";
                    
                    return RedirectToAction(nameof(Index));
                }
                catch { }
            }

            return View(categorieOnderdelen);
        }

        // POST: Admin/CategorieOnderdelen/Delete/5
        [Route("Admin/CategorieOnderdelen/Delete/{id}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorieOnderdelen = await _context.CategorieOnderdelen
                                            .Include(c=>c.Children)  
                                            .Include(p=>p.Products)
                                            .SingleOrDefaultAsync(m => m.OnderdelenCategorieId == id);
           
            if (categorieOnderdelen.Products.Count() == 0)
            {
                try
                {
                    _context.CategorieOnderdelen.Remove(categorieOnderdelen);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = $"De categorie <b>{categorieOnderdelen.OnderdelenCategorienaam}</b> werd verwijderd!";
                   
                }
                catch
                {
                    TempData["AlertMessage"] = $"De categorie <b>{categorieOnderdelen.OnderdelenCategorienaam}</b> kon niet verwijderd worden.";
                   
                }
            }
            else
            {
                TempData["AlertMessage"] = $"De categorie <b>{categorieOnderdelen.OnderdelenCategorienaam}</b> kon niet verwijderd worden. Er zijn reeds producten aan verbonden!";
              

            }
            return RedirectToAction(nameof(Index));

        }

        private bool CategorieOnderdelenExists(int id)
        {
            return _context.CategorieOnderdelen.Any(e => e.OnderdelenCategorieId == id);
        }

        private bool CategorieNaamOnderdelenExists(string checkNaam)
        {
            return _context.CategorieOnderdelen.Any(c => c.OnderdelenCategorienaam == checkNaam); ;
        }

        private bool CategorieNaamOnderdelenMoreExists(int id,string checkNaam)
        {
            return _context.CategorieOnderdelen
                              .Any(c => c.OnderdelenCategorienaam == checkNaam && c.OnderdelenCategorieId != id); ;
        }

    }
}
