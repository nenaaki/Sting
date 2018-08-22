namespace Sting.Controls
{
    public abstract class DocumentViewModelBase : CaptionViewModel, IDocumentViewModel
    {
        public override ICommandBase CloseCommand { get; }

        public abstract IDocumentHost Owner { get; set; }

        public virtual string ViewModelId
        {
            get { return GetType().ToString(); }
        }

        public DocumentViewModelBase()
        {
            CloseCommand = new DelegateCommand(() => QueryClosing());
        }

        /// <summary>
        /// 保存処理です。
        /// </summary>
        /// <returns></returns>
        public bool Save() => SaveCore();

        protected abstract bool SaveCore();

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
    }
}