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

        public async Task<OperationResult<List<ClientDTO>>> GetClients(QueryParameters<IClient> queryParameters)
        {
            return await this.client.GetClientsAsync(new Server.Queries.QueryParameters()
            {
                Filtros = queryParameters.Filtros.Select(filtro => JsonNetAdapter.Serialize(new FixVisitor().Visit(filtro))).ToArray(),
                Take = queryParameters.Take
            });
        }

        public async Task<OperationResult> SaveClient(ClientDTO client)
        {
            return await this.client.SaveClientAsync(client);
        }
    }
}
