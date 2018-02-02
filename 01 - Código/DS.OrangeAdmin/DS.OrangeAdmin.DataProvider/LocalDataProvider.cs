using System;
using System.Collections.Generic;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.DataProvider
{
    public class LocalDataProvider : IDataProvider
    {
        public async Task<OperationResult<ClientDTO>> GetClient(Guid id)
        {
            return await BusinessProvider.Clients.GetClient(id);
        }

        public async Task<OperationResult<int>> GetCount(QueryParameters<Client> parameters)
        {
            return await BusinessProvider.Clients.GetCount(parameters);
        }

        public async Task<OperationResult<List<ClientDTO>>> GetClients(QueryParameters<Client> parameters)
        {
            return await BusinessProvider.Clients.GetClients(parameters);
        }

        public async Task<OperationResult<List<ClientGridDTO>>> GetClientsGrid(QueryParameters<Client> parameters)
        {
            return await BusinessProvider.Clients.GetClientsGrid(parameters);
        }

        public async Task<OperationResult> SaveClient(ClientDTO client)
        {
            return await BusinessProvider.Clients.SaveOrUpdate(client);
        }
    }
}
