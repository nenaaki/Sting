using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public class UncachedSolidColorBrush : ISolidColorBrush
    {
        public Color32 Color { get; set; }

        public Brush GetBrush(bool freezing = true)
        {
            var brush = new SolidColorBrush(Color);
            if (freezing && brush.CanFreeze)
                brush.Freeze();

            return brush;
        }
    }
}