using DS.OrangeAdmin.Core.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public class ClientsSearchResultVM : ObservableObject
    {
        public ClientsSearchResultVM() : base()
        {

        }

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
