namespace Sting
{
    /// <summary>
    /// 非表示化可能なレコードのインターフェース
    /// </summary>
    public interface IHidable
    {
        bool IsVisible { get; set; }
    }
}