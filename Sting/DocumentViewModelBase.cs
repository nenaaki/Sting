namespace Sting
{
    public abstract class DocumentViewModelBase : ViewModelBase, IDocumentViewModel
    {
        protected DocumentViewModelBase()
        {
        }

        public virtual bool QueryClosing()
        {
            return true;
        }

        public abstract ICommandBase CloseCommand { get; }

        private string _title;

        /// <summary>
        /// タイトル
        /// </summary>
        public string Title
        {
            get => _title;
            set => UpdateField(value, ref _title);
        }

        public abstract IDocumentHost Owner { get; set; }

        private bool _isDirty;

        /// <summary>
        /// 変更済みフラグ
        /// </summary>
        public bool IsDirty
        {
            get => _isDirty;
            set => UpdateValueField(value, ref _isDirty);
        }

        public virtual string ViewModelId
        {
            get { return GetType().ToString(); }
        }
    }
}