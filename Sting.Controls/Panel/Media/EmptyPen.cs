using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public class EmptyPen : IPen
    {
        public static readonly EmptyPen Instance = new EmptyPen();

        public Pen GetPen(bool freezing)
        {
            return null;
        }
    }
}