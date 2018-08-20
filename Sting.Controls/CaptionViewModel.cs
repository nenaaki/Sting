using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sting;

namespace Sting.Controls
{
    public class CaptionViewModel : ViewModelBase
    {
        private bool _isDirty;

        public bool IsDirty
        {
            get => _isDirty;
            set => UpdateValueField(value, ref _isDirty);
        }

        private string _title;

        public string Title
        {
            get => _title;
            set => UpdateField(value, ref _title);
        }

        public ICommandBase CloseCommand { get; }

        public CaptionViewModel(ICommandBase closeCommand)
        {
            CloseCommand = closeCommand;
        }
    }
}