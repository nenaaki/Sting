using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace Sting.Controls.Panel
{
    public partial class GridLayouter : LayouterBase
    {
        public class ColumnDefinition
        {
            public double? Width { get; set; }

            public Func<ControlBase, ColumnDefinition, Size> Measure { get; set; }

            public Action<ControlBase, DrawingContext, Size> Drawer { get; set; }
        }

        public ObservableCollection<ColumnDefinition> ColumnDefinitions { get; set; }

        private double[] _columnWidthArray;

        private double[] _rowHeighArray;

        public GridLayouter()
        {
            ColumnDefinitions = new ObservableCollection<ColumnDefinition>();

            ColumnDefinitions.CollectionChanged += ColumnDefinitions_CollectionChanged;
        }

        private void ColumnDefinitions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            InvalidateVisual();
        }

        public override void Measure(Size availableSize)
        {
            var columnCount = ColumnDefinitions.Count;
            if (columnCount == 0)
                return;

            _columnWidthArray = new double[columnCount];
            _rowHeighArray = new double[(Children.Count + columnCount - 1) / ColumnDefinitions.Count];

            // MEMO : 行と桁のサイズを確定します。
            {
                int row = 0, column = 0;
                foreach (var child in Children)
                {
                    if (child.MeasureDirty)
                        child.Measure(availableSize);

                    var size = child.DesiredSize;
                    _columnWidthArray[column] = Math.Max(_columnWidthArray[column], size.Width);
                    _rowHeighArray[row] = Math.Max(_rowHeighArray[row], size.Height);

                    if (++column >= columnCount)
                    {
                        row++;
                        column = 0;
                    }
                }
            }

            // MEMO : 矩形をキャッシュします。
            {
                int row = 0, column = 0;
                var location = new Point();
                ChildRectDic.Clear();
                foreach (var child in Children)
                {
                    ChildRectDic.Add(child, new Rect(location, child.DesiredSize));

                    location.X += _columnWidthArray[column];

                    if (++column >= columnCount)
                    {
                        location.Y += _rowHeighArray[row];
                        location.X = 0;
                        row++;
                        column = 0;
                    }
                }
            }

            DesiredSize = new Size(_columnWidthArray.Sum(), _rowHeighArray.Sum());
        }
    }
}