namespace Sting
{
    /// <summary>
    /// ViewModelの基底クラスです。
    /// </summary>
    public abstract class ViewModelBase : NotifyObjectBase
    {
        protected void UpdateCommandState(ICommandBase[] commands)
        {
            for (int idx = 0; idx < commands.Length; idx++)
                CommandManager.Post(commands[idx]);
        }
    }
}