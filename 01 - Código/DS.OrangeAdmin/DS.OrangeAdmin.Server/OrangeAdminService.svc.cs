using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DS.OrangeAdmin.Core;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Server.Queries;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Shared.Serializer;
using System.Linq.Expressions;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrangeAdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrangeAdminService.svc or OrangeAdminService.svc.cs at the Solution Explorer and start debugging.
    public class OrangeAdminService : IOrangeAdmin
    {
        public IList<ClientDTO> GetClients(QueryParameters queryParameters)
        {
            Core.Queries.QueryParameters coreParameters = new Core.Queries.QueryParameters()
            {
                Filtros = queryParameters.Filtros.Select(filtro => JsonNetAdapter.Deserialize<Expression<Func<IClient, bool>>>(filtro)).ToList(),
                Take = queryParameters.Take
            };

            return BusinessProvider.Clients.GetClients(coreParameters);
        }

        /*public OperationResult SaveClient(ClientDTO client)
        {
            return BusinessProvider.Clients.SaveOrUpdate(client);
        }*/
        /*public void GetClients()
        {
            
        }*/
    }
}
