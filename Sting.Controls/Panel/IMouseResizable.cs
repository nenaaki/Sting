using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Sting.Controls.Panel
{
    /// <summary>
    /// マウスでリサイズできるコントロールです。
    /// </summary>
    interface IMouseResizable
    {
        bool CanHorizontalResizing { get; }

        bool CanVerticalResizeing { get; }
    }
}
