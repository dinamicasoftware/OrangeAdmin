using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.OrangeAdmin.DataProvider
{
    public interface IDataProvider
    {
        IQueryable<ClientDTO> GetClients();
        OperationResult SaveClient(ClientDTO client);
    }
}
