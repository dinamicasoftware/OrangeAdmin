using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.Core.Queries
{
    public class QueryParameters<T>
    {
        public QueryParameters()
        {
            this.Filtros = new List<Expression<Func<T, bool>>>();
        }

        public IList<Expression<Func<T, bool>>> Filtros { get; set; }
        public int Take { get; set; }
    }
}
