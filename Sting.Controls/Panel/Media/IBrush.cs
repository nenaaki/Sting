using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public interface IBrush
    {
        Brush GetBrush(bool freezing = true);
    }
}