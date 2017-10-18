using System;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Core.Base;

namespace DS.OrangeAdmin.Core.DTO
{
    public class PhoneNumberDTO : BaseDTO
    {
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public ContactTypeDTO ContactType { get; set; }
        [DataMember]
        public bool Default { get; set; }
    }
}
