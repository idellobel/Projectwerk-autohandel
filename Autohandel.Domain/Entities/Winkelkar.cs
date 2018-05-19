using Autohandel.Domain.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class Winkelkar
    {
        private readonly AutohandelContext _context;

        private Winkelkar(AutohandelContext context)
        {
            _context = context;
        }

        public string WinkelkarId { get; set; }

        public List<WinkelkarItem> WinkelkarItems { get; set; }

        public static Winkelkar GetWinkelkar(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AutohandelContext>();
            string karId = session.GetString("KarId") ?? Guid.NewGuid().ToString();

            session.SetString("KarId", karId);

            return new Winkelkar(context) { WinkelkarId = karId };
        }

        public void ToevoegenAanKar(OnderdelenProducten product, int bedrag)
        {
            var winkelkarItem = _context.WinkelkarItems.SingleOrDefault(
                              p => p.Product.Artikelnummer == product.Artikelnummer && p.WinkelkarId == WinkelkarId);

            if (winkelkarItem == null)
            {

                winkelkarItem = new WinkelkarItem
                {
                    WinkelkarId = WinkelkarId,
                    Product = product,
                    Aantal = 1
                };

                _context.WinkelkarItems.Add(winkelkarItem);
              
            }
            else
            {
                winkelkarItem.Aantal++;
            }
            _context.SaveChanges();

        }
        public int VerwijderUitKar(OnderdelenProducten product)
        {
            var winkelkarItem = _context.WinkelkarItems.SingleOrDefault(
                              p => p.Product.Artikelnummer == product.Artikelnummer && p.WinkelkarId == WinkelkarId);

            var localAantal = 0;

            if (winkelkarItem != null)
            {
                if (winkelkarItem.Aantal > 1)
                {
                    winkelkarItem.Aantal--;
                    localAantal = winkelkarItem.Aantal;
                }
                else
                {
                    _context.WinkelkarItems.Remove(winkelkarItem);
                }
            }
            _context.SaveChanges();

            return localAantal;
        }

        public List<WinkelkarItem> GetWinkelkarItems()
        {
            return WinkelkarItems ??
                (WinkelkarItems =
                _context.WinkelkarItems.Where(k => k.WinkelkarId == WinkelkarId)
                .Include(o => o.Product)
                .ToList());
        }

        public void LedigKar()
        {
            var winkelkarItems = _context
                .WinkelkarItems
                .Where(kar => kar.WinkelkarId == WinkelkarId);

            _context.WinkelkarItems.RemoveRange(winkelkarItems);

            _context.SaveChanges();
        }

        public int GetWinkelkarTotaal()
        {

            //var totaal = _context.WinkelkarItems.Where(k => k.WinkelkarId == WinkelkarId)
            //    .Select(k => k.Product.Prijs * k.Aantal).Sum();


           //Rechtstreeks Product.Prijs converteren naar int lukt niet, vandaar 'new'!

            var ItemsMetKorting = _context.WinkelkarItems.Where(k => k.WinkelkarId == WinkelkarId)
                                   .Where(k => k.Product.Korting == true)
                                   .Select(k => new
                                   {
                                       K = (int)k.Product.Prijs,
                                       Kk = (int)(k.Product.Prijs * 0.15M),
                                       A = k.Aantal
                                   })
                                   .AsEnumerable()
                                   .Select(k => (k.K - k.Kk) * k.A).Sum();
                                  



            var Items = _context.WinkelkarItems.Where(k => k.WinkelkarId == WinkelkarId)
                                   .Where(k => k.Product.Korting == false)
                                    .Select(k => new
                                    {
                                        K = (int)k.Product.Prijs,
                                        A = k.Aantal
                                    })
                                   .AsEnumerable()
                                   .Select(k => (k.K ) * k.A).Sum();
           

           int totaal =( Items + ItemsMetKorting);

          
            return totaal;
        }
    }
}
