using B4.EE.DellobelI.Domain.Services.Abstract;
using FreshMvvm;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class MainViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;

        public MainViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;

        }
        //Footer met nieuw navigatie
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
        
        public ICommand OpenStatistiekPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<StatistiekViewModel>(true);
            });

        public ICommand OpenDatumPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<KlantViewModel>(true);
            });


        //Aankoop en verkoop
        public ICommand OpenAanKoopPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModel<AankoopViewModel>(true);
            });

        public ICommand OpenOverzichtVerkoopPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModel<OverzichtVerkoopViewModel>(true);
           });

    }
}
