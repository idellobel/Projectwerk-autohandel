using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.Mock
{
    public class KlantenInMemoryService : IKlantenService
    {
         private static List<Klant> klanten = new List<Klant>
        {
            new Klant{
                Id = new Guid(),
                Naam= "Pauwels Paul",
                Adres = "Doornstraat",
                Postnummer= 8670,
                Woonplaats = "Oostduinkerke",
                Telefoonnummer= "058594566",
                Email= "paul.pauwels@gmail.com",
                KlantStatus = KlantStatus.Verkoper,
                AutoId = 1
           },
            new Klant{
                Id = new Guid(),
                Naam= "Pittevils Roger",
                Adres = "Asweg 9",
                Postnummer= 8450,
                Woonplaats = "Oostende",
                Telefoonnummer= "0485999999",
                Email= "roger.pittevils@gmail.com",
                KlantStatus = KlantStatus.Verkoper,
                AutoId = 2
           },
            new Klant{
                Id = new Guid(),
                Naam= "Rogiers Bernard",
                Adres = "Koekoekstraat 12",
                Postnummer= 8630,
                Woonplaats = "Veurne",
                Telefoonnummer= "0478151214",
                Email= "bernard.rogiers@gmail.com",
                KlantStatus = KlantStatus.Verkoper,
                AutoId = 3
           },
            new Klant{
                Id = new Guid(),
                Naam= "Jansens Gert",
                Adres = "Klaverstraat 17",
                Postnummer= 8600,
                Woonplaats = "Diksmuide",
                Telefoonnummer= "0479756210",
                Email= "bernard.rogiers@gmail.com",
                KlantStatus = KlantStatus.Verkoper,
                AutoId = 4
           },
            new Klant{
                Id = new Guid(),
                Naam= "Peeters Piet",
                Adres = "Arsenaalstraat 6",
                Postnummer= 8620,
                Woonplaats = "Nieuwpoort",
                Telefoonnummer= "0478662478",
                Email= "piet.peeters@gmail.com",
                KlantStatus = KlantStatus.Koper,
                AutoId = 5
           },
            new Klant{
                Id = new Guid(),
                Naam= "Bomans Caroline",
                Adres = "Stuiverwijk 46",
                Postnummer= 8620,
                Woonplaats = "Nieuwpoort",
                Telefoonnummer= "0499184768",
                Email= "caroline.bomans@gmail.com",
                KlantStatus = KlantStatus.Koper,
                AutoId = 6,
                
           },

        };

        public async Task<IEnumerable<Klant>> GetAllKlanten()
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            return klanten;
        }

        public async Task<IEnumerable<Klant>> GetAllKlantenOrdered()
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            var klanten = await GetAllKlanten();
            var orderedKlanten =  klanten.OrderBy(k => k.Naam.Substring(0, 1));
            return orderedKlanten;
        }

        public async Task<Klant> GetKlantById(Guid id)
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            return klanten.FirstOrDefault(u => u.Id == id);
        }

        public async Task SaveKlant(Klant klant)
        {
            var nieuwKlant = await GetKlantById(klant.Id);
            nieuwKlant = klant;
        }

        public async Task DeleteKlant(Guid id)
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            var klant = klanten.FirstOrDefault(k => k.Id == id);
            klanten.Remove(klant);
        }

    }
}
