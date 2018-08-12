namespace Sting
{
    /// <summary>
    /// 展開可能なもののインターフェースです。
    /// </summary>
    public interface IExpandable
    {
        /// <summary>
        /// 展開しているかどうかを取得または設定します。
        /// </summary>
        bool IsExpanded { get; set; }
    }
}