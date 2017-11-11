using System;
using System.Collections.Generic;
using System.ServiceModel;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Server.Queries;
using DS.OrangeAdmin.Core.Operations;
using System.Threading.Tasks;
using System.Linq.Expressions;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrangeAdmin
    {
        [OperationContract]
        Task<OperationResult<ClientDTO>> GetClient(Guid id);
        [OperationContract]
        Task<OperationResult<List<ClientDTO>>> GetClients(QueryParameters parameters);
        [OperationContract]
        Task<OperationResult> SaveClient(ClientDTO client);
    }
}
