using System.Collections.ObjectModel;

namespace Sting
{
    public interface IDocumentHost
    {
        ObservableCollection<IDocumentViewModel> Documents { get; }

        ObservableCollection<IPanelViewModel> ToolPanels { get; }

        IPanelViewModel ActiveDocument { get; set; }
    }
}