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
	public partial class EditAanbodPage : ContentPage
	{
		public EditAanbodPage ()
		{
			InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<EditAanbodViewModel, Auto>(this, Constants.MessageNames.VoertuigenEdit,
               async (EditAanbodViewModel sender, Auto editVoertuig) =>
               {
                   await DisplayAlert("Gewijzigd", $"Het voertuig {editVoertuig.Merk}, {editVoertuig.Model} is gewijzigd", "Ok");
               });

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<EditAanbodViewModel, Auto>(this, Constants.MessageNames.VoertuigenEdit);

            base.OnDisappearing();
        }
    }
}