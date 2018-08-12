namespace Sting
{
    public interface IPanelViewModel
    {
        string ViewModelId { get; }

        IDocumentHost Owner { get; set; }

        ICommandBase CloseCommand { get; }

        string Title { get; set; }
    }
}