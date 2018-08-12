using System;
using System.Windows.Input;

namespace Sting
{
    /// <summary>
    /// 外部から<see cref="ICommand.CanExecuteChanged"/>の通知ができるコマンドです。
    /// ViewModel内ではこのインターフェースでコマンドを保持します。
    /// </summary>
    public interface ICommandBase : ICommand
    {
        /// <summary>
        /// <see cref="ICommand.CanExecuteChanged"/>を通知できます。
        /// </summary>
        void RaiseCanExecuteChanged();
    }

    /// <summary>
    /// コマンドの基底クラスです。
    /// </summary>
    public abstract class CommandBase : ICommandBase
    {
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public virtual bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);
    }

    /// <summary>
    /// コマンドの基底クラスです。
    /// </summary>
    public abstract class CommandBase<T> : CommandBase
        where T : class
    {
        protected T Source { get; }

        /// <summary>
        /// コンストラクターです。
        /// </summary>
        /// <param name="source">ViewModelを想定しています。</param>
        public CommandBase(T source)
        {
            Source = source;
        }
    }
}