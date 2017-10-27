using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Core.Operations
{
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

        public bool Successful { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }

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

        public T Result { get; set; }
    }
}
