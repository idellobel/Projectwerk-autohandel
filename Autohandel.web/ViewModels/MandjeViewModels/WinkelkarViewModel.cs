using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.MandjeViewModels
{
    public class WinkelkarViewModel
    {
        public Winkelkar Winkelkar { get; set; }

        public decimal WinkelkarTotaal { get; set; }
    }
}
