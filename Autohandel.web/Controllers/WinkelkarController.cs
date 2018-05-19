using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autohandel.Domain.Entities;
using Autohandel.web.Interfaces;
using Autohandel.web.ViewModels.MandjeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Autohandel.web.Controllers
{
    [Authorize]
    [Route("Winkelkar")]
    public class WinkelkarController : Controller
    {
        private readonly IOnderdelenProductenRepository _onderdelenProductenRepository;
        private readonly Winkelkar _winkelkar;

        public WinkelkarController(IOnderdelenProductenRepository onderdelenProductenRepository, Winkelkar winkelkar )
        {
            _onderdelenProductenRepository = onderdelenProductenRepository;
            _winkelkar = winkelkar;
        }
        [Route("Index")]
        public ViewResult Index()
        {
            var items = _winkelkar.GetWinkelkarItems();
            _winkelkar.WinkelkarItems = items;

            var wKVM = new WinkelkarViewModel
            {
                Winkelkar = _winkelkar,
                WinkelkarTotaal = _winkelkar.GetWinkelkarTotaal()
            };
            return View(wKVM);

        }
        [Route("ToevoegenAanWinkelkar/{id}")]
        public RedirectToActionResult ToevoegenAanWinkelkar(string id)
        {
            var selectedProduct = _onderdelenProductenRepository.Producten.FirstOrDefault(p => p.Artikelnummer == id);

            if(selectedProduct != null)
            {
                _winkelkar.ToevoegenAanKar(selectedProduct, 1);
            }
            return RedirectToAction("Index");
        }
        [Route("VerwijderUitKar/{id}")]
        public RedirectToActionResult VerwijderUitKar(string id)
        {
            var selectedProduct = _onderdelenProductenRepository.Producten.FirstOrDefault(p => p.Artikelnummer == id);

            if (selectedProduct != null)
            {
                _winkelkar.VerwijderUitKar(selectedProduct);
            }
            return RedirectToAction("Index");   
        }
    }
}