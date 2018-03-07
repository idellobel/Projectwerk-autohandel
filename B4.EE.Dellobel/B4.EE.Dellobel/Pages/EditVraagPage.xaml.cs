using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Pages;
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
	public partial class EditVraagPage : ContentPage
	{
		public EditVraagPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<EditVraagViewModel, Auto>(this, Constants.MessageNames.VoertuigenEdit,
               async (EditVraagViewModel sender, Auto editVoertuig) =>
               {
                   await DisplayAlert("Gewijzigd", $"Het voertuig {editVoertuig.Merk}, {editVoertuig.Model} is gewijzigd", "Ok");
               });

            MessagingCenter.Subscribe<EditVraagViewModel, Auto>(this, Constants.MessageNames.VoertuigenEditFault,
               async (EditVraagViewModel sender, Auto editVoertuig) =>
               {
                   await DisplayAlert("Invoerfout", $"Het veld Verkoopprijs dient correct ingevuld", "Ok");
               });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<EditVraagViewModel, Auto>(this, Constants.MessageNames.VoertuigenEdit);
            MessagingCenter.Unsubscribe<EditVraagViewModel, Auto>(this, Constants.MessageNames.VoertuigenEditFault);
            base.OnDisappearing();
        }
    }
}