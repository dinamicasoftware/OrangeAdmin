using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Client.UI.DataSources
{
    //public interface IDataSource { }

    public interface IDataSource//<T> : IDataSource
    {
        Task<int> Count();
        Task<IList> GetData(int take, int skip);
    }
}
