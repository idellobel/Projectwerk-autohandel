using Autohandel.Domain.Entities;
using Autohandel.Domain.Extensions;
using System.Collections.Generic;
using System.Linq;


namespace Autohandel.Domain.Data
{
    public class DataSeeder
    {
        public static void Seed(AutohandelContext context)
        {
            List<MerkType> allTypes = context.Types.ToList();
            List<Merk> allMerken = context.Merken.ToList();
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
                    new MerkType {MerkTypeNaam = "Giulia"},     //0
                    new MerkType {MerkTypeNaam = "Giulietta" },  //1
                    new MerkType {MerkTypeNaam = "Stelvio"},    //2
                    new MerkType {MerkTypeNaam = "MiTo" },       //3
                    new MerkType {MerkTypeNaam = "156"},        //4
                    new MerkType {MerkTypeNaam = "Brera" },      //5
                    new MerkType {MerkTypeNaam = "Spider" },     //6

                    //Audi
                    new MerkType {MerkTypeNaam = "A3"},        //7
                    new MerkType {MerkTypeNaam = "A4"},        //8
                    new MerkType {MerkTypeNaam = "A5"},        //9
                    new MerkType {MerkTypeNaam = "A6"},        //10
                    new MerkType {MerkTypeNaam = "A1"},        //11

                    //BMW
                     new MerkType {MerkTypeNaam = "1 Reeks" },        //12
                     new MerkType {MerkTypeNaam = "2 Reeks" },        //13
                     new MerkType {MerkTypeNaam = "3 Reeks" },        //14
                     new MerkType {MerkTypeNaam = "4 Reeks"},        //15
                     new MerkType {MerkTypeNaam = "5 Reeks"},        //16
                     new MerkType {MerkTypeNaam = "i3" },             //17
                     new MerkType {MerkTypeNaam = "X1"},             //18
                     new MerkType {MerkTypeNaam = "X3" },             //19
                     new MerkType {MerkTypeNaam = "Z4" },             //20

                     //CITROEN
                     new MerkType {MerkTypeNaam = "C4 AIRCROSS" },   //21
                     new MerkType {MerkTypeNaam = "C1"},            //22
                     new MerkType {MerkTypeNaam = "C3"},            //23
                     new MerkType {MerkTypeNaam = "C4" },            //24
                     new MerkType {MerkTypeNaam = "C4 Cactus"},     //25
                     new MerkType {MerkTypeNaam = "JUMPER"},        //26
                     new MerkType {MerkTypeNaam = "C5"},            //27
                     
                     //DAEWOO
                     new MerkType {MerkTypeNaam = "Nubira" },       //28
                     
                     //DAIHATSU
                     new MerkType {MerkTypeNaam = "Charade" },        //29
                 
                     //FIAT
                     new MerkType {MerkTypeNaam = "500"},           //30
                     new MerkType {MerkTypeNaam = "Panda"},          //31
                     new MerkType {MerkTypeNaam = "Punto"},          //32
                     new MerkType {MerkTypeNaam = "Tipo"},         //33
                     new MerkType {MerkTypeNaam = "Bravo" },        //34
                     
                     //FORD
                     new MerkType {MerkTypeNaam = "Ecosport"},       //35
                     new MerkType {MerkTypeNaam = "Edge"},          //36
                     new MerkType {MerkTypeNaam = "Fiesta"},       //37
                     new MerkType {MerkTypeNaam = "Focus"},          //38
                     new MerkType {MerkTypeNaam = "Galaxy"},         //39
                     new MerkType {MerkTypeNaam = "B-Max"},         //40
                     new MerkType {MerkTypeNaam = "C-Max"},          //41
                     new MerkType {MerkTypeNaam = "Transit"},        //42
                     new MerkType {MerkTypeNaam = "S-Max"},          //43
                     
                     //HONDA
                     new MerkType {MerkTypeNaam = "CR-V"},          //44
                     new MerkType {MerkTypeNaam = "Jazz"},         //45
                     
                     //HYUNDAI
                     new MerkType {MerkTypeNaam = "i10"},           //46
                     new MerkType {MerkTypeNaam = "i20"},           //47

                     //JAGUAR
                     new MerkType {MerkTypeNaam = "XE"},            //48
                     new MerkType {MerkTypeNaam = "XJ"},            //49
                     new MerkType {MerkTypeNaam = "E-PACE"},    //50
                     
                     //KIA
                     new MerkType {MerkTypeNaam = "Carens"},     //51
                     new MerkType {MerkTypeNaam = "Rio"},         //52
                     new MerkType {MerkTypeNaam = "Picanto"},       //53
                     new MerkType {MerkTypeNaam = "Venga"},      //54
                     new MerkType {MerkTypeNaam = "cee'd"},        //55
                     new MerkType {MerkTypeNaam = "Hybrid"},        //56
                     new MerkType {MerkTypeNaam = "Optima"},    //57
                     new MerkType {MerkTypeNaam = "Soul EV"},      //58
                    
                     //LANDROVER
                     new MerkType {MerkTypeNaam = "Discovery"},           //59
                     new MerkType {MerkTypeNaam = "Range Rover Evoque"},    //60

                     //MAZDA
                     new MerkType {MerkTypeNaam = "Mazda2"},        //61
                     new MerkType {MerkTypeNaam = "Mazda3"},        //62
                     new MerkType {MerkTypeNaam = "CX-3"},        //63
                     new MerkType {MerkTypeNaam = "CX-5"},       //64
                     new MerkType {MerkTypeNaam = "MX-5"},        //65

                     //MERCEDES
                     new MerkType {MerkTypeNaam = "A-Klasse"},      //66
                     new MerkType {MerkTypeNaam = "B-Klasse"},    //67
                     new MerkType {MerkTypeNaam = "C-Klasse"},       //68
                     new MerkType {MerkTypeNaam = "CLA"},           //69
                     new MerkType {MerkTypeNaam = "GLA SUV"},       //70

                     //MITSUBISHI
                     new MerkType {MerkTypeNaam = "SPACE STAR"},     //71
                     new MerkType {MerkTypeNaam = "ASX"},          //72
                     new MerkType {MerkTypeNaam = "ECLIPSE CROSS"},  //73
                     new MerkType {MerkTypeNaam = "OUTLANDER"},   //74

                     //NISSAN
                     new MerkType {MerkTypeNaam = "JUKE"},          //75
                     new MerkType {MerkTypeNaam = "MICRA"},            //76
                     new MerkType {MerkTypeNaam = "NOTE" },           //77
                     new MerkType {MerkTypeNaam = "LEAF"},            //78

                     //OPEL
                      new MerkType {MerkTypeNaam = "ADAM"},            //79
                     new MerkType {MerkTypeNaam = "AGILA"},           //80
                     new MerkType {MerkTypeNaam = "AMPERA"},       //81
                     new MerkType {MerkTypeNaam = "ASTRA"},          //82
                     new MerkType {MerkTypeNaam = "CASCADA"},      //83
                     new MerkType {MerkTypeNaam = "CORSA"},           //84
                     new MerkType {MerkTypeNaam = "CROSSLAND X"},     //85
                     new MerkType {MerkTypeNaam = "GRANDLAND X"},    //87
                     new MerkType {MerkTypeNaam = "INSIGNIA"},        //88
                     new MerkType {MerkTypeNaam = "KARL"},           //89
                     new MerkType {MerkTypeNaam = "MERIVA"},          //90
                     new MerkType {MerkTypeNaam = "MOKKA"},          //91
                     new MerkType {MerkTypeNaam = "MOVANO"},         //92

                     //PEUGEOT
                     new MerkType {MerkTypeNaam = "207"},            //93
                     new MerkType {MerkTypeNaam = "208"},         //94
                     new MerkType {MerkTypeNaam = "2008"},         //95
                     new MerkType {MerkTypeNaam = "308"},          //96
                     new MerkType {MerkTypeNaam = "3008"},         //97
                     new MerkType {MerkTypeNaam = "4007"},           //98
                     new MerkType {MerkTypeNaam = "5008"},          //99
                     new MerkType {MerkTypeNaam = "508"},         //100
                     new MerkType {MerkTypeNaam = "TRAVELLER"},      //101
                   
                     //PORCHE
                     new MerkType {MerkTypeNaam = "718 BOXSTER"},      //102
                     new MerkType {MerkTypeNaam = "718 CAYMAN"},    //103
                     new MerkType {MerkTypeNaam = "911"},              //104
                     new MerkType {MerkTypeNaam = "CAYENNE"},         //105
                     new MerkType {MerkTypeNaam = "MACAN"},            //106
                     new MerkType {MerkTypeNaam = "PANAMERA"},       //107

                     //RENAULT
                     new MerkType {MerkTypeNaam = "CAPTUR"},          //108
                     new MerkType {MerkTypeNaam = "CLIO"},             //109
                     new MerkType {MerkTypeNaam = "ESPACE"},         //110
                     new MerkType {MerkTypeNaam = "KADJAR"},          //111
                     new MerkType {MerkTypeNaam = "KOLEOS"},           //112
                     new MerkType {MerkTypeNaam = "MEGANE"},        //113
                     new MerkType {MerkTypeNaam = "SCENIC"},         //114
                     new MerkType {MerkTypeNaam = "TALISMAN"},         //115
                     new MerkType {MerkTypeNaam = "TWINGO"},          //116
                     new MerkType {MerkTypeNaam = "TWIZY"},          //117
                     new MerkType {MerkTypeNaam = "ZOE"},              //118

                     //VOLKSWAGEN
                     new MerkType {MerkTypeNaam = "CC"},              //119
                     new MerkType {MerkTypeNaam = "GOLF"},            //120
                     new MerkType {MerkTypeNaam = "JETTA"},         //121
                     new MerkType {MerkTypeNaam = "NEW BEETLE"},       //123
                     new MerkType {MerkTypeNaam = "PASSAT"},          //124
                     new MerkType {MerkTypeNaam = "POLO"},            //125
                     new MerkType {MerkTypeNaam = "SCIROCCO"},       //126
                     new MerkType {MerkTypeNaam = "SHARAN"},          //127
                     new MerkType {MerkTypeNaam = "TIGUAN"},          //128
                     new MerkType {MerkTypeNaam = "TOUAREG"},         //129
                     new MerkType {MerkTypeNaam = "TOURAN"},          //130
                     new MerkType {MerkTypeNaam = "T-ROC"},           //131
                     new MerkType {MerkTypeNaam = "UP!"},            //132
                     new MerkType {MerkTypeNaam = "TRANSPORTER"},     //133

                     //VOLVO
                     new MerkType {MerkTypeNaam = "S60"},              //134
                     new MerkType {MerkTypeNaam = "S60 CROSS COUNTRY"},  //135
                     new MerkType {MerkTypeNaam = "S90"},                //136
                     new MerkType {MerkTypeNaam = "V40"},                //137
                     new MerkType {MerkTypeNaam = "V40 CROSS COUNTRY"},  //138
                     new MerkType {MerkTypeNaam = "V60"},              //139
                     new MerkType {MerkTypeNaam = "V60 CROSS COUNTRY"},  //140
                     new MerkType {MerkTypeNaam = "V90"},              //141
                     new MerkType {MerkTypeNaam = "XC40"},               //142
                     new MerkType {MerkTypeNaam = "XC60"},              //143
                     new MerkType {MerkTypeNaam = "XC90"},              //144

                     //DACIA
                     new MerkType { MerkTypeNaam = "DUSTER"},            //145
                     
                  
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
                                  FiguurURL = @"wwwroot/images/vtgn/fronts/8_FRONT.jpg",
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
                                  FiguurURL = @"~/images/vtgn/fronts/39_FRONT.jpg",
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
                }
                context.SaveChanges();

            }
        }
    }

