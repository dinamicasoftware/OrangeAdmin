using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.BLL;
using DS.OrangeAdmin.Core;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;

namespace DS.OrangeAdmin.DataProvider
{
    public class LocalDataProvider : IDataProvider
    {
        public IList<ClientDTO> GetClients(QueryParameters queryParameters)
        {
            return BusinessProvider.Clients.GetClients(queryParameters);
        }

        public OperationResult SaveClient(ClientDTO client)
        {
            return BusinessProvider.Clients.SaveOrUpdate(client);
        }
    }
}
