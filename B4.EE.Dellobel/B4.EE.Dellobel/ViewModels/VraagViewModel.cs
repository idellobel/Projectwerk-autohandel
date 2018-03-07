using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using FreshMvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class VraagViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;
        private Voertuigen voertuigenLijst;
        private Auto editAuto;



        public VraagViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;

        }

        private ObservableCollection<Auto> voertuigenVraag;
        public ObservableCollection<Auto> VoertuigenVraag
        {
            get { return voertuigenVraag; }
            set
            {
                voertuigenVraag = value;
                RaisePropertyChanged(nameof(VoertuigenVraag));
            }
        }

        private string merk;
        public string Merk
        {
            get { return merk; }
            set
            {
                merk = value;
                RaisePropertyChanged(nameof(Merk));
            }
        }

        private string model;
        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                RaisePropertyChanged(nameof(Model));
            }
        }

        private string bouwjaar; // int geeft 0
        public string Bouwjaar
        {
            get { return bouwjaar; }
            set
            {
                bouwjaar = value;
                RaisePropertyChanged(nameof(Bouwjaar));
            }
        }

        private string prijs;


        public string Prijs
        {
            get { return prijs; }
            set
            {
                prijs = value;
                RaisePropertyChanged(nameof(Prijs));
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);


            voertuigenLijst = initData as Voertuigen;

            voertuigenVraag = new ObservableCollection<Auto>(voertuigenLijst.Autoos as List<Auto>);



        }

        public override void ReverseInit(object returnedData)
        {
            base.ReverseInit(returnedData);
            //if (returnedData is Voertuigen)
            //{
            //    RefreshVoertuigenlijst();
            //}
        }

        private void RefreshVoertuigenlijst()
        {
            var voertuigen = voertuigenVraag;
            //VoertuigenAanbod = null;
            VoertuigenVraag = new ObservableCollection<Auto>(voertuigen);

            foreach (Auto a in VoertuigenVraag)
            {
                Merk = a.Merk;
                Model = a.Model;
                Bouwjaar = a.Bouwjaar.ToString();
                Prijs = a.Prijs.ToString();

            }
        }
        //protected override void ViewIsAppearing(object sender, EventArgs e)
        //{
        //    base.ViewIsAppearing(sender, e);
        //    RefreshVoertuigenlijst();
        //}

        public ICommand ToEditVraagCommand => new Command<Auto>(
          async (Auto auto) =>
          {
              editAuto = auto;

              await CoreMethods.PushPageModelWithNewNavigation<EditVraagViewModel>(editAuto, true);


          }
          );

        public ICommand TerugOverzichtVerkoopPageCommand => new Command(
          async () =>
          {


              await CoreMethods.PushPageModelWithNewNavigation<OverzichtVerkoopViewModel>(true);


          }
          );
    }
}
