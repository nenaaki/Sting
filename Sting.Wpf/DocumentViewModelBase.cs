namespace Sting
{
    public abstract class DocumentViewModelBase : ViewModelBase, IDocumentViewModel
    {
        /// <summary>
        /// <see cref="IsDirty"/>がtrueの場合保存に成功したらtrue、
        /// <see cref="IsDirty"/>がfalseの場合常にtrueを返します。
        /// </summary>
        /// <returns></returns>
        public virtual bool QueryClosing()
        {
            if (IsDirty)
            {
                return Save();
            }
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

        public virtual bool Save() => true;
    }
}