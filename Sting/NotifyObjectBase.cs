using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Sting
{
    /// <summary>
    /// <see cref="INotifyPropertyChanged"/>を持つクラスの基底クラスです。
    /// </summary>
    public abstract class NotifyObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// <see cref="PropertyChanged"/>を発行します。
        /// </summary>
        /// <param name="propertyName">変更されたプロパティ名</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            OnPropertyChanged(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// オブジェクト型のフィールド更新処理です。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="field"></param>
        /// <param name="dependedProperties"></param>
        /// <param name="dependedCommands"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool UpdateField<T>(T value, ref T field, string[] dependedProperties = null, ICommandBase[] dependedCommands = null, [CallerMemberName]string propertyName = null)
            where T : class
        {
            if (field == value)
                return false;

            field = value;
            NotifyPropertyChanged(propertyName, dependedProperties, dependedCommands);
            return true;
        }

        /// <summary>
        /// 値型のフィールド更新処理です。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="field"></param>
        /// <param name="dependedProperties"></param>
        /// <param name="dependedCommands"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected bool UpdateValueField<T>(T value, ref T field, string[] dependedProperties = null, ICommandBase[] dependedCommands = null, [CallerMemberName]string propertyName = null)
            where T : struct, IEquatable<T>
        {
            if (field.Equals(value))
                return false;

            field = value;
            NotifyPropertyChanged(propertyName, dependedProperties, dependedCommands);
            return true;
        }

        /// <summary>
        /// 比較を行わずに強制的に更新する処理です。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="field"></param>
        /// <param name="dependedProperties"></param>
        /// <param name="dependedCommands"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        protected void ForceUpdateValueField<T>(T value, ref T field, string[] dependedProperties = null, ICommandBase[] dependedCommands = null, [CallerMemberName]string propertyName = null)
        {
            field = value;
            NotifyPropertyChanged(propertyName, dependedProperties, dependedCommands);
        }

        /// <summary>
        /// 依存しているプロパティと共に通知を行います。
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="dependedProperties"></param>
        /// <param name="dependedCommands"></param>
        private void NotifyPropertyChanged(string propertyName, string[] dependedProperties, ICommandBase[] dependedCommands)
        {
            Debug.Assert(!string.IsNullOrEmpty(propertyName));

            RaisePropertyChanged(propertyName);

            if (dependedProperties != null)
            {
                for (int idx = 0; idx < dependedProperties.Length; idx++)
                    RaisePropertyChanged(dependedProperties[idx]);
            }

            if (dependedCommands != null)
            {
                for (int idx = 0; idx < dependedCommands.Length; idx++)
                    CommandManager.Post(dependedCommands[idx]);
            }
        }

        /// <summary>
        /// 内部のプロパティが変更された際の処理です。
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName) { }
    }
}