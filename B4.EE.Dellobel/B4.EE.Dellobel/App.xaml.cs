using B4.EE.DellobelI.Domain.Services.Abstract;
using B4.EE.DellobelI.Domain.Services.Mock;
using B4.EE.DellobelI.ViewModels;
using FreshMvvm;

using Xamarin.Forms;

namespace B4.EE.DellobelI
{
	public partial class App : Application
	{
		public App ()
		{
            InitializeComponent();

            FreshIOC.Container.Register<IKlantenService>(new KlantenInMemoryService());
            FreshIOC.Container.Register<IVoertuigenService>(new VoertuigenInMemoryService());
            FreshIOC.Container.Register<IUrenService>(new UrenInMemoryService());

            //FreshIOC.Container.Register<IKlantenService>(new AppKlantenSQLiteService());
            //FreshIOC.Container.Register<IVoertuigenService>(new VoertuigenSQLiteService());
            //FreshIOC.Container.Register<IUrenService>(new UrenSQLiteService());

            //register dependencies
            FreshIOC.Container.Register<TTextfileService>(DependencyService.Get<TTextfileService>());
            FreshIOC.Container.Register<ISoundPlayer>(DependencyService.Get<ISoundPlayer>());
            FreshIOC.Container.Register<IEmailService>(DependencyService.Get<IEmailService>());

            //MainPage = new B4.EE.DellobelI.Pages.MainPage();
            MainPage = new FreshNavigationContainer(FreshPageModelResolver.ResolvePageModel<MainViewModel>());
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
