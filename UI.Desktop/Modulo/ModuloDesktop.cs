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
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class ModuloDesktop : ApplicationForm
    {
        private Modulo _moduloActual;
        public Modulo ModuloActual { get => _moduloActual; set => _moduloActual = value; }

        public ModuloDesktop()
        {
            InitializeComponent();
        }

        public ModuloDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ModuloDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (Convert.ToString(modo) == "Baja")
            {
                ReadOnlyFields();
            }
            ModuloLogic mdl = new ModuloLogic();
            ModuloActual = mdl.GetOne(ID);
            MapearDeDatos();
        }

        public void ReadOnlyFields()
        {
            this.txtDescripcion.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ModuloActual.ID.ToString();
            this.txtDescripcion.Text = this.ModuloActual.Descripcion;

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
                Modulo p = new Modulo();
                ModuloActual = p;
                ModuloActual.State = BusinessEntity.States.New; 

                ModuloActual.Descripcion = this.txtDescripcion.Text;


            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = ModuloActual.ID.ToString();
                ModuloActual.Descripcion = this.txtDescripcion.Text;

                ModuloActual.State = BusinessEntity.States.Modified;
            }

            else if(mf == "Baja")
            {
                ModuloActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ModuloLogic mdl = new ModuloLogic();
            mdl.Save(ModuloActual);
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
