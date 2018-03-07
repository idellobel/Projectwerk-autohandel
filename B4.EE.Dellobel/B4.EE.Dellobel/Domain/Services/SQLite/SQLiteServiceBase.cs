using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using SQLite.Net;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace B4.EE.DellobelI.Domain.Services.SQLite
{
    /// <summary>
    /// Basisklasse voor alle "SQLite" implementaties van een service
    /// </summary>
    public abstract class SQLiteServiceBase
    {
        protected readonly SQLiteConnection connection;

        public SQLiteServiceBase()
        {
            //get the platform-specific SQLiteConnection
            var connectionFactory = DependencyService.Get<ISQLiteConnectionFactory>();
            connection = connectionFactory.CreateConnection("jikandata.db1");

            ////verwijdert bestaande tabellen
            //connection.DropTable<User>();
            //connection.DropTable<AppSettings>();
            //connection.DropTable<LocationGroup>();
            //connection.DropTable<Location>();

            //maakt tabellen aan (indien ze niet bestaan)
            connection.CreateTable<Voertuigen>();
            connection.CreateTable<Auto>();
            connection.CreateTable<Klant>();
            connection.CreateTable<WerkUren>();

            //seed

            //if (connection.Table<Voertuigen>().Count() == 0)
            //{
                // only insert the data if it doesn't already exist

                var voertuigen = new List<Voertuigen>
            {

                new Voertuigen{
                    Id = 0,
                    VoertuigenStatus = VoertuigenStatus.Aanbod,
                    Autoos = new List<Auto>()
                },
                new Voertuigen
                {
                    Id = 1,
                    VoertuigenStatus = VoertuigenStatus.Gekocht,
                    Autoos = new List<Auto>()
                },
                new Voertuigen
                {
                    Id = 2,
                    VoertuigenStatus = VoertuigenStatus.Verkocht,
                    Autoos = new List<Auto>()
                },
                new Voertuigen
                {
                    Id = 3,
                    VoertuigenStatus = VoertuigenStatus.Vraag,
                    Autoos = new List<Auto>()
                }
            };
                connection.InsertOrReplaceAll(voertuigen);

                voertuigen[0].Autoos = new List<Auto>
            {
                new Auto{
                    Id = 1, Merk = "Peugeot",
                    Model = "308",
                    Bouwjaar = 2014,
                    Prijs = 10524M,
                    AanBod = new DateTime(2018,01,19),
                    AutoStatus = AutoStatus.Aanbod,
                    Brandstof = Brandstof.Diesel,
                    EersteEigenaar = "Ja",
                    KMstand = 52000,
                    KlantNaam = "Pauwels Paul"


                },

                new Auto{
                    Id = 2, Merk = "Audi",
                    Model = "A1",
                    Bouwjaar = 2013,
                    Prijs = 12000M,
                    AanBod = new DateTime(2018,01,14),
                    AutoStatus = AutoStatus.Aanbod,
                    Brandstof = Brandstof.Benzine,
                    EersteEigenaar = "Nee",
                    KMstand = 85000,
                    KlantNaam = "Pittevils Roger"

                },

                new Auto{
                    Id = 3, Merk = "BMW",
                    Model = "3 Reeks",
                    Bouwjaar = 2015,
                    Prijs = 14000M,
                    AanBod = new DateTime(2018,01,4),
                    AutoStatus = AutoStatus.Aanbod,
                    Brandstof = Brandstof.Benzine,
                    EersteEigenaar = "Ja",
                    KMstand = 28000,
                    KlantNaam = "Rogiers Bernard"

                }
            };
                connection.InsertOrReplaceAll(voertuigen[0].Autoos);

                voertuigen[1].Autoos = new List<Auto>
            {
                new Auto{
                    Id = 4 ,Merk = "Citroën",
                    Model = "C4",
                    Bouwjaar = 2014,
                    Prijs = 10000M,
                    Aankoop = new DateTime(2018,01,4),
                    AutoStatus = AutoStatus.Gekocht,
                    Brandstof = Brandstof.Diesel,
                    EersteEigenaar = "Nee",
                    KMstand = 48000,
                    KlantNaam = "Janssens Gert"

                }
            };
                connection.InsertOrReplaceAll(voertuigen[1].Autoos);

                voertuigen[2].Autoos = new List<Auto>
            {
                new Auto{
                    Id = 5, Merk = "Ford",
                    Model = "B-Max",
                    Bouwjaar = 2016,
                    Prijs = 18000M,
                    Verkoop = new DateTime(2018,01,8),
                    AutoStatus = AutoStatus.Verkocht,
                    Brandstof = Brandstof.Diesel,
                    EersteEigenaar = "Ja",
                    KMstand = 12000,
                    KlantNaam = "Peeters Piet"
                },

                new Auto{
                    Id = 7, Merk = "Audi",
                    Model = "A6",
                    Bouwjaar = 2017,
                    Prijs = 38000M,
                    Verkoop = new DateTime(2018,01,19),
                    AutoStatus = AutoStatus.Verkocht,
                    Brandstof = Brandstof.Diesel,
                    EersteEigenaar = "Ja",
                    KMstand = 8000,
                    KlantNaam = "Goudezeune Gaby"
                }
            };
                connection.InsertOrReplaceAll(voertuigen[2].Autoos);

                voertuigen[3].Autoos = new List<Auto>
            {
                new Auto{
                    Id = 6, Merk = "Opel",
                    Model = "Corsa",
                    Bouwjaar = 2012,
                    Prijs = 6500M,
                    Vraag = new DateTime(2018,01,7),
                    AutoStatus = AutoStatus.Vraag,
                    Brandstof = Brandstof.Benzine,
                    KlantNaam = "Bomans Caroline"

                }

            };
                connection.InsertOrReplaceAll(voertuigen[3].Autoos);

                var klanten = new List<Klant>
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
                connection.InsertOrReplaceAll(klanten);

                var werkurenlijst = new List<WerkUren>
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
                connection.InsertOrReplaceAll(werkurenlijst);

            //}
        }
    }
}
