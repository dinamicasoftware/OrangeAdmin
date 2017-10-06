using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;

namespace DS.OrangeAdmin.DataProvider
{
    public class ExternalDataProvider : IDataProvider
    {
        public IQueryable<ClientDTO> GetClients()
        {
            throw new NotImplementedException();
        }
    }
}
