using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {
        public MateriaLogic()
        {
            MateriaData = new MateriaAdapter();
        }

        private MateriaAdapter _MateriaData;
        public MateriaAdapter MateriaData { get => _MateriaData; set => _MateriaData = value; }


        public Business.Entities.Materia GetOne(int id)
        {
            return MateriaData.GetOne(id);
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }

        public void Save(Business.Entities.Materia obj)
        {
            MateriaData.Save(obj);
        }

        public void Delete(int id)
        {
            MateriaData.Delete(id);
        }

    }
}
