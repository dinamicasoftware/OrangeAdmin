
using DS.OrangeAdmin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.InitialData;

namespace DS.OrangeAdmin.Data
{
    public class OrangeContext : DbContext
    {
        public OrangeContext() : base("OrangeDB")
        {
            //Database.SetInitializer<OrangeContext>(null);
            Database.SetInitializer<OrangeContext>(new OrangeInitializer());
            //Database.SetInitializer<OrangeContext>(new OrangeInitializer(this));
            //Database.SetInitializer<OrangeContext>(new CreateDatabaseIfNotExists<OrangeContext>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasKey(u => u.Id).ToTable("Clientes");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Client> ClientsDao { get; set; }
        public virtual DbSet<Foo> FoosDao { get; set; }
    }
}
