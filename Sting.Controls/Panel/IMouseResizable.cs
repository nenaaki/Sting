namespace Sting.Controls.Panel
{
    /// <summary>
    /// マウスでリサイズできるコントロールです。
    /// </summary>
    internal interface IMouseResizable
    {
        bool CanHorizontalResizing { get; }

        bool CanVerticalResizeing { get; }
    }
}