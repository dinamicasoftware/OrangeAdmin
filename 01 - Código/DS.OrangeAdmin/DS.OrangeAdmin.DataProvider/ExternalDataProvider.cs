using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using DS.OrangeAdmin.Shared.Serializer;
using DS.OrangeAdmin.Shared.Expressions;

namespace DS.OrangeAdmin.DataProvider
{
    public class ExternalDataProvider : IDataProvider
    {
        OrangeAdminService.OrangeAdminClient client;

        public ExternalDataProvider()
        {
            this.client = new OrangeAdminService.OrangeAdminClient();
        }

        public IList<ClientDTO> GetClients(QueryParameters queryParameters)
        {
            return this.client.GetClients(new OrangeAdminService.QueryParameters()
            {
                Filtros = queryParameters.Filtros.Select(filtro => JsonNetAdapter.Serialize(new FixVisitor().Visit(filtro))).ToArray(),
                Take = queryParameters.Take
            });
        }

        public OperationResult SaveClient(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
