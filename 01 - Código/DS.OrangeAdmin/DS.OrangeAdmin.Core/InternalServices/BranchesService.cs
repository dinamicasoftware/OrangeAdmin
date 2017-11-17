using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Core.Operations;

namespace DS.OrangeAdmin.Core.InternalServices
{
    public static class BranchesService
    {
        public static void PrepareToSave(ICollection<Branch> branches, DateTime now)
        {
            if (branches != null)
            {
                foreach (var item in branches)
                {
                    item.UpdatedAt = now;
                    if (item.Id == Guid.Empty)
                    {
                        item.CreatedAt = now;
                    }
                    PhoneNumbersService.PrepareToSave(item.PhoneNumbers, now);
                }
            }
        }

        public static OperationResult Validate(ICollection<Branch> branches)
        {
            if (branches != null)
            {
                foreach (var branch in branches)
                {
                    if (string.IsNullOrEmpty(branch?.Address))
                    {
                        return new OperationResult(false, "La dirección de la sucursal no puede ser vacía");
                    }
                }
            }

            return new OperationResult();
        }
    }
}
