using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.EE.DellobelI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class KlantInitPage : ContentPage
	{
		public KlantInitPage()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<KlantInitViewModel, Klant>(this, Constants.MessageNames.KlantinvoerFout,
               async (KlantInitViewModel sender, Klant editVoertuig) =>
               {
                   await DisplayAlert("Input", $"Hier geen nieuwe klant aanmaken!", "Ok");
               });

           
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<KlantInitViewModel, Klant>(this, Constants.MessageNames.KlantinvoerFout );
            
            base.OnDisappearing();
        }
    }
}