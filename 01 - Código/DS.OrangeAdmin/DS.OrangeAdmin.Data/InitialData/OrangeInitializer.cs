using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Data.InitialData
{
    class OrangeInitializer : MigrateDatabaseToLatestVersion<OrangeContext, MigrateDBConfiguration>
    {
        //public OrangeInitializer(OrangeContext context) //mal: esto obliga a correr el seed siempre
        //{
        //    Seed(context);
        //}
        public override void InitializeDatabase(OrangeContext context)
        {
            base.InitializeDatabase(context);
        }

        /*protected override void Seed(OrangeContext context)
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
        }*/
    }
}
