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
                    cmd.CommandText = "SELECT * FROM clt__clientes LIMIT 10000";

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

                            try
                            {
                                await dataProvider.SaveClient(client);
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