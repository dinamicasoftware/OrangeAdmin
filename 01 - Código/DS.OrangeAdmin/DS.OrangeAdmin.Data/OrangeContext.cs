using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Data.InitialData;

namespace DS.OrangeAdmin.Data
{
    public class OrangeContext : DbContext
    {
        public OrangeContext() : base("OrangeDB")
        {
            Database.SetInitializer(new OrangeInitializer());
            this.Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Client>().HasKey(u => u.Id).ToTable("Clientes");
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Client> ClientsDao { get; set; }
        public virtual DbSet<ClientType> ClientTypesDao { get; set; }
        public virtual DbSet<ContactType> ContactTypesDao { get; set; }
        public virtual DbSet<Country> CountriesDao { get; set; }
        public virtual DbSet<DocumentType> DocumentTypesDao { get; set; }
        public virtual DbSet<Email> EmailsDao { get; set; }
        public virtual DbSet<IVAType> IVATypesDao { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumbersDao { get; set; }
        public virtual DbSet<State> StatesDao { get; set; }
        public virtual DbSet<Zone> ZonesDao { get; set; }
        public virtual DbSet<Branch> BranchesDao { get; set; }
    }
}
