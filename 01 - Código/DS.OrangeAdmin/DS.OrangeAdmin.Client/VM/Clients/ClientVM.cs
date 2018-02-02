using System;

namespace DS.OrangeAdmin.Client.VM.Clients
{
    public class ClientVM : ObservableObject
    {
        public ClientVM() : base()
        {
        }

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                RaisePropertyChangedEvent(nameof(Id));
            }
        }

        private string _nombre;
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                RaisePropertyChangedEvent(nameof(Nombre));
            }
        }
        
        private string _code;
        public string Código
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
                RaisePropertyChangedEvent(nameof(Código));
            }
        }

        private string _alias;
        public string Alias
        {
            get
            {
                return _alias;
            }
            set
            {
                _alias = value;
                RaisePropertyChangedEvent(nameof(Alias));
            }
        }

        private string _documentNumber;
        public string NúmeroDeDocumento
        {
            get { return _documentNumber; }
            set
            {
                _documentNumber = value;
                RaisePropertyChangedEvent(nameof(NúmeroDeDocumento));
            }
        }

        private string _observation;
        public string Observaciones
        {
            get { return _observation; }
            set
            {
                _observation = value;
                RaisePropertyChangedEvent(nameof(Observaciones));
            }
        }

        private string _defaultEmail;
        public string DefaultEmail
        {
            get { return _defaultEmail; }
            set
            {
                _defaultEmail = value;
                RaisePropertyChangedEvent(nameof(DefaultEmail));
            }
        }
    }
}
