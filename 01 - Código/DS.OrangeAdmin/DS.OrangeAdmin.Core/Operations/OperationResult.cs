using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Core.Operations
{
    public class OperationResult
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Messages { get; set; }
    }
}
