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
using DS.OrangeAdmin.Core.DTO;

namespace DS.OrangeAdmin.Client.UI.Clients
{
    public partial class ClientsSearch
    {
        protected readonly ClientsSearchResultVM _vm;

        public ClientsSearch()
        {
            InitializeComponent();

            _vm = new ClientsSearchResultVM();

            DataContext = _vm;
        }
        
        private void NewClient(object sender, RoutedEventArgs e)
        {
            UIUtils.OpenNewModalWindow(new NewClient());
        }


        private void NuevoCliente_Click(object sender, RoutedEventArgs e)
        {
            _vm.AddClient();
        }
    }
}
