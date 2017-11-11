using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using DS.OrangeAdmin.Shared.Entities;
using DS.OrangeAdmin.Shared.Expressions;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;
using System.Linq.Expressions;

namespace DS.OrangeAdmin.DataProvider
{
    public class LocalDataProvider : IDataProvider
    {
        public async Task<OperationResult<ClientDTO>> GetClient(Guid id)
        {
            return await BusinessProvider.Clients.GetClient(id);
        }

        public async Task<OperationResult<List<ClientDTO>>> GetClients(QueryParameters<Client> parameters)
        {
            return await BusinessProvider.Clients.GetClients(parameters);
        }

        public async Task<OperationResult> SaveClient(ClientDTO client)
        {
            return await BusinessProvider.Clients.SaveOrUpdate(client);
        }
    }
}
