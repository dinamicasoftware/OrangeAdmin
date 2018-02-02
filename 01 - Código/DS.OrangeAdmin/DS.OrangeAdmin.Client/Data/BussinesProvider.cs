using System;
using DS.OrangeAdmin.DataProvider;

namespace DS.OrangeAdmin.Client.Data
{
    static class BussinesProvider
    {
        private static IDataProvider _dataProvider;
        public static IDataProvider DataProvider => _dataProvider ?? (_dataProvider = new LocalDataProvider());
    }
}
