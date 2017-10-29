using DS.OrangeAdmin.Client.VM;
using DS.OrangeAdmin.Client.VM.Clients;
using DS.OrangeAdmin.DataProvider;
using DS.OrangeAdmin.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DS.OrangeAdmin.Client.Util;

namespace DS.OrangeAdmin.Client.UI.Clients
{
    /// <summary>
    /// Lógica de interacción para ClientsSearch.xaml
    /// </summary>
    public partial class ClientsSearch
    {
        private IDataProvider dataProvider;
        private ObservableObject vm;

        public ClientsSearch()
        {
            InitializeComponent();
            dataProvider = new LocalDataProvider();
            vm = new ClientsSearchResultVM();
            CleanSearch();
            this.DataContext = vm;
        }

        private void FindClients(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.nameTextBlock.Text)) return;
            var parameters = new Core.Queries.QueryParameters<IClient>
            {
                Filtros = new List<Expression<Func<IClient, bool>>>
                {
                    client => client.Name.Trim().ToLower().Contains(this.nameTextBlock.Text.Trim().ToLower())
                }
            };
            var results = new ObservableCollection<ClientsVM>(ClientsVMHandler.GetClients(dataProvider.GetClients(parameters).Result));
            (vm as ClientsSearchResultVM).Clients = results;
        }

        private void NewClient(object sender, RoutedEventArgs e)
        {
            UIUtils.OpenNewModalWindow(new NewClient());
        }

        private void RefreshClients(object sender, RoutedEventArgs e)
        {
            CleanSearch();
        }

        private void CleanClientsSearch(object sender, RoutedEventArgs e)
        {
            CleanSearch();
        }

        // Utils
        private void CleanSearch()
        {
            this.nameTextBlock.Text = "";
            var parameters = new Core.Queries.QueryParameters<IClient> { };
            var results = new ObservableCollection<ClientsVM>(ClientsVMHandler.GetClients(dataProvider.GetClients(parameters).Result));
            (vm as ClientsSearchResultVM).Clients = results;
        }
    }
}
