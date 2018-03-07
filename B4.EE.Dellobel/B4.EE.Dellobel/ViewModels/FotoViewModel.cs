using B4.EE.DellobelI.Domain.Models;
using B4.EE.DellobelI.Domain.Services.Abstract;
using FreshMvvm;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class FotoViewModel : FreshBasePageModel
    {
        private IKlantenService klantenService;
        private IVoertuigenService voertuigenService;

        private Auto currentAuto;


        public FotoViewModel(IKlantenService klantenService, IVoertuigenService voertuigenService)
        {
            this.klantenService = klantenService;
            this.voertuigenService = voertuigenService;

        }
        #region Properties
        private int id;
        public int Id
        {
            get { return id; }
        }

        private string foto;
        public string Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                RaisePropertyChanged(nameof(Foto));
            }
        }

        private ImageSource fotoSource;


        public ImageSource FotoSource
        {
            get { return fotoSource; }
            set
            {
                fotoSource = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public override void Init(object initData)
        {

            base.Init(initData);

            currentAuto = initData as Auto;

            id = currentAuto.Id;
            currentAuto.Foto = $"{currentAuto.Merk}_{ currentAuto.Model}";
        }


        public ICommand FotoCommand => new Command(
                async () =>
                {
                    var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });

                    if (photo != null)
                        FotoSource = ImageSource.FromStream(() => { return photo.GetStream(); });

                    var documentsDirectory = Environment.GetFolderPath
                        (Environment.SpecialFolder.Personal);
                    Foto = System.IO.Path.Combine(documentsDirectory, $"{currentAuto.Foto}.jpg");
                    
                    await EditFotoAsync();
                   
                });
        private async Task EditFotoAsync()
        {

            var currentVoertuigen = await voertuigenService.GetVoertuigenLijst(0);

            var auto = currentVoertuigen.Autoos.FirstOrDefault(currentAuto => currentAuto.Id == Id);

            if (auto != null)
            {
                auto.Foto = Foto;

                await voertuigenService.SaveVoertuigenLijst(currentVoertuigen);
            }

        }
    }
}
