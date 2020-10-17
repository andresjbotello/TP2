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


        public Business.Entities.Usuario GetOne(int id) 
        {
            return UsuarioData.GetOne(id);
        }

        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public void Save(Business.Entities.Usuario obj)
        {
            PasswordHasher pwd_hasher = new PasswordHasher();
            string pwd_hashed = pwd_hasher.Generate(obj.Clave);
            obj.Clave = pwd_hashed;
            UsuarioData.Save(obj);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public Usuario Login(string usuario, string pass)
        {
            Usuario usr = UsuarioData.GetOne(usuario, pass);
            PasswordHasher pwd_hasher = new PasswordHasher();
            bool res = pwd_hasher.IsValid(pass, usr.Clave);
            if (res == true)
            {
                return usr;
            }
            else
            {
                return null;
            }
        }

        public Usuario GetOneByPersona(Persona p)
        {
            return UsuarioData.GetOneByPersonaId(p.ID);
        }
    }
}
