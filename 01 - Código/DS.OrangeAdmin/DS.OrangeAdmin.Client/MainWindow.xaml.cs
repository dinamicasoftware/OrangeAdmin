using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Editors.Settings;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Threading;
using DevExpress.Xpf.Ribbon;
using DS.OrangeAdmin.Client.UI.Clients;

namespace RibbonControl_Ex
{
    public partial class MainWindow : DXRibbonWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            new SearchClients().ShowDialog();
        }
    }
}
