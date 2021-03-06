﻿using System;
using System.Collections.Generic;
using DS.OrangeAdmin.Data.Base;
using DS.OrangeAdmin.Shared.Entities;

namespace DS.OrangeAdmin.Data.Entities
{
    public class Client : BaseEntity
    {
        public Client()
        {
            this.Emails = new HashSet<Email>();
            this.Branches = new HashSet<Branch>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public DocumentType DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public IVAType IVA { get; set; }
        public ClientType ClientType { get; set; }
        public Branch Address { get; set; }
        public ICollection<Branch> Branches { get; set; }
        public Email Email { get; set; }
        public ICollection<Email> Emails { get; set; }
        public string Observation { get; set; }
    }
}
