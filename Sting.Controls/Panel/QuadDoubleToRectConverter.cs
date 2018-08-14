using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// ４つのdouble値を左上位置、サイズに見立てて<see cref="Rect"/>を生成するコンバーターです。
    /// </summary>
    public sealed class QuadDoubleToRectConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 4)
            {
                var rect = new Rect((double)values[0], (double)values[1], (double)values[2], (double)values[3]);
                return rect;
            }
            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var rect = (Rect)value;

            return new object[] { rect.X, rect.Y, rect.Width, rect.Height };
        }
    }
}