using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DS.OrangeAdmin.Client.Util
{
    public static class UIUtils
    {
        public static void OpenNewModalWindow(Window w)
        {
            w.ShowDialog();
        }
    }
}
