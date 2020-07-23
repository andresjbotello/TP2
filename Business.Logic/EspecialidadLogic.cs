using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        public EspecialidadLogic()
        {
            EspecialidadData = new EspecialidadAdapter();
        }

        private EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData { get => _EspecialidadData; set => _EspecialidadData = value; }



        public Business.Entities.Especialidad GetOne(int id)
        {
            return EspecialidadData.GetOne(id);
        }

        public List<Especialidad> GetAll()
        {
            return EspecialidadData.GetAll();
        }

        public void Save(Business.Entities.Especialidad obj)
        {
            EspecialidadData.Save(obj);
        }

        public void Delete(int id)
        {
            EspecialidadData.Delete(id);
        }
    }
}
