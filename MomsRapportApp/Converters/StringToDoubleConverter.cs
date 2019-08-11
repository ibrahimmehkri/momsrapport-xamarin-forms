using System;
using System.Diagnostics;
using System.Globalization;
using Xamarin.Forms;
namespace MomsRapportApp.Converters
{
    public class StringToDoubleConverter : IValueConverter
    {
        public StringToDoubleConverter()
        {
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string text = (string)value;
            return Double.Parse(text); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
