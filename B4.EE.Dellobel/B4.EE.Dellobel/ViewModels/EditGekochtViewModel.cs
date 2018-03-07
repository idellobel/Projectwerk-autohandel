using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Domain.Validators;
using FluentValidation;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class EditGekochtViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;
        private IValidator autoValidator;
        private IValidator klantValidator;
        private Auto currentAuto;
        private Klant currentKlant;
        private Voertuigen currentVoertuigen;

        public EditGekochtViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;
            autoValidator = new AutoValidator();
            klantValidator = new KlantValidator();
        }

        #region Properties

        private bool isVisibleWijzig = true;
        public bool IsVisibleWijzig
        {
            get { return isVisibleWijzig; }
            set
            {
                isVisibleWijzig = value;
                RaisePropertyChanged(nameof(IsVisibleWijzig));
            }
        }

        private bool isVisibleGereed = false;
        public bool IsVisibleGereed
        {
            get { return isVisibleGereed; }
            set
            {
                isVisibleGereed = value;
                RaisePropertyChanged(nameof(IsVisibleGereed));
            }
        }

        private bool isVisibleFoto = false;
        public bool IsVisibleFoto
        {
            get { return isVisibleFoto; }
            set
            {
                isVisibleFoto = value;
                RaisePropertyChanged(nameof(IsVisibleFoto));
            }
        }

        private int id;
        public int Id
        {
            get { return id; }
        }

        private string autoStatus;
        public string AutoStatus
        {
            get { return autoStatus; }
            set
            {
                autoStatus = value;
                RaisePropertyChanged(nameof(AutoStatus));
            }
        }
        private string brandstof;
        public string Brandstof
        {
            get { return brandstof; }
            set
            {
                brandstof = value;
                RaisePropertyChanged(nameof(Brandstof));
            }
        }

        private string eersteEigenaar;
        public string EersteEigenaar
        {
            get { return eersteEigenaar; }
            set
            {
                eersteEigenaar = value;
                RaisePropertyChanged(nameof(EersteEigenaar));
            }
        }

        private string kmStand;
        public string KmStand
        {
            get { return kmStand; }
            set
            {
                kmStand = value;
                RaisePropertyChanged(nameof(KmStand));
            }
        }

        private DateTime verkoop;
        public DateTime Verkoop
        {
            get { return verkoop; }
            set
            {
                verkoop = value;
                RaisePropertyChanged(nameof(Verkoop));
            }
        }

        private string aankoop;
        public string Aankoop
        {
            get { return aankoop; }
            set
            {
                aankoop = value;
                RaisePropertyChanged(nameof(Aankoop));
            }
        }

        private string klantNaam;
        public string KlantNaam
        {
            get { return klantNaam; }
            set
            {
                klantNaam = value;
                RaisePropertyChanged(nameof(KlantNaam));
            }
        }

        private string merk;
        public string Merk
        {
            get { return merk; }
            set
            {
                merk = value;
                RaisePropertyChanged(nameof(Merk));
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                RaisePropertyChanged(nameof(Model));
            }
        }

        private string bouwjaar; // int geeft 0
        public string Bouwjaar
        {
            get { return bouwjaar; }
            set
            {
                bouwjaar = value;
                RaisePropertyChanged(nameof(Bouwjaar));
            }
        }

        private string prijs;
        public string Prijs
        {
            get { return prijs; }
            set
            {
                prijs = value;
                RaisePropertyChanged(nameof(Prijs));
            }
        }

        private string prijsError;
        public string PrijsError
        {
            get { return prijsError; }
            set
            {
                prijsError = value;
                RaisePropertyChanged(nameof(PrijsError));
                RaisePropertyChanged(nameof(PrijsErrorVisible));
            }
        }

        public bool PrijsErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(PrijsError); }
        }

        private string naam = string.Empty;
        public string Naam
        {
            get { return naam; }
            set
            {
                naam = value;
                RaisePropertyChanged(nameof(Naam));
            }
        }

        private string naamError;
        public string NaamError
        {
            get { return naamError; }
            set
            {
                naamError = value;
                RaisePropertyChanged(nameof(NaamError));
                RaisePropertyChanged(nameof(NaamErrorVisible));
            }
        }

        public bool NaamErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(NaamError); }
        }

        private string telefoonnummer = string.Empty;
        public string Telefoonnummer
        {
            get { return telefoonnummer; }
            set
            {
                telefoonnummer = value;
                RaisePropertyChanged(nameof(Telefoonnummer));
            }
        }

        private string telefoonnummerError;
        public string TelefoonnummerError
        {
            get { return telefoonnummerError; }
            set
            {
                telefoonnummerError = value;
                RaisePropertyChanged(nameof(TelefoonnummerError));
                RaisePropertyChanged(nameof(TelefoonnummerErrorVisible));
            }
        }

        public bool TelefoonnummerErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(TelefoonnummerError); }
        }


        private string adres = string.Empty;
        public string Adres
        {
            get { return adres; }
            set
            {
                adres = value;
                RaisePropertyChanged(nameof(Adres));
            }
        }

        private string woonplaats = string.Empty;
        public string Woonplaats
        {
            get { return woonplaats; }
            set
            {
                woonplaats = value;
                RaisePropertyChanged(nameof(Woonplaats));
            }
        }

        #endregion



        public override void Init(object initData)
        {

            base.Init(initData);

            currentAuto = initData as Auto;

        }

        private void LoadEditGekochtState()
        {

            AutoStatus = currentAuto.AutoStatus.ToString();
            Bouwjaar = currentAuto.Bouwjaar.ToString();
            Merk = currentAuto.Merk;
            Model = currentAuto.Model;
            Prijs = currentAuto.Prijs.ToString();
            Aankoop = currentAuto.Aankoop.ToString("dd-MMM-yyyy", CultureInfo.CurrentCulture); ;
            KmStand = currentAuto.KMstand.ToString();
            Brandstof = currentAuto.Brandstof.ToString();
            EersteEigenaar = currentAuto.EersteEigenaar;
            //Verkoop = Convert.ToDateTime("01-jan-2000", CultureInfo.CurrentCulture);
            Verkoop = DateTime.Now;
            KlantNaam = currentAuto.KlantNaam;
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            LoadEditGekochtState();
        }

        private bool Validate(Auto auto)
        {
            var validationResult = autoValidator.Validate(auto);
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(auto.Prijs))
                {
                    PrijsError = error.ErrorMessage;
                }

            }
            return validationResult.IsValid;

        }

        private bool Validate(Klant klant)
        {
            var validationResult = klantValidator.Validate(klant);
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(klant.Naam))
                {
                    NaamError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(klant.Telefoonnummer))
                {
                    TelefoonnummerError = error.ErrorMessage;
                }

            }
            return validationResult.IsValid;
        }

        private async Task EditVoertuigStateAsync()
        {
            id = currentAuto.Id;

            currentVoertuigen = await voertuigenService.GetVoertuigenLijst(1);

            currentAuto = currentVoertuigen.Autoos.FirstOrDefault(currentAuto => currentAuto.Id == Id);

            if (currentAuto != null)
            {
                currentKlant = new Klant();

                currentKlant.Naam = Naam;
                currentKlant.Telefoonnummer = Telefoonnummer;
                currentKlant.Adres = Adres;
                currentKlant.KlantStatus = KlantStatus.Verkoper;
                currentKlant.Woonplaats = Woonplaats;
                currentKlant.Id = new Guid();

                currentAuto.Merk = Merk;
                currentAuto.Model = Model;
                currentAuto.Prijs = Convert.ToDecimal(Prijs);
                currentAuto.AutoStatus = (AutoStatus)Enum.Parse(typeof(AutoStatus), AutoStatus);
                currentAuto.Bouwjaar = Convert.ToInt16(Bouwjaar);
                currentAuto.Verkoop = Convert.ToDateTime(Verkoop);
                currentAuto.KMstand = Convert.ToInt32(KmStand);
                currentAuto.KlantId = currentKlant.Id;
                currentAuto.KlantNaam = currentKlant.Naam;
                await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);

            }


        }

        public ICommand WijzigCommand => new Command(
           async () =>
           {
               try
               {
                   await EditVoertuigStateAsync();
                   IsVisibleGereed = true;
                   if (currentAuto.AutoStatus != (AutoStatus)Enum.Parse(typeof(AutoStatus), "Gekocht"))
                   {
                       IsVisibleGereed = false;
                       if (Validate(currentKlant))
                       {
                           await klantenService.SaveKlant(currentKlant);

                           var autolijst = await voertuigenService.GetVoertuigenLijst(2);
                           if (autolijst.Autoos == null) autolijst.Autoos = new List<Auto>();
                           autolijst.Autoos.Add(currentAuto);
                           currentVoertuigen.Autoos.Remove(currentAuto);
                           await voertuigenService.SaveVoertuigenLijst(autolijst);
                           await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);



                           MessagingCenter.Send(this, Constants.MessageNames.VoertuigenEdit, currentAuto);
                           //await CoreMethods.PopPageModel(false, true);
                           IsVisibleWijzig = false;
                           IsVisibleGereed = true;
                       }
                    }
               }
               catch (Exception ex)
               {
                   Debug.WriteLine(ex.Message);
                   MessagingCenter.Send(this, Constants.MessageNames.VoertuigenEditFault, currentAuto);

               }

           }
           );

        public ICommand TerugGekochtPageCommand => new Command(
          async () =>
          {

              await CoreMethods.PushPageModel<GekochtViewModel>(currentVoertuigen, false, true);


          }
          );
    }
}

