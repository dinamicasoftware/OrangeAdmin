using DS.OrangeAdmin.Core.Base;
using System;
using System.Data.Services.Common;
using System.Runtime.Serialization;

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
    }
}
