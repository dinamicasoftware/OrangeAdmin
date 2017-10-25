using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Core.Operations;

namespace DS.OrangeAdmin.DataProvider
{
    public class ExternalDataProvider : IDataProvider
    {
        public IQueryable<ClientDTO> GetClients()
        {
            throw new NotImplementedException();
        }

        public OperationResult SaveClient(ClientDTO client)
        {
            throw new NotImplementedException();
        }
    }
}
