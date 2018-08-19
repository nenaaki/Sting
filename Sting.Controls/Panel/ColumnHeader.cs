using System.Windows;
using System.Windows.Media;
using Sting.Controls.Panel.Behavior;

namespace Sting.Controls.Panel
{
    public class ColumnHeader : TextBlock, IMouseResizable
    {
        private Brush _background = Brushes.LightGray;

        private Pen _splitterPen = new Pen(Brushes.GhostWhite, 1);

        private static IMouseInput _mouseInput = new Resizable();

        public override IMouseInput MouseInput
        {
            get
            {
                return _mouseInput;
            }
        }

        public bool CanHorizontalResizing
        {
            get { return true; }
        }

        public bool CanVerticalResizeing
        {
            get { return false; }
        }

        public override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawRectangle(_background, null, new Rect(DesiredSize));

            drawingContext.DrawLine(_splitterPen, new Point(DesiredSize.Width - 1, 0), new Point(DesiredSize.Width - 1, DesiredSize.Height));

            base.OnRender(drawingContext);
        }
    }
}