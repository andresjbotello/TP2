using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using Data.Database;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        private Persona _personaActual;
        public Persona PersonaActual { get => _personaActual; set => _personaActual = value; }

        public PersonaDesktop()
        {
            InitializeComponent();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.dtFechaNacimiento.Value = this.PersonaActual.FechaNacimiento;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtTipoPersona.Text = this.PersonaActual.GetIDTipoPersona().ToString();
            this.txtIDPlan.Text = this.PersonaActual.IDPlan.ToString();

            string mf = Convert.ToString(Modo);
            if (mf == "Alta" || mf == "Modificacion")
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if(mf == "Baja")
            {
                this.btnAceptar.Text = "Eliminar";
            }
            else if (mf == "Consulta")
            {
                this.btnAceptar.Text = "Aceptar";
            }


        }

        public override void MapearADatos()
        {
            string mf = Convert.ToString(Modo);
            if (mf == "Alta")
            {
                Persona p = new Persona();
                PersonaActual = p;
                PersonaActual.State = BusinessEntity.States.New; 

                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Nombre =  this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.FechaNacimiento = this.dtFechaNacimiento.Value;
                PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                PersonaActual.SetTipoPersonaById(int.Parse(this.txtTipoPersona.Text));
                PersonaActual.IDPlan = int.Parse(this.txtIDPlan.Text);

            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = PersonaActual.ID.ToString();
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Nombre = this.txtNombre.Text;
                PersonaActual.Apellido = this.txtApellido.Text;
                PersonaActual.Email = this.txtEmail.Text;
                PersonaActual.Direccion = this.txtDireccion.Text;
                PersonaActual.Telefono = this.txtTelefono.Text;
                PersonaActual.FechaNacimiento = this.dtFechaNacimiento.Value;
                PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
                PersonaActual.SetTipoPersonaById(int.Parse(this.txtTipoPersona.Text));
                PersonaActual.IDPlan = int.Parse(this.txtIDPlan.Text);
                PersonaActual.State = BusinessEntity.States.Modified;
            }

            else if(mf == "Baja")
            {
                PersonaActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            this.Close();
        }

    }
}
