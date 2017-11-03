using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Client.Util
{
    public class Customer
    {
        public string Nombre { get; set; }
        public string Apelido { get; set; }
        public string Email { get; set; }

        public static List<Customer> Customers()
        {
            return new List<Customer>
            {
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" },
                new Customer { Apelido = "Meabe", Nombre = "Armando", Email = "armando@meabe.com" }
            };
        }
    }
}
