using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public interface ISolidColorBrush : IBrush
    {
        Color32 Color { get; set; }
    }
}