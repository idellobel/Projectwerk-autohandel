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
	public partial class ClockPage : ContentPage
	{
		public ClockPage ()
		{
			InitializeComponent ();
		}
        //protected override void OnAppearing()
        //{
        //    MessagingCenter.Subscribe<ClockViewModel, WerkUren>(this, Constants.MessageNames.WerkUrenDeleted,
        //       async (ClockViewModel sender, WerkUren werkuur) =>
        //       {
        //           await DisplayAlert("Verwijderen", $"U staat op het punt {werkuur.GewerkteTijd} te verwijderen?", "OK");
                   
        //       });

        //    base.OnAppearing();
        //}

        //protected override void OnDisappearing()
        //{
        //    MessagingCenter.Unsubscribe<ClockViewModel, WerkUren>(this, Constants.MessageNames.WerkUrenDeleted);

        //    base.OnDisappearing();
        //}
    }
}