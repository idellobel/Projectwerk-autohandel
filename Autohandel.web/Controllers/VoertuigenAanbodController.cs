using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.Domain.DTO_klassen;

namespace Autohandel.web.Controllers
{
    [Produces("application/json")]
    
    //Is in ontwerp aangewend samen met het gebruik van vue.js. Vue.js gaf vie het attributt 'v-bind' problemen met een correcte ivoer van img.

    public class VoertuigenAanbodController : Controller
    {
        private readonly AutohandelContext _context;

        public VoertuigenAanbodController(AutohandelContext context)
        {
            _context = context;
        }
        [Route("api/VoertuigenAanbod")]
        // GET: api/VoertuigenAanbod
        [HttpGet]
        public IEnumerable<VoertuigDTO> GetVoertuigen()
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
            return voertuigen.Where(v => v.FaktuurNr == null);


        }
        [Route("api/GetVoertuigenOpMerk")]
        // GET: api/GetVoertuigenOpMerk
        [HttpGet]
        public IEnumerable<VoertuigDTO> GetVoertuigenOpMerk(string merk)
        {
             var voertuigen = from v in _context.Voertuigen
                                 select new VoertuigDTO()
                                 {
                                     VoertuigId = v.VoertuigId,
                                     MerkNaam = v.Merk.MerkNaam,
                                     VoertuigTitel = v.VoertuigTitel,
                                     Prijs = v.Prijs.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("nl-BE")),
                                     FiguurURL = v.FiguurURL.Remove(0, 2),
                                     MerkTypeNaam = v.MerkType.MerkTypeNaam,
                                     KlantNaam = v.Klant.KlantNaam,
                                     FaktuurNr = v.Faktuur.FaktuurNr,
                                     VoertuigArtikelNummer = v.VoertuigArtikelNummer,
                                     VoertuigCatId = v.VoertuigCatId
                                 };

                var voertuigenOpMerk = voertuigen.Where(v => v.FaktuurNr == null);
            if(voertuigenOpMerk.Where(v => v.MerkNaam == merk) == null)
            {
                return NotFound() as IQueryable<VoertuigDTO>;
            }


                return voertuigenOpMerk.Where(v => v.MerkNaam == merk);
            


        }
        [Route("api/GetVoertuigenOpPrijs")]
        // GET: api/GetVoertuigenOpPrijs
        [HttpGet]
        public IEnumerable<VoertuigDTO> GetVoertuigenOpPrijs(decimal minprijs, decimal maxprijs)
        {
            var voertuigen = from v in _context.Voertuigen
                             select new VoertuigDTO()
                             {
                                 VoertuigId = v.VoertuigId,
                                 MerkNaam = v.Merk.MerkNaam,
                                 VoertuigTitel = v.VoertuigTitel,
                                 Prijs = v.Prijs.ToString("C0", System.Globalization.CultureInfo.GetCultureInfo("nl-BE")),
                                 FiguurURL = v.FiguurURL.Remove(0, 2),
                                 MerkTypeNaam = v.MerkType.MerkTypeNaam,
                                 KlantNaam = v.Klant.KlantNaam,
                                 FaktuurNr = v.Faktuur.FaktuurNr,
                                 VoertuigArtikelNummer = v.VoertuigArtikelNummer,
                                 VoertuigCatId = v.VoertuigCatId
                             };

            var voertuigenOpMerk = voertuigen.Where(v => v.FaktuurNr == null);



            return (voertuigenOpMerk.Where(v => (Convert.ToDecimal(v.Prijs) >= minprijs))
                                    .Where(v => Convert.ToDecimal(v.Prijs) <= maxprijs));



        }


        // GET: api/VoertuigenAanbod/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVoertuig([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voertuig = await _context.Voertuigen.SingleOrDefaultAsync(m => m.VoertuigId == id);

            if (voertuig == null)
            {
                return NotFound();
            }

            return Ok(voertuig);
        }

        // PUT: api/VoertuigenAanbod/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoertuig([FromRoute] long id, [FromBody] Voertuig voertuig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != voertuig.VoertuigId)
            {
                return BadRequest();
            }

            _context.Entry(voertuig).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoertuigExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VoertuigenAanbod
        [HttpPost]
        public async Task<IActionResult> PostVoertuig([FromBody] Voertuig voertuig)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Voertuigen.Add(voertuig);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoertuig", new { id = voertuig.VoertuigId }, voertuig);
        }

        // DELETE: api/VoertuigenAanbod/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoertuig([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var voertuig = await _context.Voertuigen.SingleOrDefaultAsync(m => m.VoertuigId == id);
            if (voertuig == null)
            {
                return NotFound();
            }

            _context.Voertuigen.Remove(voertuig);
            await _context.SaveChangesAsync();

            return Ok(voertuig);
        }

        private bool VoertuigExists(long id)
        {
            return _context.Voertuigen.Any(e => e.VoertuigId == id);
        }
    }
}