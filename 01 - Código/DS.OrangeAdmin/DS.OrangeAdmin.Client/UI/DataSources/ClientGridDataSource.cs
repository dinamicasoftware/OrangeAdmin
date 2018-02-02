using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Client.VM.Clients;
using System.Collections;

namespace DS.OrangeAdmin.Client.UI.DataSources
{
    public class ClientGridDataSource : IDataSource
    {
        public async Task<int> Count()
        {
            return await PL.Clients.GetCount();
        }

        public async Task<IList> GetData(int take, int skip)
        {
            return await PL.Clients.GetClients(take, skip);
        }
    }
}
