using System;
using System.Collections.Generic;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.DataProvider
{
    public class ExternalDataProvider : IDataProvider
    {
        OrangeAdminService.OrangeAdminClient client;

        public ExternalDataProvider()
        {
            this.client = new OrangeAdminService.OrangeAdminClient();
        }

        public async Task<OperationResult<ClientDTO>> GetClient(Guid id)
        {
            return await this.client.GetClientAsync(id);
        }

        public async Task<OperationResult<int>> GetCount(QueryParameters<Client> parameters)
        {
            //return await this.client.GetClientsGridAsync(DS.OrangeAdmin.Server.Queries.QueryParameters.Serialize(parameters));
            throw new NotImplementedException();
        }

        public async Task<OperationResult<List<ClientDTO>>> GetClients(QueryParameters<Client> parameters)
        {
            return await this.client.GetClientsAsync(DS.OrangeAdmin.Server.Queries.QueryParameters.Serialize(parameters));
        }

        public async Task<OperationResult<List<ClientGridDTO>>> GetClientsGrid(QueryParameters<Client> parameters)
        {
            //return await this.client.GetClientsGridAsync(DS.OrangeAdmin.Server.Queries.QueryParameters.Serialize(parameters));
            throw new NotImplementedException();
        }

        public async Task<OperationResult> SaveClient(ClientDTO client)
        {
            return await this.client.SaveClientAsync(client);
        }
    }
}
