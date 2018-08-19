namespace Sting.Controls.Panel
{
    public interface IFrameworkElement : IUIElement
    {
        double Width { get; set; }

        double Height { get; set; }

        double MinWidth { get; set; }

        double MinHeight { get; set; }

        double MaxWidth { get; set; }

        double MaxHeight { get; set; }

        double ActualWidht { get; }

        double ActualHeight { get; }
    }
}