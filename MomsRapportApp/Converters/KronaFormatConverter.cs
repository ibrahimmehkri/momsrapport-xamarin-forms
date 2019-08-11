using System;
using System.Globalization;
using Xamarin.Forms;

namespace MomsRapportApp.Converters
{
    public class KronaFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double amount = (double)value;
            CultureInfo.CurrentCulture = new CultureInfo("sv-SE");
            return amount.ToString("c");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; 
        }
    }
}
