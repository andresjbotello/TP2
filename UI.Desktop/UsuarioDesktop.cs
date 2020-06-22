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
using System.Runtime.CompilerServices;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {
        private Business.Entities.Usuario _usuarioActual;
        public Usuario UsuarioActual { get => _usuarioActual; set => _usuarioActual = value; }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public UsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtClave.Text = this.UsuarioActual.Clave;
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.txtEmail.Text = this.UsuarioActual.Email;

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
                Usuario u = new Business.Entities.Usuario();
                UsuarioActual = u;
                UsuarioActual.State = BusinessEntity.States.New; 

                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.Clave = this.txtClave.Text;

            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = UsuarioActual.ID.ToString();
                UsuarioActual.Nombre = this.txtNombre.Text;
                UsuarioActual.Apellido = this.txtApellido.Text;
                UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                UsuarioActual.Email = this.txtEmail.Text;
                UsuarioActual.Clave = this.txtClave.Text;
                UsuarioActual.State = BusinessEntity.States.Modified;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }

        public override bool Validar()
        {
            //TERMINAR LA VALIDACION, NO SEAS BOLUDO ROMERO
            bool o = false;
            if(txtNombre.Text != "" && txtApellido.Text != "" && txtUsuario.Text != "" && txtEmail.Text != "" && txtClave.Text != "" && txtConfirmarClave.Text != "")
            {
                if(txtConfirmarClave.ToString() == txtClave.ToString() )
                {
                    o = true;
                }

                else
                {
                    Notificar("Error de contraseña", "Las contraseñas no coinciden!", MessageBoxButtons.OK , MessageBoxIcon.Error);
                    o = false;
                }
            } //TERMINAR LA VALIDACION, NO SEAS BOLUDO ROMERO
            else
            {
                Notificar("Error","Campos vacios!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return o; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool res = Validar();
            if (res)
            {
                GuardarCambios();
                this.Close();
            }
        }
    }
}
