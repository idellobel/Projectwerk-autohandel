using B4.EE.DellobelI.Domain.Services.Abstract;
using System;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;

[assembly: Dependency(typeof(B4.EE.DellobelI.UWP.Services.PlatformSoundPlayer))]

namespace B4.EE.DellobelI.UWP.Services
{
    internal class PlatformSoundPlayer : ISoundPlayer
    {
        public async Task PlaySound()
        {
            MediaElement mysong = new MediaElement();
            Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package
                .Current.InstalledLocation.GetFolderAsync("Assets");
            Windows.Storage.StorageFile file = await folder.GetFileAsync("munchausen.mp3");
            var stream = await file.OpenReadAsync();
            mysong.SetSource(stream, file.ContentType);
            mysong.Play(); } }
}
