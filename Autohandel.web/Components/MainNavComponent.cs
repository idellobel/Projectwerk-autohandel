using Autohandel.web.ViewModels.Components;
using Autohandel.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Autohandel.web.ViewModels;

namespace Autohandel.web.Components
{
  

    [ViewComponent(Name = "MainNavigation")]
    public class MainNavComponent : ViewComponent
    {
        SignInManager<ApplicationUser> SignInManager;
        UserManager<ApplicationUser> UserManager;
        private IEnumerable<MainNavLinkVm> PublicLinks { get; set; }
        private IEnumerable<MainNavLinkVm> AdminLinks { get; set; }

        public MainNavComponent()
        {
            PublicLinks = new List<MainNavLinkVm>
            {
                new MainNavLinkVm{ Controller="Home", Action="Index", Text="Welkom"},
                new MainNavLinkVm{ Controller="Home", Action="About", Text="Diensten"},
                new MainNavLinkVm{ Controller="Home", Action="", Text="Ons aanbod wagens"},
                new MainNavLinkVm{ Controller="Home", Action="", Text="Onderdelen"},
                new MainNavLinkVm{ Controller="Home", Action="Team", Text="Ons team"},
                new MainNavLinkVm{ Controller="Home", Action="Contact", Text="Contact"},
                //new MainNavLinkVm{Area= "Admin", Controller="Home", Action= "Index", Text=$"ADMIN-AREA" },
              
              

            };
            AdminLinks = new List<MainNavLinkVm>
            {
                new MainNavLinkVm{ Controller="Home", Action="Index", Text="Home"},
                new MainNavLinkVm{ Controller="DataDisplay", Action="Index", Text="DataBaseData"},
                new MainNavLinkVm{ Area="Admin" , Controller="Home", Action="Index", Text="Dashboard"},
                new MainNavLinkVm{ Area="Admin" , Controller="Home", Action="Voertuigen", Text="Voertuigen"},
                new MainNavLinkVm{ Area="Admin" , Controller="Home", Action="VoertuigOnderdelen", Text="Onderdelen"},
                new MainNavLinkVm{ Area="Admin" , Controller="Home", Action="Personen", Text="Personen"},
                new MainNavLinkVm{ Area="Admin" , Controller="Home", Action="Adminstratie", Text="Administratie"},

                //new MainNavLinkVm{ Area="Admin" , Controller="DataDisplay", Action="Index", Text="DataBaseData"},

            };



        }

        public Task<IViewComponentResult> InvokeAsync(bool showAdmin)
        {
            var navLinks = PublicLinks;
            if (showAdmin) navLinks = AdminLinks;
            foreach (var navlink in navLinks)
            {
                if (this.RouteData.Values["area"]?.ToString().ToLower() == navlink.Area?.ToLower()
                    &&
                    this.RouteData.Values["controller"]?.ToString().ToLower() == navlink.Controller.ToLower()
                    &&
                    this.RouteData.Values["action"]?.ToString().ToLower() == navlink.Action.ToLower())
                {
                    navlink.IsActive = true;
                }
            }
            //return View(navLinks);
            return Task.FromResult<IViewComponentResult>(View(navLinks)); //avoids warning about lacking await operator
        }
    }
}
