using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autohandel.Domain.Data;
using Autohandel.Domain.DTO_klassen;
using Autohandel.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Autohandel.web.Controllers
{
    [Produces("application/json")]

    //Deze controller is aangewend voor het functioneren van de publieke site 'aanbod voertuigen'.
    
    public class VoertuigAanbodController : Controller
    {
        private readonly AutohandelContext _context;

        public VoertuigAanbodController(AutohandelContext context)   
        {
            _context = context;
        }

        [Route("api/VoertuigAanbod")]
        public IEnumerable<VoertuigDTO> GetAllVoertuigen()
        {

            var voertuigen = from v in _context.Voertuigen
                             select new VoertuigDTO()
                             {
                                 VoertuigId = v.VoertuigId,
                                 MerkNaam = v.Merk.MerkNaam,
                                 VoertuigTitel = v.VoertuigTitel,
                                 Prijs = v.Prijs.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("nl-BE")),
                                 FiguurURL = v.FiguurURL/*.Remove(0, 2)*/,
                                 MerkTypeNaam = v.MerkType.MerkTypeNaam,
                                 KlantNaam = v.Klant.KlantNaam,
                                 FaktuurNr = v.Faktuur.FaktuurNr,
                                 VoertuigArtikelNummer = v.VoertuigArtikelNummer,
                                 VoertuigCatId = v.VoertuigCatId
                             };
            return voertuigen.Where(v => v.FaktuurNr == null)
                .OrderBy(v => v.VoertuigCatId)
                .ThenBy(v => v.MerkNaam)
                .ThenBy(v => v.MerkTypeNaam)
                .ThenBy(v => v.Prijs);

        }
        [Route("api/VoertuigAanbod/{merknaam}")]
        public IEnumerable<VoertuigDTO> GetAllVoertuigenOpMerk(string merknaam)
        {
            var voertuigen = from v in _context.Voertuigen
                             select new VoertuigDTO()
                             {
                                 VoertuigId = v.VoertuigId,
                                 MerkNaam = v.Merk.MerkNaam,
                                 VoertuigTitel = v.VoertuigTitel,
                                 Prijs = v.Prijs.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("nl-BE")),
                                 FiguurURL = v.FiguurURL,
                                 MerkTypeNaam = v.MerkType.MerkTypeNaam,
                                 KlantNaam = v.Klant.KlantNaam,
                                 FaktuurNr = v.Faktuur.FaktuurNr,
                                 VoertuigArtikelNummer = v.VoertuigArtikelNummer,
                                 VoertuigCatId = v.VoertuigCatId
                             };

            var voertuigenOpMerk = voertuigen.Where(v => v.FaktuurNr == null);
            if (voertuigenOpMerk.Where(v => v.MerkNaam.ToUpper() == merknaam.ToUpper()) == null)
            {
                TempData["AlertMessage"] = $"Geen resultaat. Probeer opnieuw!";

                return NotFound() as IQueryable<VoertuigDTO>;
                
            }


            return voertuigenOpMerk.Where(v => v.MerkNaam.ToUpper() == merknaam.ToUpper())
                  .OrderBy(v => v.VoertuigCatId)
                  .ThenBy(v => v.MerkNaam)
                  .ThenBy(v => v.MerkTypeNaam)
                  .ThenBy(v => v.Prijs);
        }



        [Route("api/VoertuigAanbod/{lenprijs}/{richtprijs}")]
        public IEnumerable<VoertuigDTO> GetVoertuigenOpPrijs(int lenprijs, string richtprijs) 
        {
            int test = lenprijs;
           string test2 = richtprijs;
            var voertuigen = from v in _context.Voertuigen
                             select new VoertuigDTO()
                             {
                                 VoertuigId = v.VoertuigId,
                                 MerkNaam = v.Merk.MerkNaam,
                                 VoertuigTitel = v.VoertuigTitel,
                                 Prijs = v.Prijs.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("nl-BE")),
                                 FiguurURL = v.FiguurURL,
                                 MerkTypeNaam = v.MerkType.MerkTypeNaam,
                                 KlantNaam = v.Klant.KlantNaam,
                                 FaktuurNr = v.Faktuur.FaktuurNr,
                                 VoertuigArtikelNummer = v.VoertuigArtikelNummer,
                                 VoertuigCatId = v.VoertuigCatId
                             };
            if (lenprijs == 7)
            {
                return voertuigen.Where(v => v.FaktuurNr == null)
                                              .Where(v => v.Prijs.Length == lenprijs)
                                              //.Where(v => v.Prijs.Substring(0, 1) == maxprijs.Substring(0, 1))
                                              .OrderBy(v => v.VoertuigCatId)
                                              .ThenBy(v => v.MerkNaam)
                                              .ThenBy(v => v.MerkTypeNaam)
                                              .ThenBy(v => v.Prijs);
            }
            if(lenprijs == 8)
            {
                return voertuigen.Where(v => v.FaktuurNr == null)
                                             .Where(v => v.Prijs.Length == lenprijs)
                                             .Where(v => v.Prijs.Substring(0, 1) == richtprijs.Substring(0, 1))
                                             .OrderBy(v => v.VoertuigCatId)
                                             .ThenBy(v => v.MerkNaam)
                                             .ThenBy(v => v.MerkTypeNaam)
                                             .ThenBy(v => v.Prijs);
            }
            else
            {
                return voertuigen.Where(v => v.FaktuurNr == null)
               .OrderBy(v => v.VoertuigCatId)
               .ThenBy(v => v.MerkNaam)
               .ThenBy(v => v.MerkTypeNaam)
               .ThenBy(v => v.Prijs);
            }
           
        }

    }
}