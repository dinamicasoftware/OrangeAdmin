using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public class NewClientVM : ObservableObject
    {

        private string _code;
        [Required(ErrorMessage = "El código es requerido")]
        //[EmailAddress(ErrorMessage = "Email Address is Invalid")] <-- el framework ya valida formato de emails
        public string Code
        {
            get { return _code; }
            set
            {
                _code = value;
                RaisePropertyChangedEvent(nameof(Code));
            }
        }
    }
}
