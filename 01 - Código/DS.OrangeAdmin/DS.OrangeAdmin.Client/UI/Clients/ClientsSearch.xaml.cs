using DS.OrangeAdmin.Client.VM;
using DS.OrangeAdmin.Client.VM.Clients;
using DS.OrangeAdmin.DataProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace DS.OrangeAdmin.Client.UI.Clients
{
    /// <summary>
    /// Lógica de interacción para ClientsSearch.xaml
    /// </summary>
    public partial class ClientsSearch : ContentControl
    {
        private IDataProvider dataProvider;
        private ObservableObject vm;

        public ClientsSearch()
        {
            InitializeComponent();
            
            dataProvider = new LocalDataProvider();
            vm = new ClientsSearchResultVM
            {
                Clients = new ObservableCollection<ClientsVM>(ClientsVMHandler.GetClients(dataProvider.GetClients(new Core.Queries.QueryParameters())))
            };

            this.DataContext = vm;
        }
    }
}
