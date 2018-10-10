using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Autohandel.web.Controllers
{
    [Route("Order")]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly Winkelkar _winkelkar;

        public OrderController(IOrderRepository orderRepository, Winkelkar winkelkar)
        {
            _orderRepository = orderRepository;
            _winkelkar = winkelkar;
        }
        [Route("Afrekenen")]
        public IActionResult Afrekenen()
        {
            return View();
        }

        [HttpPost]
        [Route("Afrekenen")]
        public IActionResult Afrekenen(Order order)
        {
            var items = _winkelkar.GetWinkelkarItems();
            _winkelkar.WinkelkarItems = items;

            if(_winkelkar.WinkelkarItems.Count == 0)
            {
                ModelState.AddModelError("", "Uw winkelkar bevat geen items!");
                
            }

            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);

                //Uitcommentariëren voor de presentatie: Blijkbaar staat HOWEST uitgaand verkeer op poort 25 niet toe.

                SmtpClient client = new SmtpClient("uit.telenet.be", 25);
                MailMessage message = new MailMessage("ivan.dellobel@gmail.com", order.Email);
                message.Subject = $"Bevestging van ordernummer: {order.OrderId} van {order.OrderGeplaatst} uur :";

                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("ORDERBEVESTIGING:");
                sb.AppendLine();
                sb.AppendFormat("Verzendgegevens:");
                sb.AppendLine();
                sb.AppendFormat("Naam: {0}{1}", order.Naam, Environment.NewLine);
                sb.AppendFormat("Voornaam: {0}{1}", order.Voornaam, Environment.NewLine);
                sb.AppendFormat("Adres: {0}{1}", order.Adres, Environment.NewLine);
                sb.AppendFormat("Postcode: {0}{1}", order.Postcode, Environment.NewLine);
                sb.AppendFormat("Gemeente: {0}{1}", order.Gemeente, Environment.NewLine);
                sb.AppendFormat("Land: {0}{1}", order.Land, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("Bestelling:");
                sb.AppendLine();
                foreach (var item in order.OrderDetails)
                {
                    sb.AppendFormat("Product: {0}{1}", item.Product.Artikelnaam, Environment.NewLine);
                    sb.AppendFormat("Aantal: {0}{1}", item.Aantal, Environment.NewLine);
                    sb.AppendFormat("Prijs: €{0}{1} ", item.Product.Korting ? (int)item.Product.Prijs - (int)(item.Product.Prijs * 0.15M) : (int)item.Product.Prijs, Environment.NewLine);
                    sb.AppendLine();

                }
                sb.AppendFormat("Totaal prijs:  €{0}{1}", order.OrderTotaal, Environment.NewLine);
                sb.AppendLine();
                sb.AppendFormat("vriendelijke groeten");
                sb.AppendLine();
                sb.AppendLine("Auto Vandenheede");

                message.Body = sb.ToString();
                client.Send(message);

                //Tot hier!

                _winkelkar.LedigKar();
                TempData["SuccessMessage"] = $"Uw bestelling is met succes afgerond! Een bevestigingsmail wordt dadelijk verstuurd.";
                return RedirectToAction("Index", new { Controller = "Home" });
            }
            return View(order);
        }
        //[Route("AfrekenenOK")]
        //public IActionResult AfrekenenOK()
        //{

        //    TempData["SuccessMessage"] = $"Uw bestelling is met succes afgerond! Een bevestigingsmail wordt dadelijk verstuurd.";

        //    return View();
        //}
    }
}