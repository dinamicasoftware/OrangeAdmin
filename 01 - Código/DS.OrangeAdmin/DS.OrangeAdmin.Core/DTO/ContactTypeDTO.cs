using System;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Core.Base;

namespace DS.OrangeAdmin.Core.DTO
{
    public class ContactTypeDTO  : BaseDTO
    {
        [DataMember]
        public string Description { get; set; }
    }
}
