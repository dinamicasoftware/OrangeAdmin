using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public class ClientsVM : ObservableObject
    {
        public ClientsVM() : base()
        {
        }

        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                RaisePropertyChangedEvent(nameof(Nombre));
            }
        }
    }
}
