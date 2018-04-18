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
	public partial class StatistiekPage : ContentPage
	{
		public StatistiekPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
           

            MessagingCenter.Subscribe<StatistiekViewModel>(this, Constants.MessageNames.MailBevestiging,
               async (StatistiekViewModel sender) =>
               {
                   await DisplayAlert("Bericht is verzonden", $"Uw weekgegevens zijn verstuurd." +
                                           $"\nVriendelijke groeten" +
                                           $"\nDe personeelsverantwoordelijke ", "OK");
               });
            MessagingCenter.Subscribe<StatistiekViewModel>(this, Constants.MessageNames.MailNietVerstuurd,
               async (StatistiekViewModel sender) =>
               {
                   await DisplayAlert("Bericht wordt niet verzonden!", $"Zie de internetverbinding na.", "OK");
               });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            
            MessagingCenter.Unsubscribe<StatistiekViewModel>(this, Constants.MessageNames.MailBevestiging);
            MessagingCenter.Unsubscribe<StatistiekViewModel>(this, Constants.MessageNames.MailNietVerstuurd);

            base.OnDisappearing();
        }
    }
}