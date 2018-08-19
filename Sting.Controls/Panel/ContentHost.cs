using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Sting.Controls.Panel.Behavior;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// １つのControlBaseに複数のControlBaseを描画するためのホストです。
    /// </summary>

    public class ContentHost : ControlBase
    {
        public override IMouseInput MouseInput
        {
            get
            {
                return null;
            }
        }

        public ObservableCollection<ContentBase> Contents { get; private set; }

        public ContentHost()
        {
            Contents = new ObservableCollection<ContentBase>();
        }

        public override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            foreach (var content in Contents)
            {
                content.OnRender(drawingContext);
            }
        }

        protected override Size MeasureOverride(Size remainedSize)
        {
            var rect = new Rect();
            foreach (var content in Contents)
            {
                rect.Union(content.Bounds);
            }
            if (DesiredSize != rect.Size)
                InvalidateArrange();

            return rect.Size;
        }

        protected override Rect ArrangeOverride(Rect rect)
        {
            return base.ArrangeOverride(rect);
        }
    }
}