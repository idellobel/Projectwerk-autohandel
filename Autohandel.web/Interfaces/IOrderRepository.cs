using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Interfaces
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}
