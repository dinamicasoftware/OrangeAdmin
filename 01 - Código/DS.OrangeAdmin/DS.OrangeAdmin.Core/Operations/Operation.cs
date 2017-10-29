using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Core.Operations
{
    public delegate Task<OperationResult> Operation<T>(T param);
}
