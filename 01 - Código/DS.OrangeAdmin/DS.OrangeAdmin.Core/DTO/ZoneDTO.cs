using System;
using System.Runtime.Serialization;
using DS.OrangeAdmin.Core.Base;

namespace DS.OrangeAdmin.Core.DTO
{
    public class ZoneDTO : BaseDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public CountryDTO Country { get; set; }
    }
}
