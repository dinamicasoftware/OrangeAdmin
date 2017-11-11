using System;
using System.Collections.Generic;
using DS.OrangeAdmin.Data.Base;

namespace DS.OrangeAdmin.Data.Entities
{
    public class Branch : BaseEntity
    {
        public Branch()
        {
            this.PhoneNumbers = new HashSet<PhoneNumber>();
        }

        public string Address { get; set; }
        public string City { get; set; }
        public string ZIP { get; set; }
        public Country Country { get; set; }
        public State State { get; set; } 
        public Zone Zone { get; set; } 
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}
