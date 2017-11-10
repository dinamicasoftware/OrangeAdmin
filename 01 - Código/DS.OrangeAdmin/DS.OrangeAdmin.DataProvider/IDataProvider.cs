using System;
using System.Collections.Generic;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using DS.OrangeAdmin.Shared.Entities;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.DataProvider
{
    public interface IDataProvider
    {
        Task<OperationResult<ClientDTO>> GetClient(Guid id);
        Task<OperationResult<List<ClientDTO>>> GetClients(Expression<Func<Client, bool>> filtro);
        Task<OperationResult<List<ClientDTO>>> GetClients(int skip = 0, int take = 0);
        Task<OperationResult> SaveClient(ClientDTO client);
    }
}
