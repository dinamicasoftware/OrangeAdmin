using System;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Markup;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Tools;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Globalization;
using System.Windows.Threading;
using DS.OrangeAdmin.DataProvider;
using Syncfusion.SfSkinManager;

namespace DS.OrangeAdmin.Client
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            IDataProvider dataProvider = new LocalDataProvider();
            //var clients = dataProvider.GetClients(); //.Where(cli => cli.Nombre.Length > 8);
            //var clients2 = dataProvider.GetClients();
            //var count = clients.Count();
            //var newClient = new ClientDTO();
            //newClient.Name = "Leo!";
            //dataProvider.SaveClient(newClient);



            //RibbonTextBox _ribbonTextBox = new RibbonTextBox() { Text = "RibbonTextBox" };
            //_ribbonBar2.Items.Add(_ribbonTextBox);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SfSkinManager.SetVisualStyle(this, (VisualStyles)Enum.Parse(typeof(VisualStyles), ((sender as ComboBox).SelectedItem as ComboBoxItem).Content.ToString()));
        }
    }

}
