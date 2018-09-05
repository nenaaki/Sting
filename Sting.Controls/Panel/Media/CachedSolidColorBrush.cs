using System.Collections.Generic;
using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public class CachedSolidColorBrush : ISolidColorBrush
    {
        private static Dictionary<Immutable.Color32, SolidColorBrush> Brushes { get; } = new Dictionary<Immutable.Color32, SolidColorBrush>();

        public static void Clear()
        {
            Brushes.Clear();
        }

        public Immutable.Color32 Color { get; set; }

        public Brush GetBrush(bool freezing = true)
        {
            if (freezing)
            {
                SolidColorBrush brush;
                if (Brushes.TryGetValue(Color, out brush))
                    return brush;

                brush = new SolidColorBrush(Color);
                brush.Freeze();
                Brushes.Add(Color, brush);
                return brush;
            }

            return new SolidColorBrush(Color);
        }
    }
}