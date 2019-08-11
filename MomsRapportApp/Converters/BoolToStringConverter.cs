using System;
using System.Globalization;
using Xamarin.Forms;

namespace MomsRapportApp.Converters
{
    public class BoolToStringConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool condition = (bool)value;
            if (condition)
            {
                return "Income";
            } else
            {
                return "Expense";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null; 
        }
    }
}
