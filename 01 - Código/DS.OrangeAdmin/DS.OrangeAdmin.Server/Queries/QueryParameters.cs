using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DS.OrangeAdmin.Server.Queries
{
    [DataContract]
    public class QueryParameters
    {
        public QueryParameters()
        {
            this.Filtros = new List<string>();
        }

        [DataMember]
        public IList<string> Filtros { get; set; }
        [DataMember]
        public int Take { get; set; }
    }
}