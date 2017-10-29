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
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Queries;
using DS.OrangeAdmin.DataProvider;
using DS.OrangeAdmin.Shared;
using Syncfusion.Windows.Tools.Controls;
using DS.OrangeAdmin.Client.UI.Clients;
using DS.OrangeAdmin.Shared.Entities;

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
            QueryParameters<IClient> queryParameters = new QueryParameters<IClient>();
            var nombre = "Leo!";
            ClientDTO clt = new ClientDTO();
            queryParameters.Filtros.Add(client => client.Name == "Leo!");
            queryParameters.Filtros.Add(client => client.Name.Length < 8);
            var clients = dataProvider.GetClients(queryParameters).Result.Result; //.Where(cli => cli.Nombre.Length > 8);
            //queryParameters.Filtros.Add(client => client.Name == client.Alias);
            queryParameters.Filtros.Add(client => client.Name == nombre);
            queryParameters.Filtros.Add(client => client.Id == clients.FirstOrDefault().Id);
            var clients2 = dataProvider.GetClients(queryParameters).Result.Result;
            var count = clients.Count();
            var newClient = new ClientDTO();
            newClient.Name = "Leo!";
            //dataProvider.SaveClient(newClient);
            //RibbonTextBox _ribbonTextBox = new RibbonTextBox() { Text = "RibbonTextBox" };
            //_ribbonBar2.Items.Add(_ribbonTextBox);
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            var clientsABM = new ClientsSearch();
            this._mdiContainer.Children.Add(clientsABM);
            DockingManager.SetHeader(clientsABM, "A/B/M Clientes");
            DockingManager.SetState(clientsABM, DockState.Document);

            //this.OpenNewModalWindow(new ClientsSearch());
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