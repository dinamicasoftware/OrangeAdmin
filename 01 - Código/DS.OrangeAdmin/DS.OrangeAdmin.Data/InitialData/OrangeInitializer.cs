using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Data.InitialData
{
    public class OrangeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<OrangeContext>
    {
        //public OrangeInitializer(OrangeContext context) //mal: esto obliga a correr el seed siempre
        //{
        //    Seed(context);
        //}

        protected override void Seed(OrangeContext context)
        {
            var clients = new List<Client>
            {
                new Client
                {
                    Id = Guid.NewGuid(),
                    Codigo = "cod01",
                    CodigoPostal = "3000",
                    Direccion = "Ayacucho 832",
                    Localidad = "Santa Fe",
                    Nombre = "Armando Andrés Meabe",
                    NombreFantasia = "Armando SRL"
                }
            };

            clients.ForEach(x => context.ClientsDao.Add(x));
            context.SaveChanges();
        }
    }
}
