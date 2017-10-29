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

namespace DS.OrangeAdmin.DataProvider
{
    public class LocalDataProvider : IDataProvider
    {
        public async Task<OperationResult<List<ClientDTO>>> GetClients(QueryParameters<IClient> queryParameters)
        {
            return await BusinessProvider.Clients.GetClients(new QueryParameters<IClient>()
            {
                Filtros = queryParameters.Filtros.Select(filtro => new FixVisitor().Visit(filtro)).ToArray(),
                Take = queryParameters.Take
            });
        }

        public async Task<OperationResult> SaveClient(ClientDTO client)
        {
            return await BusinessProvider.Clients.SaveOrUpdate(client);
        }
    }
}
