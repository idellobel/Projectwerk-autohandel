using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using FreshMvvm;
using Xamarin.Forms.Maps;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace B4.EE.DellobelI.ViewModels
{
    public class LocatieViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;
        private Klant locatieKlant;
        private string KlantAdres;
      

        public LocatieViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;
           
        }

        #region Properties

        private ObservableCollection<Pin> pinCollection = new ObservableCollection<Pin>();
        public ObservableCollection<Pin> PinCollection
        {
            get { return pinCollection; }
            set
            {
                pinCollection = value;
                RaisePropertyChanged();
            }
        }
        private string pinLabel;
        public string PinLabel
        {
            get { return pinLabel; }
            set
            {
                pinLabel = value;
                RaisePropertyChanged();
            }
        }


        private Position myPosition;


        public Position MyPosition
        {
            get { return myPosition; }
            set
            {
                myPosition = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async override void Init(object initData)
        {
            base.Init(initData);

            locatieKlant = initData as Klant;
            KlantAdres = $"{ locatieKlant.Adres} { locatieKlant.Woonplaats} België ";
            //KlantAdres = $"Pacific Ave, San Francisco, California";
            await PinLocationsAsync();
        }


        private async Task PinLocationsAsync()  // async taak tot ophalen van de locatie
        {
            await Task.Run(async () =>
            {



                Geocoder gc = new Geocoder();

                //I believe the suggested format is:

                //House Number, Street Direction, Street Name, Street Suffix, City, State, Zip, Country

                //Manueel positie invoeren op UWP

                MyPosition = new Position(51.134634, 2.763420);
                PinLabel = $"{KlantAdres}";
                PinCollection.Add(new Pin() { Position = MyPosition, Type = PinType.Generic, Label = PinLabel });


                 
                var result =
                    await gc.GetPositionsForAddressAsync(KlantAdres);

                foreach (Position pos in result)
                {
                    Debug.WriteLine("Lat: {0}, Lng: {1}", pos.Latitude, pos.Longitude);
                    //MyPosition = new Position(pos.Latitude, pos.Longitude);
                    MyPosition = new Position(51.134634, 2.763420);
                    PinLabel = $"{KlantAdres}";
                    PinCollection.Add(new Pin() { Position = MyPosition, Type = PinType.Generic, Label = PinLabel });
                }
            });




        }

    }
}
