using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Client.VM.Clients;

namespace DS.OrangeAdmin.Client.UI.Bll
{
    public class ClientsBll
    {
        public static async Task<ClientsSearchResultVM> GetClientsSearchResultVM()
        {
            var parameters = new Core.Queries.QueryParameters<Data.Entities.Client>
            {
                //Includes = new List<Expression<Func<Data.Entities.Client, object>>>(),
                //OrderBy = new List<Expression<Func<Data.Entities.Client, object>>>(new List<Expression<Func<Data.Entities.Client, object>>>(x => x.))
            };

            var clients = new List<ClientsVM>(ClientsVMHandler.GetClients((await ClientBusinessProvider.DataProvider.GetClients(parameters)).Result));
            var vm = new ClientsSearchResultVM
            {
                Clients = new ObservableCollection<ClientsVM>(clients)
            };

            return vm;
        }
    }
}
