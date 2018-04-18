using B4.EE.DellobelI.Domain.Services.Abstract;
using System;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;


[assembly: Dependency(typeof(B4.EE.DellobelI.UWP.Services.TextfileService))]

namespace B4.EE.DellobelI.UWP.Services
{
    internal class TextfileService : TTextfileService
    {
        public async Task SaveText(string filename, string text)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await localFolder
                .CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(sampleFile, text);
        }
        public async Task<string> LoadText(string filename)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
            string text = await FileIO.ReadTextAsync(sampleFile);
            return text;
        }
    }
}
