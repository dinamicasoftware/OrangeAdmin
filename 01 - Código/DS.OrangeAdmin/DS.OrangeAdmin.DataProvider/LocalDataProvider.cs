using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.BLL;
using DS.OrangeAdmin.Core;
using DS.OrangeAdmin.Core.Operations;

namespace DS.OrangeAdmin.DataProvider
{
    public class LocalDataProvider : IDataProvider
    {
        public IQueryable<ClientDTO> GetClients()
        {
            return BusinessProvider.Clients.GetClients();
        }

        public OperationResult SaveClient(ClientDTO client)
        {
            return BusinessProvider.Clients.SaveOrUpdate(client);
        }
    }
}
