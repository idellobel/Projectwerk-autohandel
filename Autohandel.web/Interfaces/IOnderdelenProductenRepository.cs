using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Interfaces
{
     public interface IOnderdelenProductenRepository
    {
        IEnumerable<OnderdelenProducten> Producten { get;  }
        IEnumerable<OnderdelenProducten> ProductenMetKorting { get; }

        OnderdelenProducten GetProductenbyArtikelNummer(string artikelNummer);
    }
}
