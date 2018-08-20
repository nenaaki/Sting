using Sting.Controls.Enums;

namespace Sting.Controls
{
    public class MultiModeViewModel : ViewModelBase
    {
        private ViewMode _viewMode;

        public ViewMode ViewMode
        {
            get => _viewMode;
            set => ProcessUpdateEnumField(value, ref _viewMode);
        }
    }
}