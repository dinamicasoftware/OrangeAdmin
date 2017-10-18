using System;
using System.Runtime.Serialization;

namespace DS.OrangeAdmin.Core.Base
{
    public class BaseDTO
    {
        [DataMember]
        public Guid Id { get; set; }
    }
}
