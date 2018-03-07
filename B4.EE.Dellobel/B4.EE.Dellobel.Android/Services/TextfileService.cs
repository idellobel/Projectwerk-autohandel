using System;
using B4.EE.DellobelI.Domain.Services.Abstract;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.IO;

[assembly: Dependency(typeof(B4.EE.DellobelI.Droid.Services.TextfileService))]

namespace B4.EE.DellobelI.Droid.Services
{
    public class TextfileService : TTextfileService
    {
        public async Task SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
            await Task.Delay(0);
        }

        

        public async Task <string> LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            await Task.Delay(0);
            return File.ReadAllText(filePath);
        }
    }
}