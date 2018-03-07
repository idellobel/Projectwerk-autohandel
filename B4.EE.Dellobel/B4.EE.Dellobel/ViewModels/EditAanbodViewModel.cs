using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Domain.Validators;
using FluentValidation;
using FreshMvvm;
using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace B4.EE.DellobelI.ViewModels
{
    public class EditAanbodViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;
        private IValidator autoValidator;
        private Auto currentAuto;
        private Voertuigen currentVoertuigen ;

        public EditAanbodViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;
            autoValidator = new AutoValidator();
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
        private string aanbod;
        public string Aanbod
        {
            get { return aanbod; }
            set
            {
                aanbod = value;
                RaisePropertyChanged(nameof(Aanbod));
            }
        }

        private DateTime aankoop = DateTime.Now ;
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

        private string foto;
        public string Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                RaisePropertyChanged(nameof(Foto));
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

        #endregion



        public override void Init(object initData)
        {

            base.Init(initData);

            currentAuto = initData as Auto;

            //LoadEditAanbodState();
        }

        private void LoadEditAanbodState()
        {
            
            AutoStatus = currentAuto.AutoStatus.ToString();
            Aanbod = currentAuto.AanBod.ToString("dd-MMM-yyyy", CultureInfo.CurrentCulture);
            //Aankoop = Convert.ToDateTime("01-jan-2000", CultureInfo.CurrentCulture);
            Bouwjaar = currentAuto.Bouwjaar.ToString();
            Brandstof = currentAuto.Brandstof.ToString();
            Foto = currentAuto.Foto;
            Merk = currentAuto.Merk;
            Model = currentAuto.Model;
            Prijs = currentAuto.Prijs.ToString();
            Verkoop = Convert.ToDateTime("01-jan-2000", CultureInfo.CurrentCulture);
            KmStand = currentAuto.KMstand.ToString();
            EersteEigenaar = currentAuto.EersteEigenaar;
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

        private async Task EditVoertuigStateAsync()
        {
            id = currentAuto.Id;
            
            currentVoertuigen = await voertuigenService.GetVoertuigenLijst(0);

            var auto = currentVoertuigen.Autoos.FirstOrDefault(currentAuto => currentAuto.Id == Id);

            if (auto != null)
            {
                auto.Merk = Merk;
                auto.Model = Model;
                auto.Prijs = Convert.ToDecimal(Prijs);
                auto.AutoStatus = (AutoStatus)Enum.Parse(typeof(AutoStatus), AutoStatus);
                auto.AanBod = Convert.ToDateTime(Aanbod);
                auto.Aankoop = Convert.ToDateTime(Aankoop);
                auto.Bouwjaar = Convert.ToInt16(Bouwjaar);
                auto.Brandstof = (Brandstof)Enum.Parse(typeof(Brandstof), Brandstof); ;
                auto.Foto = Foto;
                auto.Verkoop = Convert.ToDateTime(Verkoop);
                auto.KMstand = Convert.ToInt32(KmStand);
                auto.EersteEigenaar = EersteEigenaar;
            }
            


            if(auto.AutoStatus == (AutoStatus)Enum.Parse(typeof(AutoStatus),"Gekocht"))
            {
              var autolijst =  await voertuigenService.GetVoertuigenLijst(1);
                if (autolijst.Autoos == null) autolijst.Autoos = new List<Auto>();
                autolijst.Autoos.Add(auto);
                currentVoertuigen.Autoos.Remove(auto);
                await voertuigenService.SaveVoertuigenLijst(autolijst);
                await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);
            }
            if (auto.AutoStatus == (AutoStatus)Enum.Parse(typeof(AutoStatus), "Verkocht"))
            {
                var autolijst = await voertuigenService.GetVoertuigenLijst(2);
                if (autolijst.Autoos == null) autolijst.Autoos = new List<Auto>();
                autolijst.Autoos.Add(auto);
                currentVoertuigen.Autoos.Remove(auto);
                await voertuigenService.SaveVoertuigenLijst(autolijst);
                await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);
            }

            //Verplaatsen naar status.Vraag niet zinvol.
            //if (auto.AutoStatus == (AutoStatus)Enum.Parse(typeof(AutoStatus), "Vraag"))
            //{
            //    var autolijst = await voertuigenService.GetVoertuigenLijst(3);
            //    if (autolijst.Autoos == null) autolijst.Autoos = new List<Auto>();
            //    autolijst.Autoos.Add(auto);
            //    currentVoertuigen.Autoos.Remove(auto);
            //    await voertuigenService.SaveVoertuigenLijst(autolijst);
            //    await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);
            //}
       
        }

        public ICommand WijzigCommand => new Command(
           async () =>
           {
              
               if (Validate(currentAuto))
               {
                   await EditVoertuigStateAsync();


                   MessagingCenter.Send(this, Constants.MessageNames.VoertuigenEdit, currentAuto);
                    //await CoreMethods.PopPageModel(false, true);

                }
               IsVisibleWijzig = false;
               IsVisibleGereed = true;
               //IsVisibleLocatie = true;

           }
           );

        public ICommand FotoCommand => new Command(
           async () =>
           {

               await CoreMethods.PushPageModel<FotoViewModel>(currentAuto, false, true);


           }
           );

        public ICommand TerugAanbodPageCommand => new Command(
          async () =>
          {

              await CoreMethods.PushPageModel<AanbodViewModel>(currentVoertuigen,false, true);


          }
          );
    }
}
