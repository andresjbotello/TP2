using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Desktop.Report
{
    public class reportesPersonasObject
    {

        int _id;

        string _usuario;

        string _nombre;

        string _apellido;

        string _direccion;

        string _email;

        string _telefono;

        DateTime _fechaNacimiento;

        int _legajo;

        string _tipoPersona;

        string _plan;

        string _habilitado;

        public reportesPersonasObject(Persona p)
        {
            this.Id = p.ID;
            this.Usuario = p.Usuario.NombreUsuario;
            this.Nombre = p.Nombre;
            this.Apellido = p.Apellido;
            this.Direccion = p.Direccion;
            this.Email = p.Email;
            this.Telefono = p.Telefono;
            this.FechaNacimiento = p.FechaNacimiento;
            this.Legajo = p.Legajo;
            this.TipoPersona = p.TipoPersona.ToString();
            this.Plan = p.Plan.Descripcion;
            this.Habilitado = (p.Usuario.Habilitado) ? "Si" : "No";
        }

        public int Id { get => _id; set => _id = value; }
        public string Usuario { get => _usuario; set => _usuario = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellido { get => _apellido; set => _apellido = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public DateTime FechaNacimiento { get => _fechaNacimiento; set => _fechaNacimiento = value; }
        public int Legajo { get => _legajo; set => _legajo = value; }
        public string TipoPersona { get => _tipoPersona; set => _tipoPersona = value; }
        public string Plan { get => _plan; set => _plan = value; }
        public string Habilitado { get => _habilitado; set => _habilitado = value; }
        
    }
        
}
