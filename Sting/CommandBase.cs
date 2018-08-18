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
    /// <typeparam name="T">パラメーターの型</typeparam>
    public abstract class CommandBase<T> : CommandBase
    {
        public sealed override bool CanExecute(object parameter) => CanExecute((T)parameter);

        public virtual bool CanExecute(T parameter) => true;

        public sealed override void Execute(object parameter) => Execute((T)parameter);

        public abstract void Execute(T parameter);
    }
}