using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public class UncachedPen : IPen
    {
        public ISolidColorBrush Brush { get; set; }

        public double Thickness { get; set; }

        public Pen GetPen(bool freezing)
        {
            var pen = new Pen(Brush.GetBrush(), Thickness);
            if (freezing && pen.CanFreeze)
                pen.Freeze();

            return pen;
        }
    }
}