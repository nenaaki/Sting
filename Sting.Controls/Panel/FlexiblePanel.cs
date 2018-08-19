using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// 高速パネルのクラスです。
    /// <see cref="UIElement.Measure"/>を実行すると内部の全要素の配置が終わります。
    /// この情報を元にBindingパスにて仮想化を実施します。
    /// </summary>
    [ContentProperty("Layouter")]
    public class FlexiblePanel : FrameworkElement
    {
        public class Information
        {
            public int UnusedVisualChildCount { get; set; }

            public int VisualChildCount { get; set; }

            public int ChildCount { get; set; }
        }

        /// <summary>
        /// バインディング中に仮想化を要求している場合 true です。
        /// </summary>
        private bool _present;

        private readonly List<VirtualElementHost> _visualChildren = new List<VirtualElementHost>();

        private readonly List<VirtualElementHost> _unusedElements = new List<VirtualElementHost>();

        private readonly Dictionary<ControlBase, UIElement> _elements = new Dictionary<ControlBase, UIElement>();

        private readonly Dictionary<ControlBase, Rect> _childRectDic = new Dictionary<ControlBase, Rect>();

        public FlexiblePanel()
        {
            Unloaded += Panel_Unloaded;
        }

        private void Panel_Unloaded(object sender, RoutedEventArgs e)
        {
            ClearCache();
        }

        private void ClearCache()
        {
            foreach (var element in _unusedElements)
            {
                if (element.Content == null)
                {
                    RemoveVisualChild(element);
                    _visualChildren.Remove(element);
                }
            }
            _unusedElements.Clear();
        }

        /// <summary>
        /// パネルの状態を取得します。
        /// </summary>
        public Information GetInformation()
        {
            var count = _childRectDic.Sum(each =>
            {
                var host = each.Key as ContentHost;
                return host != null ? host.Contents.Count : 1;
            });
            return new Information
            {
                UnusedVisualChildCount = _unusedElements.Count,
                VisualChildCount = _visualChildren.Count,
                ChildCount = count,
            };
        }

        /// <summary>
        /// 最上位のレイアウターを設定します。
        /// </summary>
        public LayouterBase Layouter
        {
            get { return (LayouterBase)GetValue(LayouterProperty); }
            set { SetValue(LayouterProperty, value); }
        }

        public static readonly DependencyProperty LayouterProperty =
            DependencyProperty.Register("Layouter", typeof(LayouterBase), typeof(FlexiblePanel), new PropertyMetadata(null,
                (d, e) =>
                {
                    var panel = (FlexiblePanel)d;
                    var newLayouter = (LayouterBase)e.NewValue;
                    var oldLayouter = (LayouterBase)e.OldValue;
                    if (oldLayouter != null)
                        oldLayouter.Panel = null;
                    if (newLayouter != null)
                        newLayouter.Panel = panel;
                }));

        /// <summary>
        /// 描画範囲を設定します。
        /// </summary>
        public Rect Viewport
        {
            get { return (Rect)GetValue(ViewportProperty); }
            set { SetValue(ViewportProperty, value); }
        }

        public static readonly DependencyProperty ViewportProperty =
            DependencyProperty.Register("Viewport", typeof(Rect), typeof(FlexiblePanel), new PropertyMetadata(Rect.Empty,
                (d, e) =>
                {
                    var panel = (FlexiblePanel)d;
                    panel.Present();
                }));

        /// <inheritdoc />
        protected override Size ArrangeOverride(Size finalSize)
        {
            var layouter = Layouter;
            if (layouter != null)
            {
                foreach (var visual in _visualChildren)
                {
                    if (visual.Content == null)
                        continue;

                    visual.Arrange(_childRectDic[visual.Content]);
                }
                layouter.Arrange(new Rect(finalSize));
                var size = layouter.DesiredSize;
                return new Size(Math.Max(finalSize.Width, size.Width), Math.Max(finalSize.Height, size.Height));
            }
            return base.ArrangeOverride(finalSize);
        }

        /// <inheritdoc />
        protected override Size MeasureOverride(Size availableSize)
        {
            var layouter = Layouter;
            if (layouter != null)
            {
                foreach (var visual in _visualChildren)
                {
                    if (visual.Content == null)
                        continue;

                    visual.Measure(availableSize);
                }
                return layouter.DesiredSize;
            }
            return base.MeasureOverride(availableSize);
        }

        /// <inheritdoc />
        protected override Visual GetVisualChild(int index)
        {
            return _visualChildren[index];
        }

        /// <inheritdoc />
        protected override int VisualChildrenCount
        {
            get
            {
                return _visualChildren.Count;
            }
        }

        /// <summary>
        /// バインディング処理中に仮想化を実行します。
        /// </summary>
        public void PostPresent()
        {
            if (!_present)
            {
                _present = true;
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.DataBind,
                    new Action(() =>
                    {
                        Present();
                    }));
            }
        }

        /// <summary>
        /// 仮想化を実行します。
        /// </summary>
        private void Present()
        {
            _present = false;

            if (Layouter == null)
                return;

            Layouter.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));

            var elements = new HashSet<ControlBase>();

            var viewport = Viewport;
            _childRectDic.Clear();
            Layouter.CalcRectDic(_childRectDic, new Point());
            foreach (var item in _childRectDic)
            {
                if (viewport.IntersectsWith(item.Value))
                {
                    elements.Add(item.Key);
                }
            }

            // MEMO : 表示中のものを表示できる分だけのホストを作ります。
            while (_visualChildren.Count < elements.Count)
            {
                var e = new VirtualElementHost();
                AddVisualChild(e);
                _visualChildren.Add(e);
                _unusedElements.Add(e);
            }

            foreach (var c in _visualChildren)
            {
                if (c.Content != null && !elements.Contains(c.Content))
                {
                    _elements.Remove(c.Content);
                    c.Content = null;
                    c.Visibility = Visibility.Collapsed;
                    _unusedElements.Add(c);
                }
            }

            foreach (var item in elements)
            {
                UIElement element;
                if (!_elements.TryGetValue(item, out element))
                {
                    var index = _unusedElements.Count - 1;
                    var t = _unusedElements[index];
                    _unusedElements.RemoveAt(index);
                    t.Content = item;
                    t.Visibility = Visibility.Visible;
                    _elements.Add(item, t);
                    t.InvalidateMeasure();
                    t.InvalidateVisual();
                }
                else
                {
                    if (item.MeasureDirty)
                        element.InvalidateMeasure();
                    if (item.ArrangeDirty)
                        element.InvalidateVisual();
                }
            }

            InvalidateMeasure();
            InvalidateVisual();
        }
    }
}