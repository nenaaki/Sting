using Sting.Controls.Panel;
using Sting.Controls.Panel.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sting.Controls.Panel.Shapes
{
    public abstract class GeometryShapeBase : ShapeBase
    {
        protected StreamGeometry Geometry { get; } = new StreamGeometry();

        protected void ProcessGeometryUpdated()
        {
            Bounds = Geometry.Bounds;

            Owner?.InvalidateArrange();
        }

        public override void OnRender(DrawingContext drawingContext)
        {
            var pen = (Pen ?? EmptyPen.Instance).GetPen();
            var background = (Background ?? EmptyBrush.Instance).GetBrush();

            drawingContext.DrawGeometry(background, pen, Geometry);
        }
    }
}