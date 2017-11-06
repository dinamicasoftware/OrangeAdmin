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
