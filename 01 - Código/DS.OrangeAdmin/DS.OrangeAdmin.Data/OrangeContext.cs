
using DS.OrangeAdmin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Data
{
    public class OrangeContext : DbContext
    {
        public OrangeContext() : base("Name=OrangeDB")
        {
            Database.SetInitializer<OrangeContext>(null);
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>().HasKey(u => u.Id).ToTable("Clientes");
        }

        public virtual DbSet<Client> ClientsDao { get; set; }
    }
}
