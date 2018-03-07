using B4.EE.DellobelI.Domain.Services.Abstract;
using FreshMvvm;

using System.Windows.Input;
using Xamarin.Forms;

namespace B4.EE.DellobelI.ViewModels
{
    public class KaartViewModel : FreshBasePageModel
    {
        private TTextfileService fileService;

        public KaartViewModel(TTextfileService fileservice)
        {
            fileService = fileservice;
        }

        private string fileContents;

        public string FileContents
        {
            get { return fileContents; }
            set
            {
                fileContents = value;
                this.RaisePropertyChanged(nameof(FileContents));
            }
        }

        public ICommand ClearContentsCommand => new Command(
            () => {
                FileContents = null;
            }
        );

        public ICommand LoadFileCommand => new Command(
            async () => {
                FileContents = await fileService.LoadText("mysavedfile.txt");
            }
        );

        public ICommand SaveFileCommand => new Command(
            async () =>
            {
                await fileService.SaveText("mysavedfile.txt", FileContents);
            }
        );

        //Naar pagina's via footer

        public ICommand OpenStatistiekPageCommand => new Command(
           async () =>
           {
               await CoreMethods.PushPageModelWithNewNavigation<StatistiekViewModel>(true);
           });

        public ICommand OpenClockPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<ClockViewModel>(true);
            });

        public ICommand OpenHomePageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<MainViewModel>(true);
            });
        public ICommand OpenDatumPageCommand => new Command(
            async () =>
            {
                await CoreMethods.PushPageModelWithNewNavigation<KlantViewModel>(true);
            });
    }
}
