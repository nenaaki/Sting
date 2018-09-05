namespace Sting
{
    public abstract class ToolViewModelBase : ViewModelBase, IPanelViewModel
    {
        public virtual string ViewModelId => GetType().ToString();

        public IDocumentHost Owner { get; set; }

        public abstract ICommandBase CloseCommand { get; }

        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => UpdateField(value, ref _title);
        }
    }
}