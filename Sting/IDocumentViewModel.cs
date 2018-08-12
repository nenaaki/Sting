namespace Sting
{
    public interface IDocumentViewModel : IPanelViewModel
    {
        bool IsDirty { get; set; }

        bool QueryClosing();
    }
}