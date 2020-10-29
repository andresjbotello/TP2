using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {
        private string _Apellido;
        private string _Direccion;
        private string _Email;
        private DateTime _FechaNacimiento;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Telefono;
        private TipoPersonas _TipoPersona;
        private Usuario _usuario;

        public Persona()
        {
            Usuario = new Usuario();
        }

        public Persona(int id, string apellido, string direccion, string email, DateTime fechaNacimiento, int idPlan, int legajo, string nombre, string telefono, int tipoPersona, Usuario usuario)
        {
            this.ID = id;
            this.Apellido = apellido;
            this.Direccion = direccion;
            this.Email = email;
            this.FechaNacimiento = fechaNacimiento;
            this.IDPlan = idPlan;
            this.Legajo = legajo;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.SetTipoPersonaById(tipoPersona);
            this.Usuario = usuario;
        }

        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Direccion { get => _Direccion; set => _Direccion = value; }
        public string Email { get => _Email; set => _Email = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public int IDPlan { get => _IDPlan; set => _IDPlan = value; }
        public int Legajo { get => _Legajo; set => _Legajo = value; }
        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Telefono { get => _Telefono; set => _Telefono = value; }
        public TipoPersonas TipoPersona { get => _TipoPersona; set => _TipoPersona = value; }
        public Usuario Usuario { get => _usuario; set => _usuario = value; }

        public enum TipoPersonas
        {
            Alumno, Profesor, Admin
        }

        public void SetTipoPersonaById(int id)
        {
            switch (id)
            {
                case (int) TipoPersonas.Alumno:
                    this.TipoPersona = TipoPersonas.Alumno;
                    break;
                case (int) TipoPersonas.Profesor:
                    this.TipoPersona = TipoPersonas.Profesor;
                    break;
                case (int) TipoPersonas.Admin:
                    this.TipoPersona = TipoPersonas.Admin;
                    break;
                default:
                    throw new Exception("No existe el tipo persona especificado: " + id.ToString());
            }
        }

        public int GetIDTipoPersona()
        {
            switch (this.TipoPersona)
            {
                case TipoPersonas.Alumno:
                    return 0;
                case TipoPersonas.Profesor:
                    return 1;
                case TipoPersonas.Admin:
                    return 2;
                default:
                    throw new Exception("No existe el tipo persona especificado: " + this.TipoPersona.ToString());
            }
        }
    }
}
