using DS.OrangeAdmin.Core.Base;
using System;
using System.Data.Services.Common;
using System.Runtime.Serialization;

namespace DS.OrangeAdmin.Core.DTO
{
    [DataServiceKey("Id")]
    [DataContract]
    public class ClientDTO : BaseDTO
    {
        [DataMember]
        public string Codigo { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string NombreFantasia { get; set; }
        [DataMember]
        public string Direccion { get; set; }
        [DataMember]
        public string Localidad { get; set; }
        [DataMember]
        public string CodigoPostal { get; set; }
    }
}
