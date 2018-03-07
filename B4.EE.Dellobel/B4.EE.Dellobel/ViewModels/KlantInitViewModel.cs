using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Domain.Validators;
using FluentValidation;
using FreshMvvm;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
    {
    public class KlantInitViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IValidator klantValidator;
        private IVoertuigenService voertuigenService;
        private Klant currentKlant;
        private Auto currentAuto;

        public KlantInitViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;
            klantValidator = new KlantValidator();
        }


        #region Properties

        private bool isVisibleBewaar = true;
        public bool IsVisibleBewaar
        {
            get { return isVisibleBewaar; }
            set
            {
                isVisibleBewaar = value;
                RaisePropertyChanged(nameof(IsVisibleBewaar));
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

        private string naam;
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

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                RaisePropertyChanged(nameof(Email));
            }
        }

        private string telefoonnummer;
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


        private string adres;
        public string Adres
        {
            get { return adres; }
            set
            {
                adres = value;
                RaisePropertyChanged(nameof(Adres));
            }
        }

        private string woonplaats;
        public string Woonplaats
        {
            get { return woonplaats; }
            set
            {
                woonplaats = value;
                RaisePropertyChanged(nameof(Woonplaats));
            }
        }

        private int postnummer;
        public int Postnummer
        {
            get { return postnummer; }
            set
            {
                postnummer = value;
                RaisePropertyChanged(nameof(Postnummer));
            }
        }

        private int autoId;
        public int AutoId
        {
            get { return autoId; }
            set
            {
                autoId = value;
                RaisePropertyChanged(nameof(AutoId));
            }
        }

        private string klantStatus;
        public string KlantStatus
        {
            get { return klantStatus; }
            set
            {
                klantStatus = value;
                RaisePropertyChanged(nameof(KlantStatus));
            }
        }

        #endregion



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

        public override void Init(object initData)
        {
            base.Init(initData);

            currentKlant = initData as Klant;
            Naam = currentKlant.Naam;
            Adres = currentKlant.Adres;
            Postnummer = currentKlant.Postnummer;
            Woonplaats = currentKlant.Woonplaats;
            Telefoonnummer = currentKlant.Telefoonnummer ;
            Email = currentKlant.Email;
            KlantStatus = Convert.ToString( currentKlant.KlantStatus);
            AutoId = currentKlant.AutoId;

        }

        private void SaveKlant()
        {
            if (currentKlant != null)
            { 
                currentKlant.Naam = Naam;
                currentKlant.Adres = Adres;
                currentKlant.Postnummer = Postnummer;
                currentKlant.Woonplaats = Woonplaats;
                currentKlant.Telefoonnummer = Telefoonnummer;
                currentKlant.Email = Email;
                currentKlant.KlantStatus = (KlantStatus)Enum.Parse(typeof(KlantStatus), KlantStatus); ;
                currentKlant.AutoId = AutoId;
            }
            else
            {
                MessagingCenter.Send(this, Constants.MessageNames.KlantinvoerFout, currentKlant);
            }

            
        }

        public ICommand WijzigCommand => new Command(
           async () =>
           {
                SaveKlant();
               if ( Validate(currentKlant))
               {


                   await klantenService.SaveKlant(currentKlant);

                   await CoreMethods.PushPageModelWithNewNavigation<KlantViewModel>(currentKlant, true);

               }
              

           }
           );
    }
    
}
