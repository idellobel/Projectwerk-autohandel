using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using FreshMvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class ClockViewModel : FreshBasePageModel
    {
        private IUrenService urenService;
        //private WerkUren urenLijst;

        public ClockViewModel(IUrenService urenService)
        {
            this.urenService = urenService;
        }

        #region Properties

        private ObservableCollection<WerkUren> werkUren;
        public ObservableCollection<WerkUren> WerkUren
        {
            get { return werkUren; }
            set
            {
                werkUren = value;
                RaisePropertyChanged(nameof(WerkUren));
            }
        }


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


        private DateTime startDatum ;
        public DateTime StartDatum
        {
            get { return startDatum; }
            set
            {
                startDatum = value;
                RaisePropertyChanged(nameof(StartDatum));
            }
        }

        #endregion
        public async override void Init (object initData)
        {
            base.Init(initData);
            await RefreshWerkUrenlijst();
            //var uren = await urenService.GetAllUren();
            
            //WerkUren = null;

            //WerkUren = new ObservableCollection<WerkUren>(uren);
            
        }


        private async Task RefreshWerkUrenlijst()
        {
            var uren = await urenService.GetAllUren();

            WerkUren = null;

            WerkUren = new ObservableCollection<WerkUren>(uren);
        }



        //}
        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await RefreshWerkUrenlijst();
        }

        public ICommand DeleteUrenCommand => new Command<WerkUren>(
              async  (WerkUren werkuur) =>
                {
                    //MessagingCenter.Send(this, Constants.MessageNames.WerkUrenDeleted, werkuur);
                    //int id = werkuur.WerkId;
                    //werkUren.Remove(werkuur);


                    await urenService.DeleteUren(werkuur.WerkId);
                    //await urenService.GetAllUren();
                    await RefreshWerkUrenlijst();

                    await CoreMethods.PushPageModelWithNewNavigation<ClockViewModel>(true);

                });


        public ICommand ToClockInitCommand => new Command(
         async () =>
         {
             await CoreMethods.PushPageModelWithNewNavigation<ClockInitViewModel>( true);
         });

       



        //Naar pagina's vanuit footer
        public ICommand OpenKaartPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModelWithNewNavigation<KaartViewModel>(true);
           });

        public ICommand OpenStatistiekPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<StatistiekViewModel>(true);
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

        //public ICommand TerugMainPageCommand => new Command(
        //    async () =>
        //    {
        //        await CoreMethods.PushPageModel<MainViewModel>(true);
        //    });
    }
}
