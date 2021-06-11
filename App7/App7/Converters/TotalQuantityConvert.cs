using System;
using System.Globalization;
using Xamarin.Forms;

namespace App7.Converters
{
    public class TotalQuantityConvert : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Model.Viewitem && value != null)
            {
                Model.Viewitem tmp = (Model.Viewitem)value;
                return string.Format(" + {0} ", tmp.TotalQuantity);
            }

            return null;
        }

    
        public object ConvertBack(object value, Type targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
