using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.DatadisplayViewModels
{
    public class DatadisplayViewModel
    {
        public IEnumerable<VoertuigCategorie> voertuigCategorieen { get; set; }
        public IEnumerable<Merk> autoMerken { get; set; }
        public IEnumerable<MerkType> automodellen { get; set; }
        public IEnumerable<Voertuig> aanbodVoertuigen { get; set; }
        public IEnumerable<CategorieOnderdelen>categorieOnderdelen { get; set; }
        public IEnumerable<OnderdelenProducten> onderdelenProducten { get; set; }
        public IEnumerable<Leverancier> leveranciers { get; set; }
        public IEnumerable<Klant> klanten { get; set; }
        public IEnumerable<Onderhoud> onderhoudslijst { get; set; }
        public IEnumerable<Faktuur> fakturenlijst { get; set; }
        public IEnumerable<Garantie> garantielijst { get; set; }


    }
}
