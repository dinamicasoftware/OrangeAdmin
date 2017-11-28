using DS.OrangeAdmin.Core.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Client.Util;
using DS.OrangeAdmin.DataProvider;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public class ClientsSearchResultVM : ObservableObject
    {
        private ObservableCollection<ClientsVM> _clients;
        public ObservableCollection<ClientsVM> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                RaisePropertyChangedEvent(nameof(Clients));
            }
        }
    }
}
