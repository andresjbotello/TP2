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
    public partial class ModuloUsuarioDesktop : ApplicationForm
    {
        private ModuloUsuario _moduloUsuarioActual;

        public ModuloUsuario ModuloUsuarioActual { get => _moduloUsuarioActual; set => _moduloUsuarioActual = value; }

        public ModuloUsuarioDesktop()
        {
            InitializeComponent();
        }

        public ModuloUsuarioDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ModuloUsuarioDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();            
            ModuloUsuarioActual = mul.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtIDModUsr.Text = this.ModuloUsuarioActual.ID.ToString();
            this.txtIDMod.Text = this.ModuloUsuarioActual.IdModulo.ToString();
            this.txtIDUsr.Text = this.ModuloUsuarioActual.IdUsuario.ToString();
            this.txtAlta.Text = this.ModuloUsuarioActual.PermiteAlta.ToString();
            this.txtBaja.Text = this.ModuloUsuarioActual.PermiteBaja.ToString();
            this.txtModi.Text = this.ModuloUsuarioActual.PermiteModificacion.ToString();
            this.txtConsulta.Text = this.ModuloUsuarioActual.PermiteConsulta.ToString();

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
                ModuloUsuario mu = new ModuloUsuario();
                ModuloUsuarioActual = mu;
                ModuloUsuarioActual.State = BusinessEntity.States.New;

                ModuloUsuarioActual.IdModulo = Convert.ToInt32(this.txtIDMod.Text);
                ModuloUsuarioActual.IdUsuario = Convert.ToInt32(this.txtIDUsr.Text);
                ModuloUsuarioActual.PermiteAlta = Convert.ToBoolean(this.txtAlta.Text);
                ModuloUsuarioActual.PermiteBaja = Convert.ToBoolean(this.txtBaja.Text);
                ModuloUsuarioActual.PermiteModificacion = Convert.ToBoolean(this.txtModi.Text);
                ModuloUsuarioActual.PermiteConsulta = Convert.ToBoolean(this.txtConsulta.Text);

            }
            else if (mf == "Modificacion")
            {
                this.txtIDModUsr.Text = ModuloUsuarioActual.ID.ToString();
                ModuloUsuarioActual.IdModulo = Convert.ToInt32(this.txtIDMod.Text);
                ModuloUsuarioActual.IdUsuario = Convert.ToInt32(this.txtIDUsr.Text);
                ModuloUsuarioActual.PermiteAlta = Convert.ToBoolean(this.txtAlta.Text);
                ModuloUsuarioActual.PermiteBaja = Convert.ToBoolean(this.txtBaja.Text);
                ModuloUsuarioActual.PermiteModificacion = Convert.ToBoolean(this.txtModi.Text);
                ModuloUsuarioActual.PermiteConsulta = Convert.ToBoolean(this.txtConsulta.Text);

                ModuloUsuarioActual.State = BusinessEntity.States.Modified;
            }

            else if(mf == "Baja")
            {
                ModuloUsuarioActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ModuloUsuarioLogic mul = new ModuloUsuarioLogic();
            mul.Save(ModuloUsuarioActual);
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
