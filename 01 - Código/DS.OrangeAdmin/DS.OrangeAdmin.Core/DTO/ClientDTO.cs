using System;
using System.Collections.Generic;
using System.Data.Services.Common;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Core.Base;
using DS.OrangeAdmin.Data.Entities;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.Core.DTO
{
    [DataServiceKey("Id"), DataContract]
    public class ClientDTO : BaseDTO, IClient
    {
        public ClientDTO()
        {

        }

        internal ClientDTO(Client client)
        {
            this.Alias = client.Alias;
            //this.ClientType = Map(client.ClientType),
            this.Code = client.Code;
            this.CreatedAt = client.CreatedAt;
            this.Deleted = client.Deleted;
            this.DocumentNumber = client.DocumentNumber;
            //this.DocumentType = Map(client.DocumentType);
            //this.Emails = Map(client.Emails);
            this.Id = client.Id;
            //this.IVA = Map(client.IVA);
            this.Name = client.Name;
            this.Observation = client.Observation;
            this.UpdatedAt = client.UpdatedAt;
        }

        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Alias { get; set; }
        [DataMember]
        public DocumentTypeDTO DocumentType { get; set; }
        [DataMember]
        public string DocumentNumber { get; set; }
        [DataMember]
        public IVATypeDTO IVA { get; set; }
        [DataMember]
        public ClientTypeDTO ClientType { get; set; }
        [DataMember]
        public IList<EmailDTO> Emails { get; set; }
        [DataMember]
        public string Observation { get; set; }
    }
}
