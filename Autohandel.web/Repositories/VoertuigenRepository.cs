using Autohandel.Domain.Data;
using Autohandel.Domain.Entities;
using Autohandel.web.ViewModels.VoertuigenViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Autohandel.web.Repositories
{
    public class VoertuigenRepository
    {

        private readonly AutohandelContext _context;

        public VoertuigenRepository(AutohandelContext context)
        {
            _context = context;
        }

        public List<VoertuigDisplayViewModel> GetVoertuigen()
        {
           
            {
                List<Voertuig> voertuigen = new List<Voertuig>();
                voertuigen = _context.Voertuigen.AsNoTracking()
                    .Include(x => x.Merk)
                    .Include(x => x.MerkType)
                    .ToList();

                if (voertuigen != null)
                {
                    List<VoertuigDisplayViewModel> voertuigenDisplay = new List<VoertuigDisplayViewModel>();
                    foreach (var x in voertuigen)
                    {
                        var voertuigDisplay = new VoertuigDisplayViewModel()
                        {
                            VoertuigArtikelNummer = x.VoertuigArtikelNummer,
                            VoertuigTitel = x.VoertuigTitel,
                            Merk = x.Merk.MerkNaam,
                            Model = x.MerkType.MerkTypeNaam,
                            Categorie = x.VoertuigCategorie.VoertuigCategorieNaam,
                            Prijs = x.Prijs,
                            Kilometerstand = x.Kilometerstand,
                            Registratie = x.Registratie,
                            Bouwjaar = x.Bouwjaar,
                            Brandstof = x.Brandstof,
                            Kleur = x.Kleur,
                            Koetswerk = x.Koetswerk,
                            GarantieTijd = x.GarantieTijd,
                            Versnelling = x.Versnelling,
                            Vermogen = x.Vermogen,
                            COTwee = x.COTwee,
                            CC = x.CC,
                            Zitplaatsen = x.Zitplaatsen,
                            Deuren = x.Deuren,
                            Binnenkleur = x.Binnenkleur,
                            Binnenbekleding = x.Binnenbekleding,
                            FiguurURL = x.FiguurURL,
                            Faktuur = x.Faktuur,
                            Klant = x.Klant


                        };
                        voertuigenDisplay.Add(voertuigDisplay);
                    }
                    return voertuigenDisplay;
                }
                return null;
            }
        }


        public VoertuigEditViewModel CreateVoertuig()
        {
            var mRepo = new MerkenRepository(_context);
            var tRepo = new ModellenRepository(_context);
            var cRepo = new CategorieRepository(_context);
            var fRepo = new FakturenRepository(_context);
            var kRepo = new KlantenRepository(_context);


            var mxLV = _context.Voertuigen
                           .Where(v => v.VoertuigArtikelNummer.Contains("v"))
                            .OrderBy(v => v.VoertuigArtikelNummer.Length)
                            .ThenBy(v => v.VoertuigArtikelNummer)
                           .Max(v => Convert.ToInt16( v.VoertuigArtikelNummer.Substring(1))+1);
            var mxPW = _context.Voertuigen
                           .Where(v => !v.VoertuigArtikelNummer.Contains("v"))
                            //.OrderBy(v => v.VoertuigArtikelNummer.Length)
                            //.ThenBy(v => v.VoertuigArtikelNummer)
                           .Max(v => Convert.ToInt16(v.VoertuigArtikelNummer) + 1);




            var voertuig = new VoertuigEditViewModel()
            {
              
                MaxLVNr= $"V{mxLV.ToString()}",
                MaxPWNr= $"{mxPW.ToString()}",
                VoertuigArtikelNummer = $"--Kies PW: {mxPW.ToString()} / LV: V{mxLV.ToString()}--",
                Bouwjaar = Convert.ToInt16(DateTime.Now.Year),
                Registratie = "../20..",
                Deuren = 4,
                Zitplaatsen = 4,
                Vermogen = "... pk(.. kW)",
                CC = 1000,
                GarantieTijd = "12/24 maanden",
                FiguurURL = $@"~/images/vtgn/fronts/..._FRONT.jpg",
                COTwee = "... gr",
                Merken = mRepo.GetMerken(),
                Modellen = tRepo.GetModellen(),
                Categorieen= cRepo.GetCategorieen(),
                Fakturen = fRepo.GetFakturen(),
                Klanten = kRepo.GetKlanten()
            };
            return voertuig;
        }



        public VoertuigEditViewModel EditVoertuig(long? id)  
        {
            var mRepo = new MerkenRepository(_context);
            var tRepo = new ModellenRepository(_context);
            var cRepo = new CategorieRepository(_context);
            var fRepo = new FakturenRepository(_context);
            var kRepo = new KlantenRepository(_context);

            Voertuig voertuigMod = new Voertuig();

            voertuigMod = _context.Voertuigen
              .Include(v => v.Merk)
              .Include(v => v.MerkType)
              .Include(v => v.VoertuigCategorie)
              .Include(v => v.Klant)
              .Include(v => v.Faktuur)
              //.OrderBy(v => v.VoertuigArtikelNummer.Length)
              //.ThenBy(v => v.VoertuigArtikelNummer)
              .SingleOrDefault(m => m.VoertuigId == id);


            var voertuigE = new VoertuigEditViewModel()
            {
                
                VoertuigId =id,
               
                VoertuigArtikelNummer = voertuigMod.VoertuigArtikelNummer,
                SelectedMerk = voertuigMod.MerkId.ToString(),
                SelectedModel = voertuigMod.ModelId.ToString(),
                VoertuigTitel = voertuigMod.VoertuigTitel,
                SelectedCategorie = voertuigMod.VoertuigCatId.ToString(),
                Prijs = voertuigMod.Prijs,
                Kilometerstand= voertuigMod.Kilometerstand,
                Registratie= voertuigMod.Registratie    ,
                Bouwjaar= voertuigMod.Bouwjaar,
                Brandstof= voertuigMod.Brandstof,
                Kleur = voertuigMod.Kleur,
                Koetswerk = voertuigMod.Koetswerk,
                GarantieTijd = voertuigMod.GarantieTijd,
                Versnelling = voertuigMod.Versnelling,
                Vermogen = voertuigMod.Vermogen,
                COTwee = voertuigMod.COTwee,
                CC = voertuigMod.CC,
                Zitplaatsen = voertuigMod.Zitplaatsen,
                Deuren = voertuigMod.Deuren,
                Binnenkleur = voertuigMod.Binnenkleur,
                Binnenbekleding = voertuigMod.Binnenbekleding,
                FiguurURL = voertuigMod.FiguurURL,
                SelectedFaktuur = voertuigMod.FaktuurNr.ToString(),  //Bestaan nog geen fakturen
                SelectedKlant = voertuigMod.KlantId.ToString(),
                Merken = mRepo.GetMerken(),
                Modellen = tRepo.GetModellen(voertuigMod.MerkId.ToString()),
                Categorieen = cRepo.GetCategorieen(),
                Fakturen = fRepo.GetFakturen(),
                Klanten = kRepo.GetKlanten()
            };
            return voertuigE;
        }



        public bool SaveVoertuig(VoertuigEditViewModel voertuigedit)
        {
            //Verplicht, anders null-exception!!
            var mRepo = new MerkenRepository(_context);
            var tRepo = new ModellenRepository(_context);
            var cRepo = new CategorieRepository(_context);
            var fRepo = new FakturenRepository(_context);
            var kRepo = new KlantenRepository(_context);


            if (voertuigedit != null)
            {
               
                {
                    if (voertuigedit.VoertuigArtikelNummer != string.Empty)
                    {
                        
                        var voertuigNew = new Voertuig()    
                        {
                            VoertuigArtikelNummer = voertuigedit.VoertuigArtikelNummer,
                            VoertuigTitel = voertuigedit.VoertuigTitel,
                            Prijs = voertuigedit.Prijs,
                            Kilometerstand = voertuigedit.Kilometerstand,
                            Registratie = voertuigedit.Registratie,
                            Bouwjaar = voertuigedit.Bouwjaar,
                            Brandstof = voertuigedit.Brandstof,
                            Kleur = voertuigedit.Kleur,
                            Koetswerk = voertuigedit.Koetswerk,
                            GarantieTijd = voertuigedit.GarantieTijd,
                            Versnelling = voertuigedit.Versnelling,
                            Vermogen = voertuigedit.Vermogen,
                            COTwee = voertuigedit.COTwee,
                            CC = voertuigedit.CC,
                            Zitplaatsen = voertuigedit.Zitplaatsen,
                            Deuren = voertuigedit.Deuren,
                            Binnenkleur = voertuigedit.Binnenkleur,
                            Binnenbekleding = voertuigedit.Binnenbekleding,
                            FiguurURL = voertuigedit.FiguurURL,
                            Merk = _context.Merken.SingleOrDefault(c => c.MerkId == Convert.ToInt64(voertuigedit.SelectedMerk)),
                            MerkType = _context.Types.SingleOrDefault(c => c.MerkTypeId == Convert.ToInt64(voertuigedit.SelectedModel)),
                            VoertuigCategorie = _context.VoertuigCategorieen.SingleOrDefault(c => c.VoertuigCatId == Convert.ToInt64(voertuigedit.SelectedCategorie)),
                            Klant = _context.Klanten.SingleOrDefault(c => c.KlantId == Convert.ToInt64(voertuigedit.SelectedKlant)),
                            Faktuur = _context.Fakturen.SingleOrDefault(c => c.FaktuurNr == Convert.ToInt64(voertuigedit.SelectedFaktuur)),
                            
                        };

                                           

                        _context.Voertuigen.Add(voertuigNew);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            //Return false if voertuigedit == null or voertuigArtikelNummer is empty
            return false;
        }


        public bool SaveEditVoertuig(long id,VoertuigEditViewModel voertuigedit)
        {
            //Verplicht, anders null-exception!!
            var mRepo = new MerkenRepository(_context);
            var tRepo = new ModellenRepository(_context);
            var cRepo = new CategorieRepository(_context);
            var fRepo = new FakturenRepository(_context);
            var kRepo = new KlantenRepository(_context);


            if (voertuigedit != null)
            {

                {
                    if (voertuigedit.VoertuigArtikelNummer != string.Empty)
                    {

                        var voertuigUpdate = new Voertuig()
                        {
                            VoertuigId = id,
                            VoertuigArtikelNummer = voertuigedit.VoertuigArtikelNummer,
                            VoertuigTitel = voertuigedit.VoertuigTitel,
                            Prijs = voertuigedit.Prijs,
                            Kilometerstand = voertuigedit.Kilometerstand,
                            Registratie = voertuigedit.Registratie,
                            Bouwjaar = voertuigedit.Bouwjaar,
                            Brandstof = voertuigedit.Brandstof,
                            Kleur = voertuigedit.Kleur,
                            Koetswerk = voertuigedit.Koetswerk,
                            GarantieTijd = voertuigedit.GarantieTijd,
                            Versnelling = voertuigedit.Versnelling,
                            Vermogen = voertuigedit.Vermogen,
                            COTwee = voertuigedit.COTwee,
                            CC = voertuigedit.CC,
                            Zitplaatsen = voertuigedit.Zitplaatsen,
                            Deuren = voertuigedit.Deuren,
                            Binnenkleur = voertuigedit.Binnenkleur,
                            Binnenbekleding = voertuigedit.Binnenbekleding,
                            FiguurURL = voertuigedit.FiguurURL,
                            Merk = _context.Merken.SingleOrDefault(c => c.MerkId == Convert.ToInt64(voertuigedit.SelectedMerk)),
                            MerkType = _context.Types.SingleOrDefault(c => c.MerkTypeId == Convert.ToInt64(voertuigedit.SelectedModel)),
                            VoertuigCategorie = _context.VoertuigCategorieen.SingleOrDefault(c => c.VoertuigCatId == Convert.ToInt64(voertuigedit.SelectedCategorie)),
                            Klant = _context.Klanten.SingleOrDefault(c => c.KlantId == Convert.ToInt64(voertuigedit.SelectedKlant)),
                            Faktuur = _context.Fakturen.SingleOrDefault(c => c.FaktuurNr == Convert.ToInt64(voertuigedit.SelectedFaktuur)),

                        };



                        _context.Voertuigen.Update(voertuigUpdate);
                        _context.SaveChanges();
                        return true;
                    }
                }
            }
            //Return false if voertuigedit == null or voertuigArtikelNummer is empty
            return false;
        }

        private bool VoertuigExists(long id)
        {
            return _context.Voertuigen.Any(e => e.VoertuigId == id);
        }
    }
}
