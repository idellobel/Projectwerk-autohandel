using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B4.EE.DellobelI.Domain.Services.Mock
{
    public class VoertuigenInMemoryService : IVoertuigenService
    {
            private static List<Voertuigen> voertuigenLijsten;
            private static List<Voertuigen> VoertuigenLijsten
            {
                get
                {
                    if (voertuigenLijsten == null)
                        voertuigenLijsten = InitializeVoertuigenLijsten();
                    return voertuigenLijsten;
                }
            }

            private static List<Voertuigen> InitializeVoertuigenLijsten()
            {
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

            //

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
            }
                ;
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

            return voertuigen;
            }

        ////public async Task<IEnumerable<Voertuigen>> GetVoertuigenLijstForKlant(Guid userid)
        ////{
        ////    await Task.Delay(Constants.Constants.Mocking.FakeDelay);
        ////    return VoertuigenLijsten.Where(k => k.VoertuigenStatus.);
        ////}

        public async Task<IEnumerable<Voertuigen>> GetAll()
            {
                await Task.Delay(Constants.Constants.Mocking.FakeDelay);
                return VoertuigenLijsten;
            }

            public async Task<Voertuigen> GetVoertuigenLijst(int voertuigenId)
            {
                await Task.Delay(Constants.Constants.Mocking.FakeDelay);
                return VoertuigenLijsten.FirstOrDefault(v => v.Id == voertuigenId);
            }

            public async Task SaveVoertuigenLijst(Voertuigen voertuigen)
            {
                await Task.Delay(Constants.Constants.Mocking.FakeDelay);
                var savedVoertuigen = VoertuigenLijsten.FirstOrDefault(v => v.Id == voertuigen.Id);
                if (savedVoertuigen == null) 
                {
                savedVoertuigen = voertuigen;
                
                VoertuigenLijsten.Add(savedVoertuigen);
                }
               
            }

            public async Task DeleteVoertuigenLijst(int voertuigenId)
            {
                await Task.Delay(Constants.Constants.Mocking.FakeDelay);
                var voertuigen = VoertuigenLijsten.FirstOrDefault(v => v.Id == voertuigenId);
                VoertuigenLijsten.Remove(voertuigen);
            }

        }
    }

