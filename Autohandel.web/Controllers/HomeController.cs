﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Autohandel.web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Autohandel.web.ViewModels.ContactViewModels;
using System.Net.Mail;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Autohandel.Domain.Entities;
using Autohandel.web.Services;
using Microsoft.Extensions.Logging;
using Autohandel.Domain.Data;
using System.Net.Http;
using Newtonsoft.Json;
using Autohandel.Domain.DTO_klassen;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Autohandel.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ILogger _logger;
        private readonly AutohandelContext _context;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ILogger<AccountController> logger,
            AutohandelContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            var onderdelenhoofdcat = _context.CategorieOnderdelen
                                   .Include(c => c.Parent)
                                   .Where(c => c.ParentId == null)
                                   .OrderBy(c => c.OnderdelenCategorienaam)
                                   .ToList();             
           

            ViewData["Message"] = "Your application description page.";

            return View(onderdelenhoofdcat);
        }

        [Authorize]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactInformatieViewModel input)   
        {
            var info = input.Onderwerp;


            if (ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient("uit.telenet.be", 25);
                MailMessage message = new MailMessage(_userManager.GetUserName(User), "ivan.dellobel@gmail.com");
                message.Subject = $"Een vraag van {input.Voornaam} {input.Naam} :";

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("Naam: {0}{1}", input.Naam, Environment.NewLine);
                sb.AppendFormat("Voornaam: {0}{1}", input.Voornaam, Environment.NewLine);
                sb.AppendFormat("Onderwerp: {0}{1}", input.Onderwerp, Environment.NewLine);
                sb.AppendFormat("Land: {0}{1}", input.Land, Environment.NewLine);


                message.Body = sb.ToString();
                client.Send(message);

                TempData["SuccessMessage"] = "Uw bericht wordt zo vlug mogelijk behandeld!";
                return RedirectToAction("Index", new { Controller = "Home" });
            }
            return View(input);

        }

        public IActionResult Team()
        {
            ViewData["Message"] = "Your team page.";

            return View();
        }

       public IActionResult VoertuigenInAaanbod()
        {
            return View();
        }

        public IActionResult VoorraadWagens()
        {
            string uri = "https://" + Request.Host.Host + ':' + Request.Host.Port + "/api/VoertuigAanbod";

            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);


                return View(

                    Task.Factory.StartNew
                    (
                        () => JsonConvert.DeserializeObject<List<VoertuigDTO>>(response.Result)
                    )
                    .Result
                    );
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
