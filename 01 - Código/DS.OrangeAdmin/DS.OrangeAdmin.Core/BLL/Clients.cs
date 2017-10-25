using System;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Data;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Core.Base;

namespace DS.OrangeAdmin.Core.BLL
{
    public class Clients : BaseBll
    {
        internal Clients()
        {

        }

        public IQueryable<ClientDTO> GetClients()
        {
            var context = new OrangeContext();
            return context.ClientsDao.Select(client => new ClientDTO()
            {
                //Codigo = client.Codigo,
                //CodigoPostal = client.CodigoPostal,
                //Direccion = client.Direccion,
                Id = client.Id,
                Alias = client.Alias,
                Code = client.Code,
                Name = client.Name
            });
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
