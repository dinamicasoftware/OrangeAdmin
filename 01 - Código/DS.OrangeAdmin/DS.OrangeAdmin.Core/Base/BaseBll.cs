using System;
using DS.OrangeAdmin.Core.Operations;
using System.Data.Entity.Infrastructure;

namespace DS.OrangeAdmin.Core.Base
{
    public abstract class BaseBll
    {
        protected OperationResult safeOperation<T>(Operation<T> operation, T param)
        {
            OperationResult operationResult;
            bool retryOperation;
            int retryCounter = 0;

            do
            {
                try
                {
                    operationResult = operation(param);
                    retryOperation = false;
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    operationResult = new OperationResult(false, ex.ToString());
                    if (retryCounter < 3)
                    {
                        retryOperation = true;
                        retryCounter++;
                    }
                    else
                    {
                        retryOperation = false;
                    }
                }
                catch (Exception ex)
                {
                    operationResult = new OperationResult(false, ex.ToString());
                    retryOperation = false;
                }
            } while (retryOperation);

            return operationResult;
        }
    }
}
