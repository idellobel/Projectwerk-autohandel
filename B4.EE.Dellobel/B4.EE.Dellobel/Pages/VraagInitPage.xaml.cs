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
	public partial class VraagInitPage : ContentPage
	{
		public VraagInitPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            MessagingCenter.Subscribe<VraagInitViewModel, Auto>(this, Constants.MessageNames.VoertuigenEdit,
               async (VraagInitViewModel sender, Auto editVoertuig) =>
               {
                   await DisplayAlert("Gewijzigd", $"Het voertuig {editVoertuig.Merk}, {editVoertuig.Model} is gewijzigd", "Ok");
               });

            MessagingCenter.Subscribe<VraagInitViewModel, Auto>(this, Constants.MessageNames.VoertuigenDeleteFault,
               async (VraagInitViewModel sender, Auto editVoertuig) =>
               {
                   await DisplayAlert("Selecteerfout", $"Selecteer status 'Vraag'", "Ok");
               });
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<VraagInitViewModel, Auto>(this, Constants.MessageNames.VoertuigenEdit);
            MessagingCenter.Unsubscribe<VraagInitViewModel, Auto>(this, Constants.MessageNames.VoertuigenDeleteFault);
            base.OnDisappearing();
        }
    }
}