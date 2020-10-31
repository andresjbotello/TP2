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
using System.Runtime.InteropServices;

namespace UI.Desktop
{
    public partial class PersonaDesktop : ApplicationForm
    {
        private bool _cambiaClave = true;

        private Persona _personaActual;
        public Persona PersonaActual { get => _personaActual; set => _personaActual = value; }


        public PersonaDesktop()
        {
            InitializeComponent();
            FillComboBoxs();
        }

        public PersonaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
            if (Modo.Equals(ModoForm.Alta))
            {
                this.lkModificarClave.Visible = false;
            }
        }

        public PersonaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
            if (!Modo.Equals(ModoForm.Alta) && !Modo.Equals(ModoForm.Baja))
            {
                this._cambiaClave = false;
                this.ChequearVisibilidadCamposClave();
            }
            else
            {
                this.lkModificarClave.Visible = false;
            }
           
            MapearDeDatos();
        }

        private void ChequearVisibilidadCamposClave()
        {
            this.lblClave.Visible = this._cambiaClave;
            this.txtClave.Visible = this._cambiaClave;
            this.lblConfirmarClave.Visible = this._cambiaClave;
            this.txtConfirmarClave.Visible = this._cambiaClave;

            if (this._cambiaClave)
            {
                this.txtClave.Text = "";
                this.txtConfirmarClave.Text = "";
            }
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
            this.cmbBoxTiposPersona.SelectedIndex = SeleccionarTipoPersona();
            this.cmbBoxPlanes.SelectedIndex = SeleccionarPlan();

            this.txtNombreUsuario.Text = this.PersonaActual.Usuario.NombreUsuario;
            this.chkHabilitado.Checked = this.PersonaActual.Usuario.Habilitado;
            this.txtClave.Text = "";
            this.txtConfirmarClave.Text = "";

            string mf = Convert.ToString(Modo);
            if (mf == "Alta" || mf == "Modificacion")
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if(mf == "Baja")
            {
                this.btnAceptar.Text = "Eliminar";
                #region Oculto
                this.txtID.Enabled = false;
                this.txtNombre.Enabled = false;
                this.txtApellido.Enabled = false;
                this.txtEmail.Enabled = false;
                this.txtDireccion.Enabled = false;
                this.txtTelefono.Enabled = false;
                this.dtFechaNacimiento.Enabled = false;
                this.txtLegajo.Enabled = false;
                this.cmbBoxTiposPersona.Enabled = false;
                this.cmbBoxPlanes.Enabled = false;

                this.txtNombreUsuario.Enabled = false;
                this.chkHabilitado.Enabled = false;
                this.txtClave.Enabled = false;
                this.txtConfirmarClave.Enabled = false;
                #endregion

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
                this.SetPersonaAttributesFromForm();

            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = PersonaActual.ID.ToString();
                this.SetPersonaAttributesFromForm();
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
            pl.Save(PersonaActual, this._cambiaClave);
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

        private void FillComboBoxs()
        {
            this.FillComboBoxPlan();
            this.FillComboBoxTipoPersona();
        }

        private void FillComboBoxPlan()
        {
            PlanLogic pl = new PlanLogic();

            List<Plan> planes = pl.GetAll();

            cmbBoxPlanes.DisplayMember = "Text";
            cmbBoxPlanes.ValueMember = "Value";

            foreach (Plan e in planes)
            {
                cmbBoxPlanes.Items.Add(new
                {
                    Text = e.Descripcion,
                    Value = e.ID.ToString()
                }
                );
            }
        }

        private void FillComboBoxTipoPersona()
        {
            cmbBoxTiposPersona.DisplayMember = "Text";
            cmbBoxTiposPersona.ValueMember = "Value";

            for (int tipoCargo = (int)Persona.TipoPersonas.Alumno; tipoCargo <= (int)Persona.TipoPersonas.Admin; tipoCargo++)
            {
                String texto = "";

                switch (tipoCargo)
                {
                    case (int)Persona.TipoPersonas.Alumno:
                        texto = "Alumno";
                        break;
                    case (int)Persona.TipoPersonas.Profesor:
                        texto = "Profesor";
                        break;
                    case (int)Persona.TipoPersonas.Admin:
                        texto = "Admin";
                        break;
                }

                cmbBoxTiposPersona.Items.Add(new
                {
                    Text = texto,
                    Value = tipoCargo.ToString()
                }
                );
            }

        }

        private int SeleccionarPlan()
        {
            for (int i = 0; i < this.cmbBoxPlanes.Items.Count; i++)
            {
                if ((this.cmbBoxPlanes.Items[i] as dynamic).Value == this.PersonaActual.IDPlan.ToString())
                {
                    return i;
                }
            };

            return -1;
        }

        private int SeleccionarTipoPersona()
        {
            for (int i = 0; i < this.cmbBoxTiposPersona.Items.Count; i++)
            {
                if ((this.cmbBoxTiposPersona.Items[i] as dynamic).Value == this.PersonaActual.GetIDTipoPersona().ToString())
                {
                    return i;
                }
            };

            return -1;
        }

        private void SetPersonaAttributesFromForm()
        {
            PersonaActual.Nombre = this.txtNombre.Text;
            PersonaActual.Apellido = this.txtApellido.Text;
            PersonaActual.Email = this.txtEmail.Text;
            PersonaActual.Direccion = this.txtDireccion.Text;
            PersonaActual.Telefono = this.txtTelefono.Text;
            PersonaActual.FechaNacimiento = this.dtFechaNacimiento.Value;
            PersonaActual.Legajo = int.Parse(this.txtLegajo.Text);
            PersonaActual.SetTipoPersonaById((Convert.ToInt32((this.cmbBoxTiposPersona.SelectedItem as dynamic).Value)));
            PersonaActual.IDPlan = Convert.ToInt32((this.cmbBoxPlanes.SelectedItem as dynamic).Value);
            PersonaActual.Usuario.Nombre = this.txtNombre.Text;
            PersonaActual.Usuario.Apellido = this.txtApellido.Text;
            PersonaActual.Usuario.NombreUsuario = this.txtNombreUsuario.Text;
            PersonaActual.Usuario.Habilitado = this.chkHabilitado.Checked;
            PersonaActual.Usuario.Email = this.txtEmail.Text;

            if (this._cambiaClave)
            {
                PersonaActual.Usuario.Clave = this.txtClave.Text;
            }
            
        }

        private void lkModificarClave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this._cambiaClave = !this._cambiaClave;

            this.lkModificarClave.Text = (this._cambiaClave) ? "Volver atrás" : "Modificar contraseña";

            this.ChequearVisibilidadCamposClave();
        }
    }
}
