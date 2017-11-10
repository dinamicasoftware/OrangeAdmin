using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Core.InternalServices
{
    public static class ClientsServices
    {
        public static void PrepareToSave(Client client)
        {
            DateTime now = DateTime.Now;
            client.UpdatedAt = now;

            if (client.Id == Guid.Empty)
            {
                client.CreatedAt = now;
                
            }

            MailsServices.PrepareToSave(client.Emails, now);
        }
    }
}
