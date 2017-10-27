using System;
using System.Collections.Generic;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Queries;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.DataProvider
{
    public interface IDataProvider
    {
        OperationResult<IList<ClientDTO>> GetClients(QueryParameters<IClient> queryParameters);
        OperationResult SaveClient(ClientDTO client);
    }
}
