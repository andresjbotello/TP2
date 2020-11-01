using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Especialidad : BusinessEntity
    {
        public Especialidad()
        {
            //sin nada
        }
        public Especialidad(int id, string desc)
        {
            ID = id;
            Descripcion = desc;
        }


        private string _Descripcion;
        public string Descripcion { get => _Descripcion; set => _Descripcion = value; }
    }
}
