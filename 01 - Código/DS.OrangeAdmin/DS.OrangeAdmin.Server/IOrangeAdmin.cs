using System;
using System.Collections.Generic;
using System.ServiceModel;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Server.Queries;
using DS.OrangeAdmin.Core.Operations;

namespace DS.OrangeAdmin.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrangeAdmin
    {

        [OperationContract]
        OperationResult<IList<ClientDTO>> GetClients(QueryParameters queryParameters);
       //void GetClients(QueryParameters queryParameters);
        //void GetClients();
    }
}
