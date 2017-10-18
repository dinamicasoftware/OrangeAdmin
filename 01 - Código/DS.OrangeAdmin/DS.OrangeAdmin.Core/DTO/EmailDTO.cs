using System;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Core.Base;

namespace DS.OrangeAdmin.Core.DTO
{
    public class EmailDTO : BaseDTO
    {
        [DataMember]
        public string EmailAddress { get; set; }
        [DataMember]
        public ContactTypeDTO ContactType { get; set; }
        [DataMember]
        public bool Default { get; set; }
    }
}
