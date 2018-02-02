using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DS.OrangeAdmin.Client.VM.Clients;
using System.Collections.Generic;

namespace DS.OrangeAdmin.Client.UI.PL
{
    public static class Clients
    {
        /*public static async Task<ClientsGridVM> GetClientsGridVM()
        {
            var parameters = new Core.Queries.QueryParameters<DS.OrangeAdmin.Data.Entities.Client>
            {
                Take = 100
                //OrderBy = new List<Expression<Func<Data.Entities.Client, object>>>(new List<Expression<Func<Data.Entities.Client, object>>>(x => x.))
            };

            var vm = new ClientsGridVM();

            var result = await DS.OrangeAdmin.Client.Data.BussinesProvider.DataProvider.GetClientsGrid(parameters);
            if (result.Successful)
            {
                vm.Clients = new ObservableCollection<ClientVM>(result.Result.Select(x => new ClientVM
                {
                    Id = x.Id,
                    Nombre = x.Name,
                    Alias = x.Alias,
                    Código = x.Code,
                    DefaultEmail = x.Email?.EmailAddress
                }));
            }

            return vm;
        }*/

        public static async Task<int> GetCount()
        {
            var parameters = new Core.Queries.QueryParameters<DS.OrangeAdmin.Data.Entities.Client>
            {
                //OrderBy = new List<Expression<Func<Data.Entities.Client, object>>>(new List<Expression<Func<Data.Entities.Client, object>>>(x => x.))
            };

            var result = await DS.OrangeAdmin.Client.Data.BussinesProvider.DataProvider.GetCount(parameters);
            if (result.Successful)
            {
                return result.Result;
            }
            else
            {
                return result.Result;
            }
        }

        public static async Task<ObservableCollection<ClientVM>> GetClients(int take, int skip)
        {
            ObservableCollection<ClientVM> clientsVM;

            var parameters = new Core.Queries.QueryParameters<DS.OrangeAdmin.Data.Entities.Client>
            {
                Take = take,
                Skip = skip
                //OrderBy = new List<Expression<Func<Data.Entities.Client, object>>>(new List<Expression<Func<Data.Entities.Client, object>>>(x => x.))
            };

            var result = await DS.OrangeAdmin.Client.Data.BussinesProvider.DataProvider.GetClientsGrid(parameters);
            if (result.Successful)
            {
                clientsVM = new ObservableCollection<ClientVM>(result.Result.Select(x => new ClientVM
                {
                    Id = x.Id,
                    Nombre = x.Name,
                    Alias = x.Alias,
                    Código = x.Code,
                    DefaultEmail = x.Email?.EmailAddress
                }));
            }
            else
            {
                clientsVM = null;
            }

            return clientsVM;
        }

        public static async Task<ClientVM> GetClilent(Guid id)
        {
            ClientVM vm;

            var result = await DS.OrangeAdmin.Client.Data.BussinesProvider.DataProvider.GetClient(id);
            if (result.Successful)
            {
                var client = result.Result;
                vm = new ClientVM()
                {
                    Id = client.Id,
                    Nombre = client.Name,
                    Alias = client.Alias,
                    Código = client.Code,
                    DefaultEmail = client.Email?.EmailAddress
                };
            }
            else
            {
                vm = null;
            }

            return vm;
        }

        /*public static IEnumerable<ClientVM> GetClients(IList<ClientDTO> clientsQuery)
        {
            return clientsQuery.Select(x => new ClientVM
            {
                Nombre = x.Name,
                Alias = x.Alias,
                Código = x.Code,
                NúmeroDeDocumento = $"{x.DocumentType?.Name} {x.DocumentNumber}",
                DefaultEmail = x.Emails?.FirstOrDefault()?.EmailAddress,
                Observaciones = x.Observation
            });
        }*/
    }
}
