using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Core.Base;
using DS.OrangeAdmin.Core.Operations;

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

        public static OperationResult Validate(Client client)
        {
            if (string.IsNullOrEmpty(client?.Code))
            {
                return new OperationResult(false, "El código de cliente no puede ser vacío");
            }
            if (string.IsNullOrEmpty(client?.Name))
            {
                return new OperationResult(false, "El nombre de cliente no puede ser vacío");
            }

            var validateMails = MailsService.Validate(client.Emails);
            if (!validateMails.Successful)
            {
                return validateMails;
            }

            var validateBranches = BranchesService.Validate(client.Branches);
            if (!validateBranches.Successful)
            {
                return validateBranches;
            }

            return new OperationResult();
        }
    }
}
