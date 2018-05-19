using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AutohandelContext _context;
        private readonly Winkelkar _winkelkar;

        public OrderRepository(AutohandelContext context, Winkelkar winkelkar)
        {
            _context = context;
            _winkelkar = winkelkar;
        }

        public void CreateOrder(Order order)
        {
            order.OrderGeplaatst = DateTime.Now;
            order.OrderTotaal = _winkelkar.GetWinkelkarTotaal();
            _context.Orders.Add(order);

            var winkelkarItems = _winkelkar.WinkelkarItems;

            foreach (var item in winkelkarItems)
            {
                var OrderDetail = new OrderDetail()
                {
                    Aantal = item.Aantal,
                    ArtikelNummer = item.Product.Artikelnummer,
                    OrderId = order.OrderId,
                    Prijs = item.Product.Korting ?(int)item.Product.Prijs - (int)(item.Product.Prijs * 0.15M) : (int)item.Product.Prijs
            };
                _context.OrderDetails.Add(OrderDetail);
            }
            _context.SaveChanges();


        }

        
    }
}
