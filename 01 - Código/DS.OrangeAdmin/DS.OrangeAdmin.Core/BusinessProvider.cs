using DS.OrangeAdmin.Core.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Core
{
    public static class BusinessProvider
    {
        private static Clients clients;

        public static Clients Clients
        {
            get
            {
                if (clients == null)
                    clients = new Clients();

                return clients;
            }
        }
    }
}
