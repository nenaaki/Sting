using System.Windows;

namespace Sting.Controls.Panel
{
    public partial class CanvasLayouter : LayouterBase
    {
        public override void Measure(Size availableSize)
        {
            var totalRect = new Rect();
            ChildRectDic.Clear();
            foreach (var child in Children)
            {
                child.Measure(availableSize);
                var size = child.DesiredSize;
                var location = GetChilldLocation(child);

                var rect = new Rect(location, size);
                ChildRectDic.Add(child, rect);
                totalRect.Union(rect);
            }
            DesiredSize = totalRect.Size;
        }
    }
}