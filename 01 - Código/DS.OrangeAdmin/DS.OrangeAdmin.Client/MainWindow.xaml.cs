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

            IDataProvider dataProvider = new ExternalDataProvider();
            QueryParameters queryParameters = new QueryParameters();
            queryParameters.Filtros.Add(client => client.Name == "Leo!");
            var clients = dataProvider.GetClients(queryParameters); //.Where(cli => cli.Nombre.Length > 8);
            var clients2 = dataProvider.GetClients(queryParameters).ToList();
            var count = clients.Count();
            var newClient = new ClientDTO();
            newClient.Name = "Leo!";
            dataProvider.SaveClient(newClient);
        }
    }
}
