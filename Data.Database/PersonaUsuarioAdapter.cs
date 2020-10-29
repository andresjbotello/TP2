using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class PersonaUsuarioAdapter : Adapter
    {
        private UsuarioAdapter _usuarioAdapter;

        private PersonaAdapter _personaAdapter;

        public PersonaUsuarioAdapter()
        {
            this.UsuarioAdapter = new UsuarioAdapter();
            this.PersonaAdapter = new PersonaAdapter();
        }

        public UsuarioAdapter UsuarioAdapter { get => _usuarioAdapter; set => _usuarioAdapter = value; }
        public PersonaAdapter PersonaAdapter { get => _personaAdapter; set => _personaAdapter = value; }
    }
}
