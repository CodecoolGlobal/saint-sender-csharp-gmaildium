using Svg;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SaintSender.DesktopUI.Converters
{
    class DateStringFormatConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string date = value.ToString();
            date = date.Remove(date.Length - 10);
            return date;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime parsedDate = DateTime.Parse(value.ToString());
            return parsedDate;
        }
    }
}
