using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Sting.Controls.Panel.Media
{
    public class EmptyBrush : IBrush
    {
        public static readonly EmptyBrush Instance = new EmptyBrush();

        public Brush GetBrush(bool freezing = true)
        {
            return null;
        }
    }
}