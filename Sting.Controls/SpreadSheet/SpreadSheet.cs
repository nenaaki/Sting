using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sting.Controls.SpreadSheet
{
    public class SpreadSheet : Panel.FlexiblePanel
    {
        public SpreadSheet()
        {
            Layouter = new Panel.GridLayouter();
        }
    }
}
