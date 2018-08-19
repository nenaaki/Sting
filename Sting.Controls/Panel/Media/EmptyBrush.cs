using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public class EmptyBrush : IBrush
    {
        public static readonly EmptyBrush Instance = new EmptyBrush();

        public Brush GetBrush(bool freezing = true)
        {
            return null;
        }
    }
}