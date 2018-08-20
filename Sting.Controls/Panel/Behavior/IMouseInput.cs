using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sting.Controls.Panel.Behavior
{
    public interface IMouseInput
    {
        void MouseMoved(VirtualElementHost element, ControlBase control, MouseEventArgs e);

        void MouseLightButtonDown(VirtualElementHost element, ControlBase contorol, MouseButtonEventArgs e);

        void MouseLightButtonUp(VirtualElementHost element, ControlBase contorol, MouseButtonEventArgs e);
    }
}
