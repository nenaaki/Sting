using System;
using System.Windows;
using System.Windows.Data;

namespace Sting.Converters
{
    public sealed class BoolToVisibilityConverter : IValueConverter
    {
        public readonly static BoolToVisibilityConverter Instance = new BoolToVisibilityConverter();

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool isVisible)
            {
                if (parameter is string param)
                {
                    if (param.Length == 2)
                    {
                        var index = isVisible ? 0 : 1;
                        switch (param[index])
                        {
                            case 'c':
                            case 'C':
                                return Visibility.Collapsed;

                            case 'v':
                            case 'V':
                                return Visibility.Visible;

                            case 'h':
                            case 'H':
                                return Visibility.Hidden;
                        }
                    }
                    else
                        return DependencyProperty.UnsetValue;
                }
                else
                    return isVisible ? Visibility.Visible : Visibility.Collapsed;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}