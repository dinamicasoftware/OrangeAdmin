using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using DS.OrangeAdmin.Shared.Serializer;
using DS.OrangeAdmin.Shared.Expressions;
using DS.OrangeAdmin.Shared.Entities;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.DataProvider
{
    public class ExternalDataProvider : IDataProvider
    {
        OrangeAdminService.OrangeAdminClient client;

        public ExternalDataProvider()
        {
            this.client = new OrangeAdminService.OrangeAdminClient();
        }

        public async Task<OperationResult<List<ClientDTO>>> GetClients(int skip = 0, int take = 0)
        {
            return null;// await this.client.GetClientsAsync(skip, take);
        }

        public async Task<OperationResult> SaveClient(ClientDTO client)
        {
            return await this.client.SaveClientAsync(client);
        }
    }
}
