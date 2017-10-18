using System;
using DS.OrangeAdmin.Data.Base;

namespace DS.OrangeAdmin.Data.Entities
{
    public class Email : BaseEntity
    {
        public string EmailAddress { get; set; }
        public ContactType ContactType { get; set; }
        public bool Default { get; set; }
    }
}
