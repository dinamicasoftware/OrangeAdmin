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

namespace DS.OrangeAdmin.Core.BLL
{
    public class Clients : BaseBll
    {
        internal Clients()
        {

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
                return new OperationResult<List<ClientDTO>>((await query.Include(cli => cli.Emails).ToListAsync()).Select(client => EntityToDTO.Map(client)).ToList());
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
            var context = new OrangeContext();

            DateTime now = DateTime.Now;
            Client clientToSave = DTOToEntity.Map(client);
            clientToSave.UpdatedAt = now;

            if (client.Id == Guid.Empty)
            {
                clientToSave.CreatedAt = now;

                if (clientToSave.Emails != null)
                {
                    foreach (var item in clientToSave.Emails)
                    {
                        item.UpdatedAt = now;
                        if (item.Id == Guid.Empty)
                        {
                            item.CreatedAt = now;
                        }
                    }
                }

                context.ClientsDao.Add(clientToSave);
            }
            else
            {
                //Client clientToSave = context.ClientsDao.Find(client.Id);
                if (clientToSave.Emails != null)
                {
                    if (clientToSave.Emails != null)
                    {
                        foreach (var item in clientToSave.Emails)
                        {
                            item.UpdatedAt = now;
                            if (item.Id == Guid.Empty)
                            {
                                item.CreatedAt = now;
                            }
                        }
                    }
                }

                context.Entry(clientToSave).State = EntityState.Modified;
            }

            await context.SaveChangesAsync();

            return new OperationResult();
        }
    }
}
