using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        public DocenteCursoLogic()
        {
            DocenteCursoData = new DocenteCursoAdapter();
        }

        private DocenteCursoAdapter _DocenteCursoData;
        public DocenteCursoAdapter DocenteCursoData { get => _DocenteCursoData; set => _DocenteCursoData = value; }


        public DocenteCurso GetOne(int id) 
        {
            return DocenteCursoData.GetOne(id);
        }

        public List<DocenteCurso> GetAll()
        {
            return DocenteCursoData.GetAll();
        }

        public void Save(DocenteCurso obj)
        {
            DocenteCursoData.Save(obj);
        }

        public void Delete(int id)
        {
            DocenteCursoData.Delete(id);
        }

    }
}
