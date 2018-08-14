using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// <see cref="FlexiblePanel"/>上に配置する全てのコントロールをホストする<see cref="FrameworkElement"/>です。
    /// </summary>
    public sealed class VirtualElementHost : FrameworkElement
    {
        /// <summary>
        /// <see cref="Content"/>が設定されていない場合のサイズを用意しておきます。
        /// </summary>
        private static readonly Size _zeroSize = new Size();

        private ControlBase _content;

        /// <summary>5
        /// 実体を格納します。
        /// </summary>
        public ControlBase Content
        {
            get { return _content; }

            set
            {
                if (_content == value)
                    return;

                _content = value;

                InvalidateVisual();
            }
        }

        private Visual _child;

        /// <summary>
        /// 子<see cref="Visual"/>を1つ保持することがあり得ます。
        /// </summary>
        public Visual Child
        {
            get { return _child; }

            set
            {
                if (_child == value)
                    return;

                if (_child != null)
                    RemoveVisualChild(_child);

                if (value != null)
                    AddVisualChild(value);

                _child = value;
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            var margin = Content.Margin;
            drawingContext.PushTransform(new TranslateTransform(margin.Left, margin.Top));
            Content.OnRender(drawingContext);
            drawingContext.Pop();
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            if (Content == null)
            {
                return _zeroSize;
            }

            Content.Measure(availableSize);
            return Content.DesiredSize;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            if (Content == null)
                return _zeroSize;

            Content.Arrange(new Rect(finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return index == 0 ? Child : null;
        }

        protected override int VisualChildrenCount
        {
            get { return Child == null ? 0 : 1; }
        }

        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            if (_content != null)
            {
                var result = _content.HitTest(hitTestParameters);
            }

            return base.HitTestCore(hitTestParameters);
        }

        protected override GeometryHitTestResult HitTestCore(GeometryHitTestParameters hitTestParameters)
        {
            if (_content != null)
            {
                var result = _content.HitTest(hitTestParameters);
            }

            return base.HitTestCore(hitTestParameters);
        }

        /// <summary>
        /// マウスの移動に対するアクション
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (_content != null && _content.MouseInput != null)
            {
                _content.MouseInput.MouseMoved(this, _content, e);
            }
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            if (_content != null && _content.MouseInput != null)
            {
                _content.MouseInput.MouseLightButtonDown(this, _content, e);
            }
            else
            {
                base.OnMouseLeftButtonDown(e);
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if (_content != null && _content.MouseInput != null)
            {
                _content.MouseInput.MouseLightButtonUp(this, _content, e);
            }
            else
            {
                base.OnMouseLeftButtonUp(e);
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            var mouseResizable = _content as IMouseResizable;

            CaptureMouse();
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            ReleaseMouseCapture();
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);

            Cursor = null;
        }
    }
}