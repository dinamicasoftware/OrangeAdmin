using System;
using System.Runtime.Serialization;

namespace DS.OrangeAdmin.Core.Base
{
    public class BaseDTO
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public DateTime CreatedAt { get; set; }
        [DataMember]
        public DateTime UpdatedAt { get; set; }
        [DataMember]
        public bool Deleted { get; set; }
    }
}
