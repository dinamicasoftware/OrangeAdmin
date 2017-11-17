using System;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Core.Operations
{
    public delegate Task<OperationResult> DBOperation<T>(T param);
}
