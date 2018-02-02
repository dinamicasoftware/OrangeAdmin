using System;
using DS.OrangeAdmin.Client.UI.Views.Base;

namespace DS.OrangeAdmin.Client.UI.Views.Clients
{
    /// <summary>
    /// Interaction logic for ClientEdit.xaml
    /// </summary>
    public partial class ClientEdit : DSDocumentPanel
    {
        public ClientEdit()
        {
            InitializeComponent();

            this.aceptar.ItemClick += Aceptar_ItemClick;
            this.cancelar.ItemClick += Cancelar_ItemClick;
        }

        private void Aceptar_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            MainWindow.RemoveFromMainWindow(this);
        }

        private void Cancelar_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            MainWindow.RemoveFromMainWindow(this);
        }
    }
}
