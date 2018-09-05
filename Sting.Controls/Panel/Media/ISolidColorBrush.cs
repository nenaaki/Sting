namespace Sting.Controls.Panel.Media
{
    public interface ISolidColorBrush : IBrush
    {
        Immutable.Color32 Color { get; set; }
    }
}