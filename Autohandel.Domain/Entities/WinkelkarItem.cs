using System;
using System.Collections.Generic;
using System.Text;

namespace Autohandel.Domain.Entities
{
    public class WinkelkarItem
    {
        public int WinkelkarItemId { get; set; }

        public virtual OnderdelenProducten Product { get; set; }
            
        public int Aantal { get; set; }

        public string WinkelkarId { get; set; }
    }
}
