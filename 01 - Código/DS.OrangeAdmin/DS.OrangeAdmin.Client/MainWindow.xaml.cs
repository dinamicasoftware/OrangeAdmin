using System;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using DS.OrangeAdmin.Client.UI.Views.Base;
using DS.OrangeAdmin.Client.UI.Views.Clients;
using DS.OrangeAdmin.Client.VM.Clients;

namespace DS.OrangeAdmin.Client
{
    public partial class MainWindow : DXRibbonWindow
    {
        private static MainWindow CurrentMainWindow { get; set; }

        public static void ShowInMainWindow(DSDocumentPanel panel)
        {
            CurrentMainWindow.Show(panel);
        }

        public static void RemoveFromMainWindow(DSDocumentPanel panel)
        {
            CurrentMainWindow.Close(panel);
        }

        public MainWindow()
        {
            InitializeComponent();
            abmClientes.ItemClick += AbmClientes_ItemClick;
            abmClientesLink.ItemClick += AbmClientes_ItemClick;
            CurrentMainWindow = this;
        }

        private void AbmClientes_ItemClick(object sender, ItemClickEventArgs e)
        {
            ClientsGrid clientsGrid = new ClientsGrid();
            clientsGrid.DataContext = new ClientsGridVM();
            clientsGrid.Caption = "A/B/M de Clientes";
            Show(clientsGrid);
        }

        public void Show(DSDocumentPanel panel)
        {
            documentGroup1.Add(panel);
            dockManager1.Activate(panel);
        }

        public void Close(DSDocumentPanel panel)
        {
            documentGroup1.Remove(panel);
        }
    }
}
