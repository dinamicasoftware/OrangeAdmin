using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Core.Operations
{
    [DataContract]
    public class OperationResult
    {
        public OperationResult()
        {
            this.Successful = true;
        }

        public OperationResult(bool successful, params string[] messages)
        {
            this.Successful = successful;
            this.Messages = messages;
        }

        [DataMember]
        public bool Successful { get; set; }
        [DataMember]
        public IEnumerable<string> Messages { get; set; }
    }

    [DataContract]
    public class OperationResult<T> : OperationResult
    {
        public OperationResult(T result)
        {
            this.Successful = true;
            this.Result = result;
        }

        public OperationResult(bool successful, params string[] messages) : base(successful, messages)
        {

        }

        [DataMember]
        public T Result { get; set; }
    }
}
