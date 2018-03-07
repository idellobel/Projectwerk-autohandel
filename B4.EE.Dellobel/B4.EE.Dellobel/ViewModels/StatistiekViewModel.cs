using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Extensions;
using FreshMvvm;
using System.Windows.Input;
using System;
using Xamarin.Forms;
using System.Linq;

namespace B4.EE.DellobelI.ViewModels
{
    class StatistiekViewModel : FreshBasePageModel
    {
        
        private IUrenService urenService;
        private IEmailService emailService;
        private ISoundPlayer soundPlayer;
        private string currentUurWeek;
        private string currentOmzetWeek;
       
        
        public StatistiekViewModel(IUrenService urenService, IEmailService emailService, ISoundPlayer soundPlayer )
        {
            this.urenService = urenService;
            this.emailService = emailService;
            this.soundPlayer = soundPlayer;

        }

        #region Properties

        private TimeSpan weekUur;
        public TimeSpan WeekUur
        {
            get { return weekUur; }
            set
            {
                weekUur = value;
                RaisePropertyChanged(nameof(WeekUur));
            }
        }

        private TimeSpan maandUur;
        public TimeSpan MaandUur
        {
            get { return maandUur; }
            set
            {
                maandUur = value;
                RaisePropertyChanged(nameof(MaandUur));
            }
        }

        private TimeSpan jaarUur; 
        public TimeSpan JaarUur
        {
            get { return jaarUur; }
            set
            {
                jaarUur = value;
                RaisePropertyChanged(nameof(JaarUur));
            }
        }

        private decimal weekOmzet;
        public decimal WeekOmzet
        {
            get { return weekOmzet; }
            set
            {
                weekOmzet = value;
                RaisePropertyChanged(nameof(WeekOmzet));
            }
        }

        private decimal maandOmzet;
        public decimal MaandOmzet
        {
            get { return maandOmzet; }
            set
            {
                maandOmzet = value;
                RaisePropertyChanged(nameof(MaandOmzet));
            }
        }

        private decimal jaarOmzet;
        public decimal JaarOmzet
        {
            get { return jaarOmzet; }
            set
            {
                jaarOmzet = value;
                RaisePropertyChanged(nameof(JaarOmzet));
            }
        }

        #endregion 

        private async void BerekenUren()
        {
            var uren = await urenService.GetAllUren();
                        
            var weekCriteria = DateTime.Now.Date.AddDays(-7);

            WeekUur = uren.Where(d => d.Datum >= weekCriteria)
                      .Sum(s => s.GewerkteTijd);

            MaandUur = uren.Where(predicate: d => d.Datum.Year == DateTime.Now.Year && d.Datum.Month == DateTime.Now.Month)
                      .Sum(s => s.GewerkteTijd);

            JaarUur = uren.Where(d => d.Datum.Year == DateTime.Now.Year)
                      .Sum(s => s.GewerkteTijd);

            WeekOmzet = uren.Where(d => d.Datum >= weekCriteria)
                      .Sum(s => s.Waarde);

            MaandOmzet = uren.Where(predicate: d => d.Datum.Year == DateTime.Now.Year && d.Datum.Month == DateTime.Now.Month)
                        .Sum(s => s.Waarde);

            JaarOmzet = uren.Where(d => d.Datum.Year == DateTime.Now.Year)
                        .Sum(s => s.Waarde);
        }

      

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            BerekenUren();
        }

        private void SaveStatistiekState()
        {
            currentUurWeek = WeekUur.ToString();
            currentOmzetWeek = WeekOmzet.ToString();

        }


        public ICommand VerstuurWeekOverichtCommand => new Command(
          async () =>
          {
              SaveStatistiekState();

              //var emailService = DependencyService.Get<IEmailService>();
              await emailService.SendMailAsync(
                                $" Onderwerp = Weekgegevens ",
                                $"\n Uren = {currentUurWeek}\n Omzet = {currentOmzetWeek}" +
                                $"\n vriendelijke groeten" +
                                $"\n Ivan ",
                               "ivan.dellobel@gmail.com", //HRM
                               "Ivan Dellobel",
                               "ivan.dellobel@gmail.com",
                               "Ivan Dellobel"

                               );

              await soundPlayer.PlaySound();

              MessagingCenter.Send(this, Constants.MessageNames.MailBevestiging);

          }
          );


         //naar pagina's via footer
        public ICommand OpenKaartPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModelWithNewNavigation<KaartViewModel>(true);
           });

        public ICommand OpenClockPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<ClockViewModel>(true);
            });

        public ICommand OpenHomePageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<MainViewModel>(true);
            });
        public ICommand OpenDatumPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<KlantViewModel>(true);
            });
    }
   

}
