using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace B4.EE.DellobelI.Converters
{
    public class DatumToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime tijd = (DateTime)value;


            if (value is DateTime)
            {
                string format = tijd.ToString("d MMM yyyy");
                return $"Datum: {format}";
            }
            else
                throw new ArgumentException("waarde is van type 'DateTime'", "value");
        }



        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}

