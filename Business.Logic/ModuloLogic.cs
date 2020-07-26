using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class ModuloLogic : BusinessLogic
    {
        public ModuloLogic()
        {
            ModuloData = new ModuloAdapter();
        }

        private ModuloAdapter _ModuloData;
        public ModuloAdapter ModuloData { get => _ModuloData; set => _ModuloData = value; }


        public Modulo GetOne(int id)
        {
            return ModuloData.GetOne(id);
        }

        public List<Modulo> GetAll()
        {
            return ModuloData.GetAll();
        }

        public void Save(Modulo obj)
        {
            ModuloData.Save(obj);
        }

        public void Delete(int id)
        {
            ModuloData.Delete(id);
        }
    }
}
