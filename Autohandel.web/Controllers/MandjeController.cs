using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.Domain.Extensions;
using Autohandel.web.ViewModels.MandjeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autohandel.web.Controllers
{
    [Authorize]
    [Route("Mandje")]
    public class MandjeController : Controller
    {
        private readonly AutohandelContext _context;
        private List<MandjeItemViewModel> mandje;

        public MandjeController (AutohandelContext context)
        {
            _context = context;
        }
        


        [Route("Index")]
        public IActionResult Index()
        {
             mandje = SessionHelper.GetObjectFromJson<List<MandjeItemViewModel>>(HttpContext.Session, "mandje");
            ViewBag.mandje = mandje;
            ViewBag.total = mandje.Sum(item => item.Product.Prijs * item.Aantal);
            ViewBag.items = mandje.Sum(item => item.Aantal);
            return View();
        }


        [Route("Buy/{id}")]
        public IActionResult Buy(string id)
        {
             mandje = SessionHelper.GetObjectFromJson<List<MandjeItemViewModel>>(HttpContext.Session, "mandje");
            var producten = _context.OnderdelenProducten.ToList();
            if (SessionHelper.GetObjectFromJson<List<MandjeItemViewModel>>(HttpContext.Session, "mandje") == null)
            {
                List<MandjeItemViewModel> mandje = new List<MandjeItemViewModel>();
                mandje.Add(new MandjeItemViewModel { Product = producten.FirstOrDefault(p=>p.Artikelnummer==id), Aantal = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "mandje", mandje);
            }
            else
            {
                List<MandjeItemViewModel> mandje = SessionHelper.GetObjectFromJson<List<MandjeItemViewModel>>(HttpContext.Session, "mandje");
                int index = isExist(id);
                if (index != -1)
                {
                    mandje[index].Aantal++;
                }
                else
                {
                    mandje.Add(new MandjeItemViewModel { Product = producten.FirstOrDefault(p => p.Artikelnummer == id), Aantal = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "mandje", mandje);
            }
            return RedirectToAction("Index");
        }
        [Route("Remove/{id}")]
        public IActionResult Remove(string id)
        {
            List<MandjeItemViewModel> mandje = SessionHelper.GetObjectFromJson<List<MandjeItemViewModel>>(HttpContext.Session, "mandje");
            int index = isExist(id);
            mandje.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "mandje", mandje);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<MandjeItemViewModel> mandje = SessionHelper.GetObjectFromJson<List<MandjeItemViewModel>>(HttpContext.Session, "mandje");
            for (int i = 0; i < mandje.Count(); i++)
            {
                if (mandje[i].Product.Artikelnummer.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}