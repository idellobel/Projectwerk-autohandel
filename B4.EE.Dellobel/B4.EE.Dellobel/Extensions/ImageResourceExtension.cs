using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace B4.EE.DellobelI.Extensions
{
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            //get the ImageSource based on the given ResourceId 
            var imageSource = ImageSource.FromResource(Source, Assembly.GetExecutingAssembly());
            return imageSource;
        }
    }
}
