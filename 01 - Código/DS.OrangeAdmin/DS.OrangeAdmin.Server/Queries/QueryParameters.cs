using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DS.OrangeAdmin.Server.Queries
{
    public class QueryParameters
    {
        public QueryParameters()
        {
            this.Filtros = new List<string>();
        }

        public IList<string> Filtros { get; set; }
        public int Take { get; set; }
    }
}