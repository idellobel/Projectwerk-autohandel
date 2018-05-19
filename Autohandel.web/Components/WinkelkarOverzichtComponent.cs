using Autohandel.Domain.Entities;
using Autohandel.web.ViewModels.MandjeViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Components
{
    public class WinkelkarOverzichtComponent : ViewComponent
    {
        private readonly Winkelkar _winkelkar;

        public WinkelkarOverzichtComponent(Winkelkar winkelkar )
        {
            _winkelkar = winkelkar;
        }

        public IViewComponentResult Invoke()
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
    }
}
