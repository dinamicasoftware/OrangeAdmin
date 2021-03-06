﻿using System;
using DS.OrangeAdmin.Data.Base;

namespace DS.OrangeAdmin.Data.Entities
{
    public class PhoneNumber : BaseEntity
    {
        public string Number { get; set; }
        public ContactType ContactType { get; set; }
        public bool Default { get; set; }
    }
}
