using System;
using System.Collections.Generic;
using System.Linq;
using DS.OrangeAdmin.Core.Base;
using System.Runtime.Serialization;

namespace DS.OrangeAdmin.Core.DTO
{
    public class BranchDTO : BaseDTO
    {
        public BranchDTO()
        {
            this.PhoneNumbers = new HashSet<PhoneNumberDTO>();
        }

        [DataMember]
        public string Address { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string ZIP { get; set; }
        [DataMember]
        public CountryDTO Country { get; set; }
        [DataMember]
        public StateDTO State { get; set; }
        [DataMember]
        public ZoneDTO Zone { get; set; }
        [DataMember]
        public virtual ICollection<PhoneNumberDTO> PhoneNumbers { get; set; }
    }
}
