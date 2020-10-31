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
    public partial class ComisionDesktop : ApplicationForm
    {
        private Business.Entities.Comision _comActual;
        public Comision ComActual { get => _comActual; set => _comActual = value; }

        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (Convert.ToString(modo) == "Baja")
            {
                ReadOnlyFields();
            }
            ComisionLogic comLogic = new ComisionLogic();
            ComActual = comLogic.GetOne(ID);
            MapearDeDatos();
        }

        public void ReadOnlyFields()
        {
            this.txtAnioEspecialidad.Enabled = false;
            this.txtDescCom.Enabled = false;
            this.txtIDPlan.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            this.txtIDCom.Text = this.ComActual.ID.ToString();
            this.txtDescCom.Text = Convert.ToString(this.ComActual.Descripcion);
            this.txtAnioEspecialidad.Text = Convert.ToString(this.ComActual.AnioEspecialidad);
            this.txtIDPlan.Text = Convert.ToString(this.ComActual.IDPlan);

            string mf = Convert.ToString(Modo);
            if (mf == "Alta" || mf == "Modificacion")
            {
                this.btnAceptar.Text = "Guardar";
            }
            else if (mf == "Baja")
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
                Comision c = new Business.Entities.Comision();
                ComActual = c;
                ComActual.State = BusinessEntity.States.New;

                ComActual.Descripcion = Convert.ToString(this.txtDescCom.Text);
                ComActual.IDPlan = Convert.ToInt32(this.txtIDPlan.Text);
                ComActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);

            }
            else if (mf == "Modificacion")
            {
                this.txtIDCom.Text = ComActual.ID.ToString();
                ComActual.Descripcion = Convert.ToString(this.txtDescCom.Text);
                ComActual.IDPlan = Convert.ToInt32(this.txtIDPlan.Text);
                ComActual.AnioEspecialidad = Convert.ToInt32(this.txtAnioEspecialidad.Text);

                ComActual.State = BusinessEntity.States.Modified;
            }

            else if (mf == "Baja")
            {
                ComActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic comLogic = new ComisionLogic();
            comLogic.Save(ComActual);
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

        private void lblidMateria_Click(object sender, EventArgs e)
        {

        }
    }
}
