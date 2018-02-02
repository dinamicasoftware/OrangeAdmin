using System;
using System.Threading.Tasks;
using DS.OrangeAdmin.Client.UI.Views.Base;
using DS.OrangeAdmin.Client.VM.Clients;

namespace DS.OrangeAdmin.Client.UI.Views.Clients
{
    /// <summary>
    /// Interaction logic for ClientsGrid.xaml
    /// </summary>
    public partial class ClientsGrid : DSDocumentPanel
    {
        public ClientsGrid()
        {
            InitializeComponent();
            this.edit.ItemClick += Edit_ItemClick;
            //cargarDatos();
        }

        private async void Edit_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            ClientVM selected = this.datagrid.SelectedItem as ClientVM;
            ClientEdit edit = new ClientEdit();
            edit.Caption = "Cliente " + selected?.Nombre;
            var client = await UI.PL.Clients.GetClilent(selected.Id);
            edit.DataContext = client;
            MainWindow.ShowInMainWindow(edit);
        }

        /*async Task cargarDatos()
        {
            var clients = await DS.OrangeAdmin.Client.UI.PL.Clients.GetClientsGridVM();

            if (clients?.Clients != null)
            {
                this.datagrid.ItemsSource = clients.Clients;
            }
        }*/
    }
}
