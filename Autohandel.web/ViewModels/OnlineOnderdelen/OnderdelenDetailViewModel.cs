using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.OnlineOnderdelen
{
    public class OnderdelenDetailViewModel
    {
        public OnderdelenProducten OnderdeelDetail { get; set; }
        public List<String> OnderdelenAfbeeldingen { get; set; }    
        public string FilesName { get; set; }
        public string Url { get; set; }
        public string Informatie { get; set; }
    }
}
