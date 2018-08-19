using System.Globalization;
using System.Windows;
using System.Windows.Media;
using Sting.Controls.Panel.Behavior;

namespace Sting.Controls.Panel
{
    public class TextBlock : ControlBase
    {
        public string FontName { get; set; }

        public double FontSize { get; set; }

        public Brush FontBrush { get; set; }

        public string Text { get; set; }

        protected DrawingGroup _drawing;

        protected Rect _rectCache;

        public override IMouseInput MouseInput => null;

        public override void OnRender(DrawingContext drawingContext)
        {
            if (_drawing == null)
                Render();

            drawingContext.DrawDrawing(_drawing);
        }

        protected override Size MeasureOverride(Size remainedSize)
        {
            base.MeasureOverride(remainedSize);

            if (_drawing == null)
            {
                if (double.IsNaN(Width) && double.IsNaN(Height))
                {
                    Render();
                    _rectCache = new Rect();
                    _rectCache.Union(_drawing.Bounds);
                }
                else
                {
                    _rectCache = new Rect(new Size(Width, Height));
                }

                //_rectCache.Inflate(new Size(Margin, Margin));
            }

            return CalcSize(remainedSize, _rectCache.Size);
        }

        private void Render()
        {
            var dipInfo = VisualTreeHelper.GetDpi(Panel);
            _drawing = new DrawingGroup();
            using (var dc = _drawing.Open())
            {
                dc.DrawText(
                    new FormattedText(Text,
                        CultureInfo.CurrentCulture,
                        FlowDirection.LeftToRight,
                        new Typeface(FontName), FontSize, FontBrush, dipInfo.PixelsPerDip),
                    new Point());
            }
            _drawing.Freeze();
        }
    }
}