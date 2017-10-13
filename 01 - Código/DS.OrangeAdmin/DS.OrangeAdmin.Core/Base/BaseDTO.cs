using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Core.Base
{
    public class BaseDTO
    {
        [DataMember]
        public int Id { get; set; }
    }
}
