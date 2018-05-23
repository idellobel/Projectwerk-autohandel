using System;
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
using Microsoft.AspNetCore.SignalR.Client;

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
            var tijd = DateTime.Now;

            if (ModelState.IsValid)
            {
                SmtpClient client = new SmtpClient("uit.telenet.be", 25);
                MailMessage message = new MailMessage(_userManager.GetUserName(User), "ivan.dellobel@gmail.com");
                message.Subject = $"Een vraag van {input.Voornaam} {input.Naam} van {tijd} uur:";

                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.AppendFormat("Naam: {0}{1}", input.Naam, Environment.NewLine);
                sb.AppendFormat("Voornaam: {0}{1}", input.Voornaam, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("Onderwerp: {0}{1}", input.Onderwerp, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("Land: {0}{1}", input.Land, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("Antwoorden op mail: {0}{1}", _userManager.GetUserName(User), Environment.NewLine);


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
    
        public IActionResult Chat()
        {
                #if DEBUG
                            ViewBag.RunState = "Debug";
                #else
                           ViewBag.RunState = "Release";
                #endif

            return View();
        }

        [HttpPost]
        public ActionResult ShowTelemetry([FromBody] Telemetry telemetry)
        {
            try
            {
                #if DEBUG
                var connection = new HubConnectionBuilder()
                                  .WithUrl("https://localhost:44303/chat")
                                  //.WithTransport(Microsoft.AspNetCore.Sockets.TransportType.LongPolling)
                                  //.WithConsoleLogger()
                                  .Build();
                #else
                    var connection = new HubConnectionBuilder()
                                      .WithUrl("http://signalrapplication.azurewebsites.net/chat")
                                      .WithConsoleLogger()
                                      .Build();
                #endif
                connection.StartAsync().Wait();
                var text = telemetry == null || string.IsNullOrEmpty(telemetry.text)
                                          ? "***"
                                          : telemetry.text;
                connection.SendAsync("Send", text).Wait(); // InvokeAsync("Send", text)
                
                connection.DisposeAsync().Wait();
                return Json("Success");
            }
            catch (Exception ex)
            {
                return Json($"Exception {ex.Message}");
            }
        }

        public class Telemetry
        {
            public string deviceName { get; set; }
            public string text { get; set; }
            public DateTime dateTime { get; set; }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
