using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario: BusinessEntity
    {
        private string _NombreUsuario;
        private string _Clave;
        private string _Nombre;
        private string _Apellido;
        private string _Email;
        private bool _Habilitado;
        private int _idPersona;

        public Usuario()
        {

        }

        public Usuario(int idUsuario, string nombreUsuario, string clave, string nombre, string apellido, string email, bool habilitado, int idPersona)
        {
            this.ID = idUsuario;
            this.NombreUsuario = nombreUsuario;
            this.Clave = clave;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Email = email;
            this.Habilitado = habilitado;
            this.IdPersona = idPersona;
        }

        public string NombreUsuario { get => _NombreUsuario; set => _NombreUsuario = value; }
        public string Clave { get => _Clave; set => _Clave = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Email { get => _Email; set => _Email = value; }
        public bool Habilitado { get => _Habilitado; set => _Habilitado = value; }
        public int IdPersona { get => _idPersona; set => _idPersona = value; }
    }
}
