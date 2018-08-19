using System;
using System.Windows.Input;

namespace Sting.Controls.Panel.Behavior
{
    public class Resizable : IMouseInput
    {
        public void MouseLightButtonDown(VirtualElementHost element, ControlBase contorol, MouseButtonEventArgs e)
        {
            element.CaptureMouse();
        }

        public void MouseLightButtonUp(VirtualElementHost element, ControlBase contorol, MouseButtonEventArgs e)
        {
            element.ReleaseMouseCapture();
        }

        public void MouseMoved(VirtualElementHost element, ControlBase control, MouseEventArgs e)
        {
            var mouseResizable = (IMouseResizable)control;

            var position = e.GetPosition(element);

            if (element.IsMouseCaptured)
            {
                if (element.Cursor == Cursors.SizeWE)
                {
                    control.Width = Math.Max(0, position.X);
                }
                else if (element.Cursor == Cursors.SizeNS)
                {
                    control.Height = Math.Max(0, position.Y);
                }
            }
            else
            {
                bool changed = false;

                if (mouseResizable.CanHorizontalResizing)
                {
                    if (Math.Abs(control.DesiredSize.Width - position.X) < 4)
                    {
                        element.Cursor = Cursors.SizeWE;
                        changed = true;
                    }
                    else
                    {
                        element.Cursor = null;
                    }
                }

                if (!changed && mouseResizable.CanVerticalResizeing)
                {
                    if (Math.Abs(control.DesiredSize.Height - position.Y) < 4)
                    {
                        element.Cursor = Cursors.SizeNS;
                    }
                    else
                    {
                        element.Cursor = null;
                    }
                }
            }
        }
    }
}