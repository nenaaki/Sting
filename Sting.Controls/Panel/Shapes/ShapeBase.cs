using Sting.Controls.Panel.Media;

namespace Sting.Controls.Panel.Shapes
{
    public class ShapeBase : ContentBase
    {
        public IPen Pen { get; set; }

        public IBrush Background { get; set; }
    }
}