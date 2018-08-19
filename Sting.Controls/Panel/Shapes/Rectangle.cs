using System.Windows.Media;
using Sting.Controls.Panel.Media;

namespace Sting.Controls.Panel.Shapes
{
    internal class Rectangle : ShapeBase
    {
        public override void OnRender(DrawingContext drawingContext)
        {
            var pen = (Pen ?? EmptyPen.Instance).GetPen();
            var background = (Background ?? EmptyBrush.Instance).GetBrush();

            drawingContext.DrawRectangle(background, pen, Bounds);
        }
    }
}