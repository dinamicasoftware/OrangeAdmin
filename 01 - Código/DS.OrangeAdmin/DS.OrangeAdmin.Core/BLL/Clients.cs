using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Data;
using DS.OrangeAdmin.Data.Entities;
using System.Data.Entity.Infrastructure;
using DS.OrangeAdmin.Core.Operations;

namespace DS.OrangeAdmin.Core.BLL
{
    public class Clients
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
            return safeSaveOrUpdate(client);
        }

        private OperationResult safeSaveOrUpdate(ClientDTO client)
        {
            OperationResult operationResult;
            bool retryOperation;
            int retryCounter = 0;

            do
            {
                try
                {
                    operationResult = saveOrUpdate(client);
                    retryOperation = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    operationResult = new OperationResult(false, ex.ToString());
                    if (retryCounter < 3)
                    {
                        retryOperation = true;
                        retryCounter++;
                    }
                    else
                    {
                        retryOperation = false;
                    }
                }
                catch (Exception ex)
                {
                    operationResult = new OperationResult(false, ex.ToString());
                    retryOperation = false;
                }
            } while (retryOperation);

            return operationResult;
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
