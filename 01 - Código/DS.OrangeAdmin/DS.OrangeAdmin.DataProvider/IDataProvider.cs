using DS.OrangeAdmin.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DS.OrangeAdmin.DataProvider
{
    public interface IDataProvider
    {
        IQueryable<ClientDTO> GetClients();
        void SaveClient(ClientDTO client);
    }
}
