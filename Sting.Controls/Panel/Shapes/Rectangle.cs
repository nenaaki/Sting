using Sting.Controls.Panel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

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