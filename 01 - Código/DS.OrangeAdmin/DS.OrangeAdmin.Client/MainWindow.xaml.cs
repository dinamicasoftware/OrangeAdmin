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
            var clients = dataProvider.GetClients(); //.Where(cli => cli.Nombre.Length > 8);
            var count = clients.Count();
            var newClient = new ClientDTO();
            newClient.Nombre = "Leo!";
            dataProvider.SaveClient(newClient);
        }
    }
}
