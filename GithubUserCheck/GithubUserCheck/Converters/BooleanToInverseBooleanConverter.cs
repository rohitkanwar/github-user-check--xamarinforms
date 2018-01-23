using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GithubUserCheck.Converters
{
    /// <summary>
    /// Converts a boolean value to its inverse (negative).
    /// </summary>
    class BooleanToInverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Try to convert the given value to a boolean one:
            bool extractedValue = false;
            if (value is bool)
            {
                extractedValue = (bool)value;
            }

            return !extractedValue;
        }

        // Used in case of two-way binding.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // For this particular converter, the Convert and ConvertBack functionalities are exactly the same.
            return Convert(value, targetType, parameter, culture);
        }
    }
}
