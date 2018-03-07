using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.Mock
{
    public class UrenInMemoryService : IUrenService
    {
        private static List<WerkUren> werkurenlijst = new List<WerkUren>
        {
            new WerkUren{
                WerkId = 5,
                Datum= new DateTime(2018,01,19),
                BeginTijd = new TimeSpan(8,0,0),
                EindTijd = new TimeSpan(8,30,0),
                Aankoop = 0M,
                Verkoop = 0M,
                Waarde = 0M,
                GewerkteTijd = new TimeSpan(0,30,0),
                Toelichting = "Aanbod Pauwels, Peugeot 308",
                AutoId = 1
           },
            new WerkUren{
                WerkId = 4,
                Datum= new DateTime(2018,01,14),
                BeginTijd = new TimeSpan(10,30,0),
                EindTijd = new TimeSpan(12,0,0),
                Aankoop = 0M,
                Verkoop = 0M,
                Waarde = 0M,
                GewerkteTijd = new TimeSpan(1,30,0),
                Toelichting = "Aanbod Pittevils, Audi A1",
                AutoId = 2
           },
             new WerkUren{
                WerkId = 1,
                Datum= new DateTime(2018,01,04),
                BeginTijd = new TimeSpan(14,0,0),
                EindTijd = new TimeSpan(16,30,0),
                Aankoop = 0M,
                Verkoop = 0M,
                Waarde = 0M,
                GewerkteTijd = new TimeSpan(2,30,0),
                Toelichting = "Aanbod Rogiers, BMW 3Reeks",
                AutoId = 3,
           },
              new WerkUren{
                WerkId = 0,
                Datum= new DateTime(2018,01,04),
                BeginTijd = new TimeSpan(9,0,0),
                EindTijd = new TimeSpan(11,30,0),
                Aankoop = 10000M,
                Verkoop = 0M,
                Waarde = -10000M,
                GewerkteTijd = new TimeSpan(2,30,0),
                Toelichting = "Koop Janssens Gert, Citroën C4",
                AutoId = 4
           },
               new WerkUren{
                WerkId = 3,
                Datum= new DateTime(2018,01,8),
                BeginTijd = new TimeSpan(15,0,0),
                EindTijd = new TimeSpan(17,30,0),
                Aankoop = 14500M,
                Verkoop = 18000M,
                Waarde = 3500M,
                GewerkteTijd = new TimeSpan(2,30,0),
                Toelichting = "Aanbod Peeters Piet, Ford B-Max",
                AutoId = 5
           },
                new WerkUren{
                WerkId = 2,
                Datum= new DateTime(2018,01,7),
                BeginTijd = new TimeSpan(8,0,0),
                EindTijd = new TimeSpan(8,30,0),
                Aankoop = 0M,
                Verkoop = 0M,
                Waarde = 0M,
                GewerkteTijd = new TimeSpan(0,30,0),
                Toelichting = "Vraag van Bomans, Opel Corsa",
                 AutoId = 6
           },
                new WerkUren{
                WerkId = 6,
                Datum= new DateTime(2018,01,19),
                BeginTijd = new TimeSpan(15,0,0),
                EindTijd = new TimeSpan(17,30,0),
                Aankoop = 30000M,
                Verkoop = 38000M,
                Waarde = 8000M,
                GewerkteTijd = new TimeSpan(2,30,0),
                Toelichting = "Verkoop Goudezeune, Audi A6",
                 AutoId = 7
           },
        };

        public static List<WerkUren> Werkurenlijst { get => werkurenlijst; set => werkurenlijst = value; }

        public async Task<IEnumerable<WerkUren>> GetAllUren()
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            return Werkurenlijst;
        }

        public async Task<WerkUren> GetUrenById(int id)
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            return Werkurenlijst.FirstOrDefault(u => u.WerkId == id);
        }

        public async Task SaveUren(WerkUren werk)
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            Werkurenlijst.Add(werk);
            //var nieuwWerkuren = await GetUrenById(werk.WerkId);
            //nieuwWerkuren = werk;
        }

        public async Task DeleteUren(int werkId)
        {
            await Task.Delay(Constants.Constants.Mocking.FakeDelay);
            var werkuren = werkurenlijst.FirstOrDefault(w => w.WerkId == werkId);
            Werkurenlijst.Remove(werkuren);
        }

    }
}
