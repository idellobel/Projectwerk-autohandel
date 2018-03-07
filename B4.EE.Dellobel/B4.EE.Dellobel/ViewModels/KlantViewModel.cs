using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Pages;
using FreshMvvm;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class KlantViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        

        public KlantViewModel(IKlantenService klantenService)
        {
            this.klantenService = klantenService;
        }

        #region Properties

        private ObservableCollection<Klant> klanten;
        public ObservableCollection<Klant> Klanten
        {
            get { return klanten; }
            set
            {
                klanten = value;
                RaisePropertyChanged(nameof(Klanten));
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


       

        #endregion
        public async override void Init(object initData)
        {
            base.Init(initData);
            await RefreshKlantenlijst();
          
        }


        private async Task RefreshKlantenlijst()
        {
            var klanten = await klantenService.GetAllKlantenOrdered();
            
            Klanten = null;

            Klanten = new ObservableCollection<Klant>(klanten);
           
        }



        //}
        protected async override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            await RefreshKlantenlijst();
        }

        //public ICommand WijzigCommand => new Command<Klant>(
        //      async (Klant klant) =>
        //      {
        //          //MessagingCenter.Send(this, Constants.MessageNames.WerkUrenDeleted, werkuur);
        //          //int id = werkuur.WerkId;
        //          //werkUren.Remove(werkuur);


        //          await klantenService.DeleteKlant(klant.Id);
        //          //await urenService.GetAllUren();
        //          await RefreshKlantenlijst();

        //          await CoreMethods.PushPageModelWithNewNavigation<KlantViewModel>(true);

        //      });


        public ICommand ToKlantInitCommand => new Command<Klant>(
         async (Klant klant) =>
         {
             await CoreMethods.PushPageModel<KlantInitViewModel>(klant,true);
         });



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
        public ICommand OpenStatistiekPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<StatistiekViewModel>(true);
            });
    }
}
