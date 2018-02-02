using DS.OrangeAdmin.Client.UI.DataSources;
using System;
using System.Collections.ObjectModel;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public class ClientsGridVM : ObservableObject
    {
        /*private ObservableCollection<ClientVM> _clients;
        public ObservableCollection<ClientVM> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                RaisePropertyChangedEvent(nameof(Clients));
            }
        }*/

        public ClientsGridVM()
        {
            this.DataSource = new ClientGridDataSource();
        }

        private ClientGridDataSource _dataSource;
        public ClientGridDataSource DataSource
        {
            get { return this._dataSource; }
            private set { this._dataSource = value; RaisePropertyChangedEvent(nameof(DataSource)); }
        }
    }
}
