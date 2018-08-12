using System.Windows;
using System.Windows.Media;

namespace Sting.Controls.Panel
{
    public abstract class ContentBase
    {
        public ContentHost Owner { get; set; }

        private Rect _bounds;

        public Rect Bounds
        {
            get { return _bounds; }
            set
            {
                if (_bounds == value)
                    return;

                _bounds = value;

                Owner?.InvalidateVisual();
            }
        }

        public virtual void OnRender(DrawingContext drawingContext)
        {
        }
    }
}