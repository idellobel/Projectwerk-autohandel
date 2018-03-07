using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Domain.Validators;
using FluentValidation;
using FreshMvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class ClockInitViewModel : FreshBasePageModel
    {
        private IUrenService urenService;
        private IValidator werkUrenValidator;
        private WerkUren currentWerkUren;

        public ClockInitViewModel(IUrenService urenService)
        {
            this.urenService = urenService;
            werkUrenValidator = new WerkUrenValidator();
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

        private DateTime startDatum = DateTime.Now;
        public DateTime StartDatum
        {
            get { return startDatum; }
            set
            {
                startDatum = value;
                RaisePropertyChanged(nameof(StartDatum));
            }
        }

        private string startDatumError;
        public string StartDatumError
        {
            get { return startDatumError; }
            set
            {
                startDatumError = value;
                RaisePropertyChanged(nameof(StartDatumError));
                RaisePropertyChanged(nameof(StartDatumErrorVisible));
            }
        }

        public bool StartDatumErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(StartDatumError); }
        }


        private TimeSpan startTijd = new TimeSpan(7,55,00);
        public TimeSpan StartTijd
        {
            get { return startTijd; }
            set
            {
                startTijd = value;
                RaisePropertyChanged(nameof(StartTijd));
                RaisePropertyChanged(nameof(GewerkteTijd));
            }
        }

        private string startTijdError;
        public string StartTijdError
        {
            get { return startDatumError; }
            set
            {
                startTijdError = value;
                RaisePropertyChanged(nameof(StartTijdError));
                RaisePropertyChanged(nameof(StartTijdErrorVisible));
            }
        }

        public bool StartTijdErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(StartTijdError); }
        }

        private TimeSpan eindTijd = new TimeSpan(17,0,0);
        public TimeSpan EindTijd
        {
            get { return eindTijd; }
            set
            {
                eindTijd = value;
                RaisePropertyChanged(nameof(EindTijd));
                RaisePropertyChanged(nameof(GewerkteTijd));
            }
        }

        private string eindTijdError;
        public string EindTijdError
        {
            get { return eindTijdError; }
            set
            {
                startDatumError = value;
                RaisePropertyChanged(nameof(EindTijdError));
                RaisePropertyChanged(nameof(EindTijdErrorVisible));
            }
        }

        public bool EindTijdErrorVisible
        {
            get { return !string.IsNullOrWhiteSpace(EindTijdError); }
        }

        private string toelichting;
        public string Toelichting
        {
            get { return toelichting; }
            set
            {
                toelichting = value;
                RaisePropertyChanged(nameof(Toelichting));
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
                RaisePropertyChanged(nameof(Waarde));
            }
        }

        private string verkoop;
        public string Verkoop
        {
            get { return verkoop; }
            set
            {
                verkoop = value;
                RaisePropertyChanged(nameof(Verkoop));
                RaisePropertyChanged(nameof(Waarde));
            }
        }

        public TimeSpan GewerkteTijd
        {
            get
            {
                TimeSpan gewerkteTijd = EindTijd - StartTijd;
                return gewerkteTijd;
            }
        }

        public decimal Waarde
        {
            get
            {
                decimal Waarde = Convert.ToDecimal(Verkoop) - Convert.ToDecimal(Aankoop);
                return Waarde;
            }
        }
        #endregion


        private void SaveWerkuren()
        {
            currentWerkUren = new WerkUren();

            currentWerkUren.WerkId = new int();
            currentWerkUren.Aankoop = Convert.ToDecimal(Aankoop);
            currentWerkUren.BeginTijd = StartTijd;
            currentWerkUren.EindTijd = EindTijd;
            currentWerkUren.Datum = StartDatum;
            currentWerkUren.GewerkteTijd = GewerkteTijd;
            currentWerkUren.Waarde = Waarde;
            currentWerkUren.Toelichting = Toelichting;
            

        }

        private bool Validate(WerkUren werk)
        {
            var validationResult = werkUrenValidator.Validate(werk);
            foreach (var error in validationResult.Errors)
            {
                if (error.PropertyName == nameof(werk.Datum))
                {
                    StartDatumError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(werk.BeginTijd))
                {
                    StartTijdError = error.ErrorMessage;
                }
                if (error.PropertyName == nameof(werk.EindTijd))
                {
                    EindTijdError = error.ErrorMessage;
                }


            }
            return validationResult.IsValid;
        }
        public ICommand BewaarWerkUrenCommand => new Command(
          async () =>
          {
              SaveWerkuren();
              if (Validate(currentWerkUren)) 
              {


                  await urenService.SaveUren(currentWerkUren);
                  MessagingCenter.Send(this, Constants.MessageNames.WerkUrenSaved, currentWerkUren);
                  //await CoreMethods.PopPageModel(false, true);
                  await CoreMethods.PushPageModel<ClockViewModel>(false, true);
              }
              IsVisibleBewaar = false;
              IsVisibleGereed = true;
             

          }
          );
        public ICommand TerugClockPageFromGereedCommand => new Command(
        async () =>
        {

            //await CoreMethods.PushPageModel<ClockViewModel>(false, true);

            await CoreMethods.PopPageModel(false, true);

        }
        );


        public ICommand TerugClockPageCommand => new Command(
         async () =>
         {

             await CoreMethods.PushPageModel<ClockViewModel>( false, true);

             //await CoreMethods.PopPageModel(currentWerkUren, true);

         }
         );
    }
}