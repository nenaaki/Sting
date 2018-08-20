using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// 1か所にすべて重ねるレイアウター
    /// </summary>
    internal class LayerLayouter : LayouterBase
    {
        public override void Measure(Size availableSize)
        {
            var baseSize = availableSize;
            var totalSize = new Size();

            foreach (var child in Children)
            {
                child.Measure(baseSize);
                var size = child.DesiredSize;
                totalSize.Height = Math.Max(totalSize.Height, size.Height);
                totalSize.Width = Math.Max(totalSize.Width, size.Width);
            }
            DesiredSize = totalSize;
        }
    }
}