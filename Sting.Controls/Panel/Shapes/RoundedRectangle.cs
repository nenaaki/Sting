using Sting.Controls.Panel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sting.Controls.Panel.Shapes
{
    public class RoundedRectangle : ShapeBase
    {
        public double RadiusX { get; set; }

        public double RadiusY { get; set; }

        public override void OnRender(DrawingContext drawingContext)
        {
            var pen = (Pen ?? EmptyPen.Instance).GetPen();
            var background = (Background ?? EmptyBrush.Instance).GetBrush();

            drawingContext.DrawRoundedRectangle(background, pen, Bounds, RadiusX, RadiusY);
        }
    }
}