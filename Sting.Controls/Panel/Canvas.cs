using Sting.Controls.Panel.Behavior;
using System;
using System.Windows;
using System.Windows.Media;

namespace Sting.Controls.Panel
{
    public class Canvas : ControlBase
    {
        public override IMouseInput MouseInput
        {
            get
            {
                return null;
            }
        }

        private Pen _pen = new Pen(Brushes.Red, 1.71);

        private Tuple<Point, Point>[] _lines;

        public Tuple<Point, Point>[] Lines
        {
            get { return _lines; }

            set
            {
                _lines = value;

                InvalidateVisual();
            }
        }

        protected DrawingGroup _drawing;

        protected Rect _rectCache;

        public Canvas()
        {
            _pen.Freeze();
        }

        public override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawDrawing(_drawing);
        }

        protected override Size MeasureOverride(Size remainedSize)
        {
            base.MeasureOverride(remainedSize);

            if (_drawing == null)
            {
                _drawing = new DrawingGroup();
                using (var dc = _drawing.Open())
                {
                    if (_lines != null)
                    {
                        foreach (var line in _lines)
                        {
                            dc.DrawLine(_pen, line.Item1, line.Item2);
                        }
                    }
                }
                _drawing.Freeze();
                _rectCache = new Rect();
                _rectCache.Union(_drawing.Bounds);

                //_rectCache.Inflate(new Size(Margin, Margin));
            }

            return _rectCache.Size;
        }
    }
}