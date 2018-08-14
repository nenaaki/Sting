using System.Collections.ObjectModel;

namespace Sting.Controls.Panel
{
    public interface ILayouter : IUIElement
    {
        ObservableCollection<ControlBase> Children { get; }
    }
}
