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
    public class ClientDTO : BaseDTO
    {
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
        public IList<BranchDTO> Branches { get; set; }
        [DataMember]
        public string Observation { get; set; }
    }
}
