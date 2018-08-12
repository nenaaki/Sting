using System.Windows;
using System.Windows.Media;

namespace Sting.Controls.Panel
{
    public interface IUIElement
    {
        /// <summary>
        /// レイアウトを確定するための親を取得または設定します。
        /// </summary>
        ILayouter Parent { get; set; }

        /// <summary>
        /// <see cref="MeasureOverride"/>で計測されたサイズを保持します。
        /// </summary>
        Size DesiredSize { get; }

        /// <summary>
        /// 描画を行います。
        /// </summary>
        /// <param name="drawingContext"></param>
        void OnRender(DrawingContext drawingContext);

        bool ArrangeDirty { get; }

        bool MeasureDirty { get; }

        void InvalidateMeasure();

        void InvalidateArrange();

        void InvalidateVisual();
    }
}
