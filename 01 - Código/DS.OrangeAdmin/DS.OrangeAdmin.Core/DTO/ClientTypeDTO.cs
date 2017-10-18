using System;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Core.Base;

namespace DS.OrangeAdmin.Core.DTO
{
    public class ClientTypeDTO : BaseDTO
    {
        [DataMember]
        public string Name { get; set; }
    }
}
