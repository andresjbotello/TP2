using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloUsuarioLogic : BusinessLogic
    {
        public ModuloUsuarioLogic()
        {
            ModuloUsuarioData = new ModuloUsuarioAdapter();
        }

        private ModuloUsuarioAdapter moduloUsuarioData;

        public ModuloUsuarioAdapter ModuloUsuarioData { get => moduloUsuarioData; set => moduloUsuarioData = value; }

        public ModuloUsuario GetOne(int id)
        {
            return ModuloUsuarioData.GetOne(id);
        }

        public List<ModuloUsuario> GetAll()
        {
            return ModuloUsuarioData.GetAll();
        }

        public void Save(ModuloUsuario modUsr)
        {
            ModuloUsuarioData.Save(modUsr);
        }

        public void Delete(int id)
        {
            ModuloUsuarioData.Delete(id);
        }

    }
}
