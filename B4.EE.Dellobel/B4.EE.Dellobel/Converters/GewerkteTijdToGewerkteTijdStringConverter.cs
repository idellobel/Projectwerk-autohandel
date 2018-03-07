using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace B4.EE.DellobelI.Converters
{
    public class GewerkteTijdToGewerkteTijdStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TimeSpan tijd = (TimeSpan)value;


            if (value is TimeSpan)
            {
                string formatH = tijd.ToString("hh");
                string formatM = tijd.ToString("mm");
                return $"{formatH} uur en {formatM} min";
            }
            else
                throw new ArgumentException("waarde is van type 'Timespan'", "value");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
