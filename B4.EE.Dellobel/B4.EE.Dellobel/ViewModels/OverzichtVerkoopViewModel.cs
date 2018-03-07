using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using FreshMvvm;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class OverzichtVerkoopViewModel : FreshBasePageModel
      
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;
        //private Voertuigen voertuigenLijst;




        public OverzichtVerkoopViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;
          
        }

        public ICommand ToAanbodCommand => new Command<Voertuigen>(
          async (Voertuigen voertuigenLijst) =>
          {
              voertuigenLijst = new Voertuigen();
              voertuigenLijst.Id = 0;
              voertuigenLijst = await voertuigenService.GetVoertuigenLijst(voertuigenLijst.Id);
              await CoreMethods.PushPageModel<AanbodViewModel>(voertuigenLijst,true);
          });

        public ICommand ToVerkochtCommand => new Command<Voertuigen>(
          async (Voertuigen voertuigenLijst) =>
          {
              voertuigenLijst = new Voertuigen();
              voertuigenLijst.Id = 2;
              voertuigenLijst = await voertuigenService.GetVoertuigenLijst(voertuigenLijst.Id);

              await CoreMethods.PushPageModel<VerkochtViewModel>(voertuigenLijst,true);
          });

        public ICommand ToGekochtCommand => new Command<Voertuigen>(
          async (Voertuigen voertuigenLijst) =>
          {
              voertuigenLijst = new Voertuigen();
              voertuigenLijst.Id = 1;
              voertuigenLijst = await voertuigenService.GetVoertuigenLijst(voertuigenLijst.Id);
              await CoreMethods.PushPageModel<GekochtViewModel>(voertuigenLijst,true);
          });

        public ICommand ToVraagCommand => new Command<Voertuigen>(
         async (Voertuigen voertuigenLijst) =>
         {
             voertuigenLijst = new Voertuigen();
             voertuigenLijst.Id = 3;
             voertuigenLijst = await voertuigenService.GetVoertuigenLijst(voertuigenLijst.Id);
             await CoreMethods.PushPageModel<VraagViewModel>(voertuigenLijst, true);
         });


        public ICommand ToVraagPlusCommand => new Command<Voertuigen>(
          async (Voertuigen voertuigenLijst) =>
          {
            await CoreMethods.PushPageModel<VraagInitViewModel>(voertuigenLijst,true);
          });

        public ICommand TerugVerkoopPageCommand => new Command(
          async () =>
          {
              await CoreMethods.PushPageModel<MainViewModel>();
          });


    }
}
