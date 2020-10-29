using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        public PersonaLogic()
        {
            PersonaData = new PersonaAdapter();
        }

        private PersonaAdapter _PersonaData;
        public PersonaAdapter PersonaData { get => _PersonaData; set => _PersonaData = value; }


        public Persona GetOne(int id) 
        {
            return PersonaData.GetOne(id);
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public List<Persona> GetAll(Persona.TipoPersonas tipoPersonas)
        {
            return PersonaData.GetAll(tipoPersonas);
        }

        public Persona Save(Persona obj, bool nuevaClave)
        {

            obj = this.VerificarClave(obj, nuevaClave);

            return PersonaData.Save(obj);
        }

        private Persona VerificarClave(Persona p, bool nuevaClave)
        {

            if (nuevaClave)
            {
                PasswordHasher pwd_hasher = new PasswordHasher();

                string pwd_hashed = pwd_hasher.Generate(p.Usuario.Clave);

                p.Usuario.Clave = pwd_hashed;
            }

            return p;
        }

    }
}
