using System;
using System.Windows;
using System.Windows.Media;

namespace Sting.Controls.Panel.Shapes
{
    public class PieShape : GeometryShapeBase
    {
        public double Start { get; set; }

        public double Angle { get; set; }

        private void Render(StreamGeometryContext context)
        {
            var bounds = Bounds;

            var direction = Angle < 0 ? SweepDirection.Counterclockwise : SweepDirection.Clockwise;
            bool isLarge = Math.Abs(Angle) > Math.PI;

            var rx = bounds.Width / 2;
            var ry = bounds.Height / 2;

            var cx = rx + bounds.X;
            var cy = ry + bounds.Y;

            var x1 = bounds.X + rx + Math.Cos(Start) * rx;
            var y1 = bounds.Y + ry + Math.Sin(Start) * ry;

            var x2 = bounds.X + rx + Math.Cos(Start + Angle) * rx;
            var y2 = bounds.Y + ry + Math.Sin(Start + Angle) * ry;

            context.BeginFigure(new Point(cx, cy), true, true);

            context.LineTo(new Point(x1, y1), false, false);

            context.ArcTo(new Point(x2, y2), new Size(rx, ry), 0, isLarge, direction, true, false);
        }

        public override void OnRender(DrawingContext drawingContext)
        {
            Geometry.Clear();

            using (var context = Geometry.Open())
            {
                Render(context);
            }

            drawingContext.DrawGeometry(Background?.GetBrush(), Pen?.GetPen(), Geometry);
        }
    }
}