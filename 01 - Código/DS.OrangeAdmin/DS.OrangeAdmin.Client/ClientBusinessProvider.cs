using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Client.UI.Bll;
using DS.OrangeAdmin.DataProvider;

namespace DS.OrangeAdmin.Client
{
    public static class ClientBusinessProvider
    {
        private static IDataProvider _dataProvider;
        public static IDataProvider DataProvider => _dataProvider ?? (_dataProvider = new LocalDataProvider());

        private static ClientsBll _clientsBll;
        //public static ClientsBll ClientsBlls => new ClientsBll();
        public static ClientsBll ClientsBll => _clientsBll ?? (_clientsBll = new ClientsBll());
    }
}
