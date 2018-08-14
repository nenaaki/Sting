using System.Windows;

namespace Sting.Controls
{
    /// <summary>
    /// <see cref="Freezable"/>の拡張メソッド群です。
    /// </summary>
    public static class FreezableExtentions
    {
        /// <summary>
        /// <see cref="Freezable.Freeze"/>を実行する拡張メソッドです。
        /// </summary>
        /// <param name="freezable"><see cref="Freezable"/></param>
        public static Freezable WithFreeze(this Freezable freezable)
        {
            if (freezable.CanFreeze)
            {
                freezable.Freeze();
            }
            return freezable;
        }
    }
}