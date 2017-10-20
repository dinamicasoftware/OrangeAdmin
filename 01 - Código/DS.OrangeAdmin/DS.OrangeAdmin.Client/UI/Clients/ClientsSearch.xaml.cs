using DS.OrangeAdmin.Client.VM;
using DS.OrangeAdmin.Client.VM.Clients;
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
using System.Windows.Shapes;

namespace DS.OrangeAdmin.Client.UI.Clients
{
    /// <summary>
    /// Lógica de interacción para ClientsSearch.xaml
    /// </summary>
    public partial class ClientsSearch : Window
    {
        private IDataProvider dataProvider;
        private ObservableObject vm;

        public ClientsSearch()
        {
            InitializeComponent();

            dataProvider = new LocalDataProvider();
            vm = new ClientsSearchResultVM
            {
                Clients = VM.Clients.ClientsVMHandler.GetClients(dataProvider.GetClients()).ToList()
            };

            this.DataContext = vm;

            //UI();
        }

        //protected async void UI()
        //{
        //    this.grid1.DataContext = (vm as ClientsSearchResultVM).Clients;
        //}
    }
}
