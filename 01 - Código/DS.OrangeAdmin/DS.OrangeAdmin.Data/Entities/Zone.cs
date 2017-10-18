using System;
using DS.OrangeAdmin.Data.Base;

namespace DS.OrangeAdmin.Data.Entities
{
    public class Zone : BaseEntity
    {
        public string Name { get; set; }
        public Country Country { get; set; }
    }
}
