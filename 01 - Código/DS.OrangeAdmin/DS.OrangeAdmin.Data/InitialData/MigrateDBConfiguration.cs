using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Data.InitialData
{
    class MigrateDBConfiguration : System.Data.Entity.Migrations.DbMigrationsConfiguration<OrangeContext>
    {
        public MigrateDBConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = false;
        }
    }
}
