using Autohandel.Domain.Entities;
using Autohandel.Domain.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.Domain.Data
{
    public class DataSeeder
    {
        public static void Seed(AutohandelContext context)
        {
            //List<MerkType> allTypes = context.Types.ToList();
            //List<Merk> allMerken = context.Merken.ToList();
            //Seed voertuigenCategorie
            if (!context.VoertuigCategorieen.Any())
            {
                VoertuigCategorie[] voertuigCategorieen = new[]
                {
                    new VoertuigCategorie{ VoertuigCategorieNaam = "Personenwagen"},
                    new VoertuigCategorie{ VoertuigCategorieNaam = "Bestelwagen"}
                };
                context.VoertuigCategorieen.AddRange(voertuigCategorieen);
                context.SaveChanges();
            }

            //Seed Merken


            if (!context.Merken.Any())
            {
                Merk[] merken = new[]
                {
                    new Merk() { MerkNaam = "Alfa Romeo" },  //0
                    new Merk() { MerkNaam = "Audi"},        //1
                    new Merk() { MerkNaam = "BMW"},         //2
                    new Merk() { MerkNaam = "Citroen" },     //3
                    new Merk() { MerkNaam = "Daewoo"},      //4
                    new Merk() { MerkNaam = "Daihatsu" },    //5
                    new Merk() { MerkNaam = "Fiat"},        //6
                    new Merk() { MerkNaam = "Ford" },        //7
                    new Merk() { MerkNaam = "Honda" },       //8
                    new Merk() { MerkNaam = "Hyundai" },     //9
                    new Merk() { MerkNaam = "Jaguar" },      //10
                    new Merk() { MerkNaam = "Kia" },         //11
                    new Merk() { MerkNaam = "Landrover" },   //12
                    new Merk() { MerkNaam = "Mazda" },       //13
                    new Merk() { MerkNaam = "Mercedes" },    //14
                    new Merk() { MerkNaam = "Mitsubishi" },  //15
                    new Merk() { MerkNaam = "Nissan"  },      //16
                    new Merk() { MerkNaam = "Opel" },        //17
                    new Merk() { MerkNaam = "Peugeot" },     //18
                    new Merk() { MerkNaam = "Porsche"},     //19
                    new Merk() { MerkNaam = "Renault"},     //20
                    new Merk() { MerkNaam = "Volkswagen" },  //21
                    new Merk() { MerkNaam = "Volvo" },       //22
                    new Merk() { MerkNaam = "Dacia"},        //23
                };
                context.Merken.AddRange(merken);
                context.SaveChanges();
            }


            if (!context.Types.Any())
                {
                    MerkType[] types = new[]
                {
                    //Alfa Romeo
                    new MerkType {MerkTypeNaam = "Giulia", MerkId= 1},     //0
                    new MerkType {MerkTypeNaam = "Giulietta", MerkId= 1 },  //1
                    new MerkType {MerkTypeNaam = "Stelvio", MerkId= 1},    //2
                    new MerkType {MerkTypeNaam = "MiTo", MerkId= 1 },       //3
                    new MerkType {MerkTypeNaam = "156", MerkId= 1},        //4
                    new MerkType {MerkTypeNaam = "Brera", MerkId= 1 },      //5
                    new MerkType {MerkTypeNaam = "Spider", MerkId= 1 },     //6

                    //Audi
                    new MerkType {MerkTypeNaam = "A3", MerkId= 22},        //7
                    new MerkType {MerkTypeNaam = "A4", MerkId= 22},        //8
                    new MerkType {MerkTypeNaam = "A5", MerkId= 22},        //9
                    new MerkType {MerkTypeNaam = "A6", MerkId= 22},        //10
                    new MerkType {MerkTypeNaam = "A1", MerkId= 22},        //11

                    //BMW
                     new MerkType {MerkTypeNaam = "1 Reeks", MerkId= 21 },        //12
                     new MerkType {MerkTypeNaam = "2 Reeks", MerkId= 21 },        //13
                     new MerkType {MerkTypeNaam = "3 Reeks", MerkId= 21 },        //14
                     new MerkType {MerkTypeNaam = "4 Reeks", MerkId= 21},        //15
                     new MerkType {MerkTypeNaam = "5 Reeks", MerkId= 21},        //16
                     new MerkType {MerkTypeNaam = "i3", MerkId= 21 },             //17
                     new MerkType {MerkTypeNaam = "X1", MerkId= 21},             //18
                     new MerkType {MerkTypeNaam = "X3", MerkId= 21 },             //19
                     new MerkType {MerkTypeNaam = "Z4", MerkId= 21 },             //20

                     //CITROEN
                     new MerkType {MerkTypeNaam = "C4 AIRCROSS", MerkId= 20 },   //21
                     new MerkType {MerkTypeNaam = "C1", MerkId= 20},            //22
                     new MerkType {MerkTypeNaam = "C3", MerkId= 20},            //23
                     new MerkType {MerkTypeNaam = "C4", MerkId= 20 },            //24
                     new MerkType {MerkTypeNaam = "C4 Cactus", MerkId= 20},     //25
                     new MerkType {MerkTypeNaam = "JUMPER", MerkId= 20},        //26
                     new MerkType {MerkTypeNaam = "C5", MerkId= 20},            //27
                     
                     //DAEWOO
                     new MerkType {MerkTypeNaam = "Nubira", MerkId= 19 },       //28
                     
                     //DAIHATSU
                     new MerkType {MerkTypeNaam = "Charade", MerkId= 18 },        //29
                 
                     //FIAT
                     new MerkType {MerkTypeNaam = "500", MerkId= 17},           //30
                     new MerkType {MerkTypeNaam = "Panda", MerkId= 17},          //31
                     new MerkType {MerkTypeNaam = "Punto", MerkId= 17},          //32
                     new MerkType {MerkTypeNaam = "Tipo", MerkId= 17},         //33
                     new MerkType {MerkTypeNaam = "Bravo", MerkId= 17 },        //34
                     
                     //FORD
                     new MerkType {MerkTypeNaam = "Ecosport", MerkId= 16},       //35
                     new MerkType {MerkTypeNaam = "Edge", MerkId= 16},          //36
                     new MerkType {MerkTypeNaam = "Fiesta", MerkId= 16},       //37
                     new MerkType {MerkTypeNaam = "Focus", MerkId= 16},          //38
                     new MerkType {MerkTypeNaam = "Galaxy", MerkId= 16},         //39
                     new MerkType {MerkTypeNaam = "B-Max", MerkId= 16},         //40
                     new MerkType {MerkTypeNaam = "C-Max", MerkId= 16},          //41
                     new MerkType {MerkTypeNaam = "Transit", MerkId= 16},        //42
                     new MerkType {MerkTypeNaam = "S-Max", MerkId= 16},          //43
                     
                     //HONDA
                     new MerkType {MerkTypeNaam = "CR-V", MerkId= 15},          //44
                     new MerkType {MerkTypeNaam = "Jazz", MerkId= 15},         //45
                     
                     //HYUNDAI
                     new MerkType {MerkTypeNaam = "i10", MerkId= 14},           //46
                     new MerkType {MerkTypeNaam = "i20", MerkId= 14},           //47

                     //JAGUAR
                     new MerkType {MerkTypeNaam = "XE", MerkId= 13},            //48
                     new MerkType {MerkTypeNaam = "XJ", MerkId= 13},            //49
                     new MerkType {MerkTypeNaam = "E-PACE", MerkId= 13},    //50
                     
                     //KIA
                     new MerkType {MerkTypeNaam = "Carens", MerkId= 12},     //51
                     new MerkType {MerkTypeNaam = "Rio", MerkId= 12},         //52
                     new MerkType {MerkTypeNaam = "Picanto", MerkId= 12},       //53
                     new MerkType {MerkTypeNaam = "Venga", MerkId= 12},      //54
                     new MerkType {MerkTypeNaam = "cee'd", MerkId= 12},        //55
                     new MerkType {MerkTypeNaam = "Hybrid", MerkId= 12},        //56
                     new MerkType {MerkTypeNaam = "Optima", MerkId= 12},    //57
                     new MerkType {MerkTypeNaam = "Soul EV", MerkId= 12},      //58
                    
                     //LANDROVER
                     new MerkType {MerkTypeNaam = "Discovery", MerkId= 11},           //59
                     new MerkType {MerkTypeNaam = "Range Rover Evoque", MerkId= 11},    //60

                     //MAZDA
                     new MerkType {MerkTypeNaam = "Mazda2", MerkId= 10},        //61
                     new MerkType {MerkTypeNaam = "Mazda3", MerkId= 10},        //62
                     new MerkType {MerkTypeNaam = "CX-3", MerkId= 10},        //63
                     new MerkType {MerkTypeNaam = "CX-5", MerkId= 10},       //64
                     new MerkType {MerkTypeNaam = "MX-5", MerkId= 10},        //65

                     //MERCEDES
                     new MerkType {MerkTypeNaam = "A-Klasse", MerkId= 9},      //66
                     new MerkType {MerkTypeNaam = "B-Klasse", MerkId= 9},    //67
                     new MerkType {MerkTypeNaam = "C-Klasse", MerkId= 9},       //68
                     new MerkType {MerkTypeNaam = "CLA", MerkId= 9},           //69
                     new MerkType {MerkTypeNaam = "GLA SUV", MerkId= 9},       //70

                     //MITSUBISHI
                     new MerkType {MerkTypeNaam = "SPACE STAR", MerkId= 8},     //71
                     new MerkType {MerkTypeNaam = "ASX", MerkId= 8},          //72
                     new MerkType {MerkTypeNaam = "ECLIPSE CROSS", MerkId= 8},  //73
                     new MerkType {MerkTypeNaam = "OUTLANDER", MerkId= 8},   //74

                     //NISSAN
                     new MerkType {MerkTypeNaam = "JUKE", MerkId= 7},          //75
                     new MerkType {MerkTypeNaam = "MICRA", MerkId= 7},            //76
                     new MerkType {MerkTypeNaam = "NOTE", MerkId= 7 },           //77
                     new MerkType {MerkTypeNaam = "LEAF", MerkId= 7},            //78

                     //OPEL
                      new MerkType {MerkTypeNaam = "ADAM", MerkId= 6},            //79
                     new MerkType {MerkTypeNaam = "AGILA", MerkId= 6},           //80
                     new MerkType {MerkTypeNaam = "AMPERA", MerkId= 6},       //81
                     new MerkType {MerkTypeNaam = "ASTRA", MerkId= 6},          //82
                     new MerkType {MerkTypeNaam = "CASCADA", MerkId= 6},      //83
                     new MerkType {MerkTypeNaam = "CORSA", MerkId= 6},           //84
                     new MerkType {MerkTypeNaam = "CROSSLAND X", MerkId= 6},     //85
                     new MerkType {MerkTypeNaam = "GRANDLAND X", MerkId= 6},    //87
                     new MerkType {MerkTypeNaam = "INSIGNIA", MerkId= 6},        //88
                     new MerkType {MerkTypeNaam = "KARL", MerkId= 6},           //89
                     new MerkType {MerkTypeNaam = "MERIVA", MerkId= 6},          //90
                     new MerkType {MerkTypeNaam = "MOKKA", MerkId= 6},          //91
                     new MerkType {MerkTypeNaam = "MOVANO", MerkId= 6},         //92

                     //PEUGEOT
                     new MerkType {MerkTypeNaam = "207", MerkId= 5},            //93
                     new MerkType {MerkTypeNaam = "208", MerkId= 5},         //94
                     new MerkType {MerkTypeNaam = "2008", MerkId= 5},         //95
                     new MerkType {MerkTypeNaam = "308", MerkId= 5},          //96
                     new MerkType {MerkTypeNaam = "3008", MerkId= 5},         //97
                     new MerkType {MerkTypeNaam = "4007", MerkId= 5},           //98
                     new MerkType {MerkTypeNaam = "5008", MerkId= 5},          //99
                     new MerkType {MerkTypeNaam = "508", MerkId= 5},         //100
                     new MerkType {MerkTypeNaam = "TRAVELLER", MerkId= 5},      //101
                   
                     //PORCHE
                     new MerkType {MerkTypeNaam = "718 BOXSTER", MerkId= 4},      //102
                     new MerkType {MerkTypeNaam = "718 CAYMAN", MerkId= 4},    //103
                     new MerkType {MerkTypeNaam = "911", MerkId= 4},              //104
                     new MerkType {MerkTypeNaam = "CAYENNE", MerkId= 4},         //105
                     new MerkType {MerkTypeNaam = "MACAN", MerkId= 4},            //106
                     new MerkType {MerkTypeNaam = "PANAMERA", MerkId= 4},       //107

                     //RENAULT
                     new MerkType {MerkTypeNaam = "CAPTUR", MerkId= 3},          //108
                     new MerkType {MerkTypeNaam = "CLIO", MerkId= 3},             //109
                     new MerkType {MerkTypeNaam = "ESPACE", MerkId= 3},         //110
                     new MerkType {MerkTypeNaam = "KADJAR", MerkId= 3},          //111
                     new MerkType {MerkTypeNaam = "KOLEOS", MerkId= 3},           //112
                     new MerkType {MerkTypeNaam = "MEGANE", MerkId= 3},        //113
                     new MerkType {MerkTypeNaam = "SCENIC", MerkId= 3},         //114
                     new MerkType {MerkTypeNaam = "TALISMAN", MerkId= 3},         //115
                     new MerkType {MerkTypeNaam = "TWINGO", MerkId= 3},          //116
                     new MerkType {MerkTypeNaam = "TWIZY", MerkId= 3},          //117
                     new MerkType {MerkTypeNaam = "ZOE", MerkId= 3},              //118

                     //VOLKSWAGEN
                     new MerkType {MerkTypeNaam = "CC", MerkId= 2},              //119
                     new MerkType {MerkTypeNaam = "GOLF", MerkId= 2},            //120
                     new MerkType {MerkTypeNaam = "JETTA", MerkId= 2},         //121
                     new MerkType {MerkTypeNaam = "NEW BEETLE", MerkId= 2},       //123
                     new MerkType {MerkTypeNaam = "PASSAT", MerkId= 2},          //124
                     new MerkType {MerkTypeNaam = "POLO", MerkId= 2},            //125
                     new MerkType {MerkTypeNaam = "SCIROCCO", MerkId= 2},       //126
                     new MerkType {MerkTypeNaam = "SHARAN", MerkId= 2},          //127
                     new MerkType {MerkTypeNaam = "TIGUAN", MerkId= 2},          //128
                     new MerkType {MerkTypeNaam = "TOUAREG", MerkId= 2},         //129
                     new MerkType {MerkTypeNaam = "TOURAN", MerkId= 2},          //130
                     new MerkType {MerkTypeNaam = "T-ROC", MerkId= 2},           //131
                     new MerkType {MerkTypeNaam = "UP!", MerkId= 2},            //132
                     new MerkType {MerkTypeNaam = "TRANSPORTER", MerkId= 2},     //133

                     //VOLVO
                     new MerkType {MerkTypeNaam = "S60", MerkId= 23},              //134
                     new MerkType {MerkTypeNaam = "S60 CROSS COUNTRY", MerkId= 23},  //135
                     new MerkType {MerkTypeNaam = "S90", MerkId= 23},                //136
                     new MerkType {MerkTypeNaam = "V40", MerkId= 23},                //137
                     new MerkType {MerkTypeNaam = "V40 CROSS COUNTRY", MerkId= 23},  //138
                     new MerkType {MerkTypeNaam = "V60", MerkId= 23},              //139
                     new MerkType {MerkTypeNaam = "V60 CROSS COUNTRY", MerkId= 23},  //140
                     new MerkType {MerkTypeNaam = "V90", MerkId= 23},              //141
                     new MerkType {MerkTypeNaam = "XC40", MerkId= 23},               //142
                     new MerkType {MerkTypeNaam = "XC60", MerkId= 23},              //143
                     new MerkType {MerkTypeNaam = "XC90", MerkId= 23},              //144

                     //DACIA
                     new MerkType { MerkTypeNaam = "DUSTER", MerkId= 24},            //145
                     
                  
                };
                context.Types.AddRange(types);
                context.SaveChanges();
                    //allTypes = types.ToList();
                }

                //seed voertuigen
                if (!context.Voertuigen.Any())
                {
                    Voertuig[] voertuigen = new[]
                    {
                    new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A1"),
                                  VoertuigArtikelNummer = "1",
                                  FiguurURL = @"~/images/vtgn/fronts/1_FRONT.jpg",
                                  VoertuigTitel= "1.4 TDi",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "12/2016",
                                  Kilometerstand = 15000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 17250M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1422,
                                  COTwee = "91 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 4,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                    },
                    new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A1"),
                                  VoertuigArtikelNummer = "2",
                                  FiguurURL = @"~/images/vtgn/fronts/2_FRONT.jpg",
                                  VoertuigTitel = "1.0 TFSI",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "03/2017",
                                  Kilometerstand = 16526,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 17450M,
                                  GarantieTijd = "24 maanden",
                                  CC = 999,
                                  COTwee = "97 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                    },
                    new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A3"),
                                  VoertuigArtikelNummer = "3",
                                  FiguurURL = @"~/images/vtgn/fronts/3_FRONT.jpg",
                                  VoertuigTitel = "1.0 TFSI Sport",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "08/2017",
                                  Kilometerstand = 5741,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 23500M,
                                  GarantieTijd = "24 maanden",
                                  CC = 999,
                                  COTwee = "107 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                    },
                    new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A3"),
                                  VoertuigArtikelNummer = "4",
                                  FiguurURL = @"~/images/vtgn/fronts/4_FRONT.jpg",
                                  VoertuigTitel = "1.6 TDi Sport",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "03/2017",
                                  Kilometerstand = 15000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 22900M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1598,
                                  COTwee = "107 gr",
                                  Deuren = 3,
                                  Zitplaatsen = 5,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                    },
                    new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A5"),
                                  VoertuigArtikelNummer = "5",
                                  FiguurURL = @"~/images/vtgn/fronts/5_FRONT.jpg",
                                  VoertuigTitel= "2.0 TDi Quattro S line S tronic DPF",
                                  Koetswerk = Koetswerk.Coupé,
                                  Registratie = "03/2014",
                                  Kilometerstand = 95550,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 25900M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1968,
                                  COTwee = "139 gr",
                                  Deuren = 2,
                                  Zitplaatsen = 4,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2014,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                    },
                    new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "BMW"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "3 Reeks"),
                                  VoertuigArtikelNummer = "6",
                                  FiguurURL = @"~/images/vtgn/fronts/6_FRONT.jpg",
                                  VoertuigTitel= "D NW MOD GPS AIRCO 6V PDC USB AUX ALU/VELGEN B/C",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "05/2016",
                                  Kilometerstand = 61909,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 18990M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1995,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "102 gr",
                                  Deuren = 2,
                                  Zitplaatsen = 4,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                    },
                    new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "BMW"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "3 Reeks"),
                                  VoertuigArtikelNummer = "7",
                                  FiguurURL = @"~/images/vtgn/fronts/7_FRONT.jpg",
                                  VoertuigTitel= "316 d TOURING CUIR/NAVI/TO PANO/JA17",
                                  Koetswerk = Koetswerk.Break,
                                  Registratie = "07/2013",
                                  Kilometerstand = 24140,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 16748M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1995,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "123 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.blauw.ToString(),
                                  Binnenbekleding = Binnenbekleding.Leder,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2013,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "BMW"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "3 Reeks"),
                                  VoertuigArtikelNummer = "8",
                                  FiguurURL = @"~/images/vtgn/fronts/8_FRONT.jpg",
                                  VoertuigTitel= "316DA Touring Aut. Navi/leder/PDC",
                                  Koetswerk = Koetswerk.Break,
                                  Registratie = "02/2014",
                                  Kilometerstand = 24140,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 18950M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1995,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "119 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.wit.ToString(),
                                  Binnenbekleding = Binnenbekleding.Leder,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2014,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "BMW"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "5 Reeks"),
                                  VoertuigArtikelNummer = "9",
                                  FiguurURL = @"~/images/vtgn/fronts/9_FRONT.jpg",
                                  VoertuigTitel= "520 dXas x Drive Pack M",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "08/2015",
                                  Kilometerstand = 49266,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 34998M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1995,
                                  Vermogen = "188 pk(140 kW)",
                                  COTwee = "129 gr",
                                  Deuren = 4,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Leder,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2015,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "BMW"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "1 Reeks"),
                                  VoertuigArtikelNummer = "10",
                                  FiguurURL = @"~/images/vtgn/fronts/10_FRONT.jpg",
                                  VoertuigTitel= "Sportshatch",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "09/2016",
                                  Kilometerstand = 26606,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 19900M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1496,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "89 gr",
                                  Deuren = 3,
                                  Kleur = Kleur.zwart.ToString(),
                                  Binnenbekleding = Binnenbekleding.Velour,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Ford"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "B-Max"),
                                  VoertuigArtikelNummer = "11",
                                  FiguurURL = @"~/images/vtgn/fronts/11_FRONT.jpg",
                                  VoertuigTitel= "Titanium+gps+camera+parkh+zetelverw+garantie tot 07/2021 of 100.000km",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "07/2017",
                                  Kilometerstand = 22243,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 14900M,
                                  GarantieTijd = "24 maanden",
                                  CC = 998,
                                  Vermogen = "125 pk(92 kW)",
                                  Deuren = 5,
                                  Kleur = Kleur.zwart.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Ford"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "C-Max"),
                                  VoertuigArtikelNummer = "12",
                                  FiguurURL = @"~/images/vtgn/fronts/12_FRONT.jpg",
                                  VoertuigTitel= "1.5 TDCI Titanium 120pk",
                                  Koetswerk = Koetswerk.Monovolume,
                                  Registratie = "10/2017",
                                  Kilometerstand = 7500,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 20950M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1499,
                                  Vermogen = "120 pk(88 kW)",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Ford"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "C-Max"),
                                  VoertuigArtikelNummer = "13",
                                  FiguurURL = @"~/images/vtgn/fronts/13_FRONT.jpg",
                                  VoertuigTitel= "1.6 TDCi Trend Style Start-Stop/Navigatie/1j gar.",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "01/2015",
                                  Kilometerstand = 73000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 13500M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1560,
                                  Vermogen = "114 pk(85 kW)",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.bruin.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2015,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Opel"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "ASTRA"),
                                  VoertuigArtikelNummer = "14",
                                  FiguurURL = @"~/images/vtgn/fronts/14_FRONT.jpg",
                                  VoertuigTitel= "1.6 CDTi ecoFLEX Ultimate Edition NAVI",
                                  Koetswerk = Koetswerk.Break,
                                  Registratie = "03/2016",
                                  Kilometerstand = 68184,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 12248M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1598,
                                  Vermogen = "109 pk(81 kW)",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.zilver.ToString(),
                                  Binnenbekleding = Binnenbekleding.Semileder,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Opel"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "ASTRA"),
                                  VoertuigArtikelNummer = "15",
                                  FiguurURL = @"~/images/vtgn/fronts/15_FRONT.jpg",
                                  VoertuigTitel= "SPORTSSEDAN 1.7 CDTI 130PK COSMO € 12.990 ALL IN !",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "04/2014",
                                  Kilometerstand = 39000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 12990M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1686,
                                  Vermogen = "130 pk(96 kW)",
                                  Deuren = 4,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Semileder,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2014,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Opel"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "CORSA"),
                                  VoertuigArtikelNummer = "16",
                                  FiguurURL = @"~/images/vtgn/fronts/16_FRONT.jpg",
                                  VoertuigTitel= "1.3 CDTI Enjoy Start/Stop",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "08/2016",
                                  Kilometerstand = 20929,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 10748M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1248,
                                  Vermogen = "74 pk(55 kW)",
                                  COTwee = "98 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.zilver.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Opel"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "CORSA"),
                                  VoertuigArtikelNummer = "17",
                                  FiguurURL = @"~/images/vtgn/fronts/17_FRONT.jpg",
                                  VoertuigTitel= "ENJOY 1.3CDTI * 2 JAAR GARANTIE *",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "08/2016",
                                  Kilometerstand = 15845,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 10990M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1248,
                                  Vermogen = "95 pk(70 kW)",
                                  COTwee = "87 gr",
                                  Deuren = 3,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Opel"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "AGILA"),
                                  VoertuigArtikelNummer = "18",
                                  FiguurURL = @"~/images/vtgn/fronts/18_FRONT.jpg",
                                  VoertuigTitel= "Essentia",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "06/2013",
                                  Kilometerstand = 38210,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 7490M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1242,
                                  Vermogen = "94 pk(69 kW)",
                                  COTwee = "119 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Grijs,
                                  Bouwjaar = 2013,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "207"),
                                  VoertuigArtikelNummer = "19",
                                  FiguurURL = @"~/images/vtgn/fronts/19_FRONT.jpg",
                                  VoertuigTitel= "Access",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "02/2014",
                                  Kilometerstand = 27152,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 7980M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1360,
                                  Vermogen = "72 pk(54 kW)",
                                  COTwee = "145 gr",
                                  Deuren = 5,
                                  Kleur = Kleur.rood.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2014,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                      new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "207"),
                                  VoertuigArtikelNummer = "20",
                                  FiguurURL = @"~/images/vtgn/fronts/20_FRONT.jpg",
                                  VoertuigTitel= "1.6i Pack",
                                  Koetswerk = Koetswerk.Cabriolet,
                                  Registratie = "01/2013",
                                  Kilometerstand = 51750,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 8900M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1598,
                                  Vermogen = "118 pk(88 kW)",
                                  COTwee = "150 gr",
                                  Deuren = 2,
                                  Zitplaatsen = 4,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2013,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "308"),
                                  VoertuigArtikelNummer = "21",
                                  FiguurURL = @"~/images/vtgn/fronts/21_FRONT.jpg",
                                  VoertuigTitel= "1.2 PureTech Active + Navi",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "09/2017",
                                  Kilometerstand = 8000,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 18990M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1199,
                                  Vermogen = "109 pk(81 kW)",
                                  COTwee = "105 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "308"),
                                  VoertuigArtikelNummer = "22",
                                  FiguurURL = @"~/images/vtgn/fronts/22_FRONT.jpg",
                                  VoertuigTitel= "1.2 PureTech GT Line STT",
                                  Koetswerk = Koetswerk.Break,
                                  Registratie = "08/2017",
                                  Kilometerstand = 333,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 22621M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1199,
                                  Vermogen = "129 pk(96 kW)",
                                  COTwee = "115 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.rood.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "308"),
                                  VoertuigArtikelNummer = "23",
                                  FiguurURL = @"~/images/vtgn/fronts/23_FRONT.jpg",
                                  VoertuigTitel= "1.6 BlueHDi Allure STT",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "06/2016",
                                  Kilometerstand = 45000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 14990M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1560,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "94 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Velour,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "2008"),
                                  VoertuigArtikelNummer = "24",
                                  FiguurURL = @"~/images/vtgn/fronts/24_FRONT.jpg",
                                  VoertuigTitel= "1.6 BlueHDi Style + Navi/facelift",
                                  Koetswerk = Koetswerk.SUV,
                                  Registratie = "02/2017",
                                  Kilometerstand = 29583,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 13749M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1560,
                                  Vermogen = "98 pk(73 kW)",
                                  COTwee = "98 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.groen.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "2008"),
                                  VoertuigArtikelNummer = "25",
                                  FiguurURL = @"~/images/vtgn/fronts/25_FRONT.jpg",
                                  VoertuigTitel= "1.2 PureTech Style",
                                  Koetswerk = Koetswerk.SUV,
                                  Registratie = "04/2016",
                                  Kilometerstand = 21017,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 13950M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1199,
                                  Vermogen = "80 pk(60 kW)",
                                  COTwee = "114 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.zwart.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "2008"),
                                  VoertuigArtikelNummer = "26",
                                  FiguurURL = @"~/images/vtgn/fronts/26_FRONT.jpg",
                                  VoertuigTitel= "GT Line 1.6",
                                  Koetswerk = Koetswerk.SUV,
                                  Registratie = "03/2017",
                                  Kilometerstand = 13973,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 18460M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1560,
                                  Vermogen = "98 pk(73 kW)",
                                  COTwee = "97 gr",
                                  Deuren = 5,
                                  Kleur = Kleur.rood.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "5008"),
                                  VoertuigArtikelNummer = "27",
                                  FiguurURL = @"~/images/vtgn/fronts/27_FRONT.jpg",
                                  VoertuigTitel= "1.6 BlueHDi GT Line",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "04/2017",
                                  Kilometerstand = 19000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 35900M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1560,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "112 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "GOLF"),
                                  VoertuigArtikelNummer = "28",
                                  FiguurURL = @"~/images/vtgn/fronts/28_FRONT.jpg",
                                  VoertuigTitel= "1.6 TDI Comfortline NAVI / PDC AV+AR",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "01/2018",
                                  Kilometerstand = 0,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 19998M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1598,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "102 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2018,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "GOLF"),
                                  VoertuigArtikelNummer = "29",
                                  FiguurURL = @"~/images/vtgn/fronts/29_FRONT.jpg",
                                  VoertuigTitel= "1.6 TDI Comfortline NAVI / PDC AV+AR",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "01/2018",
                                  Kilometerstand = 0,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 19998M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1598,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "102 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2018,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "GOLF"),
                                  VoertuigArtikelNummer = "30",
                                  FiguurURL = @"~/images/vtgn/fronts/30_FRONT.jpg",
                                  VoertuigTitel= "1.2 TSI ALLSTAR *NAVI/PARK AUTO*",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "01/2017",
                                  Kilometerstand = 15146,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 16248M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1197,
                                  Vermogen = "109 pk(81 kW)",
                                  COTwee = "114 gr",
                                  Deuren = 3,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "JETTA"),
                                  VoertuigArtikelNummer = "31",
                                  FiguurURL = @"~/images/vtgn/fronts/31_FRONT.jpg",
                                  VoertuigTitel= "1.4 TSI Hybrid 150Pk",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "01/2016",
                                  Kilometerstand = 17338,
                                  Brandstof = Brandstof.Hybride,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 20750M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1390,
                                  Vermogen = "150 pk(110 kW)",
                                  COTwee = "95 gr",
                                  Deuren = 4,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Grijs,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "JETTA"),
                                  VoertuigArtikelNummer = "32",
                                  FiguurURL = @"~/images/vtgn/fronts/32_FRONT.jpg",
                                  VoertuigTitel= "1.4 TSI DSG Hybrid Highline GPS + Xenon",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "03/2016",
                                  Kilometerstand = 13450,
                                  Brandstof = Brandstof.Hybride,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 20995M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1395,
                                  Vermogen = "148 pk(110 kW)",
                                  COTwee = "95 gr",
                                  Deuren = 4,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.wit.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Grijs,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "TOURAN"),
                                  VoertuigArtikelNummer = "33",
                                  FiguurURL = @"~/images/vtgn/fronts/33_FRONT.jpg",
                                  VoertuigTitel= "1.6 TDi DSG Trendline",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "03/2015",
                                  Kilometerstand = 29935,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 16999M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1598,
                                  Vermogen = "109 pk(81 kW)",
                                  COTwee = "115 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.beige.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2015,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Citroen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "C3"),
                                  VoertuigArtikelNummer = "34",
                                  FiguurURL = @"~/images/vtgn/fronts/34_FRONT.jpg",
                                  VoertuigTitel= "1.2 PureTech Shine NAVI / TOIT PANO / PDC AR",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "02/2018",
                                  Kilometerstand = 0,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 14498M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1199,
                                  Vermogen = "80 pk(60 kW)",
                                  COTwee = "101 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.wit.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2018,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Citroen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "C3"),
                                  VoertuigArtikelNummer = "35",
                                  FiguurURL = @"~/images/vtgn/fronts/35_FRONT.jpg",
                                  VoertuigTitel= "1.6 BlueHDi Seduction",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "06/2017",
                                  Kilometerstand = 0,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 12721M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1560,
                                  Vermogen = "74 pk(55 kW)",
                                  COTwee = "90 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Kia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "C4 AIRCROSS"),
                                  VoertuigArtikelNummer = "36",
                                  FiguurURL = @"~/images/vtgn/fronts/36_FRONT.jpg",
                                  VoertuigTitel= "1.6 e-Hdi 115 S&S Seduction 2WD",
                                  Koetswerk = Koetswerk.SUV,
                                  Registratie = "11/2016",
                                  Kilometerstand = 14025,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 22900M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1560,
                                  Vermogen = "115 pk(84 kW)",
                                  COTwee = "119 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.wit.ToString(),
                                  Binnenbekleding = Binnenbekleding.Semileder,
                                  Binnenkleur = Binnenkleur.Grijs,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Kia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "cee'd"),
                                  VoertuigArtikelNummer = "37",
                                  FiguurURL = @"~/images/vtgn/fronts/37_FRONT.jpg",
                                  VoertuigTitel= "navi edition 1.4 isg",
                                  Koetswerk = Koetswerk.Coupé,
                                  Registratie = "04/2017",
                                  Kilometerstand = 17520,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 13660M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1368,
                                  Vermogen = "98 pk(73 kW)",
                                  COTwee = "135 gr",
                                  Kleur = Kleur.rood.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Kia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "cee'd"),
                                  VoertuigArtikelNummer = "38",
                                  FiguurURL = @"~/images/vtgn/fronts/38_FRONT.jpg",
                                  VoertuigTitel= "1.4i Mind Xenon Navi Auto Airco Cruisecont Camera",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "04/2017",
                                  Kilometerstand = 5586,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 15300M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1368,
                                  Vermogen = "99 pk(74 kW)",
                                  COTwee = "135 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.zwart.ToString(),
                                  Binnenbekleding = Binnenbekleding.Semileder,
                                  Binnenkleur = Binnenkleur.Grijs,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Kia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "cee'd"),
                                  VoertuigArtikelNummer = "39",
                                  FiguurURL = @"~/images/vtgn/fronts/39_FRONT.jpg",
                                  VoertuigTitel= "1.4i Mind Xenon Navi Auto Airco Cruisecont Camera",
                                  Koetswerk = Koetswerk.Stadswagen,
                                  Registratie = "10/2015",
                                  Kilometerstand = 2150,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 14995M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1582,
                                  Vermogen = "110 pk(81 kW)",
                                  COTwee = "104 gr",
                                  Deuren = 3,
                                  Kleur = Kleur.wit.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2015,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Kia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "Carens"),
                                  VoertuigArtikelNummer = "40",
                                  FiguurURL = @"~/images/vtgn/fronts/40_FRONT.jpg",
                                  VoertuigTitel= "1.7 CRDi Automaat Sense + Panorama + Leder/Cuir",
                                  Koetswerk = Koetswerk.Monovolume,
                                  Registratie = "03/2014",
                                  Kilometerstand = 55650,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 15495M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1685,
                                  Vermogen = "134 pk(100 kW)",
                                  COTwee = "159 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Leder,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2014,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Dacia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "DUSTER"),
                                  VoertuigArtikelNummer = "41",
                                  FiguurURL = @"~/images/vtgn/fronts/41_FRONT.jpg",
                                  VoertuigTitel= "1.5 dCi 4x4 Prestige",
                                  Koetswerk = Koetswerk.SUV,
                                  Registratie = "04/2016",
                                  Kilometerstand = 50473,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 14998M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1461,
                                  Vermogen = "107 pk(80 kW)",
                                  COTwee = "123 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.zwart.ToString(),
                                  Binnenbekleding = Binnenbekleding.Leder,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Dacia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "DUSTER"),
                                  VoertuigArtikelNummer = "42",
                                  FiguurURL = @"~/images/vtgn/fronts/42_FRONT.jpg",
                                  VoertuigTitel= "1.5 dCi Black Shadow // Navi, Bluetooth, Zetelverw",
                                  Koetswerk = Koetswerk.SUV,
                                  Registratie = "10/2017",
                                  Kilometerstand = 1,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 17290M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1461,
                                  Vermogen = "107 pk(80 kW)",
                                  COTwee = "115 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.wit.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Dacia"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "DUSTER"),
                                  VoertuigArtikelNummer = "43",
                                  FiguurURL = @"~/images/vtgn/fronts/43_FRONT.jpg",
                                  VoertuigTitel= "1.6i Ambiance + GPS + Airco",
                                  Koetswerk = Koetswerk.SUV,
                                  Registratie = "10/2017",
                                  Kilometerstand = 0,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 13495M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1598,
                                  Vermogen = "113 pk(84 kW)",
                                  COTwee = "145 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.bruin.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Grijs,
                                  Bouwjaar = 2018,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "BMW"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "1 Reeks"),
                                  VoertuigArtikelNummer = "44",
                                  FiguurURL = @"~/images/vtgn/fronts/44_FRONT.jpg",
                                  VoertuigTitel= "M-SPORTSTUUR + GPS + CRUISE + PDC + AIRCO + AL",
                                  Koetswerk = Koetswerk.Stadswagen,
                                  Registratie = "03/2017",
                                  Kilometerstand = 22237,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 19795M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1499,
                                  Vermogen = "109 pk(81 kW)",
                                  COTwee = "116 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "BMW"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "1 Reeks"),
                                  VoertuigArtikelNummer = "45",
                                  FiguurURL = @"~/images/vtgn/fronts/45_FRONT.jpg",
                                  VoertuigTitel= "Airco, Alu velgen, Radio, Armsteun centraal",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "12/2013",
                                  Kilometerstand = 39439,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 14490M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1995,
                                  Vermogen = "114 pk(85 kW)",
                                  COTwee = "109 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2013,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Ford"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "B-Max"),
                                  VoertuigArtikelNummer = "46",
                                  FiguurURL = @"~/images/vtgn/fronts/46_FRONT.jpg",
                                  VoertuigTitel= "1.0i EcoBoost 100 Pk Titanium Shadow Black",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "01/2018",
                                  Kilometerstand = 35,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 16350M,
                                  GarantieTijd = "24 maanden",
                                  CC = 998,
                                  Vermogen = "99 pk(74 kW)",
                                  COTwee = "114 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.zwart.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2018,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Opel"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "CORSA"),
                                  VoertuigArtikelNummer = "47",
                                  FiguurURL = @"~/images/vtgn/fronts/47_FRONT.jpg",
                                  VoertuigTitel= "Turbo ecoFLEX S/S Enjoy",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "03/2017",
                                  Kilometerstand = 10500,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 11500M,
                                  GarantieTijd = "24 maanden",
                                  CC = 998,
                                  Vermogen = "90 pk(66 kW)",
                                  COTwee = "107 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.blauw.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A1"),
                                  VoertuigArtikelNummer = "48",
                                  FiguurURL = @"~/images/vtgn/fronts/48_FRONT.jpg",
                                  VoertuigTitel= "1.2 TFSI SPORTBACK S line Navigatie verw zetels",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "09/2014",
                                  Kilometerstand = 54727,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 16290M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1197,
                                  Vermogen = "84 pk(63 kW)",
                                  COTwee = "118 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 4,
                                  Kleur = Kleur.zilver.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2014,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A1"),
                                  VoertuigArtikelNummer = "49",
                                  FiguurURL = @"~/images/vtgn/fronts/49_FRONT.jpg",
                                  VoertuigTitel= "1.4 TDi",
                                  Koetswerk = Koetswerk.Berline,
                                  Registratie = "01/2017",
                                  Kilometerstand = 19896,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 19450M,
                                  GarantieTijd = "24 maanden",
                                  CC = 1422,
                                  COTwee = "98 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 4,
                                  Kleur = Kleur.rood.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Audi"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "A1"),
                                  VoertuigArtikelNummer = "50",
                                  FiguurURL = @"~/images/vtgn/fronts/50_FRONT.jpg",
                                  VoertuigTitel= "1.2 TFSI 44100 KM TOP ONDERH.+ ALLE ONDERH. FACTUR",
                                  Koetswerk = Koetswerk.Stadswagen,
                                  Registratie = "10/2011",
                                  Kilometerstand = 44100,
                                  Brandstof = Brandstof.Benzine,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 10900M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1197,
                                  Vermogen = "86 pk (63kW)",
                                  COTwee = "118 gr",
                                  Deuren = 3,
                                  Zitplaatsen = 4,
                                  Kleur = Kleur.zwart.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2011,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Personenwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Ford"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "Transit"),
                                  VoertuigArtikelNummer = "V1",
                                  FiguurURL = @"~/images/vtgn/fronts/V1_FRONT.jpg",
                                  VoertuigTitel= "2.2TDCi L4H3 - PRIJS INCLUSIEF BTW",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "07/2016",
                                  Kilometerstand = 9927,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 28435M,
                                  GarantieTijd = "12 maanden",
                                  CC = 2198,
                                  Vermogen = "155 pk (114 kW)",
                                  COTwee = "212 gr",
                                  Deuren = 5,
                                  Kleur = Kleur.zilver.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Opel"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "MOVANO"),
                                  VoertuigArtikelNummer = "V2",
                                  FiguurURL = @"~/images/vtgn/fronts/V2_FRONT.jpg",
                                  VoertuigTitel= "2.3 CDTi L2H2 R HD BiTurbo ecoFLEX (E5)",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "10/2016",
                                  Kilometerstand = 58090,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 15701M,
                                  GarantieTijd = "12 maanden",
                                  CC = 2299,
                                  Vermogen = "134 pk (100 kW)",
                                  COTwee = "216 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 3,
                                  Kleur = Kleur.zilver.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "TRAVELLER"),
                                  VoertuigArtikelNummer = "V3",
                                  FiguurURL = @"~/images/vtgn/fronts/V3_FRONT.jpg",
                                  VoertuigTitel= "2.0 BlueHDi L2 Standard Activ 2.0 BlueHDi",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "01/2017",
                                  Kilometerstand = 15000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 32750M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1997,
                                  Vermogen = "148 pk (110 kW)",
                                  COTwee = "139 gr",
                                  Deuren = 5,
                                  Kleur = Kleur.grijs.ToString(),
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "TRANSPORTER"),
                                  VoertuigArtikelNummer = "V4",
                                  FiguurURL = @"~/images/vtgn/fronts/V4_FRONT.jpg",
                                  VoertuigTitel= "2.0 TDi SCR BMT Baseline",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "11/2017",
                                  Kilometerstand = 9,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 35500M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1968,
                                  COTwee = "162 gr",
                                  Deuren = 5,
                                  Zitplaatsen = 5,
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                        new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Volkswagen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "TRANSPORTER"),
                                  VoertuigArtikelNummer = "V5",
                                  FiguurURL = @"~/images/vtgn/fronts/V5_FRONT.jpg",
                                  VoertuigTitel= "2.0 TDi SCR BMT Comfortline DSG",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "01/2017",
                                  Kilometerstand = 40000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 35999M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1968,
                                  COTwee = "153 gr",
                                  Deuren = 4,
                                  Zitplaatsen = 8,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Citroen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "JUMPER"),
                                  VoertuigArtikelNummer = "V6",
                                  FiguurURL = @"~/images/vtgn/fronts/V6_FRONT.jpg",
                                  VoertuigTitel= "",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "01/2016",
                                  Kilometerstand = 39116,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 18449M,
                                  GarantieTijd = "12 maanden",
                                  CC = 2198,
                                  Vermogen = "131 pk (96 kW)",
                                  COTwee = "195 gr",
                                  Deuren = 4,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenkleur = Binnenkleur.Grijs,
                                  Bouwjaar = 2016,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Citroen"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "JUMPER"),
                                  VoertuigArtikelNummer = "V7",
                                  FiguurURL = @"~/images/vtgn/fronts/V7_FRONT.jpg",
                                  VoertuigTitel= "2.0 BlueHDi L2H2 Business S&S",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "02/2017",
                                  Kilometerstand = 5000,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 21425M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1997,
                                  Vermogen = "129 pk (96 kW)",
                                  COTwee = "159 gr",
                                  Deuren =5,
                                  Zitplaatsen = 3,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Ford"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "Transit"),
                                  VoertuigArtikelNummer = "V8",
                                  FiguurURL = @"~/images/vtgn/fronts/V8_FRONT.jpg",
                                  VoertuigTitel= "2.0tdci 130pk 350L3H2 MTM 3500kg Sleep 2800kg 20.578€ netto excl btw",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "01/2017",
                                  Kilometerstand = 956,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 24900M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1998,
                                  Vermogen = "131 pk (96 kW)",
                                  COTwee = "191 gr",
                                  Kleur = Kleur.wit.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Ford"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "Transit"),
                                  VoertuigArtikelNummer = "V9",
                                  FiguurURL = @"~/images/vtgn/fronts/V9_FRONT.jpg",
                                  VoertuigTitel= "Limited 2.0 Td 130 PK Automaat",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "01/2018",
                                  Kilometerstand = 80,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Automaat,
                                  Prijs = 28435M,
                                  GarantieTijd = "12 maanden",
                                  CC = 2000,
                                  Vermogen = "129 pk (96 kW)",
                                  Deuren = 6,
                                  Zitplaatsen = 6,
                                  Kleur = Kleur.grijs.ToString(),
                                  Binnenbekleding = Binnenbekleding.Stof,
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2018,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                       new Voertuig{ Merk = context.Merken.Single(c => c.MerkNaam == "Peugeot"),
                                  MerkType = context.Types.Single(c => c.MerkTypeNaam == "TRAVELLER"),
                                  VoertuigArtikelNummer = "V10",
                                  FiguurURL = @"~/images/vtgn/fronts/V10_FRONT.jpg",
                                  VoertuigTitel= "2.0 BlueHDi L2 Standard Active S&S",
                                  Koetswerk = Koetswerk.Bedrijfsvoertuig,
                                  Registratie = "05/2017",
                                  Kilometerstand = 333,
                                  Brandstof = Brandstof.Diesel,
                                  Versnelling = Versnelling.Manueel,
                                  Prijs = 28935M,
                                  GarantieTijd = "12 maanden",
                                  CC = 1997,
                                  Vermogen = "148 pk (110 kW)",
                                  COTwee = "139 gr" ,
                                  Deuren = 4,
                                  Zitplaatsen = 5,
                                  Kleur = Kleur.bruin.ToString(),
                                  Binnenkleur = Binnenkleur.Zwart,
                                  Bouwjaar = 2017,
                                  VoertuigCategorie = context.VoertuigCategorieen.Single(c => c.VoertuigCategorieNaam == "Bestelwagen")
                       },
                };
                context.Voertuigen.AddRange(voertuigen);
                context.SaveChanges();
            }
            //Seed CategorieOnderdelen
            if (!context.CategorieOnderdelen.Any(o => o.ParentId == null))
            {
                CategorieOnderdelen[] categorieOnderdelen = new[]
                {
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Winterbanden", ParentId = null},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Wieldoppen", ParentId = null},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Trekhaken", ParentId = null},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Tapijten", ParentId = null},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Privacy Shades", ParentId = null},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Filters en Vloeistoffen", ParentId = null},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Bagage en Transport", ParentId = null}
                };
                foreach (CategorieOnderdelen o in categorieOnderdelen)
                {
                    context.CategorieOnderdelen.Add(o);
                }
                //context.CategorieOnderdelen.AddRange(categorieOnderdelen);
                context.SaveChanges();
            }
            
            //seed subcategorieën onderdelen
            if(!context.CategorieOnderdelen.Any(o => o.ParentId != null))
                { 

                CategorieOnderdelen[] categorieOnderdelen = new[]
                {
                     new CategorieOnderdelen{ OnderdelenCategorienaam = "Vaste Trekhaak", ParentId = 3},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Afneembare Trekhaak", ParentId = 3},
                    new CategorieOnderdelen{ OnderdelenCategorienaam = "Kabelset Trekhaken", ParentId = 3 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Koffermat", ParentId = 4 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Tapijt Stof", ParentId = 4 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Tapijt Rubber", ParentId = 4 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Clips", ParentId = 4 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Brandstoffilter", ParentId = 6 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Interieurfilter", ParentId = 6 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Koelvloeistof", ParentId = 6 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Luchtfilter", ParentId = 6 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Motorolie", ParentId = 6 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Remvloeistof", ParentId = 6 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Ruitensproeier", ParentId = 6 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Dakdrager", ParentId = 7 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Dakkoffer", ParentId = 7 },
                    new CategorieOnderdelen{ OnderdelenCategorienaam= "Fietsendrager", ParentId = 7 },
                };
                foreach (CategorieOnderdelen o in categorieOnderdelen)
                {
                    context.CategorieOnderdelen.Add(o);
                }

                //context.CategorieOnderdelen.AddRange(categorieOnderdelen);
                context.SaveChanges();
            }
            //Onderdeel Winterbanden
            //Seed Winterbanden
            if(!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 1))
            {
                OnderdelenProducten[] winterbanden = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_1",
                        Artikelnaam = "Michelin Alpin 5 205/55 R16 91T",
                        Artikelomschrijving = "De Michelin Alpin 5 205/55 R16 91T is een 16 inch band in de categorie winterbanden. Michelin is een A-merk band, " +
                                              "die de beste prestaties levert. De Michelin Alpin 5 205/55 R16 91T heeft gewichtsklasse 91; dat betekent dat elke band 615 kg " +
                                              "gewicht kan hebben.De snelheidsklasse van deze band is 'T'. Daarmee is de band ontwikkeld voor een snelheid tot 190 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 82.27M,
                        OpVoorraad = 47,
                        FiguurURL = @"~/images/onderdelen/banden/MI_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "91 (615kg per band)",
                            SnelheidIndex = "T (tot 190 km/h)",
                            Rolgeluid = "Rolgeluid	68dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_2",
                        Artikelnaam = "Goodyear UltraGrip 9 205/55 R16 91T",
                        Artikelomschrijving = "De Goodyear UltraGrip 9 205/55 R16 91T is een 16 inch band in de categorie winterbanden. Goodyear is een A-merk band, die de beste prestaties levert. De Goodyear UltraGrip 9 205/55 R16 91T heeft gewichtsklasse 91; dat betekent dat elke band 615 kg gewicht kan hebben. De snelheidsklasse van deze band is 'T'. Daarmee is de band ontwikkeld voor een snelheid tot 190 km/h. ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 88.52M,
                        OpVoorraad = 50,
                        FiguurURL = @"~/images/onderdelen/banden/GY_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "91 (615kg per band)",
                            SnelheidIndex = "T (tot 190 km/h)",
                            Rolgeluid = "Rolgeluid	68dB"
                        }

                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WB_3",
                        Artikelnaam = "Pirelli W 210 Snowcontrol Serie 3 205/55 R16 91H",
                        Artikelomschrijving = "De Pirelli W 210 Snowcontrol Serie 3 205/55 R16 91H is een 16 inch band in de categorie winterbanden. Pirelli is een A-merk band, die de beste prestaties levert. De W 210 Snowcontrol Serie 3 205/55 R16 91H heeft gewichtsklasse 91; dat betekent dat elke band 615 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h. ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 76.01M,
                        OpVoorraad = 24,
                        FiguurURL = @"~/images/onderdelen/banden/PI_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "91 (615kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	72dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_4",
                        Artikelnaam = "Dunlop Winter Sport 5 205/55 R16 91H",
                        Artikelomschrijving = "De Dunlop Winter Sport 5 205/55 R16 91H M+S is een 16 inch band in de categorie winterbanden. Dunlop is een A-merk band, die de beste prestaties levert. De Dunlop Winter Sport 5 205/55 R16 91H M+S heeft gewichtsklasse 91; dat betekent dat elke band 615 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 78.64M,
                        OpVoorraad = 100,
                        FiguurURL = @"~/images/onderdelen/banden/DU_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "91 (615kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	69dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_5",
                        Artikelnaam = "Continental WinterContact TS 860 195/65 R15 91H",
                        Artikelomschrijving = "De Continental WinterContact TS 860 195/65 R15 91H is een 15 inch band in de categorie winterbanden. Continental is een A-merk band, die de beste prestaties levert. De Continental WinterContact TS 860 195/65 R15 91H heeft gewichtsklasse 91; dat betekent dat elke band 615 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 71.56M,
                        OpVoorraad = 55,
                        FiguurURL = @"~/images/onderdelen/banden/CO_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "91 (615kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	72dB"
                        }

                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WB_6",
                        Artikelnaam = "Michelin Alpin 5 195/65 R15 95H",
                        Artikelomschrijving = "De Michelin Alpin 5 195/65 R15 95H XL is een 15 inch band in de categorie winterbanden. Michelin is een A-merk band, die de beste prestaties levert. De Michelin Alpin 5 195/65 R15 95H XL heeft gewichtsklasse 95; dat betekent dat elke band 690 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 77.13M,
                        OpVoorraad = 99,
                        FiguurURL = @"~/images/onderdelen/banden/MI_2_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "95 (690kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	68dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_7",
                        Artikelnaam = "Dunlop SP Winter Sport 195/65 R15 91H",
                        Artikelomschrijving = "De Dunlop SP Winter Sport 195/65 R15 91H DOT2014 is een 15 inch band in de categorie winterbanden. Dunlop is een A-merk band, die de beste prestaties levert. De SP Winter Sport 195/65 R15 91H DOT2014 heeft gewichtsklasse 91; dat betekent dat elke band 615 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 77.13M,
                        OpVoorraad = 1,
                        FiguurURL = @"~/images/onderdelen/banden/DU_2_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "91 (615kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	68dB"
                        }

                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WB_8",
                        Artikelnaam = "Continental WinterContact TS 860 225/45 R17 94V",
                        Artikelomschrijving = "De Continental WinterContact TS 860 225/45 R17 94V XL is een 17 inch band in de categorie winterbanden. Continental is een A-merk band, die de beste prestaties levert. De Continental WinterContact TS 860 225/45 R17 94V XL heeft gewichtsklasse 94; dat betekent dat elke band 670 kg gewicht kan hebben. De snelheidsklasse van deze band is 'V'. Daarmee is de band ontwikkeld voor een snelheid tot 240 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 131.29M,
                        OpVoorraad = 50,
                        FiguurURL = @"~/images/onderdelen/banden/CO_2_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "94 (670kg per band)",
                            SnelheidIndex = "V (tot 240 km/h)",
                            Rolgeluid = "Rolgeluid	72dB"
                        }

                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WB_9",
                        Artikelnaam = "Dunlop Winter Sport 5 225/45 R17 94H",
                        Artikelomschrijving = "De Dunlop Winter Sport 5 225/45 R17 94H M+S MFS XL is een 17 inch band in de categorie winterbanden. Dunlop is een A-merk band, die de beste prestaties levert. De Dunlop Winter Sport 5225/45 R17 94H M+S MFS XL heeft gewichtsklasse 94; dat betekent dat elke band 670 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h. ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 122.57M,
                        OpVoorraad = 98,
                        FiguurURL = @"~/images/onderdelen/banden/DU_3_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "94 (670kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	70dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_10",
                        Artikelnaam = "Hankook Winter i*cept EVO2 W320 225/45 R17 94H",
                        Artikelomschrijving = "De Hankook Winter i*cept EVO2 W320 225/45 R17 94H XL is een 17 inch band in de categorie winterbanden. De Hankook Winter i*cept EVO2 W320 225/45 R17 94H XL heeft gewichtsklasse 94; dat betekent dat elke band 670 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 88.30M,
                        OpVoorraad = 73,
                        FiguurURL = @"~/images/onderdelen/banden/HA_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "94 (670kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	72dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_11",
                        Artikelnaam = "Vredestein Wintrac Xtreme S 225/45 R17 94H",
                        Artikelomschrijving = "De Vredestein Wintrac Xtreme S 225/45 R17 94H XL is een 17 inch band in de categorie winterbanden. Vredestein is een A-merk band, die de beste prestaties levert. De Vredestein Wintrac Xtreme S 225/45 R17 94H XL heeft gewichtsklasse 94; dat betekent dat elke band 670 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 102.21M,
                        OpVoorraad = 80,
                        FiguurURL = @"~/images/onderdelen/banden/VE_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "94 (670kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	70dB"
                        }

                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WB_12",
                        Artikelnaam = "Kleber Krisalp HP3 225/40 R18 92V",
                        Artikelomschrijving = "De Kleber Krisalp HP3 225/40 R18 92V XL is een 18 inch band in de categorie winterbanden. Kleber is een goedkope band, te vinden in ons budgetsegment. De Kleber Krisalp HP3 225/40 R18 92V XL heeft gewichtsklasse 92; dat betekent dat elke band 630 kg gewicht kan hebben. De snelheidsklasse van deze band is 'V'. Daarmee is de band ontwikkeld voor een snelheid tot 240 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 98.95M,
                        OpVoorraad = 11,
                        FiguurURL = "GEEN AFBEELDING BESCHIKBAAR",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "92 (630kg per band)",
                            SnelheidIndex = "V (tot 240 km/h)",
                            Rolgeluid = "Rolgeluid	69dB"
                        }

                    },
                       new OnderdelenProducten
                    {
                        Artikelnummer = "WB_13",
                        Artikelnaam = "Maxxis Maxxis MA-PW 225/40 R18 92V",
                        Artikelomschrijving = "De Maxxis Maxxis MA-PW 225/40 R18 92V XL is een 18 inch band in de categorie winterbanden. De Maxxis Maxxis MA-PW 225/40 R18 92V XL heeft gewichtsklasse 92; dat betekent dat elke band 630 kg gewicht kan hebben. De snelheidsklasse van deze band is 'V'. Daarmee is de band ontwikkeld voor een snelheid tot 240 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 103.99M,
                        OpVoorraad = 1,
                        FiguurURL = "GEEN AFBEELDING BESCHIKBAAR",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "92 (630kg per band)",
                            SnelheidIndex = "V (tot 240 km/h)",
                            Rolgeluid = "Rolgeluid	72dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_14",
                        Artikelnaam = "Firestone Winterhawk 3 225/40 R18 92V",
                        Artikelomschrijving = "De Firestone Winterhawk 3 225/40 R18 92V XL M+S is een 18 inch band in de categorie winterbanden. De Firestone Winterhawk 3 225/40 R18 92V XL M+S heeft gewichtsklasse 92; dat betekent dat elke band 630 kg gewicht kan hebben. De snelheidsklasse van deze band is 'V'. Daarmee is de band ontwikkeld voor een snelheid tot 240 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 105.80M,
                        OpVoorraad = 43,
                        FiguurURL = @"~/images/onderdelen/banden/FI_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "92 (630kg per band)",
                            SnelheidIndex = "V (tot 240 km/h)",
                            Rolgeluid = "Rolgeluid	72dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_15",
                        Artikelnaam = "Pneumant Pneumant WINT. PNEUWIN 3 225/40 ",
                        Artikelomschrijving = "De Pneumant Pneumant WINT. PNEUWIN 3 225/40 R18 92V HP is een 18 inch band in de categorie winterbanden. De Pneumant WINT. PNEUWIN 3 225/40 R18 92V HP heeft gewichtsklasse 92; dat betekent dat elke band 630 kg gewicht kan hebben. De snelheidsklasse van deze band is 'V'. Daarmee is de band ontwikkeld voor een snelheid tot 240 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 104.99M,
                        OpVoorraad = 99,
                        FiguurURL = "GEEN AFBEELDING BESCHIKBAAR",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "92 (630kg per band)",
                            SnelheidIndex = "V (tot 240 km/h)",
                            Rolgeluid = "Rolgeluid	68dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_16",
                        Artikelnaam = "Bridgestone Blizzak LM-25 205/45 R16 83H",
                        Artikelomschrijving = "De Bridgestone Blizzak LM-25 205/45 R16 83H DOT2001 MFS is een 16 inch band in de categorie winterbanden. Bridgestone is een A-merk band, die de beste prestaties levert. De Blizzak LM-25 205/45 R16 83H DOT2001 MFS heeft gewichtsklasse 83; dat betekent dat elke band 487 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 64.99M,
                        OpVoorraad = 1,
                        FiguurURL = @"~/images/onderdelen/banden/BR_1_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "83 (487kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	71dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_17",
                        Artikelnaam = "Kumho WinterCraft WP51 205/45 R16 87H",
                        Artikelomschrijving = "De Kumho WinterCraft WP51 205/45 R16 87H XL is een 16 inch band in de categorie winterbanden. De Kumho WinterCraft WP51 205/45 R16 87H XL heeft gewichtsklasse 87; dat betekent dat elke band 545 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 63.73M,
                        OpVoorraad = 24,
                        FiguurURL = "GEEN AFBEELDING BESCHIKBAAR",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "87 (545kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	70dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_18",
                        Artikelnaam = "Toyo Snowprox S954 205/45 R16 87H",
                        Artikelomschrijving = "De Toyo Snowprox S954 205/45 R16 87H XL is een 16 inch band in de categorie winterbanden. Toyo is een goedkope band, te vinden in ons budgetsegment. De Toyo Snowprox S954 205/45 R16 87H XL heeft gewichtsklasse 87; dat betekent dat elke band 545 kg gewicht kan hebben. De snelheidsklasse van deze band is 'H'. Daarmee is de band ontwikkeld voor een snelheid tot 210 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 80.99M,
                        OpVoorraad = 50,
                        FiguurURL = "GEEN AFBEELDING BESCHIKBAAR",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "87 (545kg per band)",
                            SnelheidIndex = "H (tot 210 km/h)",
                            Rolgeluid = "Rolgeluid	71dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_19",
                        Artikelnaam = "Pirelli Cinturato Winter 205/45 R16 87T",
                        Artikelomschrijving = "De Pirelli Cinturato Winter 205/45 R16 87T is een 16 inch band in de categorie winterbanden. Pirelli is een A-merk band, die de beste prestaties levert. De Pirelli Cinturato Winter 205/45 R16 87T heeft gewichtsklasse 87; dat betekent dat elke band 545 kg gewicht kan hebben. De snelheidsklasse van deze band is 'T'. Daarmee is de band ontwikkeld voor een snelheid tot 190 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 117.95M,
                        OpVoorraad = 1,
                        FiguurURL = @"~/images/onderdelen/banden/PI_2_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "87 (545kg per band)",
                            SnelheidIndex = "T (tot 190 km/h)",
                            Rolgeluid = "Rolgeluid	66dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_20",
                        Artikelnaam = "Continental WinterContact TS 860 175/65 R14 82T",
                        Artikelomschrijving = "De Continental WinterContact TS 860 175/65 R14 82T is een 14 inch band in de categorie winterbanden. Continental is een A-merk band, die de beste prestaties levert. De Continental WinterContact TS 860 175/65 R14 82T heeft gewichtsklasse 82; dat betekent dat elke band 475 kg gewicht kan hebben. De snelheidsklasse van deze band is 'T'. Daarmee is de band ontwikkeld voor een snelheid tot 190 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 55.12M,
                        OpVoorraad = 4,
                        FiguurURL = @"~/images/onderdelen/banden/CO_3_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "82 (475kg per band)",
                            SnelheidIndex = "T (tot 190 km/h)",
                            Rolgeluid = "Rolgeluid	71dB"
                        }

                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WB_21",
                        Artikelnaam = "Vredestein Snowtrac 5 175/65 R14 82T",
                        Artikelomschrijving = "De Vredestein Snowtrac 5 175/65 R14 82T is een 14 inch band in de categorie winterbanden. Vredestein is een A-merk band, die de beste prestaties levert. De Vredestein Snowtrac 5 175/65 R14 82T heeft gewichtsklasse 82; dat betekent dat elke band 475 kg gewicht kan hebben. De snelheidsklasse van deze band is 'T'. Daarmee is de band ontwikkeld voor een snelheid tot 190 km/h. ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 46.64M,
                        OpVoorraad = 80,
                        FiguurURL = @"~/images/onderdelen/banden/VR_2_ZIJ.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "82 (475kg per band)",
                            SnelheidIndex = "T (tot 190 km/h)",
                            Rolgeluid = "Rolgeluid	69dB"
                        }

                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WB_22",
                        Artikelnaam = "Nokian WR D4 175/65 R14 82T",
                        Artikelomschrijving = "De Nokian WR D4 175/65 R14 82T is een 14 inch band in de categorie winterbanden. De Nokian WR D4175/65 R14 82T heeft gewichtsklasse 82; dat betekent dat elke band 475 kg gewicht kan hebben. De snelheidsklasse van deze band is 'T'. Daarmee is de band ontwikkeld voor een snelheid tot 190 km/h.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 1),
                        Prijs = 53.12M,
                        OpVoorraad = 48,
                        FiguurURL = "GEEN AFBEELDING BESCHIKBAAR",
                        Specificatie = new Specificaties
                        {
                            Type = "Winterband - Personenwagen",
                            Draagvermogen = "82 (475kg per band)",
                            SnelheidIndex = "T (tot 190 km/h)",
                            Rolgeluid = "Rolgeluid	68dB"
                        }

                    },
                };
                context.OnderdelenProducten.AddRange(winterbanden);
                context.SaveChanges();
            }
            //Onderdeel Wieldoppen
            //Seed Wieldoppen
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 2))
            {
                OnderdelenProducten[] wieldoppen = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_1",
                        Artikelnaam = "12 INCH WIELDOPPEN SET COLORADO ZILVER",
                        Artikelomschrijving = "12 inch wieldoppen set Colorado zilver , is 1 van de 3 kleinste wieldoppensets uit ons 12-inch programma.De Colorado is gemaakt " +
                        "van recycleerbaar kunststof en voorzien van een zilverkleurige en blanke laklaag.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 27.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/12 INCH WIELDOPPEN SET COLORADO ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "12 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_2",
                        Artikelnaam = "12 INCH WIELDOPPEN SET IOWA ZILVER",
                        Artikelomschrijving = "12 inch wieldoppen set Iowa zilver , 1 van de 3 kleinste wieldoppensets uit ons 12 inch  programma.De Iowa wieldoppen zijn gemaakt van recycleeerbaar kunststof " +
                        "en voorzien van een zilverkleurige en blanke laklaag. Worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking " +
                        "om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 27.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/12 INCH WIELDOPPEN SET IOWA ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "12 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_3",
                        Artikelnaam = "12 INCH WIELDOPPEN SET TINY S ZILVER",
                        Artikelomschrijving = "12 inch wieldoppen set Tiny-S zilver , 1 van de 3 kleinste wieldoppensets uit ons 12 inch programma. De Tiny-S wieldoppen zijn gemaakt van recycleerbaar kunststof en voorzien van meerdere lagen zilverkleurige lak." +
                        "De wieldoppen worden gemonteerd d.m.v. clips en een stalen ring in de rand van uw stalen velgen." +
                        "Worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden." +
                        " Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 25.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/12 INCH WIELDOPPEN SET TINY S ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "12 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_4",
                        Artikelnaam = "13 INCH WIELDOPPEN SET AGAT BW ZWART/WIT",
                        Artikelomschrijving = "13 inch wieldoppen set Agat BW zwart/wit  zijn gefabriceerd van buig- en recycleerbaar ABS kunststof en gespoten in een witte ondergrond met zwarte spaken." +
                        "Deze hippe 12-spaaks zwart-witte Agat BW wieldoppen worden eenvoudig en in nog geen 15 minuten in de rand geklikt van de stalen velgen van uw auto d.m.v. clips en een in omtrek verstelbare ring." +
                        "Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo geeft u de saaie of verweerde stalen velgen van uw auto in in minder dan een 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken/verzenden van een kartonnen afdekking om beschadiging aan de bovenste wielsierdop " +
                        "te voorkomen tijdens het transport van ons naar u.Controleer a.u.b. direct na ontvangst de wieldoppen. Mocht er een beschadiging zijn dan dit graag na ontvangst (binnen 12 uur) aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 29.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/13 INCH WIELDOPPEN SET AGAT BW ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "13 inch",
                            Kleur = Kleur.wit,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_5",
                        Artikelnaam = "13 INCH WIELDOPPEN SET AGAT WB WIT/ZWART",
                        Artikelomschrijving = "13 inch wieldoppen set Agat WB wit/zwart  zijn gefabriceerd van recycle- en buigbaar ABS kunststof en gespoten in een zwarte ondergrond met witte spaken.Deze hippe 12-spaaks wit-zwarte Agat WB wieldoppen worden eenvoudig en in nog geen 15 minuten in de rand geklikt van de stalen velgen " +
                        "van uw auto d.m.v. clips en een in omtrek verstelbare ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo geeft u de saaie of verweerde stalen velgen van uw auto in in minder dan een 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken/verzenden van een kartonnen afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u." +
                        "Controleer a.u.b. direct na ontvangst de wieldoppen. Mocht er een beschadiging zijn dan dit graag na ontvangst (binnen 12 uur)aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 29.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/13 INCH WIELDOPPEN SET AGAT WB WIT IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "13 inch",
                            Kleur = Kleur.wit,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WD_6",
                        Artikelnaam = "13 INCH WIELDOPPEN SET AGAT ZWART",
                        Artikelomschrijving = "113 inch wieldoppen set Agat mat zwart  De door ons geleverde wieldoppen hebben een gunstige prijsstelling en zijn van goede kwaliteit." +
                        "Deze 13 inch Agat mat zwart wieldoppen worden gemonteerd d.m.v. clips en een stalen ring in de rand van uw stalen velgen. Worden per set van vier stuks geleverd met 4 stalen " +
                        "ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden." +
                        "Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Geeft uw auto een nieuwe look met onze 13 inch wieldoppen. Bestel veilig en snel deze 13 inch Agat mat zwart wieldoppen.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 27.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/13 INCH WIELDOPPEN SET AGAT ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "13 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WD_7",
                        Artikelnaam = "13 INCH WIELDOPPEN SET ALABAMA STEENKOOL ZWART",
                        Artikelomschrijving = "13 inch wieldoppen set Alabama matt charcoal (steenkool zwart)  zijn gefabriceerd van eersteklas slagvast, " +
                        "recyclebaar ABS kunststof en gespoten in meerdere lagen steenkoolzwarte lak." +
                        "De wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een gepatendeerde, in 2 hoogtes verstelbare stalen ring." +
                        "Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo geeft u de saaie of verweerde stalen velgen van uw auto " +
                        "in ca. 15 minuten een compleet nieuwe look. De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. " +
                        "Deze voorzien wij voor het verpakken van kartonnen afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden." +
                        "Controleert a.u.b. direct na ontvangst de wieldoppen. Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief " +
                        "foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 30.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/13 INCH WIELDOPPEN SET ALABAMA STEENKOOL ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "13 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WD_8",
                        Artikelnaam = "13 INCH WIELDOPPEN SET AVALONE SB ZILVER/ZWART",
                        Artikelomschrijving = "13 inch wieldoppen set Avalone-SB zilver met zwarte accenten  zijn gefabriceerd van recyclebaar ABS kunststof en gespoten " +
                        "in meerdere lagen zwarte en zilverkleurige coating.Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. " +
                        "clips en een gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage " +
                        "is eenvoudig. Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van " +
                        "kartonnen afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u." +
                        "Controleer a.u.b. direct na ontvangst de wieldoppen. Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief " +
                        "foto van de beschadiging",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/13 INCH WIELDOPPEN SET AVALONE SB ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "13 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                       new OnderdelenProducten
                    {
                        Artikelnummer = "WD_9",
                        Artikelnaam = "13 INCH WIELDOPPEN SET CALIBER SB ZILVER/ZWART CARBON-LOOK",
                        Artikelomschrijving = "13 inch wieldoppen set Caliber-SB zilver/zwart met 3D carbon-look in de spaken  zijn gefabriceerd van recyclebaar ABS kunststof " +
                        "met 3D print en gespoten in meerdere lagen zwarte en zilverkleurige lak." +
                        "Deze set wieldoppen worden eenvoudig en snel geplaatst in de rand van de stalen velgen van uw auto d.m.v. clips en een gepatendeerde, " +
                        "in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van " +
                        "kartonnen afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u." +
                        "Controleer a.u.b. direct na ontvangst de wieldoppen. Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief " +
                        "foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/13 INCH WIELDOPPEN SET CALIBER SB ZILVER ZWART CARBON-LOOK IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "13 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_10",
                        Artikelnaam = "14 INCH WIELDOPPEN SET ALASKA ZWART/ZILVER",
                        Artikelomschrijving = "14 inch wieldoppen set Alaska IS hoogglans zilver met -zwarte rand en 5 wielmoerkapjes  zijn gefabriceerd van eersteklas slagvast, " +
                        "recyclebaar ABS kunststof en gespoten in meerdere lagen hoogglans zilverkleurige lak en brede hoogglanszwarte rand." +
                        "De wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een gepatendeerde, in 2 hoogtes verstelbare stalen ring." +
                        "Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo geeft u de saaie of verweerde stalen velgen van uw auto " +
                        "in ca. 15 minuten een compleet nieuwe look. De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. " +
                        "Deze voorzien wij voor het verpakken van kartonnen afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden." +
                        "Controleert a.u.b. direct na ontvangst de wieldoppen. Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail " +
                        "inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/14 INCH WIELDOPPEN SET ALASKA ZWART ZILVER IM.png",
                        Specificatie = new Specificaties
                        {
                            Formaat = "14 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_11",
                        Artikelnaam = "14 INCH WIELDOPPEN SET AVALONE SB ZILVER/ZWART",
                        Artikelomschrijving = "14 inch wieldoppen set Avalone-SB zilver met zwarte accenten  zijn gefabriceerd van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/14 INCH WIELDOPPEN SET SET AVALONE SB ZILVER ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "14 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WD_12",
                        Artikelnaam = "14 INCH WIELDOPPEN SET AVERA ZILVER/ZWART",
                        Artikelomschrijving = "14 inch wieldoppen set Avera zilver/mat zwart zijn gefabriceerd van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/14 INCH WIELDOPPEN SET AVERA ZILVER ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "14 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "WD_13",
                        Artikelnaam = "14 INCH WIELDOPPEN SET CLASSIC SE ZILVER",
                        Artikelomschrijving = "14 inch klassieke wieldoppen set Classic Special Edition zilver zijn gefabriceerd van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 41.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/14 INCH WIELDOPPEN SET CLASSIC SE ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "14 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_14",
                        Artikelnaam = "14 INCH WIELDOPPEN SET CYRKON ZILVER",
                        Artikelomschrijving = "14 inch wieldoppen set Cyrkon zilver zijn gefabriceerd van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/14 INCH WIELDOPPEN SET CYRKON ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "14 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_15",
                        Artikelnaam = "15 INCH BOLLE WIELDOPPEN SET CATO ZILVER",
                        Artikelomschrijving = "15 inch bolle wieldoppen Cato zilver van slagvast, van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/15 INCH BOLLE WIELDOPPEN SET CATO ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "15 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WD_16",
                        Artikelnaam = "15 INCH WIELDOPPEN SET ARKANSAS SG ZILVER/GUNMETAL",
                        Artikelomschrijving = "15 inch wieldoppen set Arkansas-SG zilver met antraciete spaken en chromen wielmoerkapjes  zijn gefabriceerd van eersteklas slagvast, van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 30.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/15 INCH WIELDOPPEN SET ARKANSAS SG ZILVER GUNMETAL IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "15 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "WD_17",
                        Artikelnaam = "15 INCH WIELDOPPEN SET DELAWARE GP MAT GUNMETAL/ROZE",
                        Artikelomschrijving = "15 inch wieldoppen set Delaware mat gunmetal/roze (pink) met chromen wielmoerkapjes zijn gefabriceerd van eersteklas slagvast, van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 32.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/15 INCH WIELDOPPEN SET DELAWARE GP MAT GUNMETAL ROZE IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "15 inch",
                            Kleur = Kleur.roze,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                        new OnderdelenProducten
                    {
                        Artikelnummer = "WD_18",
                        Artikelnaam = "15 INCH WIELDOPPEN SET GIGA R ZWART/ROOD",
                        Artikelomschrijving = "15 inch wieldoppen set Giga R mat zwart met rode rand zijn gefabriceerd van eersteklas slagvast, van recyclebaar ABS kunststof en gespoten in " +
                        "meerdere lagen zwarte en zilverkleurige coating. Deze set wieldoppen worden gemonteerd in de rand van de stalen velgen van uw auto d.m.v. clips en een " +
                        "gepatendeerde, in 2 hoogtes verstelbare stalen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig . " +
                        "Zo geeft u de saaie of verweerde stalen velgen van uw auto in ca. 15 minuten een compleet nieuwe look." +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos. Deze voorzien wij voor het verpakken van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het transport van ons naar u. Controleer a.u.b. direct na ontvangst de wieldoppen." +
                        " Mocht er een beschadiging zijn dan dit graag onmiddelijk aan ons melden per mail inclusief foto van de beschadiging.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 30.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/15 INCH WIELDOPPEN SET GIGA R ZWART ROOD IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "15 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                         new OnderdelenProducten
                    {
                        Artikelnummer = "WD_19",
                        Artikelnaam = "15 INCH WIELDOPPEN SET INFINITY GTS ZILVER/ZWART/CHROOM",
                        Artikelomschrijving = "15 inch wieldoppen set Infinity SC zilver/mat zwart/chroom. De door ons geleverde wieldoppen hebben een gunstige prijsstelling en zijn van goede kwaliteit." +
                        "Deze 15 inch Infinity SC zilver/chroom wieldoppen zijn universeel en passen op 99% van de stalen velgen die op de markt zijn. De wieldoppen worden gemonteerd d.m.v. clips en een stalen ring in de rand van uw stalen velgen. " +
                        "Worden per set van vier stuks geleverd met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om beschadiging " +
                        "aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig." +
                        "Zo kunt u uw auto in een korte tijd een nieuwe look geven.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 29.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/15 INCH WIELDOPPEN SET INFINITY GTS ZILVER ZWART CHROOM IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "15 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                          new OnderdelenProducten
                    {
                        Artikelnummer = "WD_20",
                        Artikelnaam = "16 INCH WIELDOPPEN SET EVO RACE ZILVER",
                        Artikelomschrijving = "16 inch wieldoppen set EVO Race zilver  zijn geproduceerd van slagvast, recyclebaar ABS kunststof en voorzien van meerdere lagen zilverkleurige " +
                        "lak en zwart/rode EVO Race logo op een spaak. De wieldoppen worden gemonteerd d.m.v. clips en een in hoogte of breedte verstelbare stalen ring in de rand van de stalen velgen " +
                        "van uw auto. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 39.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/16 INCH WIELDOPPEN SET EVO RACE ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "16 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                           new OnderdelenProducten
                    {
                        Artikelnummer = "WD_21",
                        Artikelnaam = "16 INCH WIELDOPPEN SET GIGA ZWART",
                        Artikelomschrijving = "16 inch wieldoppen set Giga mat zwart zijn geproduceerd van slagvast, recyclebaar ABS kunststof en voorzien van meerdere lagen zilverkleurige " +
                        "lak en Giga logo in het hart van de wieldop. De wieldoppen worden gemonteerd d.m.v. clips en een in hoogte of breedte verstelbare stalen ring in de rand van de stalen velgen " +
                        "van uw auto. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 34.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/16 INCH WIELDOPPEN SET GIGA ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "16 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WD_22",
                        Artikelnaam = "16 INCH WIELDOPPEN SET GRAL B ZWART",
                        Artikelomschrijving = "16 inch wieldoppen set Gral in het zwart  zijn gefabriceerd van buig- en recyclebaar kunststof en gespoten in meerdere lagen matzwarte lak. De wieldoppen worden gemonteerd d.m.v. clips en een in hoogte of breedte verstelbare stalen ring in de rand van de stalen velgen " +
                        "van uw auto. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 30.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/16 INCH WIELDOPPEN SET GRAL B ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "16 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_23",
                        Artikelnaam = "16 INCH WIELDOPPEN SET GRAL ZILVER",
                        Artikelomschrijving = "16 inch wieldoppen set Gral in zilver zijn gefabriceerd van buig- en recyclebaar kunststof en gespoten in meerdere lagen zilverkleurige coating. De wieldoppen worden gemonteerd d.m.v. clips en een in hoogte of breedte verstelbare stalen ring in de rand van de stalen velgen " +
                        "van uw auto. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 30.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/16 INCH WIELDOPPEN SET GRAL ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "16 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                        new OnderdelenProducten
                    {
                        Artikelnummer = "WD_24",
                        Artikelnaam = "16 INCH WIELDOPPEN SET LEMANS ZWART/GROEN",
                        Artikelomschrijving = "16 inch wieldoppen set LeMans mat zwart/groen  zijn geproduceerd van slagvast, recyclebaar ABS kunststof en voorzien van meerdere lagen groene en matzwarte lak en chromen ring. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 45.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/16 INCH WIELDOPPEN SET LEMANS ZWART GROEN IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "16 inch",
                            Kleur = Kleur.groen,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_25",
                        Artikelnaam = "17 INCH WIELDOPPEN SET CALIFORNIA ZILVER",
                        Artikelomschrijving = "17 inch wieldoppen California zilver en 5 wielmoerkapjes  zijn gefabriceerd van eersteklas slagvast, recyclebaar ABS kunststof en gespoten " +
                        "in meerdere lagen zilverkleurige lak en afgewerkt met een blanke laklaag. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 45.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/17 INCH WIELDOPPEN SET CALIFORNIA ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "17 inch",
                            Kleur = Kleur.zilver,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_26",
                        Artikelnaam = "17 INCH WIELDOPPEN SET NEW YORK MG MAT GUNMETAL",
                        Artikelomschrijving = "17 inch wieldoppen set New York-MG mat gunmetal met chroom ring  zijn gefabriceerd van eersteklas slagvast, recyclebaar ABS kunststof en gespoten in meerdere lagen mat antraciete coating." +
                        " Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 43.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/17 INCH WIELDOPPEN SET NEW YORK MG MAT GUNMETAL IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "17 inch",
                            Kleur = Kleur.gunmetal,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_27",
                        Artikelnaam = "17 INCH WIELDOPPEN SET SILVERSTONE PRO ZWART",
                        Artikelomschrijving = "17 inch wieldoppen Silverstone PRO mat zwart  zijn geproduceerd van slagvast, recyclebaar ABS kunststof en voorzien van meerdere lagen matzwarte lak en een chromen ring." +
                        " Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe look geven. " +
                        "De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen afdekking om " +
                        "beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er een beschadiging zijn " +
                        "dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 48.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/17 INCH WIELDOPPEN SET SILVERSTONE PRO ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "17 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "WD_28",
                        Artikelnaam = "17 INCH WIELDOPPEN SET VERMONT GUNMETAL/ZILVER",
                        Artikelomschrijving = "17 inch wieldoppen Vermont antraciet (ook wel gun metal genoemd)/zilver geven uw auto een compleet nieuwe en frisse look. " +
                        "De 17 inch Vermont wieldoppen worden eenvoudig gemonteerd aan de rand van uw velgen en worden in een stevige doos die wij voor het verpakken " +
                        "voorzien van kartonnen afdekking verstuurd. Let op dat u in de winter de wieldoppen op kamertemperatuur laat komen. " +
                        "Dit ivm de kunststof clips waarmee de wieldoppen vast komen te zitten.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 32.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/17 INCH WIELDOPPEN SET VERMONT GUNMETAL ZILVER IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "17 inch",
                            Kleur = Kleur.gunmetal,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "WD_29",
                        Artikelnaam = "17 INCH WIELDOPPEN SET VERMONT ZILVER/ZWART",
                        Artikelomschrijving = "17 inch wieldoppen Vermont zilver/mat zwart geven uw auto een compleet nieuwe en frisse look. " +
                        "De 17 inch Vermont wieldoppen worden eenvoudig gemonteerd aan de rand van uw velgen en worden in een stevige doos die wij voor het verpakken " +
                        "voorzien van kartonnen afdekking verstuurd. Let op dat u in de winter de wieldoppen op kamertemperatuur laat komen. " +
                        "Dit ivm de kunststof clips waarmee de wieldoppen vast komen te zitten.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 32.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/17 INCH WIELDOPPEN SET VERMONT ZILVER ZWART IM.jpg",
                        Specificatie = new Specificaties
                        {
                            Formaat = "17 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "WD_30",
                        Artikelnaam = "17 INCH WIELDOPPEN SET VOLANTE ZILVER/ZWART",
                        Artikelomschrijving = "17 inch wieldoppen Volante zilver/mat zwart  zijn geproduceerd van slagvast, recyclebaar ABS kunststof en voorzien van meerdere " +
                        "lagen zilverkleurige en matzwarte lak.De wieldoppen worden gemonteerd d.m.v. clips en een in hoogte of breedte verstelbare stalen ring in de rand van de " +
                        "stalen velgen van uw auto. Elke wieldop en ring zijn voorzien van een ventieluitsparing en de montage is eenvoudig. Zo kunt u uw auto in een korte tijd een nieuwe " +
                        "look geven. De wielsierdoppen worden geleverd per set van vier stuks met 4 stalen ringen in een stevige doos die wij voor het verpakken voorzien van kartonnen " +
                        "afdekking om beschadiging aan de bovenste wielsierdop te voorkomen tijdens het verzenden. Controleert u a.u.b. na ontvangst de wieldoppen en mocht er " +
                        "een beschadiging zijn dan dit onmiddelijk aan ons melden per mail inclusief foto.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 2),
                        Prijs = 48.99M,
                        FiguurURL = @"~/images/onderdelen/wieldoppen/17 INCH WIELDOPPEN SET VOLANTE ZILVER ZWART IM.png",
                        Specificatie = new Specificaties
                        {
                            Formaat = "17 inch",
                            Kleur = Kleur.zwart,
                            Materie = "Kunststof",
                            Montageset = "4 stuks"
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(wieldoppen);
                context.SaveChanges();
            }
            //Onderdeel Privacy Shades
            //seed privacy shades
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 5))
            {
                OnderdelenProducten[] privacyShades = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "PS_1",
                        Artikelnaam = "PS1 Sonniboy Audi A1 5 deurs 2012- CL 78309",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 152.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_1.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_2",
                        Artikelnaam = "PS2 Privacy Shades Audi A3 8V 5 deurs 2012",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 152.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_2.jpg",
                    },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_3",
                        Artikelnaam = "PS3 Sonniboy Audi A5 4drs 09- Compleet zonder achter portieren. CL 78296",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 152.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_3.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_4",
                        Artikelnaam =  "PS4 Sonniboy BMW 1-serie F20 5 deurs 2011- CL 78318",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 152.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_4.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_5",
                        Artikelnaam = "PS5 Sonniboy BMW 3 serie F31 Touring 2012- CL 78344",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 179.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_5.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_6",
                        Artikelnaam = "PS6 Sonniboy BMW 5-Serie Touring F11 5drs 10- Compleet CL 78276",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 179.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_6.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_7",
                        Artikelnaam = "PS7 Sonniboy Ford B-Max 2012- CL 78325",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 179.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_7.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_8",
                        Artikelnaam = "PS8 Sonniboy Ford C-Max 10- Compleet CL 78261",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 152.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_8.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_9",
                        Artikelnaam = "PS9 Sonniboy OP Astra J HB 5drs 09- CL 78268",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 179.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_9.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_10",
                        Artikelnaam = "PS10 Privacy Shades Opel Corsa D 5 deurs",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 98.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_10.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_11",
                        Artikelnaam = "PS11 Sonniboy Opel Agila B 08- Achterdeuren CL 78190",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 98.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_11.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_12",
                        Artikelnaam = "PS12 Privacy Shades Peugeot 207 5 deurs",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 98.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_12.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_13",
                        Artikelnaam = "PS13 Zonwering Peugeot 308 Hatchback 5-deurs 2013- 3-delig",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 132.74M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_13.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_14",
                        Artikelnaam = "PS14 Privacy Shades Peugeot 2008 2013",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 116.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_14.jpg",
                     },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_15",
                        Artikelnaam = "PS15 Privacy Shades Peugeot 5008 5 deurs 2009",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 125.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_15.jpg",
                     },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_16",
                        Artikelnaam = "PS16 Sonniboy VW Golf VII 5drs 2012- Compleet CL 78315",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 152.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_16.jpg",
                     },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_17",
                        Artikelnaam = "PS17 Zonwering Volkswagen Jetta VI Sedan 4drs 2010- 3-delig",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 132.75M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_17.jpg",
                   },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "PS_18",
                        Artikelnaam = "PS18 Sonniboy VW Touran 810- Compleet CL 78243",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 179.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_18.jpg",
                     },
                       new OnderdelenProducten
                    {
                        Artikelnummer = "PS_19",
                        Artikelnaam = "PS19 Originele Shades Citroen C3",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 109.26M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_19.jpg",
                     },
                       new OnderdelenProducten
                    {
                        Artikelnummer = "PS_20",
                        Artikelnaam = "PS20 Originele Shades Citroen C3 achterruit",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 94.24M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_20.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_21",
                        Artikelnaam = "PS21 Zonwering Citroen C4 AirCross Crossover 5drs 2012- 5-delig",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 162.84M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_21.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_22",
                        Artikelnaam = "PS22 Privacy Shades Kia Cee'd 5 deurs 2012",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 116.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_22.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_23",
                        Artikelnaam = "PS23 Privacy Shades Kia Carens 5 deurs 2013",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 143.09M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_23.jpg",
                     },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "PS_24",
                        Artikelnaam = "PS24 Sonniboy Dacia Duster 2010- CL 78374",
                        Artikelomschrijving = "Voor dit artikel geldt de Laagste prijsgarantie.<br/>Perfecte pasvorm, OEM. <br/>Fix zonder schroeven of boren door clips<br/>" +
                        "Beschermt kinderen tegen zonlicht en insecten.<br/>Sportieve en discrete look.<br/>Uw auto warmt minder snel op door de zon.<br/>Veilig brandwerend polyesterdoek, " +
                        "easy clean.<br/>Kan gebruikt worden met open ramen<br/>Dimt licht van achterliggende voertuigen.<br/>Demonteerbaar naar wens, zonder gebruikssporen.<br/>" +
                        "Achterraam shade bestaat uit 1 deel.<br/>Duidelijke handleiding.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 5),
                        Prijs = 152.10M,
                        FiguurURL = @"~/images/onderdelen/prShades/PS_24.jpg",
                     },
                };
                context.OnderdelenProducten.AddRange(privacyShades);
                context.SaveChanges();
            }
            //Onderdeel Trekhaken
            //seed vaste trekhaak
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 8))
            {
                OnderdelenProducten[] vasteTrekhaken = new[]
                {
                     new OnderdelenProducten
                    {
                        Artikelnummer = "VH_1",
                        Artikelnaam = "TH1 Trekhaak - vast 031-101 Bosal",
                        Artikelomschrijving= "TH1 Trekhaak - vast 031-101 Bosal",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 8),
                        Prijs = 80.47M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/vast/TH_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Vast kogelkop",
                            MaxVertikaleLast = 75,
                            Goedkeuring = "ECE4_3039",
                            Aanhangwagengewicht = 3500,
                            Montageset = "9O minuten"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "VH_4",
                        Artikelnaam = "TH4 Trekhaak - vast 034-581 Bosal",
                        Artikelomschrijving = "TH4 Trekhaak - vast 034-581 Bosal",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 8),
                        Prijs = 103.80M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/vast/TH_4.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Vast kogelkop",
                            MaxVertikaleLast = 75,
                            Goedkeuring = "ECE4_3039",
                            Aanhangwagengewicht = 1742,
                            Montageset = "9O minuten"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "VH_5",
                        Artikelnaam = "TH5 Trekhaak - vast 037-261 Bosal",
                        Artikelomschrijving = "TH5 Trekhaak - vast 037-261 Bosal",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 8),
                        Prijs = 105.41M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/vast/TH_5.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Vast kogelkop",
                            MaxVertikaleLast = 75,
                            Goedkeuring = "ECE4_4098",
                            Aanhangwagengewicht = 1900,
                            Montageset = "9O minuten"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "VH_6",
                        Artikelnaam = "TH6 Trekhaak - vast 037-141 Bosal",
                        Artikelomschrijving = "TH6 Trekhaak - vast 037-141 Bosal",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 8),
                        Prijs = 107.02M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/vast/TH_6.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Vast kogelkop",
                            MaxVertikaleLast = 85,
                            Aanhangwagengewicht = 2100,
                            Goedkeuring = "ECE4_4064",
                            Montageset = "9O minuten"
                        }
                    },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "VH_7",
                        Artikelnaam = "TH7 Trekhaak - vast 037-641 Bosal",
                        Artikelomschrijving = "TH7 Trekhaak - vast 037-641 Bosal",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 8),
                        Prijs = 107.02M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/vast/TH_7.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Vast kogelkop",
                            MaxVertikaleLast = 75,
                            Aanhangwagengewicht = 1742,
                            Goedkeuring = "ECE4_4333",
                            Montageset = "9O minuten"
                        }
                    },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "VH_8",
                        Artikelnaam = "TH8 Trekhaak vast 040-521 Bosal",
                        Artikelomschrijving = "TH8 Trekhaak vast 040-521 Bosal",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 8),
                        Prijs = 111.04M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/vast/TH_8.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Vast kogelkop",
                            MaxVertikaleLast = 85,
                            Aanhangwagengewicht = 1415,
                            Goedkeuring = "ECE7_011507",
                            Montageset = "9O minuten"
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(vasteTrekhaken);
                context.SaveChanges();
            }
            //seed afneembare trekhaak
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 22))
            {
                OnderdelenProducten[] afneemTrekhaak = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "LH_2",
                        Artikelnaam = "TH2 Trekhaak - afneembaar Bosal",
                        Artikelomschrijving = "TH2 Trekhaak - afneembaar Bosal",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 140.81M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 75,
                            Goedkeuring = "ECE4_2313",
                            Aanhangwagengewicht = 1100
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "LH_3",
                        Artikelnaam = "GDW Towbars Group - Afneembaar",
                        Artikelomschrijving = "GDW Towbars Group - Afneembaar",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 125.11M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_3.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 75,
                            Goedkeuring = "ECE4_6363",
                            Aanhangwagengewicht = 1400
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "LH_10",
                        Artikelnaam = "TH10 Trekhaak - afneembaar ECE7_0340",
                        Artikelomschrijving= "TH10 Trekhaak - afneembaar ECE7_0340",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 80.47M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_10.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 75,
                            Goedkeuring = "ECE7_0340",
                            Aanhangwagengewicht = 1450
                        }
                    },
                      new OnderdelenProducten
                    {
                        Artikelnummer = "LH_9",
                        Artikelnaam = "TH9 Trekhaak - afneembaar Trh. Bosal PSA AK",
                        Artikelomschrijving = "TH9 Trekhaak - afneembaar Trh. Bosal PSA AK",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 80.47M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_9.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 50,
                            Goedkeuring = "EC2280",
                            Aanhangwagengewicht = 1100
                        }
                    },
                        new OnderdelenProducten
                    {
                        Artikelnummer = "LH_11",
                        Artikelnaam = "TH11 Trekhaak - afneembaar EC3852",
                        Artikelomschrijving = "TH11 Trekhaak - afneembaar EC3852",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 189.09M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_11.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 75,
                            Goedkeuring = "EC3852",
                            Aanhangwagengewicht = 1200
                        }
                    },
                          new OnderdelenProducten
                    {
                        Artikelnummer = "LH_12",
                        Artikelnaam = "TH12 Trekhaak - afneembaar ECE7_0320",
                        Artikelomschrijving = "TH12 Trekhaak - afneembaar ECE7_0320",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 187.14M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_12.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 50,
                            Goedkeuring = "ECE7_0320",
                            Aanhangwagengewicht = 900
                        }
                    },
                             new OnderdelenProducten
                    {
                        Artikelnummer = "LH_13",
                        Artikelnaam = "TH13 Trekhaak - afneembaar  ECE7_011388",
                        Artikelomschrijving = "TH13 Trekhaak - afneembaar  ECE7_011388",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 217.26M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_13.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 75,
                            Goedkeuring = ": ECE7_011388",
                            Aanhangwagengewicht = 1500
                        }
                    },
                              new OnderdelenProducten
                    {
                        Artikelnummer = "LH_14",
                        Artikelnaam = "TH14 BRINK KIT Trekhaak afneembaar (BMU) + 13p kabelset",
                        Artikelomschrijving = "TH14 BRINK KIT Trekhaak afneembaar (BMU) + 13p kabelset",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 22),
                        Prijs = 377.94M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/afneem/TH_14.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Afneembare kogel",
                            MaxVertikaleLast = 85,
                            Goedkeuring = "55R",
                            Aanhangwagengewicht = 2000
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(afneemTrekhaak);
                context.SaveChanges();
            }
            //seed kabelset trekhaak
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 21))
            {
                OnderdelenProducten[] kabelsTrekhaak = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "KB_1",
                        Artikelnaam = "Kabelset universeel 7-polig Brink",
                        Artikelomschrijving= "Universele kabelset, 7-polig",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 21),
                        Prijs = 8.65M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/kabelset/KB_1_7POL.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "KB_3",
                        Artikelnaam = "Kabelset universeel 13-polig",
                        Artikelomschrijving = "Aantal polen: 13.<br/>Spanning (Volt): 12.<br/>Aanhanginrichting: E - set zonder originele steekverbinderaansluitingen." +
                        "<br/>Aanhanginrichting: zonder checkcontrolesysteem.<br/>Aanhanginrichting: zonder knipperlampcontrole(C2-moduke).<br/>Uitvoering: Voor voertuigen " +
                        "zonder CAN bussysteem.<br/>Aanhanginrichting: zonder mistlampuitschakeling.<br/>Aanhanginrichting: PDC niet uitschakelbaar.<br/>aanhanginrichting: zonder " +
                        "aanhanger stabilisatie.<br/>Uitvoering: Incl.power supply.<br/>Uitvoering: Incl.battery charge.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 21),
                        Prijs = 39.73M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/kabelset/KB_3_13POL.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "KB_2",
                        Artikelnaam = "Uni Electroset 7 polig",
                        Artikelomschrijving = "Universele Kabelset met module. 7 polige set voorzien van module,kabelboom, stekkerdoos en 3M kabel mofjes en een duidelijk aansluitschema.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 21),
                        Prijs = 89.95M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/kabelset/KB_2_7POL.jpg",
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "KB_4",
                        Artikelnaam = "Uni Electroset 13 polig",
                        Artikelomschrijving = "Universele Kabelset met module.<br/>13 polige set voorzien van module, kabelboom, stekkerdoos en 3M kabel mofjes en een " +
                        "duidelijk aansluitschema.<br/>De kabelset is geschikt voor auto's met CAN BUS CHECK CONTROL SFL LFS.<br/>Deze electroset is niet voorzien van " +
                        "originele stekkers, echter hoeft er niet worden 'geknipt'in de originele bekabeling.<br/>De aanbevolen kabelset is wel voorzien van stekkers deze " +
                        "simpel op (mits aanwezige voorbereiding) de auto kan worden aangesloten.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 21),
                        Prijs = 177.92M,
                        FiguurURL = @"~/images/onderdelen/trekhaken/kabelset/KB_4_13POL.jpg",
                    },
                };
                context.OnderdelenProducten.AddRange(kabelsTrekhaak);
                context.SaveChanges();
            }
            //Onderdeel Bagage en Transport
            //seed dakdrager
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 9))
            {
                OnderdelenProducten[] dakdrager = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DD_1",
                        Artikelnaam = "DD1 Dakdrager",
                        Artikelomschrijving = "DD1 Dakdrager",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 9),
                        Prijs = 84.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakdrager/DD_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Materie = "Aluminium",
                            Kleur = Kleur.zilver,
                            Goedkeuring = "TUV",
                            GarantieTermijn = "3 jaar",
                            Breedte = 1046 //in mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DD_2",
                        Artikelnaam = "DD2 Winprice Dakdragerset staal basic",
                        Artikelomschrijving = "Winprice dakdragerset basic.<br/><br/>set van 2 dakdragers.<br/>50 kg draagvermogen.<br/>4.2 kg eigen gewicht.<br/>Grotendeels " +
                        "pre assembled.<br/>Inclusief afwerk rubberstrip.<br/>Duurzaam staal.<br/>Citycrash getest",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 9),
                        Prijs = 85.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakdrager/DD_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Materie = "Aluminium",
                            Kleur = Kleur.zwart,
                            Goedkeuring = "TUV en Citycrash",
                            GarantieTermijn = "2 jaar",
                            Breedte = 49,
                            Hoogte = 30,
                            Vergrendeling = "Moeren"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DD_3",
                        Artikelnaam = "DD3 G3 Dakdragers Pacific Staal",
                        Artikelomschrijving = "G3 dakdragers Pacific.<br/><br/>Italiaans design.<br/>ISO / PAS 11154.<br/>Set van 2 dragers<br/>Grotendeels " +
                        "pre assembled.<br/>Montage op originele bevestigingspunten van de auto.<br/>De G3 Pacific dakdragers zijn voor auto's zonder dakreling en " +
                        "zijn door hun unieke ontwerp snel en makkelijk te monteren op het dak van uw auto. De dakdragers kunnen met gemak 50 kg dragen. " +
                        "De dakdragers zijn uitvoerig getest en absoluut veilig tot dit gewicht.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 9),
                        Prijs = 99.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakdrager/DD_3.jpg",
                        Specificatie = new Specificaties
                        {
                            Materie = "Staal",
                            Kleur = Kleur.zwart,
                            Goedkeuring = "TUV en Citycrash",
                            GarantieTermijn = "2 jaar",
                            Breedte = 49,
                            Hoogte = 30,
                            Vergrendeling = "4 slotjes met 2 sleutels"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DD_4",
                        Artikelnaam = "DD4 Dakdragerset Twinny Load Staal S16",
                        Artikelomschrijving = "Kwalitatief hoogstaande dakdragers van Twinny Load zijn leverbaar in speciaal hoogwaardig staal of aluminium.<br/>De " +
                        "dakdragers van Twinny Load zijn snel en eenvoudig te monteren.<br/>De Twinny Load dakdragers zijn TUV en GS goedgekeurd.<br/>Twinny Load 627914114 " +
                        "<br/>Pasklare dakdragers voor uw auto.<br/>75kg belastbaar" +
                        "Snelle en eenvoudige montage.<br/>Keuringen: DIN 75302; ISO 11154; TÜV; GS",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 9),
                        Prijs = 113.05M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakdrager/DD_4.jpg",
                        Specificatie = new Specificaties
                        {
                            Materie = "Staal",
                            Kleur = Kleur.zwart,
                            Goedkeuring = "TUV en GS getest",
                            GarantieTermijn = "2 jaar",
                            Vergrendeling = "inclusief slot"
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(dakdrager);
                context.SaveChanges();
            }
            //seed dakkoffer
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 15))
            {
                OnderdelenProducten[] dakkoffer = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_1",
                        Artikelnaam = "DK1 G3 dakkoffer Arjes 320 zwart",
                        Artikelomschrijving = "Deze prachtige Arjes 320 zwarte dakkoffer kunt u gelijk uit de doos gebruiken en geeft u de gewenste extra ruimte. " +
                        "Voor super snelle montage en/of wingbar dakdragers koopt u de G3 Rapid fixing kit 0360815",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 139.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_1.jpg",
                        Specificatie = new Specificaties
                        {
                            
                            Kleur = Kleur.zwart,
                            GarantieTermijn = "5 jaar",
                            Inhoud= 240, //in liter
                            Lengte= 133,// in cm 
                            Opening= "Rechterzijde",
                            Breedte = 73, //in cm,
                            Hoogte = 37,
                            MaxBelading = 50, //in kg
                            Materie = "P.S/ABS",
                            Gewicht = 7,//in kg
                            Vergrendeling = "Centraal afsluitbaar met slot",
                            Montageset = "Ja, voor dakdragers met een maximale breedte van 60 mm",
                            CityCrash = true
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_2",
                        Artikelnaam = "DK2 Hapro dakkoffer Roady 350 Silver Grey",
                        Artikelomschrijving = "De Hapro Roady is nestbaar, wat betekent dat de bodem omgekeerd in het deksel past. Zo bespaart u in opbergruimte. " +
                        "De Hapro Roady is door zijn handzaam formaat ook zeer geschikt voor de wat kleinere auto's.  ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 149.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_2.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.zilver,
                            GarantieTermijn = "3 jaar",
                            Inhoud= 300, //in liter
                            Lengte= 135,// in cm 
                            Opening= "Achterzijde",
                            Breedte = 78, //in cm,
                            Hoogte = 40,
                            MaxBelading = 50, //in kg
                            Materie = "ABS/ASA",
                            Gewicht = 11,//in kg
                            Vergrendeling = "Afsluitbaar met slot"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_3",
                        Artikelnaam = "DK3 G3 dakkoffer Hydra 480 grijs",
                        Artikelomschrijving = "Deze prachtige Hydra 480 grijze dakkoffer kunt u gelijk uit de doos gebruiken en geeft u de gewenste extra ruimte! " +
                        "Voor super snelle montage en/of wingbar dakdragers koopt u de G3 Rapid Fixing 0360815 ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 189.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_3.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.grijs,
                            GarantieTermijn = "3 jaar",
                            Inhoud= 390, //in liter
                            Lengte= 197,// in cm 
                            Opening= "Rechterzijde",
                            Breedte = 74, //in cm,
                            Hoogte = 37,
                            MaxBelading = 75, //in kg
                            Materie = "PS/ABA",
                            Gewicht = 13,//in kg
                            Vergrendeling = "Centraal afsluitbaar met slot",
                            Montageset= "Ja, snelmontage voor dakdragers met een maximale breedte van 60 mm"
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_4",
                        Artikelnaam = "DK4 G3 dakkoffer Spark 420 zwart",
                        Artikelomschrijving = "Deze dakkoffer is ook geschikt voor combinatie vervoer met bijvoorbeeld een dak-fietsendrager naast de koffer. " +
                        "De bescheiden breedte is geen probleem, de lengte zorgt ervoor dat deze koffer uw bagage tot zelf 75 kg met gemak kan bergen! " +
                        "De Spark 420 zwart metallic dakkoffer is een mooie, sportieve en gestroomlijnde dakkoffer en kunt u gelijk uit de doos gebruiken . " +
                        "De Spark 420 wordt standaard geleverd met Rapid (wingbar) Fixing Kit en zal passen op dragers tot maximaal 90mm",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 199.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_4.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.zwart,
                            GarantieTermijn = "5 jaar",
                            Inhoud= 370, //in liter
                            Lengte= 193,// in cm 
                            Opening= "Linker en rechterzijde",
                            Breedte = 55, //in cm,
                            Hoogte = 50,
                            MaxBelading = 75, //in kg
                            Materie = "PS/ABS",
                            Gewicht = 12,//in kg
                            Vergrendeling = "Centraal afsluitbaar met slot",
                            Montageset= "Ja, snelmontage voor dakdragers met een maximale breedte van 60 mm",
                            CityCrash = true
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_5",
                        Artikelnaam = "DK5 G3 dakkoffer Helios 400",
                        Artikelomschrijving = "De Helios 400 zwarte dakkoffer is een mooie gestroomlijnde brede koffer. U kunt deze gelijk uit de doos gebruiken. " +
                        "Voor super snelle montage en/of wingbar dakdragers koopt u de G3 Rapid Fixing Kit 0360815",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 199.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_5.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.zwart,
                            GarantieTermijn = "5 jaar",
                            Inhoud= 330, //in liter
                            Lengte= 144,// in cm 
                            Opening= "Linker en rechterzijde",
                            Breedte = 86, //in cm,
                            Hoogte = 38,
                            MaxBelading = 75, //in kg
                            Materie = "PS/ABS",
                            Gewicht = 10,//in kg
                            Vergrendeling = "Centraal afsluitbaar met slot",
                            Montageset= "Ja, snelmontage voor dakdragers met een maximale breedte van 60 mm",
                            CityCrash = true
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_6",
                        Artikelnaam = "DK6 G3 dakkoffer Reef 390 [extra breed]",
                        Artikelomschrijving = "De Reef 390 zwarte dakkoffer is gestroomlijnd, sportief en lekker breed! Dit maakt de dakkoffer zeer geschikt " +
                        "voor SUV of auto's met geringe dak lengte. U kunt deze gelijk uit de doos gebruiken. De Reef 390 wordt standaard geleverd met Rapid Fixing Kit en zal passen op dragers tot maximaal 90mm.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 179.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_6.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.zwart,
                            GarantieTermijn = "5 jaar",
                            Inhoud= 335, //in liter
                            Lengte= 125,// in cm 
                            Opening= "Linker en rechterzijde",
                            Breedte = 102, //in cm,
                            Hoogte = 40,
                            MaxBelading = 75, //in kg
                            Materie = "PS/ABS",
                            Gewicht = 10,//in kg
                            Vergrendeling = "Centraal afsluitbaar met slot",
                            Montageset= "Ja, snelmontage voor dakdragers met een maximale breedte van 60 mm",
                            CityCrash = true
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_7",
                        Artikelnaam = "DK7 Opvouwbare daktas 320L Zwart 105x80x45cm",
                        Artikelomschrijving = "Deze opvouwbare daktas is niet alleen handig in gebruik maar ook zeer compact op te bergen. " +
                        "Deze 'rugzak voor uw auto' is uitgevoerd in een zware kwaliteit PVC gecoat polyester met 100% waterproof ritssluiting.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 125.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_7.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.zwart,
                            Inhoud= 320, //in liter
                            GarantieTermijn="1 jaar",
                            Lengte= 105,// in cm 
                            Opening= "Linker en rechterzijde",
                            Breedte = 80, //in cm,
                            Hoogte = 45,
                            MaxBelading = 50, //in kg
                            Materie = "100% waterproof nylon en ritssluiting",
                            Gewicht = 10,//in kg
                            Vergrendeling = "Centraal afsluitbaar met slot",
                            Montageset= "Ja, snelmontage voor dakdragers met een maximale breedte van 60 mm",
                            CityCrash = true
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_8",
                        Artikelnaam = "DK8 Hapro Softbox",
                        Artikelomschrijving = "De Hapro Softbox is makkelijk op te bergen voor diegene die niet genoeg ruimte hebben voor een 'traditionele' Hapro dakkoffer. " +
                        "Om uw bagage veilig te vervoeren kunnen de dubbel deelbare ritsen aan beide zijden afgesloten worden met de twee meegeleverde hangsloten.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 179.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_8.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.zwart,
                            GarantieTermijn = "2 jaar",
                            Inhoud= 375, //in liter
                            Lengte= 110,// in cm 
                            Opening= "Linker en rechterzijde",
                            Breedte = 85, //in cm,
                            Hoogte = 42,
                            MaxBelading = 50, //in kg
                            Materie = "Weerbestendig textiel ABS/ASA",
                            Gewicht = 12//in kg
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "DK_9",
                        Artikelnaam = "DK9 G3 dakkoffer Helios 400 Camou",
                        Artikelomschrijving = "De Helios 400 Camouflage dakkoffer is naast een stoere eyecatcher ook een mooie " +
                        "gestroomlijnde brede koffer. U kunt deze gelijk uit de doos gebruiken. Voor super snelle montage en/of wingbar dakdragers koopt u de G3 Rapid Fixing Kit 0360815 (zie meebestellentip).",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 249.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_9.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.grijs,
                            GarantieTermijn = "5 jaar",
                            Inhoud= 330, //in liter
                            Lengte= 144,// in cm 
                            Opening= "Linker en rechterzijde",
                            Breedte = 86, //in cm,
                            Hoogte = 38,
                            MaxBelading = 50, //in kg
                            Materie = "PS/ABS",
                            Gewicht = 10,//in kg
                            Vergrendeling = "Centraal afsluitbaar met slot",
                            Montageset= "Ja, snelmontage voor dakdragers met een maximale breedte van 60 mm",
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "DK_10",
                        Artikelnaam = "DK10 Pro-User opvouwbare daktas 270 liter 50031",
                        Artikelomschrijving = "De dakkoffer is zeer compact waardoor deze gemakkelijk is " +
                        "op te bergen. Met een opslagcapaciteit van 270 liter is de Pro User opvouwbare daktas de ideale dakkoffer voor bijvoorbeeld een weekendje weg met uw auto. De Pro User daktas biedt dan genoeg ruimte voor uw extra bagage.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 15),
                        Prijs = 89.95M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/dakkoffer/DK_10.jpg",
                        Specificatie = new Specificaties
                        {

                            Kleur = Kleur.zwart,
                            GarantieTermijn = "1 jaar",
                            Inhoud= 270, //in liter
                            Lengte= 100,// in cm 
                            Opening= "Linker en rechterzijde",
                            Breedte = 80, //in cm,
                            Hoogte = 40,
                            MaxBelading = 50, //in kg
                            Materie = "100% waterproof Dubbellaags PVC Doek"                           
                        }
                    },

                };
                context.OnderdelenProducten.AddRange(dakkoffer);
                context.SaveChanges();
            }
            //seed fietsendragers
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 24))
            {
                OnderdelenProducten[] fietsendrager = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "FD_1",
                        Artikelnaam = "FD1 Bosal Traveller II E-bike fietsendrager 070-532",
                        Artikelomschrijving = "Waarom de Bosal Traveller II E-bike?<br/><br/>Afsluitbaar.<br/>Compact opbergen (opklapbaar).<br/>Zeer geschikt voor " +
                        "E-bikes.<br/>Kantelbaar door handig voetpedaal!<br/>Multifunctionele stekker (7/13-polig).<br/>Inclusief mistachterlicht en " +
                        "achteruitrijlicht.<br/>Anti-diefstal beveiliging.<br/>Gratis opbergtas.<br/>Wielbevestiging met snelsluiting<br/>ANWB 2016 Rijtest<br/>Rijtest " +
                        "Stabiel.<br/>Tijdens het vervoer staan de fietsen relatief stil op de drager, mede dankzij de instelbare goten en wielhouders zijn de wielen zeer goed " +
                        "vast te zetten. De wielen van fietsen met een iets grotere wielbasis, zoals randonneurs, kunnen iets overhellen.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 24),
                        Prijs = 329.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/fietsdrager/FD_1.jpg",
                        Specificatie = new Specificaties
                        {

                            AantalFietsen = 2,
                            Fietstypes = "Geschikt voor e-bikes",
                            Vergrendeling = "Ja met slot",
                            MaxBelading = 60,//in kg
                            StekkerAansluiting = "7-polig en 13-polig",
                            Mistlicht= true,// in cm 
                            Kantelfunctie= Kantelfunctie.Voetbediening,
                            Inklapbaar = true, //in cm,
                            Hoogte = 37                            
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "FD_2",
                        Artikelnaam = "FD2 Twinny Load e-Wing fietsendrager 7913050",
                        Artikelomschrijving = "Waarom de Twinny Load e-Wing?<br/><br/>Geschikt voor elektrische fietsen.<br/>Diefstalbeveiliging.<br/>Verstelbare " +
                        "wielhouders.<br/>Mistlicht & Achteruitrijlicht.<br/>Kantelfunctie.<br/>IMax gewicht: 58 kg" +
                        "<br/>ANWB fietsdragertest: Goed!.<br/>Ook voor 7-polig met verloop stekker (los bij bestellen).",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 24),
                        Prijs = 309.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/fietsdrager/FD_2.jpg",
                        Specificatie = new Specificaties
                        {

                            AantalFietsen = 2,
                            Fietstypes = "Geschikt voor e-bikes",
                            Vergrendeling = "Ja met slot",
                            MaxBelading = 58,//in kg
                            StekkerAansluiting = "13-polig",
                            Mistlicht= true,// in cm 
                            Kantelfunctie= Kantelfunctie.Voetbediening,
                            Inklapbaar = true, //in cm,
                            Montageset = "Hefboom op trekhaak", //Montage
                            Lengte= 135,
                            Breedte= 69,
                            Hoogte=70,   //Afmetingen:135x69x70
                            Gewicht = 17, // in kg
                            Dikte = 23 //afstand tussen fietsen in cm
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "FD_3",
                        Artikelnaam = "FD3 Cykell T3 fietsendrager 31",
                        Artikelomschrijving = "Waarom de Cykell Just Click T3?<br/><br/>Geschikt voor elektrische fietsen.<br/>Draagvermogen 60 kg.<br/>3" +
                        "fietsen.<br/>Geschikt voor elektrische fietse.<br/>Kantelfunctie met voetpedaal." +
                        "<br/>7-polig en 13-polig.<br/>Handige wieltjes",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 24),
                        Prijs = 675.00M,
                        FiguurURL = @"~/images/onderdelen/bagTrans/fietsdrager/FD_3.jpg",
                        Specificatie = new Specificaties
                        {

                            AantalFietsen = 3,
                            Fietstypes = "Geschikt voor e-bikes",
                            Vergrendeling = "Ja met slot",
                            MaxBelading = 60,//in kg
                            StekkerAansluiting = "7-polig en 13-polig",
                            Mistlicht= true,// in cm 
                            Kantelfunctie= Kantelfunctie.Voetbediening,
                            Inklapbaar = true, //in cm,
                            Montageset = "Just Click op trekhaak", //Montage
                            Materie = "Aluminium",
                            GarantieTermijn = "5 jaar",
                            Lengte= 100,
                            Breedte= 77,
                            Hoogte= 72,   //Afmetingen:135x69x70
                            Gewicht = 20, // in kg
                            Dikte = 20 //afstand tussen fietsen in cm
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(fietsendrager);
                context.SaveChanges();
            }
            //Onderdeel Tapijten
            //seed koffermat
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 20))
            {
                OnderdelenProducten[] koffermat = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPK_1",
                        Artikelnaam = "TPK1 Kofferbakbeschermer universeel",
                        Artikelomschrijving = "Kenmerken<br/>Vervaardigd uit 600d duurzaam polyester met waterdichte coating.<br/>U kunt de klittenband aan de achterkant " +
                        "van de mat en de flappen bevestigen aan de binnenbekleding van de wagen.<br/>Voorzien van drukknoppen en rits om de flappen aan elkaar te " +
                        "bevestigen.<br/>Beschermt uw kofferbak tegen dierenhaar, vuil en modder.<br/>Gemakkelijk te plaatsen en uit te nemen.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 20),
                        Prijs = 23.36M,
                        FiguurURL = @"~/images/onderdelen/tapijten/koffermat/TPK_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Kleur= Kleur.zwart,
                            Gewicht= 1075, //in gr
                            Mat = "100 x 100 cm",
                            Flappen = "100 x 40 cm"

                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPK_2",
                        Artikelnaam = "TPK2 Anti-Slip Kofferbakmat 120x90cm",
                        Artikelomschrijving = "Universele anti-slip mat",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 20),
                        Prijs = 23.70M,
                        FiguurURL = @"~/images/onderdelen/tapijten/koffermat/TPK_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Kleur= Kleur.zwart,
                            Gewicht= 800, //in gr
                            Mat = "120 x 90 cm",
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPK_3",
                        Artikelnaam = "TPK3 Kofferbak mat rubber",
                        Artikelomschrijving = "100% Natuurrubber. 139x108cm. Universeel, op maat te snijden. Beschermt uw kofferbak " +
                        "tegen vuil, modder, sneeuw en vocht. Gemakkelijk.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 20),
                        Prijs = 35.99M,
                        FiguurURL = @"~/images/onderdelen/tapijten/koffermat/TPK_3.jpg",
                        Specificatie = new Specificaties
                        {
                            Kleur= Kleur.zwart,
                            Gewicht= 700, //in gr
                            Mat = "139 x 108 cm",
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(koffermat);
                context.SaveChanges();
            }
            //seed tapijt rubber
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 18))
            {
                OnderdelenProducten[] tapijtRubber = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPR_1",
                        Artikelnaam = "TPR1 Mattenset rubber 'Contour'",
                        Artikelomschrijving = "100% Premium rubber. Complete set: 2 voor- en 2 achtermatten ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 18),
                        Prijs = 24.30M,
                        FiguurURL = @"~/images/onderdelen/tapijten/rubber/TPR_1.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPR_2",
                        Artikelnaam = "TPR2 Powermat Rubber mattenset universeel, set á 4 stuks (voor+achter)",
                        Artikelomschrijving = "Met vanille geur-Powermat. Rubberen mattenset universeel, set à 4 stuks (voor+achter)",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 18),
                        Prijs = 21.06M,
                        FiguurURL = @"~/images/onderdelen/tapijten/rubber/TPR_2.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPR_3",
                        Artikelnaam = "TPR3 Mattenset rubber Voyager",
                        Artikelomschrijving = "Complete set: 2 voor- en 2 achtermatten ",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 18),
                        Prijs = 21.06M,
                        FiguurURL = @"~/images/onderdelen/tapijten/rubber/TPR_3.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPR_4",
                        Artikelnaam = "TPR4 Mattenset rubbercarpet 'Dakota'",
                        Artikelomschrijving = "Universeel voor de meeste auto's. Exclusief design. Houdt uw auto vrij van vocht en " +
                        "vuil. Ideaal in alle seizoenen. Hoogwaardige kwaliteit.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 18),
                        Prijs = 31.49M,
                        FiguurURL = @"~/images/onderdelen/tapijten/rubber/TPR_4.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TPR_5",
                        Artikelnaam = "TPR5 Rubber matten set, 4 delig",
                        Artikelomschrijving = "Kenmerken:<br/><br/>Zware rubberen mattenset<br/>Rug van nopjesrubber<br/>Vuilopvang profiel<br/>Geleverd aan " +
                        "hanger<br/>Ggemakkelijk schoon te maken / af te spuiten (ook met hogedrukspuit)<br/>Hoofdmaten van de voormatten zijn 50 x 70 cm. De " +
                        "achtermatten zijn rechthoekig 46 x 34 cm.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 18),
                        Prijs = 63.11M,
                        FiguurURL = @"~/images/onderdelen/tapijten/rubber/TPR_5.jpg",
                    },
                };
                context.OnderdelenProducten.AddRange(tapijtRubber);
                context.SaveChanges();
            }
            //seed tapijt stof
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 19))
            {
                OnderdelenProducten[] tapijtStof = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TP_1",
                        Artikelnaam = "TP1 Automatten 'Malibu' universeel zwart",
                        Artikelomschrijving = "Complete set: 2 voor- en 2 achtermatten",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 19),
                        Prijs = 14.99M,
                        FiguurURL = @"~/images/onderdelen/tapijten/stof/TP_1.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TP_2",
                        Artikelnaam = "TP2 Mattenset uni 'Pink Lady'",
                        Artikelomschrijving = "Universeel. Verfraait en beschermt uw auto-interieur. Achterzijde genopte anti-slip. Makkelijk te reinigen, volledig wasbaar. 4 stuks",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 19),
                        Prijs = 21.06M,
                        FiguurURL = @"~/images/onderdelen/tapijten/stof/TP_2.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TP_3",
                        Artikelnaam = "TP3 Mattenset universeel 'Tribal' rood",
                        Artikelomschrijving = "Universeel, 4-delig. Voor verfraaiing en bescherming van het interieur. Genopte anti-slip onderlaag. Eenvoudig te reinigen, volledig wasbaar.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 19),
                        Prijs = 23.50M,
                        FiguurURL = @"~/images/onderdelen/tapijten/stof/TP_3.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TP_4",
                        Artikelnaam = "TP4 Mattenset 4-delig type C Grafiet",
                        Artikelomschrijving = "Mattenset 4-delig type C Grafiet.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 19),
                        Prijs = 30.00M,
                        FiguurURL = @"~/images/onderdelen/tapijten/stof/TP_4.jpg",
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "TP_5",
                        Artikelnaam = "TP5 Mattenset universeel 'Alu-carbon'",
                        Artikelomschrijving = "Carbon-look. Universeel voor de meeste auto's en 4x4 wagens. Eenvoudig te reinigen. " +
                        "Set bestaande uit 2 voor- en 2 achtermatten.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 19),
                        Prijs = 24.99M,
                        FiguurURL = @"~/images/onderdelen/tapijten/stof/TP_5.jpg",
                    },
                };
                context.OnderdelenProducten.AddRange(tapijtStof);
                context.SaveChanges();
            }
            //seed tapijt clips
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 17))
            {
                OnderdelenProducten[] tapijtClips = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "CL_1",
                        Artikelnaam = "CL1 Mattenclips 'VAG diversen' - set á 2 stuks",
                        Artikelomschrijving = "Set MatClip 2 stuks tbv VAG.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 17),
                        Prijs = 1.05M,
                        FiguurURL = @"~/images/onderdelen/tapijten/clips/CL_1.jpg",
                    },
                   new OnderdelenProducten
                   {
                        Artikelnummer = "CL_2",
                        Artikelnaam = "CL2 Universele mattenclips 'StyleFit' - 4 stuks t.b.v. 2 matten",
                        Artikelomschrijving = "Set a 4 mattenclips voor 2 matten.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 17),
                        Prijs = 4.95M,
                        FiguurURL = @"~/images/onderdelen/tapijten/clips/CL_2.jpg",
                   },
                };
                context.OnderdelenProducten.AddRange(tapijtClips);
                context.SaveChanges();
            }
            //Onderdeel Filters en Voeistoffen
            //seed brandstoffilter
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 23))
            {
                OnderdelenProducten[] brandstoffilters = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "BF_1",
                        Artikelnaam = "BF1 Brandstoffilter",
                        Artikelomschrijving = "BF1 Brandstoffilter",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 23),
                        Prijs = 11.43M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/brandstofFilter/BF_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Dikte= Convert.ToInt32(136.5), //mm
                            Gewicht= 37, //in gr
                            Binnendiameter= 11, //mm
                            Buitendiameter = 78 //mm
                        }
                    },
                   new OnderdelenProducten
                   {
                        Artikelnummer = "BF_2",
                        Artikelnaam = "BF2 Brandstoffilter WK 842-2 Mann",
                        Artikelomschrijving = "BF2 Brandstoffilter WK 842-2 Mann",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 23),
                        Prijs = 10.89M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/brandstofFilter/BF_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Binnendiameter= 61, //mm
                            Buitendiameter = 81, //mm
                            Hoogte = 158, //mm
                            Schroefdraad = "M 16 X 1.5" //Schroefdraad uitgang: M 16 X 1.5
                        }
                   },
                   new OnderdelenProducten
                   {
                        Artikelnummer = "BF_3",
                        Artikelnaam = "BF3 Brandstoffilter P 917 X Mann",
                        Artikelomschrijving = "BF3 Brandstoffilter P 917 X Mann",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 23),
                        Prijs = 6.55M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/brandstofFilter/BF_3.jpg",
                        Specificatie = new Specificaties
                        {
                            Binnendiameter= 19, //mm
                            Buitendiameter = 85, //mm
                            Hoogte = Convert.ToInt32(71.5), //mm
                        }
                   },
                   new OnderdelenProducten
                   {
                        Artikelnummer = "BF_4",
                        Artikelnaam = "BF4 Brandstoffilter N0001 Bosch",
                        Artikelomschrijving = "BF4 Brandstoffilter N0001 Bosch",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 23),
                        Prijs = 24.22M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/brandstofFilter/BF_4.jpg",
                        Specificatie = new Specificaties
                        {
                            Binnendiameter= 19, //mm
                            Buitendiameter = 67, //mm
                            Hoogte = 97, //mm
                        }
                   },
                   new OnderdelenProducten
                   {
                        Artikelnummer = "BF_5",
                        Artikelnaam = "BF5 Brandstoffilter 21622 FEBI",
                        Artikelomschrijving = "BF5 Brandstoffilter 21622 FEBI",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 23),
                        Prijs = 17.71M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/brandstofFilter/BF_5.jpg",
                        Specificatie = new Specificaties
                        {
                            Materie = "staal", //materiaal
                            Dikte = 193, //mm
                            Gewicht = 31, //gr
                            Binnendiameter= 19, //mm
                            Buitendiameter = 67, //mm
                            Hoogte = 97, //mm
                            Type = "Met waterafscheider" //Filter Type
                        }
                   },
                };
                context.OnderdelenProducten.AddRange(brandstoffilters);
                context.SaveChanges();
            }
            //seed interieurluchtfilter
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 16))
            {
                OnderdelenProducten[] interieurluchtfilter = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "IF_1",
                        Artikelnaam = "IF1 Interieurluchtfilter 11566 FEBI",
                        Artikelomschrijving = "IF1 Interieurluchtfilter 11566 FEBI",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 16),
                        Prijs = 11.85M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/interieurfilter/IF_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Carbon filter", //Filter type
                            Dikte= Convert.ToInt32(30.0), //mm
                            Lengte = 281, //mm
                            Gewicht = 209, //in gr
                            Breedte = 206 //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "IF_2",
                        Artikelnaam = "IF2 Interieurluchtfilter 21314 FEBI",
                        Artikelomschrijving = "IF2 Interieurluchtfilter 21314 FEBI",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 16),
                        Prijs = 14.37M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/interieurfilter/IF_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Carbon filter", //Filter type
                            Dikte= Convert.ToInt32(34.0), //mm
                            Lengte = 288, //mm
                            Gewicht = 125, //in gr
                            Breedte = 215 //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "IF_3",
                        Artikelnaam = "IF3 Interieurfilter",
                        Artikelomschrijving = "IF3 Interieurfilter",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 16),
                        Prijs = 8.58M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/interieurfilter/IF_3.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Pollenfilter", //Filter type
                            Dikte= Convert.ToInt32(12.0), //mm
                            Lengte = 185, //mm
                            Gewicht = 80, //in gr
                            Breedte = 181 //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "IF_4",
                        Artikelnaam = "IF4 Interieurluchtfilter 27873 FEBI",
                        Artikelomschrijving = "IF4 Interieurluchtfilter 27873 FEBI",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 16),
                        Prijs = 9.77M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/interieurfilter/IF_4.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Pollenfilter", //Filter type
                            Dikte= Convert.ToInt32(18.0), //mm
                            Lengte = 203, //mm
                            Gewicht = 40, //in gr
                            Breedte = 177 //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "IF_5",
                        Artikelnaam = "IF5 Interieurfilter TC-1017 AMC",
                        Artikelomschrijving = "IF5 Interieurfilter TC-1017 AMC",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 16),
                        Prijs = 8.23M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/interieurfilter/IF_5.jpg",
                        Specificatie = new Specificaties
                        {
                            Lengte = 215, //mm
                            Hoogte = 30, //in mm
                            Breedte = 150 //mm
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(interieurluchtfilter);
                context.SaveChanges();
            }
            //seed koelvloeistof
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 14))
            {
                OnderdelenProducten[] koelvloeistof = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "KV_1",
                        Artikelnaam = "KV1 Coolant Longlife -36 [1L] mengbaar",
                        Artikelomschrijving = "Universele long-life koelvloeistof mengbaar met de meeste commerciële koelvloeistoffen. " +
                        "Het tast geen rubbers, kunststoffen, metalen, aluminium of legeringen aan. Volg altijd het voorschrift van de fabrikant. " +
                        "Schadelijk bij opname door de mond. Buiten bereik van kinderen bewaren. In het geval van inslikken onmiddellijk een " +
                        "arts raadplegen en verpakking of etiket tonen. bevat 1,2-ethaandiol (ethyleenglycol)",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 14),
                        Prijs = 2.29M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/koelvloeistof/KV_1.jpg",
                        Specificatie = new Specificaties
                        {
                            
                            Inhoud = 1, //liter
                            Mengbaar = "Ja (neemt kleur van huidige vloeistof aan)"
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "KV_2",
                        Artikelnaam = "KV2 Coolant Longlife -36 [5L] mengbaar",
                        Artikelomschrijving = "Universele long-life koelvloeistof mengbaar met de meeste commerciële koelvloeistoffen. " +
                        "Het tast geen rubbers, kunststoffen, metalen, aluminium of legeringen aan. Volg altijd het voorschrift van de fabrikant. " +
                        "Schadelijk bij opname door de mond. Buiten bereik van kinderen bewaren. In het geval van inslikken onmiddellijk een " +
                        "arts raadplegen en verpakking of etiket tonen. bevat 1,2-ethaandiol (ethyleenglycol)",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 14),
                        Prijs = 15.50M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/koelvloeistof/KV_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Mengbaar = "Ja (neemt kleur van huidige vloeistof aan)"
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(koelvloeistof);
                context.SaveChanges();
            }
            //seed luchtfilter
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 13))
            {
                OnderdelenProducten[] luchtfilter = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "LF_1",
                        Artikelnaam = "LF1 Luchtfilter S3971 Bosch",
                        Artikelomschrijving = "LF1 Luchtfilter S3971 Bosch",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 13),
                        Prijs = 12.09M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/luchtfilter/LF_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Filter insert", //filtertype
                            Lengte = 257, //mm
                            Hoogte = 44, //mm
                            Breedte = 115 //mm 
                            
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "LF_2",
                        Artikelnaam = "LF2 Luchtfilter S9404 Bosch",
                        Artikelomschrijving = "LF2 Luchtfilter S9404 Bosch",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 13),
                        Prijs = 13.44M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/luchtfilter/LF_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Filter insert", //filtertype
                            Lengte = 345, //mm
                            Hoogte = 70, //mm
                            Breedte = 136 //mm 
                            
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "LF_3",
                        Artikelnaam = "LF3 Luchtfilter 21110 FEBI",
                        Artikelomschrijving = "LF3 Luchtfilter 21110 FEBI",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 13),
                        Prijs = 6.20M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/luchtfilter/LF_3.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Filter insert", //filtertype
                            Materie = "Papier", //materiaal
                            Dikte = 62, //mm
                            Buitendiameter = 275, //mm
                            Gewicht = 200, //gr
                            Binnendiameter = 225 //mm
                            
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "LF_4",
                        Artikelnaam = "LF4 Luchtfilter S0156 Bosch",
                        Artikelomschrijving = "LF4 Luchtfilter S0156 Bosch",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 13),
                        Prijs = 15.93M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/luchtfilter/LF_4.jpg",
                        Specificatie = new Specificaties
                        {
                            Type = "Filter insert", //filtertype
                            Buitendiameter = 149, //mm
                            Hoogte = 170, //mm
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "LF_5",
                        Artikelnaam = "LF5 Luchtfilter C 35 154 Mann",
                        Artikelomschrijving = "LF5 Luchtfilter C 35 154 Mann",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 13),
                        Prijs = 15.78M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/luchtfilter/LF_5.jpg",
                        Specificatie = new Specificaties
                        {
                            Breedte = 149, //mm
                            Hoogte = 70, //mm
                            Lengte = 345 //mm
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(luchtfilter);
                context.SaveChanges();
            }
            //seed motorolie
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 12))
            {
                OnderdelenProducten[] motorolie = new[] 
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_1",
                        Artikelnaam = "MO1 Motorolie 5W40 Fullsynthetic Winprice 1L",
                        Artikelomschrijving = "Vol Synthetische olie voor gebruik in benzine en dieselmotoren van personenwagens en lichte bedrijfswagens.<br/> Niet geschikt voor roetfilters. " +
                        "<br/>Verlaagt brandstofgebruik. <br/>Bevat calciumalkarylsulfonaat met lange keten. <br/>Kan een allergische reactie veroorzaken. " +
                        "<br/>Volg altijd olie voorschrift van de fabrikant van uw voertuig.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 4.30M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 1, //liter
                            Type = "5W40", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_2",
                        Artikelnaam = "MO2 Motorolie 5W30 Fullsynthetic Longlife Winprice 1L",
                        Artikelomschrijving = "Vol Synthetische olie voor gebruik in benzine-, LPG- en dieselmotoren van personenwagens en lichte bedrijfswagens.<br/>Geschikt voor roetfilters. " +
                        "<br/>Verlaagt brandstofgebruik. <br/>Bevat calciumalkarylsulfonaat met lange keten. <br/>Kan een allergische reactie veroorzaken. " +
                        "<br/>Volg altijd olie voorschrift van de fabrikant van uw voertuig.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 6.95M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 1, //liter
                            Type = "5W30", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_3",
                        Artikelnaam = "MO3 Motorolie Winprice 10W40 A3B4 1L",
                        Artikelomschrijving = "Vol Synthetische olie voor gebruik in benzine- en dieselmotoren van personenwagens en lichte bedrijfswagens.<br/>Niet geschikt voor roetfilters. " +
                        "<br/>Verlaagt brandstofgebruik. <br/>Bevat calciumalkarylsulfonaat met lange keten. <br/>Kan een allergische reactie veroorzaken. " +
                        "<br/>Volg altijd olie voorschrift van de fabrikant van uw voertuig.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 3.48M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_3.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 1, //liter
                            Type = "10W40", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_4",
                        Artikelnaam = "MO4 Motorolie Castrol Edge Titanium 5W-30 LL 5L 15669D",
                        Artikelomschrijving = "De volledig synthetische Castrol Edge 5W30 LONGLIFE Titanium is geschikt voor benzine en diesel motoren.<br/>De unieke " +
                        "TITANIUM FST™ in CASTROL EDGE verandert de fysieke manier waarop motorolie zich gedraagt onder extreme belasting. Na een complex " +
                        "raffinage proces vormen de Titanium partikels een verbinding met een organische polymer." +
                        "<br/>Deze unieke FluidStrengthTechnology™ versterkt de olie, zodat het metaal-op-metaal contact teruggebracht wordt.<br/>" +
                        "Vermindert de wrijving tot 15%. <br/>Tot 45% sterker dan vooraanstaande concurrenten. " +
                        "<br/>Behoudt kracht tot minstens 140 uur langer dan Castrol motorolie zonder titanium. De motoren van tegenwoordig werken harder, " +
                        "worden warmer en worden meer belast dan ooit tevoren. Autofabrikanten maken steeds kleinere, krachtigere en efficiëntere motoren. " +
                        "Downsizing, turbo's en geavanceerde motorontwerpen(zoals een onmiddellijke motorolie injectie en gevarieerde kleppenintervallen) hebben de druk " +
                        "in de motor en dus ook op de motorolie verdubbeld.<br/>De motorolie aan onderdelen zoals aan de nokkenas en de tuimelaar moeten een belasting " +
                        "kunnen weerstaan die soms hoger is dan 10.000kg per cm². Bij zo'n belasting is de motorolie de enige bescherming tussen de metalen oppervlakken en " +
                        "daarom moet deze uiterst sterk zijn.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 44.95M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_4.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Type = "5W30", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_5",
                        Artikelnaam = "MO5 Motorolie Kroon-Oil Torsynth 5W40 5L",
                        Artikelomschrijving = "Torsynth 5W-40 is een universele, brandstof besparende motorolie, geschikt voor alle benzine- en dieselmotoren, " +
                        "zowel zonder als met turbo-oplading, in personenwagens en bestelwagens.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 26.05M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_5.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Type = "5W40", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_6",
                        Artikelnaam = "MO6 Motorolie Castrol GTX Ultraclean 10W-40 A3B4 5ltr 15A4D4",
                        Artikelomschrijving = "Castrol GTX 10W40<br/>BESCHERM UW AUTO TEGEN SCHADELIJKE VORMING VAN SLUDGE MET CASTROL GTX.<br/>Het is meer dan alleen " +
                        "olie. Het is 'Liquid Engineering' die beschermt tegen dagelijkse problemen, zoals sludge. Zware rijomstandigheden, zoals elke dag start - stop " +
                        "verkeer, barre weersomstandigheden en verlengde verversingsintervallen, kunnen leiden tot de opbouw van een dikke, teerachtige substantie, " +
                        "de zogenaamde sludge. De opbouw van deze sludge kan schade geven aan uw motor en de prestaties verminderen.<br/>CASTROL GTX GEEFT SUPERIEURE " +
                        "MOTORBESCHERMING:<br/>Bevat een anti - sludge formule die 25 % betere sludge bescherming biedt in vergelijking met zware industrie normen.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 26.09M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_6.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Type = "10W40", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_7",
                        Artikelnaam = "MO7 Motorolie 5W40 Fullsynthetic Winprice 5L",
                        Artikelomschrijving = "Vol Synthetische olie voor gebruik in benzine en dieselmotoren van personenwagens en lichte bedrijfswagens. " +
                        "Niet geschikt voor roetfilters. Verlaagt brandstofgebruik. Bevat calciumalkarylsulfonaat met lange keten. " +
                        "Kan een allergische reactie veroorzaken. Volg altijd olie voorschrift van de fabrikant van uw voertuig.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 21.70M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_7.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Type = "5W40", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_8",
                        Artikelnaam = "MO8 Motorolie 5W30 Fullsynthetic Longlife Winprice 5L",
                        Artikelomschrijving = "Vol Synthetische olie voor gebruik in benzine en dieselmotoren van personenwagens en lichte bedrijfswagens. " +
                        "Geschikt voor roetfilters. Verlaagt brandstofgebruik. Bevat calciumalkarylsulfonaat met lange keten. " +
                        "Kan een allergische reactie veroorzaken. Volg altijd olie voorschrift van de fabrikant van uw voertuig.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 29.74M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_8.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Type = "5W30", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_9",
                        Artikelnaam = "MO9 Motorolie 5W30 Fullsynthetic Winprice 5L",
                        Artikelomschrijving = "Vol Synthetische olie voor gebruik in benzine en dieselmotoren van personenwagens en lichte bedrijfswagens. " +
                        "Geschikt voor roetfilters. Verlaagt brandstofgebruik. Bevat calciumalkarylsulfonaat met lange keten. " +
                        "Kan een allergische reactie veroorzaken. Volg altijd olie voorschrift van de fabrikant van uw voertuig.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 25.95M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_9.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Type = "5W30", //mm
                        }
                    },
                    new OnderdelenProducten
                    {
                        Artikelnummer = "MO_10",
                        Artikelnaam = "MO10 Motorolie Shell Helix HX7 10W40 5L",
                        Artikelomschrijving = "SHELL HELIX HX7 10W40<br/>MOTOROLIE MET SYNTHETISCHE TECHNOLOGIE VOOR PERSONENAUTO'S EN LICHTE BEDRIJFSWAGENS + reinigt" +
                        "de motor en houdt deze inwendig schoon + biedt uitstekende bescherming en lange motorlevensduur + verzekert vlotte koude start." +
                        "TOEPASSING:<br/>Shell Helix HX7 10W-40 kan worden toegepast in motoren van personenauto’s en lichte bedrijfswagens rijdend op benzine, " +
                        "diesel of LPG ook wanneer die zijn uitgevoerd met turbo, meerkleppentechniek, brandstofinjectie en/of katalysator.<br/>SAMENSTELLING:<br/>Shell " +
                        "Helix HX7 10W-40 bestaat uit een combinatie van synthetische basisolie, geselecteerde minerale olie en speciaal voor de universele toepassing " +
                        "ontwikkelde additieven.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 12),
                        Prijs = 25.64M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/motorolie/MO_10.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Type = "10W40", //mm
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(motorolie);
                context.SaveChanges();
            }
            //seed remvloeistof
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 11))
            {
                OnderdelenProducten[] remvloeistof = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "RV_1",
                        Artikelnaam = "RV1 Remvloeistof SAE J 1703 ",
                        Artikelomschrijving = "Remvloeistof is onverdraagzaam met onder andere autolakken; bij knoeien moet de remvloeistof direct met water afgenomen" +
                        " worden.<br/>In gesloten verpakking bewaren en vermenging met water of olieprodukten voorkomen.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 11),
                        Prijs = 8.39M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/remvloeistof/RV_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 1, //liter
                            Goedkeuring = "ISO 4925 Class 4",
                            Type = "SAE J 1703"//mm
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(remvloeistof);
                context.SaveChanges();
            }
            //seed ruitensproeier
            if (!context.OnderdelenProducten.Any(o => o.CategorieOnderdelen.OnderdelenCategorieId == 10))
            {
                OnderdelenProducten[] ruitensproeier = new[]
                {
                    new OnderdelenProducten
                    {
                        Artikelnummer = "RS_1",
                        Artikelnaam = "RS1 Ruitensproeier Antivries 5ltr -15",
                        Artikelomschrijving = "Hoge kwaliteit ruitensproeier antivries. Kant en klaar met goede reiniging en aangename geur." +
                        "Het laat geen strepen na en voorkomt bevriezing van ruiten. Ontvlambaar , buiten bereik van kinderen bewaren. In geval van inslikken onmiddellijk een " +
                        "arts raadplegen en verpakking of etiket tonen. Bevat Anionogene oppervlakte-actieve stoffen. Parfums. Benzyl Alcohol.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 10),
                        Prijs = 4.99M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/ruitensproeier/RS_1.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Geur = "Frisse lemon geur",
                            Type = "Anti-vries",//mm
                            MinimaleTemperatuur = "-15 graden"                          
                        }
                    },
                     new OnderdelenProducten
                    {
                        Artikelnummer = "RS_2",
                        Artikelnaam = "RS1 Ruitensproeier Antivries 5ltr -15",
                        Artikelomschrijving = "Frisse citroengeur.<br/>Kant en klaar.<br/>Verwijdert vuil, vet en insectresten van de autoruit.<br/>Screenwash, kant en klaar " +
                        "voor gebruik.<br/>Geeft een frisse citroenlucht en een streeploos resultaat tijdens het wissen.",
                        CategorieOnderdelen = context.CategorieOnderdelen.Single(c => c.OnderdelenCategorieId == 10),
                        Prijs = 3.39M,
                        FiguurURL = @"~/images/onderdelen/filtersVoeistof/ruitensproeier/RS_2.jpg",
                        Specificatie = new Specificaties
                        {
                            Inhoud = 5, //liter
                            Geur = "lemon",
                            Type = "Zomer"//mm
                        }
                    },
                };
                context.OnderdelenProducten.AddRange(ruitensproeier);
                context.SaveChanges();
            }

            //seed leveranciers
            if (!context.Leveranciers.Any())
            {
                Leverancier[] leveranciers = new[]
                {
                    new Leverancier{
                                    LeverancierNaam = "Bosal",
                                    LeverancierDatum = new DateTime(2018,4,2),
                                    LeverancierID = 1,
                                    Naam = "Therssen",
                                    Voornaam = "Marc",
                                    Telefoonnummer = "0478123456",
                                    Email = "info@bosal.com",
                                    Postcode = 8430,
                                    Gemeente = "Middelkerke",
                                    Adres = "Veldstraat 10",
                                    },
                    new Leverancier{
                                    LeverancierNaam = "TowBars",
                                    LeverancierDatum = new DateTime(2018,4,10),
                                    LeverancierID = 2,
                                    Naam = "Vanacker",
                                    Voornaam = "Johan ",
                                    Telefoonnummer = "0488565447",
                                    Email = "info@towbars.com ",
                                    Postcode = 8500,
                                    Gemeente = "Kortrijk",
                                    Adres = "doornstraat 16",
                                    },
                    new Leverancier{
                                    LeverancierNaam = "MANN",
                                    LeverancierDatum = new DateTime(2018,4,9),
                                    LeverancierID = 3,
                                    Naam = "Jacobs",
                                    Voornaam = "Henk  ",
                                    Telefoonnummer = "0488565447",
                                    Email = "info@mann.com",
                                    Postcode = 8450,
                                    Gemeente = "Oostende",
                                    Adres = "Bredabaan 102",
                                    },
                    new Leverancier{
                                    LeverancierNaam = "TwinnyLoad",
                                    LeverancierDatum = new DateTime(2018,4,4),
                                    LeverancierID = 4,
                                    Naam = "Peeters",
                                    Voornaam = "Hans",
                                    Telefoonnummer = "0487575757",
                                    Email = "info@twinnyLoad.be ",
                                    Postcode = 8620,
                                    Gemeente = "Nieuwpoort",
                                    Adres = "Langestraat 16",
                                    },
                    new Leverancier{
                                    LeverancierNaam = "StyleFit-Clips",
                                    LeverancierDatum = new DateTime(2018,4,2),
                                    LeverancierID = 5,
                                    Naam = "Janssens",
                                    Voornaam = "Gert",
                                    Telefoonnummer = "0478521369",
                                    Email = "info@stylefit.be",
                                    Postcode = 8620,
                                    Gemeente = "Nieuwpoort",
                                    Adres = "Brugsevaart 40",
                                    },
                    new Leverancier{
                                    LeverancierNaam = "HEUVER(banden)",
                                    LeverancierDatum = new DateTime(2018,4,10),
                                    LeverancierID = 6,
                                    Naam = "Vanzijl",
                                    Voornaam = "Herbert ",
                                    Telefoonnummer = "+31523850850 ",
                                    Email = "info@heuver.be",
                                    Postcode = 7770,
                                    Gemeente = "Hardenberg",
                                    Adres = "Zwedenweg 17",
                                    },
                    new Leverancier{
                                    LeverancierNaam = "Wieldoppengigant",
                                    LeverancierDatum = new DateTime(2018,4,5),
                                    LeverancierID = 7,
                                    Naam = "Aerts",
                                    Voornaam = "Ben ",
                                    Telefoonnummer = "+31598786093",
                                    Email = "info@concept-s.nl",
                                    Postcode = 9636,
                                    Gemeente = "Zuidbroek",
                                    Adres = "Hanzeweg 9C",
                                    },
                     new Leverancier{
                                    LeverancierNaam = "Lano Carpets",
                                    LeverancierDatum = new DateTime(2018,4,3),
                                    LeverancierID = 8,
                                    Naam = "Vandeursen",
                                    Voornaam = "Gilles",
                                    Telefoonnummer = "0456789133",
                                    Email = "marketing@lano.be",
                                    Postcode = 8530,
                                    Gemeente = "Harelbeke",
                                    Adres = "Venetiëlaan 33",
                                    },
                      new Leverancier{
                                    LeverancierNaam = "SONNIBOY",
                                    LeverancierDatum = new DateTime(2018,4,6),
                                    LeverancierID = 9,
                                    Naam = "Veres",
                                    Voornaam = "Mariska",
                                    Telefoonnummer = "+31507210808",
                                    Email = "info@sonniboy.nl",
                                    Postcode = 9723,
                                    Gemeente = "Groningen",
                                    Adres = "Verlengde Bremenweg 15 ",
                                    },
                      new Leverancier{
                                    LeverancierNaam = "Teesing(filters en vloeistoffen)",
                                    LeverancierDatum = new DateTime(2018,4,7),
                                    LeverancierID = 10,
                                    Naam = "Van Gorp",
                                    Voornaam = "Cor",
                                    Telefoonnummer = "+31704130700",
                                    Email = "orders@teesing.nl",
                                    Postcode = 2288,
                                    Gemeente = "RIJSWIJK",
                                    Adres = "Verrijn Stuartlaan 40",
                                    },
                };

                context.Leveranciers.AddRange(leveranciers);
                context.SaveChanges();
            }
            //seed Klanten
            if (!context.Klanten.Any())
            {
                Klant[] klanten = new[]
                {
                    new Klant{
                                Klantdatum = new DateTime(2018,4,10),
                                KlantNaam = "testKlantNaam",
                                KlantId = 1,
                                Naam = "testKlantFamilieNaam",
                                Voornaam = "testKlantVoornaam",
                                Postcode = 8630,
                                Gemeente = "Nieuwpoort",
                                Adres = "TestKlantadres",
                                Telefoonnummer = "0471235689",
                                Email = "testklant@test.be"

                              },
                };

                context.Klanten.AddRange(klanten);
                context.SaveChanges();

            }


            ////seed AspNetRoles
            //string[] roles = new string[] { "eigenaar", "administrator", "bezoeker", "klant", "koper", "bedrijf", "verkoper", "abonnee" };

            //foreach (string role in roles)
            //{
            //    var roleStore = new RoleStore<IdentityRole>(context);

            //    if (!context.Roles.Any(r => r.Name == role))
            //    {
            //        roleStore.CreateAsync(new IdentityRole(role)).GetAwaiter();
                  
                    
            //    }

            //}
            //context.SaveChanges();


            //var user = new ApplicationUser
            //{

            //    UserName = "Ivan@email.com",
            //    NormalizedUserName = "ivan@email.com",
            //    Email = "Ivan@email.com",
            //    NormalizedEmail = "ivan@email.com",
            //    EmailConfirmed = true,
            //    LockoutEnabled = false,
            //    SecurityStamp = Guid.NewGuid().ToString(),
                
            //};

            //if (!context.Users.Any(u => u.UserName == user.UserName))
            //{
            //    var password = new PasswordHasher<ApplicationUser>();
            //    var hashed = password.HashPassword(user, "Ivocursist#123");
            //    user.PasswordHash = hashed;
            //    var userStore = new UserStore<ApplicationUser>(context);
            //    var role =  context.Roles.Single(r => r.Name == "administrator");

            //    userStore.CreateAsync(user).GetAwaiter();
            //    userStore.AddToRoleAsync(user, role.NormalizedName).GetAwaiter();
            //    context.SaveChanges();

            //}


            context.SaveChanges();

            }
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string[] roleNames = { "eigenaar", "administrator", "bezoeker", "klant", "koper", "bedrijf", "verkoper", "abonnee" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                //creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            //creating a super user who could maintain the web app
            var poweruser = new ApplicationUser
            {
                UserName = Configuration.GetSection("AppSettings")["UserEmail"],
                Email = Configuration.GetSection("AppSettings")["UserEmail"]
            };

            string userPassword = Configuration.GetSection("AppSettings")["UserPassword"];
            var user = await UserManager.FindByEmailAsync(Configuration.GetSection("AppSettings")["UserEmail"]);

            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(poweruser, userPassword);
                if (createPowerUser.Succeeded)
                {
                    //here we tie the new user to the "Admin" role 
                    await UserManager.AddToRoleAsync(poweruser, "administrator");

                }
            }
        }
    }
}
   

