using System;
using System.Collections.Generic;
using DS.OrangeAdmin.Core.DTO;
using DS.OrangeAdmin.Data.Entities;
using System.Linq;

namespace DS.OrangeAdmin.Core.Mappings
{
    static class DTOToEntity
    {
        public static Client Map(ClientDTO client)
        {
            if (client == null)
                return null;

            return new Client()
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

        public static ClientType Map(ClientTypeDTO clientType)
        {
            if (clientType == null)
                return null;

            return new ClientType()
            {
                CreatedAt = clientType.CreatedAt,
                Deleted = clientType.Deleted,
                Id = clientType.Id,
                Name = clientType.Name,
                UpdatedAt = clientType.UpdatedAt
            };
        }

        public static DocumentType Map(DocumentTypeDTO documentType)
        {
            if (documentType == null)
                return null;

            return new DocumentType()
            {
                CreatedAt = documentType.CreatedAt,
                Deleted = documentType.Deleted,
                Id = documentType.Id,
                Name = documentType.Name,
                UpdatedAt = documentType.UpdatedAt
            };
        }

        public static IList<Email> Map(IList<EmailDTO> emails)
        {
            if (emails == null)
                return null;

            return emails.Select(email => new Email()
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

        public static ContactType Map(ContactTypeDTO contactType)
        {
            if (contactType == null)
                return null;

            return new ContactType()
            {
                CreatedAt = contactType.CreatedAt,
                Deleted = contactType.Deleted,
                Description = contactType.Description,
                Id = contactType.Id,
                UpdatedAt = contactType.UpdatedAt
            };
        }

        public static IVAType Map(IVATypeDTO ivaType)
        {
            if (ivaType == null)
                return null;

            return new IVAType()
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
