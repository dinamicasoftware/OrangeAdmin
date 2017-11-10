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
using DS.OrangeAdmin.Client.UI.Clients;
using DS.OrangeAdmin.Client.Util;
using DS.OrangeAdmin.Shared.Entities;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq.Expressions;

namespace DS.OrangeAdmin.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<Customer> Customers { get; set; }


        public MainWindow()
        {
            InitializeComponent();
            //data();
            query();
        }

        private async void query()
        {
            IDataProvider dataProvider = new LocalDataProvider();
            var mail = "gmail";
            var v = await dataProvider.GetClients(cli => cli.Emails.Any(email => email.EmailAddress.Contains(mail)));
        }

        private async void data()
        {
            IDataProvider dataProvider = new LocalDataProvider();
            int contador = 0;
            using (MySqlConnection cnn = new MySqlConnection("server=gestion.no-ip.info; database=sbs2; uid=root; pwd=automenu;"))
            {
                cnn.Open();

                using (MySqlCommand cmd = cnn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM clt__clientes LIMIT 1000";

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientDTO client = new ClientDTO();
                            client.Alias = reader.IsDBNull(reader.GetOrdinal("cltnombrefantasia")) ? null : reader.GetString("cltnombrefantasia");
                            client.Code = reader.IsDBNull(reader.GetOrdinal("cltcodigo")) ? null : reader.GetString("cltcodigo");
                            client.DocumentNumber = reader.IsDBNull(reader.GetOrdinal("cltCuit")) ? null : reader.GetString("cltCuit");
                            client.Name = reader.IsDBNull(reader.GetOrdinal("cltnombre")) ? null : reader.GetString("cltnombre");

                            if (!reader.IsDBNull(reader.GetOrdinal("cltemail")))
                            {
                                client.Emails = new List<EmailDTO>();
                                EmailDTO email = new EmailDTO();
                                email.EmailAddress = reader.GetString("cltemail");
                                client.Emails.Add(email);
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("cltDireccion")))
                            {
                                client.Branches = new List<BranchDTO>();
                                BranchDTO direccion = new BranchDTO();
                                direccion.Address = reader.GetString("cltDireccion");
                                client.Branches.Add(direccion);
                            }

                            try
                            {
                                var resp = await dataProvider.SaveClient(client);
                                if (!resp.Successful)
                                {
                                    var err = resp.Messages;
                                }
                            }
                            catch (Exception ex)
                            {
                                contador++;
                            }
                        }
                    }
                }

                cnn.Close();
            }
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            //var clientsABM = new ClientsSearch();
            //this._mdiContainer.Children.Add(clientsABM);
            //DockingManager.SetHeader(clientsABM, "A/B/M Clientes");
            //DockingManager.SetState(clientsABM, DockState.Document);

            ////this.OpenNewModalWindow(new ClientsSearch());
            UIUtils.OpenNewModalWindow(new ClientsSearch());
        }

        private void Fight(object sender, RoutedEventArgs e)
        {
            UIUtils.OpenNewModalWindow(new UI.Experimental.Window1());
        }
    }
}