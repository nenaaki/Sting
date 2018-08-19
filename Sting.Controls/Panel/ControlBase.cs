using System;
using System.Windows;
using System.Windows.Media;
using Sting.Controls.Panel.Behavior;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// <see cref="IUIElement"/>のもっとも基本的な部分の実装です。
    /// </summary>
    public abstract class ControlBase : IFrameworkElement
    {
        /// <summary>
        /// 所属するパネルです。
        /// </summary>
        public FlexiblePanel Panel { get; set; }

        /// <summary>
        /// インスタンスの生存状態を添付プロパティに伝えるための弱参照オブジェクトです。
        /// </summary>
        private readonly WeakVirtualElement _weakInstance;

        /// <summary>
        /// 計測されたサイズを表します。
        /// </summary>
        public Size DesiredSize { get; set; }

        /// <summary>
        /// 親のレイアウターです。
        /// </summary>
        public ILayouter Parent { get; set; }

        /// <summary>
        /// 位置の確定が必要であることを示します。
        /// </summary>
        public bool ArrangeDirty { get; private set; }

        public Thickness Margin { get; set; }

        /// <summary>
        /// サイズ測定が必要であることを示します。
        /// </summary>
        public bool MeasureDirty { get; private set; }

        public abstract IMouseInput MouseInput { get; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double MinWidth { get; set; }

        public double MinHeight { get; set; }

        public double MaxWidth { get; set; }

        public double MaxHeight { get; set; }

        public double ActualWidht => throw new NotImplementedException();

        public double ActualHeight => throw new NotImplementedException();

        protected ControlBase()
        {
            _weakInstance = new WeakVirtualElement(this);
        }

        public void InvalidateArrange()
        {
            ArrangeDirty = true;

            if (Parent is LayouterBase layouter)
            {
                layouter.Panel?.PostPresent();
            }
        }

        public void InvalidateMeasure()
        {
            MeasureDirty = true;
            var layouter = Parent as LayouterBase;
            if (layouter != null)
            {
                layouter.Panel?.PostPresent();
            }
        }

        public void InvalidateVisual()
        {
            InvalidateMeasure();
            InvalidateArrange();
        }

        public virtual void Measure(Size availableSize)
        {
            MeasureDirty = false;
            DesiredSize = MeasureOverride(availableSize);
        }

        public virtual void Arrange(Rect finalRect)
        {
            ArrangeOverride(finalRect);
        }

        /// <summary>
        /// サイズ計測を行います。
        /// </summary>
        protected virtual Size MeasureOverride(Size remainedSize)
        {
            return CalcSize(remainedSize, new Size());
        }

        /// <summary>
        /// 位置を確定します。
        /// </summary>
        protected virtual Rect ArrangeOverride(Rect rect)
        {
            ArrangeDirty = false;
            return rect;
        }

        /// <summary>
        /// 描画します。
        /// </summary>
        public virtual void OnRender(DrawingContext drawingContext)
        {
        }

        public virtual bool HitTest(PointHitTestParameters hitTestParameters)
        {
            return new Rect(DesiredSize).Contains(hitTestParameters.HitPoint);
        }

        public virtual bool HitTest(GeometryHitTestParameters hitTestParameters)
        {
            return new Rect(DesiredSize).IntersectsWith(hitTestParameters.HitGeometry.Bounds);
        }

        #region 添付プロパティのためのメソッド群です。

        public T GetValue<T>(AttachedProperty<T> target)
        {
            return target.GetValue(_weakInstance);
        }

        public void SetValue<T>(AttachedProperty<T> target, T val)
        {
            target.SetValue(_weakInstance, val);
        }

        #endregion 添付プロパティのためのメソッド群です。

        public override int GetHashCode()
        {
            return _weakInstance.GetHashCode();
        }

        /// <summary>
        /// <see cref="Width"/>が変更された場合の<see cref="MinWidth"/>と<see cref="MaxWidth"/>の調整を行います。
        /// </summary>
        private void UpdateWidthValues()
        {
            InvalidateMeasure();
            InvalidateVisual();
            if (double.IsNaN(Width))
            {
                MinWidth = 0;
                MaxWidth = double.PositiveInfinity;
            }
            else
            {
                MinWidth = MaxWidth = Width;
            }
        }

        /// <summary>
        /// <see cref="Height"/>が変更された場合の<see cref="MinHeight"/>と<see cref="MaxHeight"/>の調整を行います。
        /// </summary>
        private void UpdateHeightValues()
        {
            InvalidateMeasure();
            InvalidateVisual();
            if (double.IsNaN(Height))
            {
                MinHeight = 0;
                MaxHeight = double.PositiveInfinity;
            }
            else
            {
                MinHeight = MaxHeight = Height;
            }
        }

        protected Size CalcSize(Size requiredSize, Size contentSize)
        {
            var width = double.IsNaN(Width)
                ? Math.Max(Math.Min(Math.Min(requiredSize.Width, MaxWidth), contentSize.Width), MinWidth)
                : Width;
            var height = double.IsNaN(Height)
                ? Math.Max(Math.Min(Math.Min(requiredSize.Height, MaxHeight), contentSize.Height), MinHeight)
                : Height;

            return new Size(width, height);
        }
    }
}