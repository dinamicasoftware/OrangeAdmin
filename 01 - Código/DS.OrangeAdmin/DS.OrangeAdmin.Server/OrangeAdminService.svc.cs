using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Server.Queries;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Shared.Serializer;
using System.Linq.Expressions;
using DS.OrangeAdmin.Shared.Entities;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OrangeAdminService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OrangeAdminService.svc or OrangeAdminService.svc.cs at the Solution Explorer and start debugging.
    public class OrangeAdminService : IOrangeAdmin
    {
        public async Task<OperationResult<List<ClientDTO>>> GetClients(int skip = 0, int take = 0)
        {
            return await BusinessProvider.Clients.GetClients(skip, take);
        }

        public async Task<OperationResult> SaveClient(ClientDTO client)
        {
            return await BusinessProvider.Clients.SaveOrUpdate(client);
        }
    }
}
