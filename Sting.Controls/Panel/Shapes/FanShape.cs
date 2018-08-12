using System;
using System.Windows;
using System.Windows.Media;

namespace Sting.Controls.Panel.Shapes
{
    public class FanShape : PieShape
    {
        public double InnerRatio { get; set; }

        private void Render(StreamGeometryContext context)
        {
            var bounds = Bounds;

            var direction = Angle < 0 ? SweepDirection.Counterclockwise : SweepDirection.Clockwise;
            var reverse = Angle >= 0 ? SweepDirection.Counterclockwise : SweepDirection.Clockwise;
            bool isLarge = Math.Abs(Angle) > Math.PI;

            var rx = bounds.Width / 2;
            var ry = bounds.Height / 2;

            var cx = rx + bounds.X;
            var cy = ry + bounds.Y;

            var x1 = cx + Math.Cos(Start) * rx;
            var y1 = cy + Math.Sin(Start) * ry;

            var x2 = cx + Math.Cos(Start + Angle) * rx;
            var y2 = cy + Math.Sin(Start + Angle) * ry;

            var ix1 = cx + Math.Cos(Start) * rx * InnerRatio;
            var iy1 = cy + Math.Sin(Start) * ry * InnerRatio;

            var ix2 = cx + Math.Cos(Start + Angle) * rx * InnerRatio;
            var iy2 = cy + Math.Sin(Start + Angle) * ry * InnerRatio;

            context.BeginFigure(new Point(x1, y1), true, true);

            context.ArcTo(new Point(x2, y2), new Size(rx, ry), 0, isLarge, direction, true, false);

            context.LineTo(new Point(ix2, iy2), false, false);

            context.ArcTo(new Point(ix1, iy1), new Size(InnerRatio * rx, InnerRatio * ry), 0, isLarge, reverse, true, false);
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