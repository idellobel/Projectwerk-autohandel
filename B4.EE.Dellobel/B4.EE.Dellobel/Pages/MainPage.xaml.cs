using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Pages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.EE.DellobelI.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        protected override void OnAppearing()
        {
            //MessagingCenter.Subscribe<AankoopViewModel, Auto>(this, Constants.MessageNames.VoertuigenSaved,
            //   async (AankoopViewModel sender, Auto savedVoertuig) => {
            //       await DisplayAlert("Bewaard", $"Het voertuig {savedVoertuig.Merk}, {savedVoertuig.Model} is bewaard", "Ok");
            //   });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            //MessagingCenter.Unsubscribe<AankoopViewModel, Auto>(this, Constants.MessageNames.VoertuigenSaved);

            base.OnDisappearing();
        }



    }
}