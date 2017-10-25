using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Shared.Entities
{
    public interface IClient
    {
        Guid Id { get; set; }
        string Code { get; set; }
        string Name { get; set; }
        string Alias { get; set; }
        //DocumentType DocumentType { get; set; }
        string DocumentNumber { get; set; }
        //IVAType IVA { get; set; }
        //ClientType ClientType { get; set; }
        //IList<Email> Emails { get; set; }
        string Observation { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
        bool Deleted { get; set; }
    }
}
