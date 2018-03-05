using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Models.DatadisplayViewModels
{
    public class DatadisplayViewModel
    {
        public IEnumerable<VoertuigCategorie> voertuigCategorieen { get; set; }
        public IEnumerable<Merk> autoMerken { get; set; }
        public IEnumerable<MerkType> automodellen { get; set; }
        public IEnumerable<Voertuig> aanbodVoertuigen { get; set; }
        public object Categorieen { get; internal set; }
        //public IEnumerable<Klant> Klanten { get; set; }
        //public IEnumerable<Leverancier> Leveranciers { get; set; }
    }
}
