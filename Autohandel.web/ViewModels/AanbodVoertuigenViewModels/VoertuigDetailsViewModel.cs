using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.AanbodVoertuigenViewModels
{
    public class VoertuigDetailsViewModel
    {
        public Voertuig VoertuigDetail { get; set; }
        public List<String> VoertuigAfbeeldingen { get; set; }
        public string FilesName { get; set; }
        public string Url { get; set; }
        public string Informatie { get; set; }
    }
}
