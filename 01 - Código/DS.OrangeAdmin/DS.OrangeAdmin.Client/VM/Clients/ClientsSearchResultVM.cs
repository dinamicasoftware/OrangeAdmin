using DS.OrangeAdmin.Core.DTO;
using System;
using System.Collections.Generic;
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

        private List<ClientsVM> _clients;

        public List<ClientsVM> Clients
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
