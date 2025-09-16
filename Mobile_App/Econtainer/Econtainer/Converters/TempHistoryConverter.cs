using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Econtainer.Converters
{
    public class TempHistoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var history = value as List<(DateTime Time, double Temperature)>;
            return history == null ? "" : string.Join("\n", history.Select(h => $"{h.Time.ToShortDateString()}: {h.Temperature}°C"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); // Not used
        }
    }

}
