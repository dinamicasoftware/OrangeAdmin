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
                Address = Map(client.Address),
                Alias = client.Alias,
                ClientType = Map(client.ClientType),
                Code = client.Code,
                CreatedAt = client.CreatedAt,
                Deleted = client.Deleted,
                DocumentNumber = client.DocumentNumber,
                DocumentType = Map(client.DocumentType),
                Email = Map(client.Email),
                Emails = Map(client.Emails),
                Branches = Map(client.Branches),
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

        public static Email Map(EmailDTO email)
        {
            if (email == null)
                return null;

            return new Email()
            {
                ContactType = Map(email.ContactType),
                CreatedAt = email.CreatedAt,
                Default = email.Default,
                Deleted = email.Deleted,
                EmailAddress = email.EmailAddress,
                Id = email.Id,
                UpdatedAt = email.UpdatedAt
            };
        }

        public static IList<Email> Map(IList<EmailDTO> emails)
        {
            if (emails == null)
                return null;

            return emails.Select(email => Map(email)).ToList();
        }

        public static IList<PhoneNumber> Map(ICollection<PhoneNumberDTO> phones)
        {
            if (phones == null)
                return null;

            return phones.Select(phone => new PhoneNumber()
            {
                ContactType = Map(phone.ContactType),
                CreatedAt = phone.CreatedAt,
                Default = phone.Default,
                Deleted = phone.Deleted,
                Id = phone.Id,
                Number = phone.Number,
                UpdatedAt = phone.UpdatedAt
            }).ToList();
        }

        public static Branch Map(BranchDTO branch)
        {
            if (branch == null)
                return null;

            return new Branch()
            {
                Address = branch.Address,
                City = branch.City,
                Country = Map(branch.Country),
                CreatedAt = branch.CreatedAt,
                Deleted = branch.Deleted,
                Id = branch.Id,
                PhoneNumbers = Map(branch.PhoneNumbers),
                State = Map(branch.State),
                UpdatedAt = branch.UpdatedAt,
                ZIP = branch.ZIP,
                Zone = Map(branch.Zone)
            };
        }

        public static IList<Branch> Map(IList<BranchDTO> branches)
        {
            if (branches == null)
                return null;

            return branches.Select(branch => Map(branch)).ToList();
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

        public static Country Map(CountryDTO country)
        {
            if (country == null)
                return null;

            return new Country()
            {
                CreatedAt = country.CreatedAt,
                Deleted = country.Deleted,
                Id = country.Id,
                Name = country.Name,
                UpdatedAt = country.UpdatedAt
            };
        }

        public static State Map(StateDTO state)
        {
            if (state == null)
                return null;

            return new State()
            {
                Country = Map(state.Country),
                CreatedAt = state.CreatedAt,
                Deleted = state.Deleted,
                Id = state.Id,
                Name = state.Name,
                UpdatedAt = state.UpdatedAt
            };
        }

        public static Zone Map(ZoneDTO zone)
        {
            if (zone == null)
                return null;

            return new Zone()
            {
                Country = Map(zone.Country),
                CreatedAt = zone.CreatedAt,
                Deleted = zone.Deleted,
                Id = zone.Id,
                Name = zone.Name,
                UpdatedAt = zone.UpdatedAt
            };
        }
    }
}
