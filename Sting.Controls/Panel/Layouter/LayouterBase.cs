using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using Sting.Controls.Panel.Behavior;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// パネルの基幹部の実装です。
    /// </summary>
    [ContentProperty("Children")]
    public abstract partial class LayouterBase : ControlBase, ILayouter
    {
        public bool IsDirectRendering { get; set; }

        public override IMouseInput MouseInput
        {
            get
            {
                return null;
            }
        }

        protected Dictionary<ControlBase, ImmutableRect> ChildRectDic { get; private set; }

        public ObservableCollection<ControlBase> Children { get; private set; }

        protected LayouterBase()
        {
            ChildRectDic = new Dictionary<ControlBase, ImmutableRect>();

            Children = new ObservableCollection<ControlBase>();

            Children.CollectionChanged += Children_CollectionChanged;
        }

        public virtual ImmutablePoint GetChilldLocation(ControlBase child)
        {
            if (ChildRectDic.TryGetValue(child, out ImmutableRect rect))
            {
                return rect.Location;
            }
            return ImmutablePoint.Empty;
        }

        /// <summary>
        /// 親Panel更新時にパネルの変更を子に伝達します。
        /// </summary>
        private void InheritPanel()
        {
            foreach (var child in Children)
            {
                var layouter = child as LayouterBase;
                if (layouter != null)
                    layouter.Panel = Panel;
            }
            if (Panel != null)
                Panel.PostPresent();
        }

        private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            InvalidateVisual();

            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (ControlBase item in e.NewItems)
                    {
                        item.Parent = this;
                        var layouter = item as LayouterBase;
                        if (layouter != null)
                            layouter.Panel = Panel;
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                case NotifyCollectionChangedAction.Reset:
                    if (e.OldItems != null)
                    {
                        foreach (ControlBase item in e.OldItems)
                        {
                            item.Parent = null;
                            var layouter = item as LayouterBase;
                            if (layouter != null)
                                layouter.Panel = null;
                        }
                    }
                    break;
            }
            if (Panel != null)
                Panel.PostPresent();
        }

        public void CalcRectDic(Dictionary<ControlBase, ImmutableRect> dic, Point offset)
        {
            foreach (var child in Children)
            {
                var childOffset = ChildRectDic[child].Location;
                var point = new Point(childOffset.X + offset.X, childOffset.Y + offset.Y);

                dic.Add(child, new ImmutableRect(childOffset, child.DesiredSize));

                var layouter = child as LayouterBase;
                if (layouter != null && !layouter.IsDirectRendering)
                    layouter.CalcRectDic(dic, childOffset);
            }
        }

        public override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);
            if (IsDirectRendering)
            {
                RenderChildren(drawingContext);
            }
        }

        private void RenderChildren(DrawingContext drawingContext)
        {
            foreach (var child in Children)
            {
                var locationin = ChildRectDic[child].Location;

                drawingContext.PushTransform(new TranslateTransform(locationin.X, locationin.Y));
                var layouter = child as LayouterBase;
                if (layouter != null)
                {
                    var backup = layouter.IsDirectRendering;
                    layouter.IsDirectRendering = true;
                    layouter.OnRender(drawingContext);
                    layouter.IsDirectRendering = backup;
                }
                else
                {
                    child.OnRender(drawingContext);
                }
                drawingContext.Pop();
            }
        }
    }
}