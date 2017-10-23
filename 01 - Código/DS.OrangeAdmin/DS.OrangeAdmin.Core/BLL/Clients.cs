using System;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Data;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Base;
using DS.OrangeAdmin.Core.Mappings;
using System.Collections.Generic;
using DS.OrangeAdmin.Shared.Entities;
using DS.OrangeAdmin.Core.Queries;

namespace DS.OrangeAdmin.Core.BLL
{
    public class Clients : BaseBll
    {
        internal Clients()
        {

        }

        public IList<ClientDTO> GetClients(QueryParameters parameter)
        {
            var context = new OrangeContext();

            var query = context.ClientsDao.AsQueryable<IClient>();

            foreach (var filtro in parameter.Filtros)
            {
                query = query.Where(filtro);
            }

            try
            {
                return query.ToList().Select(client => EntityToDTO.Map(client)).ToList();
            }catch(Exception ex)
            {
                return null;
            }
        }

        public OperationResult SaveOrUpdate(ClientDTO client)
        {
            return this.safeOperation<ClientDTO>(saveOrUpdate, client);
        }

        private OperationResult saveOrUpdate(ClientDTO client)
        {
            var context = new OrangeContext();

            if (client.Id == Guid.Empty)
            {
                Client clientToSave = new Client()
                {
                    Code = client.Code,
                    Name = client.Name,
                    Alias = client.Alias,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                context.ClientsDao.Add(clientToSave);
            }
            else
            {
                Client clientToSave = context.ClientsDao.Find(client.Id);
                clientToSave.Code = client.Code;
                clientToSave.Name = client.Name;
                clientToSave.Alias = client.Alias;

                context.Entry(clientToSave).State = System.Data.Entity.EntityState.Modified;
            }

            context.SaveChanges();

            return new OperationResult();
        }
    }
}
