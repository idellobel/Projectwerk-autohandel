using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Domain.Validators;
using FluentValidation;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class EditVraagViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;
        private IValidator autoValidator;
        private IValidator klantValidator;
        private Auto currentAuto;
        private Voertuigen currentVoertuigen;
        private Klant currentKlant;

        public EditVraagViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
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

        //private int id;
        //public int Id
        //{
        //    get { return id; }
        //}

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
        private string vraag;
        public string Vraag
        {
            get { return vraag; }
            set
            {
                vraag = value;
                RaisePropertyChanged(nameof(Vraag));
            }
        }

        private DateTime aankoop;
        public DateTime Aankoop
        {
            get { return aankoop; }
            set
            {
                aankoop = value;
                RaisePropertyChanged(nameof(Aankoop));
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

        #endregion



        public override void Init(object initData)
        {

            base.Init(initData);

            currentAuto = initData as Auto;

            //LoadEditAanbodState();
        }

        private void LoadEditAanbodState()
        {
            
            Aankoop = Convert.ToDateTime("01-jan-2000", CultureInfo.CurrentCulture);
            AutoStatus = currentAuto.AutoStatus.ToString();
            Bouwjaar = currentAuto.Bouwjaar.ToString();
            Merk = currentAuto.Merk;
            Model = currentAuto.Model;
            Prijs = currentAuto.Prijs.ToString();
            Vraag =currentAuto.Vraag.ToString("dd-MMM-yyyy");
            Brandstof = currentAuto.Brandstof.ToString();
            KlantNaam = currentAuto.KlantNaam;

        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            LoadEditAanbodState();
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


        private async Task SaveVoertuigStateAsync()
        {
            currentVoertuigen = new Voertuigen();
            currentVoertuigen = voertuigenService.GetVoertuigenLijst(3).Result;

            currentKlant = new Klant();
            currentKlant.Naam = Naam;
            currentKlant.Telefoonnummer = Telefoonnummer;
            //currentKlant.Email = Email;
            currentKlant.Adres = Adres;
            currentKlant.KlantStatus = KlantStatus.Koper;
            currentKlant.Woonplaats = Woonplaats;
            currentKlant.Id = new Guid();

            await klantenService.SaveKlant(currentKlant);

            await klantenService.GetKlantById(currentKlant.Id);


            //currentAuto = new Auto();
            currentAuto.Merk = Merk;
            currentAuto.Model = Model;
            currentAuto.Prijs = Convert.ToDecimal(Prijs);
            currentAuto.Bouwjaar = Convert.ToInt16(Bouwjaar);
            currentAuto.Vraag = Convert.ToDateTime(currentAuto.Vraag.ToString("dd-MMM-yyyy"));
            currentAuto.KlantNaam = currentKlant.Naam;
            currentAuto.KlantId = currentKlant.Id;
          
            //currentVoertuigen.Autoos.Add(currentAuto);

            await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);

            
            if (currentAuto.AutoStatus == (AutoStatus)Enum.Parse(typeof(AutoStatus), "Gekocht"))
            {
                var autolijst = await voertuigenService.GetVoertuigenLijst(1);
                if (autolijst.Autoos == null) autolijst.Autoos = new List<Auto>();
                autolijst.Autoos.Add(currentAuto);
                currentVoertuigen.Autoos.Remove(currentAuto);
                await voertuigenService.SaveVoertuigenLijst(autolijst);
                await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);
            }
            await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);
        }

        public ICommand WijzigCommand => new Command(
           async () =>
           {
               await SaveVoertuigStateAsync();

               if (Validate(currentAuto) || Validate(currentKlant))
               {
                   
                   await klantenService.SaveKlant(currentKlant);


                   MessagingCenter.Send(this, Constants.MessageNames.VoertuigenEdit, currentAuto);
                   //await CoreMethods.PopPageModel(false, true);

               }
               IsVisibleWijzig = false;
               IsVisibleGereed = true;
               //IsVisibleLocatie = true;

           }
           );

        public ICommand TerugVraagPageCommand => new Command(
         async () =>
         {

             await CoreMethods.PushPageModelWithNewNavigation<VraagViewModel>(currentVoertuigen, true);


         }
         );


        public ICommand DeleteCommand => new Command (
          async () =>
          {
              currentVoertuigen = new Voertuigen();
              currentVoertuigen = voertuigenService.GetVoertuigenLijst(3).Result;
              currentVoertuigen.Autoos.Remove(currentAuto);
              await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);
              await CoreMethods.PushPageModelWithNewNavigation<VraagViewModel>(currentVoertuigen,  true);


          }
          );
    }
}

