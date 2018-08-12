using System;
using System.Collections.Generic;
using System.Windows.Threading;

namespace Sting
{
    /// <summary>
    /// <see cref="CommandBase"/>のマネージを行います。
    /// <see cref="Dispatcher"/>を登録して集約処理を行うことができます。
    /// <list type="bullet">
    /// <item><see cref="ICommand.CanExecuteChanged"/>を<see cref="DispatcherPriority.DataBind"/>のときに集約して発行します。</item>
    /// </list>
    /// </summary>
    internal static class CommandManager
    {
        private static Dispatcher _dispatcher;

        private readonly static HashSet<ICommandBase> _commands = new HashSet<ICommandBase>();

        /// <summary>
        /// 集約処理を行う<see cref="Dispatcher"/>を設定します。
        /// </summary>
        /// <param name="dispatcher"></param>
        public static void Start(Dispatcher dispatcher) => _dispatcher = dispatcher;

        /// <summary>
        /// 集約処理を中断します。
        /// </summary>
        public static void Stop() => _dispatcher = null;

        /// <summary>
        /// 蓄積した<see cref="ICommand.CanExecuteChanged"/>イベントを一括発行します。
        /// <see cref="DispatcherPriority.DataBind"/>の優先度で処理されるべきです。
        /// </summary>
        private static void Processing()
        {
            try
            {
                foreach (var command in _commands)
                    command.RaiseCanExecuteChanged();
            }
            finally
            {
                _commands.Clear();
            }
        }

        /// <summary>
        /// <see cref="ICommand.CanExecuteChanged"/>を発行するか、集約処理に登録します。
        /// </summary>
        /// <param name="command"></param>
        public static void Post(ICommandBase command)
        {
            if (_dispatcher == null)
            {
                command.RaiseCanExecuteChanged();
            }
            else
            {
                if (_commands.Count == 0)
                    _dispatcher.BeginInvoke(new Action(Processing), DispatcherPriority.DataBind);

                _commands.Add(command);
            }
        }
    }
}