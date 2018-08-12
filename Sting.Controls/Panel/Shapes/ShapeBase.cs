using Sting.Controls.Panel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sting.Controls.Panel.Shapes
{
    public class ShapeBase : ContentBase
    {
        public IPen Pen { get; set; }
        public IBrush Background { get; set; }
    }
}