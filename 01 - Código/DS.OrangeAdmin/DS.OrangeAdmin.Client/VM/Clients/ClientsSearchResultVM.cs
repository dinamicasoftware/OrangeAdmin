using DS.OrangeAdmin.Core.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using DevExpress.Xpf.CodeView;
using DS.OrangeAdmin.Client.Util;
using DS.OrangeAdmin.DataProvider;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public class ClientsSearchResultVM : ObservableObject
    {
        private readonly IDataProvider _dataProvider;
        public ObservableCollection<ClientsVM> Clients { get; private set; }

        public ClientsSearchResultVM() : base()
        {
            _dataProvider = new LocalDataProvider();
            Clients = new ObservableCollection<ClientsVM>();
            Init();
        }

        public async void Init()
        {
            var parameters = new Core.Queries.QueryParameters<DS.OrangeAdmin.Data.Entities.Client> { };
            var results = new List<ClientsVM>(ClientsVMHandler.GetClients((await _dataProvider.GetClients(parameters)).Result));
            //this.Clients.AddRange(results);
            foreach (var i in results) this.Clients.Add(i);
            //OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));

        }

        public void AddClient()
        {
            Clients.Add(new ClientsVM
            {
                Alias = "ARM"
            });
        }
    }
}
