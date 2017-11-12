using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Core.InternalServices
{
    public static class ClientsService
    {
        public static void PrepareToSave(Client client)
        {
            DateTime now = DateTime.Now;
            client.UpdatedAt = now;

            if (client.Id == Guid.Empty)
            {
                client.CreatedAt = now;
                
            }

            MailsService.PrepareToSave(client.Emails, now);
            BranchesService.PrepareToSave(client.Branches, now);
        }
    }
}
