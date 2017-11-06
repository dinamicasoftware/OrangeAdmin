using System;
using System.Collections.Generic;
using System.ServiceModel;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Server.Queries;
using DS.OrangeAdmin.Core.Operations;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrangeAdmin
    {
        [OperationContract]
        Task<OperationResult<List<ClientDTO>>> GetClients(int skip = 0, int take = 0);
        [OperationContract]
        Task<OperationResult> SaveClient(ClientDTO client);
    }
}
