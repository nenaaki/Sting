using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public interface IPen
    {
        Pen GetPen(bool freezing = true);
    }
}