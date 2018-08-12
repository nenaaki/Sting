using System;
using System.Windows;
using System.Windows.Controls;

namespace Sting.Controls.Panel
{
    public partial class StackLayouter : LayouterBase
    {
        public Orientation Orientation { get; set; }

        public override void Measure(Size availableSize)
        {
            Orientation orientation = Orientation;

            var baseSize = (orientation == Orientation.Horizontal)
                ? new Size(double.PositiveInfinity, availableSize.Height)
                : new Size(availableSize.Width, double.PositiveInfinity);
            var totalSize = new Size();
            ChildRectDic.Clear();
            foreach (var child in Children)
            {
                child.Measure(baseSize);
                var size = child.DesiredSize;
                switch (orientation)
                {
                    case Orientation.Horizontal:
                        ChildRectDic.Add(child, new Rect(new Point(totalSize.Width, 0), size));
                        totalSize.Height = Math.Max(totalSize.Height, size.Height);
                        totalSize.Width += size.Width;
                        break;

                    case Orientation.Vertical:
                        ChildRectDic.Add(child, new Rect(new Point(0, totalSize.Height), size));
                        totalSize.Height += size.Height;
                        totalSize.Width = Math.Max(totalSize.Width, size.Width);
                        break;
                }
            }
            DesiredSize = totalSize;
        }
    }
}