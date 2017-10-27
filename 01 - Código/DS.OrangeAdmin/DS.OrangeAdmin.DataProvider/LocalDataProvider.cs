using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using DS.OrangeAdmin.Shared.Entities;
using DS.OrangeAdmin.Shared.Expressions;

namespace DS.OrangeAdmin.DataProvider
{
    public class LocalDataProvider : IDataProvider
    {
        public OperationResult<IList<ClientDTO>> GetClients(QueryParameters<IClient> queryParameters)
        {
            return BusinessProvider.Clients.GetClients(new QueryParameters<IClient>()
            {
                Filtros = queryParameters.Filtros.Select(filtro => new FixVisitor().Visit(filtro)).ToArray(),
                Take = queryParameters.Take
            });
        }

        public OperationResult SaveClient(ClientDTO client)
        {
            return BusinessProvider.Clients.SaveOrUpdate(client);
        }
    }
}
