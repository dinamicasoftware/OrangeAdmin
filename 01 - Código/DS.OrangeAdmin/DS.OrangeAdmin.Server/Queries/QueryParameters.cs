using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Shared.Expressions;
using DS.OrangeAdmin.Shared.Serializer;

namespace DS.OrangeAdmin.Server.Queries
{
    [DataContract]
    public class QueryParameters
    {
        static FixVisitor visitor;

        static QueryParameters()
        {
            visitor = new FixVisitor();
        }

        public static QueryParameters Serialize<T>(DS.OrangeAdmin.Core.Queries.QueryParameters<T> parameters)
        {
            QueryParameters retVal = new QueryParameters();
            retVal.Skip = parameters?.Skip ?? 0;
            retVal.Take = parameters?.Take ?? 0;
            retVal.Where = parameters?.Where?.Select(filter => JsonNetAdapter.Serialize(visitor.Visit(filter)))?.ToList();
            retVal.OrderBy = parameters?.OrderBy?.Select(order => JsonNetAdapter.Serialize(visitor.Visit(order)))?.ToList();
            retVal.Includes = parameters?.Includes?.Select(include => JsonNetAdapter.Serialize(visitor.Visit(include)))?.ToList();

            return retVal;
        }

        public static DS.OrangeAdmin.Core.Queries.QueryParameters<T> Deserialize<T>(QueryParameters parameters)
        {
            DS.OrangeAdmin.Core.Queries.QueryParameters<T> retVal = new Core.Queries.QueryParameters<T>();
            try
            {
                retVal.Skip = parameters?.Skip ?? 0;
                retVal.Take = parameters?.Take ?? 0;
                retVal.Where = parameters?.Where?.Select(filter => JsonNetAdapter.Deserialize<Expression<Func<T, bool>>>(filter))?.ToList();
                retVal.OrderBy = parameters?.OrderBy?.Select(order => JsonNetAdapter.Deserialize<Expression<Func<T, object>>>(order))?.ToList();
                retVal.Includes = parameters?.Includes?.Select(include => JsonNetAdapter.Deserialize<Expression<Func<T, object>>>(include))?.ToList();
            }
            catch (Exception ex)
            {

            }
            return retVal;
        }

        public QueryParameters()
        {
            this.Where = new List<string>();
            this.Includes = new List<string>();
            this.OrderBy = new List<string>();
        }

        [DataMember]
        public IList<string> Where { get; set; }
        [DataMember]
        public IList<string> Includes { get; set; }
        [DataMember]
        public IList<string> OrderBy { get; set; }
        [DataMember]
        public int Take { get; set; }
        [DataMember]
        public int Skip { get; set; }
    }
}