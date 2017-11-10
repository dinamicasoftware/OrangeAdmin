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
using System.Linq.Expressions;

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

        public async Task<OperationResult<List<ClientDTO>>> GetClients(Expression<Func<Client, bool>> filtro)
        {
            var context = new OrangeContext();

            var query = context.ClientsDao.Where(client => !client.Deleted);
            query = query.Where(filtro);

            try
            {
                return new OperationResult<List<ClientDTO>>((await query.ToListAsync()).Select(client => EntityToDTO.Map(client)).ToList());
            }
            catch (Exception ex)
            {
                return new OperationResult<List<ClientDTO>>(false, ex.ToString());
            }
        }

        public async Task<OperationResult<List<ClientDTO>>> GetClients(int skip = 0, int take = 0)
        {
            var context = new OrangeContext();

            var query = context.ClientsDao.Where(client => !client.Deleted);

            if(skip > 0)
            {
                query = query.Skip(skip);
            }

            if(take > 0)
            {
                query = query.Take(take);
            }

            try
            {
                return new OperationResult<List<ClientDTO>>((await query.ToListAsync()).Select(client => EntityToDTO.Map(client)).ToList());
            }
            catch (Exception ex)
            {
                return new OperationResult<List<ClientDTO>>(false, ex.ToString());
            }
        }

        public async Task<OperationResult> SaveOrUpdate(ClientDTO client)
        {
            return await this.safeOperation<ClientDTO>(saveOrUpdate, client);
        }

        private async Task<OperationResult> saveOrUpdate(ClientDTO client)
        {
            Client clientToSave = DTOToEntity.Map(client);
            ClientsService.PrepareToSave(clientToSave);

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
    }
}
