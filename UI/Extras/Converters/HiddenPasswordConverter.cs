using System.Globalization;
using System.Windows.Data;

namespace UI.Extras.Converters
{
    public class HiddenPasswordConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string password && !string.IsNullOrEmpty(password))
            {
                return new string('*', password.Length);
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // ConvertBack is not needed since we don’t allow editing passwords from UI
            throw new NotImplementedException();
        }
    }
}
