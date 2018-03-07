using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Pages;
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
	public partial class ClockInitPage : ContentPage
	{
		public ClockInitPage ()
		{
			InitializeComponent ();
		}
        //protected override void OnAppearing()
        //{
        //    MessagingCenter.Subscribe<ClockInitViewModel, WerkUren>(this, Constants.MessageNames.WerkUrenSaved,
        //       async (ClockInitViewModel sender, WerkUren savedUren) =>
        //       {
        //           await DisplayAlert("Bewaard", $"{savedUren.GewerkteTijd} uren  bewaard", "Ok");
        //       });

        //    base.OnAppearing();
        //}

        //protected override void OnDisappearing()
        //{
        //    MessagingCenter.Unsubscribe<ClockInitViewModel, WerkUren>(this, Constants.MessageNames.WerkUrenSaved);

        //    base.OnDisappearing();
        //}
    }
}