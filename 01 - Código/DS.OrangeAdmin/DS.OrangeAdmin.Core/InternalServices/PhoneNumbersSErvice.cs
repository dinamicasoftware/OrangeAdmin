using DS.OrangeAdmin.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
