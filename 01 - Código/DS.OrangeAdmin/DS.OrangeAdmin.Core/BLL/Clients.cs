using System;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Data;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Base;
using DS.OrangeAdmin.Core.Mappings;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.Entity;
using DS.OrangeAdmin.Core.InternalServices;
using DS.OrangeAdmin.Core.Queries;
using AutoMapper.QueryableExtensions;

namespace DS.OrangeAdmin.Core.BLL
{
    public class Clients : BaseBll
    {
        internal Clients()
        {

        }

        public async Task<OperationResult<ClientDTO>> GetClient(Guid id)
        {
            var context = new OrangeContext();

            try
            {
                return new OperationResult<ClientDTO>(EntityToDTO.Map(await context.ClientsDao.Include(cli => cli.Emails).FirstAsync(cli => cli.Id == id)));
            }
            catch (Exception ex)
            {
                return new OperationResult<ClientDTO>(false, ex.ToString());
            }
        }

        public async Task<OperationResult<List<ClientDTO>>> GetClients(QueryParameters<Client> parameters)
        {
            var context = new OrangeContext();

            var query = context.ClientsDao.Where(client => !client.Deleted);

            if (parameters?.Where != null)
            {
                foreach (var filter in parameters.Where)
                {
                    query = query.Where(filter);
                }
            }

            if (parameters?.Skip > 0)
            {
                query = query.Skip(parameters.Skip);
            }

            if (parameters.Take > 0)
            {
                query = query.Take(parameters.Take);
            }

            if (parameters?.Includes != null)
            {
                foreach (var include in parameters.Includes)
                {
                    query = query.Include(include);
                }
            }

            if (parameters?.OrderBy != null)
            {
                foreach (var order in parameters.OrderBy)
                {
                    query = query.OrderBy(order);
                }
            }

            try
            {
                //return new OperationResult<List<ClientDTO>>((await query.ToListAsync()).Select(client => EntityToDTO.Map(client)).ToList());
                return new OperationResult<List<ClientDTO>>(await query.ProjectTo<ClientDTO>(Mappings.Config.MapperConfig).ToListAsync());
            }
            catch (Exception ex)
            {
                return new OperationResult<List<ClientDTO>>(false, ex.ToString());
            }
        }

        public async Task<OperationResult<int>> GetCount(QueryParameters<Client> parameters)
        {
            var context = new OrangeContext();

            var query = context.ClientsDao.Where(client => !client.Deleted);

            if (parameters?.Where != null)
            {
                foreach (var filter in parameters.Where)
                {
                    query = query.Where(filter);
                }
            }

            if (parameters?.Skip > 0)
            {
                query = query.Skip(parameters.Skip);
            }

            if (parameters.Take > 0)
            {
                query = query.Take(parameters.Take);
            }

            if (parameters?.Includes != null)
            {
                foreach (var include in parameters.Includes)
                {
                    query = query.Include(include);
                }
            }

            if (parameters?.OrderBy != null)
            {
                foreach (var order in parameters.OrderBy)
                {
                    query = query.OrderBy(order);
                }
            }

            try
            {
                //return new OperationResult<List<ClientDTO>>((await query.ToListAsync()).Select(client => EntityToDTO.Map(client)).ToList());
                return new OperationResult<int>(await query.CountAsync());
            }
            catch (Exception ex)
            {
                return new OperationResult<int>(false, ex.ToString());
            }
        }

        public async Task<OperationResult<List<ClientGridDTO>>> GetClientsGrid(QueryParameters<Client> parameters)
        {
            var context = new OrangeContext();

            var query = context.ClientsDao.Where(client => !client.Deleted);

            if (parameters?.Where != null)
            {
                foreach (var filter in parameters.Where)
                {
                    query = query.Where(filter);
                }
            }

            if (parameters?.Includes != null)
            {
                foreach (var include in parameters.Includes)
                {
                    query = query.Include(include);
                }
            }

            if (parameters?.OrderBy != null && parameters?.OrderBy.Count > 0)
            {
                foreach (var order in parameters.OrderBy)
                {
                    query = query.OrderBy(order);
                }
            }
            else
            {
                query = query.OrderBy(cli => cli.Code);
            }

            if (parameters?.Skip > 0)
            {
                query = query.Skip(parameters.Skip);
            }

            if (parameters.Take > 0)
            {
                query = query.Take(parameters.Take);
            }

            try
            {
                //return new OperationResult<List<ClientDTO>>((await query.ToListAsync()).Select(client => EntityToDTO.Map(client)).ToList());
                return new OperationResult<List<ClientGridDTO>>(await query.ProjectTo<ClientGridDTO>(Mappings.Config.MapperConfig).ToListAsync());
            }
            catch (Exception ex)
            {
                return new OperationResult<List<ClientGridDTO>>(false, ex.ToString());
            }
        }

        public async Task<OperationResult> SaveOrUpdate(ClientDTO client)
        {
            return await this.safeDBOperation<ClientDTO>(saveOrUpdate, client);
        }

        private async Task<OperationResult> saveOrUpdate(ClientDTO client)
        {
            Client clientToSave = DTOToEntity.Map(client);
            ClientsService.PrepareToSave(clientToSave);

            var validateClient = ClientsService.Validate(clientToSave);
            if (validateClient.Successful)
            {
                var context = new OrangeContext();
                if (clientToSave.Id == Guid.Empty)
                {
                    context.ClientsDao.Add(clientToSave);
                }
                else
                {
                    context.Entry(clientToSave).State = EntityState.Modified;
                }
                await context.SaveChangesAsync();

                return new OperationResult();
            }
            else
            {
                return validateClient;
            }
        }
    }
}
