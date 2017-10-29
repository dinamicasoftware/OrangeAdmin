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
using DS.OrangeAdmin.Client.VM.Clients;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.DataProvider;

namespace DS.OrangeAdmin.Client.UI.Clients
{
    /// <summary>
    /// Lógica de interacción para NewClient.xaml
    /// </summary>
    public partial class NewClient : Window
    {
        private IDataProvider dataProvider;
        private NewClientVM vm;

        public NewClient()
        {
            InitializeComponent();
            dataProvider = new LocalDataProvider();
            
            // TODO: traer clientTypes, documentTypes e IVAs a través del nuevo servicio async
            vm = new NewClientVM
            {

            };
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            if (
                MessageBox.Show("¿Descartar los cambios y salir?", "Cancelar", MessageBoxButton.OKCancel,
                    MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            //TODO: Validaciones. Research validators.

            var newClient = new ClientDTO
            {
                Code = CodeTextBlock.Text,
                Name = NameTextBlock.Text,
                Alias = AliasTextBlock.Text,
                DocumentNumber = DocumentNumberTextBlock.Text,
                Observation = ObservationTextBlock.Text,

                CreatedAt = DateTime.Now,
                Deleted = false
            };
            dataProvider.SaveClient(newClient);
            this.Close();
        }
    }
}
