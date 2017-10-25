using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Server.Queries;

namespace DS.OrangeAdmin.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IOrangeAdmin
    {

        [OperationContract]
        IList<ClientDTO> GetClients(QueryParameters queryParameters);
       //void GetClients(QueryParameters queryParameters);
        //void GetClients();
    }
}
