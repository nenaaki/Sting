using System;
using System.Globalization;
using System.Windows.Data;

namespace Sting.Controls
{
    public class DelegateConverter<TSource, TTarget> : IValueConverter
    {
        private readonly Func<TSource, TTarget> _convert;
        private readonly Func<TTarget, TSource> _convertBack;

        public DelegateConverter(Func<TSource, TTarget> convert, Func<TTarget, TSource> convertBack)
        {
            _convert = convert;
            _convertBack = convertBack;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _convert((TSource)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _convertBack((TTarget)value);
        }
    }
}