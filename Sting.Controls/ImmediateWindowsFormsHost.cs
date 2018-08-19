using System.Windows;
using System.Windows.Forms.Integration;

namespace Sting.Controls
{
    public class ImmediateWindowsFormsHost : WindowsFormsHost
    {
        public ImmediateWindowsFormsHost()
        {
            SizeChanged += ImmediateWindowsFormsHost_SizeChanged;
        }

        private void ImmediateWindowsFormsHost_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Child.Refresh();
        }
    }
}