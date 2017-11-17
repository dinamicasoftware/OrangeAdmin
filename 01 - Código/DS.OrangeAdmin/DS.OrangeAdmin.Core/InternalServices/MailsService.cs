using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Core.Operations;

namespace DS.OrangeAdmin.Core.InternalServices
{
    public static class MailsService
    {
        public static void PrepareToSave(ICollection<Email> emails, DateTime now)
        {
            if (emails != null)
            {
                foreach (var item in emails)
                {
                    item.UpdatedAt = now;
                    if (item.Id == Guid.Empty)
                    {
                        item.CreatedAt = now;
                    }
                }
            }
        }

        public static OperationResult Validate(ICollection<Email> emails)
        {
            if (emails != null)
            {
                foreach (var email in emails)
                {
                    if (string.IsNullOrEmpty(email?.EmailAddress))
                    {
                        return new OperationResult(false, "La dirección de email no puede ser vacía");
                    }
                }
            }

            return new OperationResult();
        }
    }
}
