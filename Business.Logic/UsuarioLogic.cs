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
            UsuarioData.Save(obj);
        }

        public void Delete(int id)
        {
            UsuarioData.Delete(id);
        }

        public Usuario Login(string usuario, string pass)
        {
            return UsuarioData.GetOne(usuario, pass);
        }

    }
}
