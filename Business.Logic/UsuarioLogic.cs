using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {
        public UsuarioLogic()
        {
            UsuarioData = new UsuarioAdapter();
        }

        private UsuarioAdapter _UsuarioData;
        public UsuarioAdapter UsuarioData { get => _UsuarioData; set => _UsuarioData = value; }

        public Usuario Login(string usuario, string pass)
        {
            Usuario usr = UsuarioData.GetOne(usuario, pass);
            if (usr != null)
            {
                PasswordHasher pwd_hasher = new PasswordHasher();
                bool res = pwd_hasher.IsValid(pass, usr.Clave);

                if (res == true)
                {
                    return usr;
                }
            }

            return null;
        }
    }
}
