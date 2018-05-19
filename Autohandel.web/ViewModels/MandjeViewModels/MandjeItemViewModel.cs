using Autohandel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.ViewModels.MandjeViewModels
{
    /// <summary>
    /// Gespecialiseerd viewmodel voor gebruik in MandjeIndexViewModel
    /// </summary>
    public class MandjeItemViewModel
    {
        public OnderdelenProducten Product { get; set; }

        public string Artikelnummer { get; set; }
        public string Artikelnaam { get; set; }
        public decimal PrijsPerStuk { get; set; }
        public string Afbeelding { get; set; }
        public bool Korting { get; set; }

        //public decimal KortingOpPrijs
        //{
        //    get
        //    {
        //        return PrijsPerStuk * 0.15M;
        //    }
        //}
        //public decimal PrijsTotaal
        //{
        //    get
        //    {
        //        if (Korting) return PrijsTotaalKorting;
        //        else
        //            return Aantal * PrijsPerStuk;
        //    }
        //}
        //public decimal PrijsTotaalKorting
        //{
        //    get
        //    {
        //        return Aantal * (PrijsPerStuk - KortingOpPrijs);
        //    }
        //}

        public int Aantal { get; set; }
    }
}

        
  
