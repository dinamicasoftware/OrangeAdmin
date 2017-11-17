using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.Operations;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Core.InternalServices
{
    public static class PhoneNumbersService
    {
        public static void PrepareToSave(ICollection<PhoneNumber> phones, DateTime now)
        {
            if (phones != null)
            {
                foreach (var item in phones)
                {
                    item.UpdatedAt = now;
                    if (item.Id == Guid.Empty)
                    {
                        item.CreatedAt = now;
                    }
                }
            }
        }

        public static OperationResult Validate(ICollection<PhoneNumber> phones)
        {
            if (phones != null)
            {
                foreach (var phone in phones)
                {
                    if (string.IsNullOrEmpty(phone?.Number))
                    {
                        return new OperationResult(false, "El número de teléfono no puede ser vacío");
                    }
                }
            }

            return new OperationResult();
        }
    }
}
