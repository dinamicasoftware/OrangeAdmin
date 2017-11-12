using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;

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
    }
}
