using System;

namespace Sting
{
    /// <summary>
    /// デリゲートでコマンドを実装します。
    /// </summary>
    public class DelegateCommand : CommandBase
    {
        private readonly Action _execute;

        private readonly Func<bool> _canExecute;

        public DelegateCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override void Execute(object parameter) => _execute();

        public override bool CanExecute(object parameter) => _canExecute?.Invoke() != false;
    }

    /// <summary>
    /// パラメーターの型が決まっているコマンドを実装します
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : CommandBase
    {
        private readonly Action<T> _execute;

        private readonly Func<T, bool> _canExecute;

        public DelegateCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public override void Execute(object parameter) => _execute((T)parameter);

        public override bool CanExecute(object parameter) => _canExecute?.Invoke((T)parameter) ?? false;
    }
}