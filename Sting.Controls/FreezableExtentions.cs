using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Sting.Controls
{
    public static class FreezableExtentions
    {
        public static  T WithFreeze<T>(T freezable)
            where T : Freezable
        {
            if(freezable.CanFreeze)
            {
                freezable.Freeze();
            }
            return freezable;
        }
    }
}
