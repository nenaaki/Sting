﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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