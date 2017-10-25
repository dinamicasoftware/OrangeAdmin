using DS.OrangeAdmin.Client.UI.Clients;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;

namespace DS.OrangeAdmin.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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



            RibbonTextBox _ribbonTextBox = new RibbonTextBox() { Text = "RibbonTextBox" };
            _ribbonBar2.Items.Add(_ribbonTextBox);
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            this.OpenNewModalWindow(new ClientsSearch());
        }

        private void Fight(object sender, RoutedEventArgs e)
        {
            this.OpenNewModalWindow(new UI.Experimental.Window1());
        }

        private void OpenNewModalWindow(Window w)
        {
            w.ShowDialog();
        }
    }
}
