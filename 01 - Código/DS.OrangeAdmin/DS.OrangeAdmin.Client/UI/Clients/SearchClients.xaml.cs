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
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Ribbon;
using DS.OrangeAdmin.DataProvider;
using DS.OrangeAdmin.Client.VM.Clients;

namespace DS.OrangeAdmin.Client.UI.Clients
{
    /// <summary>
    /// Lógica de interacción para SearchClients.xaml
    /// </summary>
    public partial class SearchClients
    {
        public SearchClients()
        {
            InitializeComponent();
            Refresh();
        }

        private async void Refresh()
        {
            this.DataContext = await BusinessProvider.ClientsBll.GetClientsSearchResultVM();
        }

        private void groupFile_CaptionButtonClick(object sender, RibbonCaptionButtonClickEventArgs e)
        {
            
        }

        private void bAbout_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
