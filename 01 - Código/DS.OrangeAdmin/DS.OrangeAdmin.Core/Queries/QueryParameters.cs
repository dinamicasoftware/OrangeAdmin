using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DS.OrangeAdmin.Core.Queries
{
    public class QueryParameters<T>
    {
        public QueryParameters()
        {
            this.Where = new List<Expression<Func<T, bool>>>();
            this.Includes = new List<Expression<Func<T, object>>>();
            this.OrderBy = new List<Expression<Func<T, object>>>();
        }

        public IList<Expression<Func<T, bool>>> Where { get; set; }
        public IList<Expression<Func<T, object>>> Includes { get; set; }
        public IList<Expression<Func<T, object>>> OrderBy { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
    }
}
