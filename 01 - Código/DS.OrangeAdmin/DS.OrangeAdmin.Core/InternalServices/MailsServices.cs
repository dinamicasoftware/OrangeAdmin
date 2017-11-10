using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Core.InternalServices
{
    public static class MailsServices
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
    }
}
