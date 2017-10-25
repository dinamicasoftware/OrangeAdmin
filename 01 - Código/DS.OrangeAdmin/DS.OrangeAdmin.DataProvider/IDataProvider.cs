using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;

namespace DS.OrangeAdmin.DataProvider
{
    public interface IDataProvider
    {
        IList<ClientDTO> GetClients(QueryParameters queryParameters);
        OperationResult SaveClient(ClientDTO client);
    }
}
