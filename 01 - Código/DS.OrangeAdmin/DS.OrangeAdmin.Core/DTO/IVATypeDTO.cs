using System;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Core.Base;

namespace DS.OrangeAdmin.Core.DTO
{
    public class IVATypeDTO : BaseDTO
    {
        [DataMember]
        public string Description { get; set; }
    }
}
