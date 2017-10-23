using DS.OrangeAdmin.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public static class ClientsVMHandler
    {
        public static IQueryable<ClientsVM> GetClients(IQueryable<ClientDTO> clientsQuery)
        {
            return clientsQuery.Select(x => new ClientsVM { Nombre = x.Name });
        }
    }
}
