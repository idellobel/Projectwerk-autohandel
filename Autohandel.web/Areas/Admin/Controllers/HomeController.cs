using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Autohandel.web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Voertuigen()
        {
            return View();
        }

        public IActionResult VoertuigOnderdelen()
        {
            return View();
        }
    }
}