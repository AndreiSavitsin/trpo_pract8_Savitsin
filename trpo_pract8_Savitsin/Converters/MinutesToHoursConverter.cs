using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace trpo_pract8_Savitsin.Converters
{
    public class MinutesToHoursConverter :IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parametr, CultureInfo culture)
        {
            if (value is int minutes)
            {
                double hours = Math.Round(minutes / 60.0, 2);
                return $"{hours} ч";
            }

            return "0 ч";
        }
        public object ConvertBack(object value, Type targetType,
            object parametr, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
