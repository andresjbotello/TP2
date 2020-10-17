using Business.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Logic
{
    public class Validaciones
    {
        static public bool Permisos(Persona P)
        {
            bool e;
            if (P.TipoPersona == Business.Entities.Persona.TipoPersonas.Alumno)
            {
                e = false;
            }
            else
            {
                e = true;
            }
            return e;
        }
    }

}
