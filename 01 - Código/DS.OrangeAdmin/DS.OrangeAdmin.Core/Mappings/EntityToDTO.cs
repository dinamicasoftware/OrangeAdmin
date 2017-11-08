using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Data.Entities;

namespace DS.OrangeAdmin.Core.Mappings
{
    static class EntityToDTO
    {
        public static ClientDTO Map(Client client)
        {
            if (client == null)
                return null;

            return  new ClientDTO()
            {
                Alias = client.Alias,
                ClientType = Map(client.ClientType),
                Code = client.Code,
                CreatedAt = client.CreatedAt,
                Deleted = client.Deleted,
                DocumentNumber = client.DocumentNumber,
                DocumentType = Map(client.DocumentType),
                Emails = Map(client.Emails),
                Id = client.Id,
                IVA = Map(client.IVA),
                Name = client.Name,
                Observation = client.Observation,
                UpdatedAt = client.UpdatedAt
            };
        }

        public static ClientTypeDTO Map(ClientType clientType)
        {
            if (clientType == null)
                return null;

            return new ClientTypeDTO()
            {
                CreatedAt = clientType.CreatedAt,
                Deleted = clientType.Deleted,
                Id = clientType.Id,
                Name = clientType.Name,
                UpdatedAt = clientType.UpdatedAt
            };
        }

        public static DocumentTypeDTO Map(DocumentType documentType)
        {
            if (documentType == null)
                return null;

            return new DocumentTypeDTO()
            {
                CreatedAt = documentType.CreatedAt,
                Deleted = documentType.Deleted,
                Id = documentType.Id,
                Name = documentType.Name,
                UpdatedAt = documentType.UpdatedAt
            };
        }

        public static IList<EmailDTO> Map(ICollection<Email> emails)
        {
            if (emails == null)
                return null;

            return emails.Select(email => new EmailDTO()
            {
                ContactType = Map(email.ContactType),
                CreatedAt = email.CreatedAt,
                Default = email.Default,
                Deleted = email.Deleted,
                EmailAddress = email.EmailAddress,
                Id = email.Id,
                UpdatedAt = email.UpdatedAt
            }).ToList();
        }

        public static ContactTypeDTO Map(ContactType contactType)
        {
            if (contactType == null)
                return null;

            return new ContactTypeDTO()
            {
                CreatedAt = contactType.CreatedAt,
                Deleted = contactType.Deleted,
                Description = contactType.Description,
                Id = contactType.Id,
                UpdatedAt = contactType.UpdatedAt
            };
        }

        public static IVATypeDTO Map(IVAType ivaType)
        {
            if (ivaType == null)
                return null;

            return new IVATypeDTO()
            {
                CreatedAt = ivaType.CreatedAt,
                Deleted = ivaType.Deleted,
                Description = ivaType.Description,
                Id = ivaType.Id,
                UpdatedAt = ivaType.UpdatedAt
            };
        }
    }
}
