using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Domain.Validators;
using FluentValidation;
using FreshMvvm;
using System;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class VraagInitViewModel : FreshBasePageModel
    { 

        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;
        private IValidator klantValidator;
        private IValidator autoValidator;
        private Klant currentKlant;
        private Auto currentAuto;
        private Voertuigen currentVoertuigen;


        public VraagInitViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;
            klantValidator = new KlantValidator();
            autoValidator = new AutoValidator();
            LoadAankoopPageState();
        }


        #region  Properties

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

        private bool isVisibleLocatie = false;
        public bool IsVisibleLocatie
        {
            get { return isVisibleLocatie; }
            set
            {
                isVisibleLocatie = value;
                RaisePropertyChanged(nameof(IsVisibleLocatie));
            }
        }
        private DateTime vraag;
        public DateTime Vraag
        {
            get { return vraag; }
            set
            {
                vraag = value;
                RaisePropertyChanged(nameof(Vraag));
            }
        }


        private bool isBusy;
        public bool IsBusy
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
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

        private bool isChecked = false;
        public bool Ischecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                RaisePropertyChanged(nameof(Ischecked));
            }
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

        private string merkError;
        public string MerkError
        {
            get { return merkError; }
            set
            {
                merkError = value;
                RaisePropertyChanged(nameof(MerkError));
                RaisePropertyChanged(nameof(MerkErrorVisible));
            }
        }

        public bool MerkErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(MerkError); }
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

        private string modelError;
        public string ModelError
        {
            get { return modelError; }
            set
            {
                modelError = value;
                RaisePropertyChanged(nameof(ModelError));
                RaisePropertyChanged(nameof(ModelErrorVisible));
            }
        }

        public bool ModelErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(ModelError); }
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

        private string bouwjaarError;
        public string BouwjaarError
        {
            get { return bouwjaarError; }
            set
            {
                bouwjaarError = value;
                RaisePropertyChanged(nameof(BouwjaarError));
                RaisePropertyChanged(nameof(BouwjaarErrorVisible));
            }
        }

        public bool BouwjaarErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(BouwjaarError); }
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

        #endregion Properties

        private void LoadAankoopPageState()
        {
            Naam = "Andy Cueppens";
            Email = "andy.cueppens@gmail.com";
            Telefoonnummer = "051458576";
            Woonplaats = "Diksmuide";
            Adres = "Landweg 5";
            Merk = "Toyota";
            Model = "Landcruiser";
            Bouwjaar = "2015";
            Prijs = "20000";
            Vraag = Convert.ToDateTime("01-jan-2000", CultureInfo.CurrentCulture);


        }

        private async Task SaveVoertuigStateAsync()
        {
            currentVoertuigen = new Voertuigen();
            currentVoertuigen = voertuigenService.GetVoertuigenLijst(3).Result;

            currentKlant = new Klant();
            currentKlant.Naam = Naam;
            currentKlant.Telefoonnummer = Telefoonnummer;
            currentKlant.Email = Email;
            currentKlant.Adres = Adres;
            currentKlant.KlantStatus = KlantStatus.Koper;
            currentKlant.Woonplaats = Woonplaats;
            currentKlant.Id = new Guid();

            await klantenService.SaveKlant(currentKlant);

            await klantenService.GetKlantById(currentKlant.Id);

            currentKlant.Auto = new Auto();
            
            currentAuto = new Auto();
            currentAuto.Merk = Merk;
            currentAuto.Model = Model;
            currentAuto.Prijs = Convert.ToDecimal(Prijs);
            currentAuto.Bouwjaar = Convert.ToInt16(Bouwjaar);
            currentAuto.Vraag = Vraag;
            currentAuto.AutoStatus = (AutoStatus)Enum.Parse(typeof(AutoStatus), AutoStatus);
            currentAuto.KlantNaam = currentKlant.Naam;
            currentAuto.KlantId = currentKlant.Id;
           
            currentVoertuigen.Autoos.Add(currentAuto);

            await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);

            currentKlant.Auto.AanBod = currentAuto.AanBod;
            currentKlant.Auto.Merk = currentAuto.Merk;
            currentKlant.Auto.Model = currentAuto.Model;
            currentKlant.Auto.Prijs = currentAuto.Prijs;
            currentKlant.AutoId = currentAuto.Id;

        }

        private bool Validate(Auto auto)
        {
            var validationResult = autoValidator.Validate(auto);
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(auto.Merk))
                {
                    MerkError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(auto.Model))
                {
                    ModelError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(auto.Prijs))
                {
                    PrijsError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(auto.Bouwjaar))
                {
                    BouwjaarError = error.ErrorMessage;
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


        public ICommand BewaarVraagCommand => new Command(
            async () =>
            {
                try
                {
                    await SaveVoertuigStateAsync();
                    if (Validate(currentAuto) || Validate(currentKlant))
                    {

                        await klantenService.SaveKlant(currentKlant);
                        MessagingCenter.Send(this, Constants.MessageNames.VoertuigenSaved, currentAuto);
                        //await CoreMethods.PopPageModel(false, true);

                    }
                    IsVisibleBewaar = false;
                    IsVisibleGereed = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    MessagingCenter.Send(this, Constants.MessageNames.VoertuigenDeleteFault, currentAuto);

                }

            }
            );

       

        public ICommand ToVraagPageCommand => new Command<Voertuigen>(
         async (Voertuigen voertuigenLijst) =>
         {
             voertuigenLijst = new Voertuigen();
             voertuigenLijst.Id = 3;
             voertuigenLijst = await voertuigenService.GetVoertuigenLijst(voertuigenLijst.Id);
             await CoreMethods.PushPageModel<VraagViewModel>(voertuigenLijst, true);
         }
          );
    }
}
