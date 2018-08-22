namespace Sting.Controls
{
    public class CaptionViewModel : ViewModelBase
    {
        private bool _isDirty;

        public bool IsDirty
        {
            get => _isDirty;
            set => UpdateValueField(value, ref _isDirty);
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => UpdateField(value, ref _title);
        }

        public virtual ICommandBase CloseCommand { get; }
    }
}