using System;
using System.Collections.Generic;
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
                Codigo = client.Codigo,
                CodigoPostal = client.CodigoPostal,
                Direccion = client.Direccion,
                Id = client.Id,
                Localidad = client.Localidad,
                Nombre = client.Nombre,
                NombreFantasia = client.NombreFantasia
            });
        }

        public OperationResult SaveOrUpdate(ClientDTO client)
        {
            return this.safeOperation<ClientDTO>(saveOrUpdate, client);
        }

        private OperationResult saveOrUpdate(ClientDTO client)
        {
            var context = new OrangeContext();

            if (client.Id == 0)
            {
                Client clientToSave = new Client()
                {
                    Codigo = client.Codigo,
                    CodigoPostal = client.CodigoPostal,
                    Direccion = client.Direccion,
                    Id = 1,
                    Localidad = client.Localidad,
                    Nombre = client.Nombre,
                    NombreFantasia = client.NombreFantasia
                };

                context.ClientsDao.Add(clientToSave);
            }
            else
            {
                Client clientToSave = context.ClientsDao.Find(client.Id);
                clientToSave.Codigo = client.Codigo;
                clientToSave.CodigoPostal = client.CodigoPostal;
                clientToSave.Direccion = client.Direccion;
                clientToSave.Localidad = client.Localidad;
                clientToSave.Nombre = client.Nombre;
                clientToSave.NombreFantasia = client.NombreFantasia;

                context.Entry(clientToSave).State = System.Data.Entity.EntityState.Modified;
            }

            context.SaveChanges();

            return new OperationResult();
        }
    }
}
