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
    public partial class PlanDesktop : ApplicationForm
    {
        private Business.Entities.Plan _planActual;
        public Plan PlanActual { get => _planActual; set => _planActual = value; }

        public PlanDesktop()
        {
            InitializeComponent();
            FillComboBoxEspecialidad();
        }

        public PlanDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (Convert.ToString(modo) == "Baja")
            {
                ReadOnlyFields();
            }
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        public void ReadOnlyFields()
        {
            this.txtDescripcion.Enabled = false;
            this.cmbBoxEspecialidades.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;

            this.cmbBoxEspecialidades.SelectedIndex = SeleccionarEspecialidad();

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
                Plan p = new Business.Entities.Plan();
                PlanActual = p;
                PlanActual.State = BusinessEntity.States.New; 

                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.IDEspecialidad = Convert.ToInt32((this.cmbBoxEspecialidades.SelectedItem as dynamic).Value);


            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = PlanActual.ID.ToString();
                PlanActual.Descripcion = this.txtDescripcion.Text;
                PlanActual.IDEspecialidad = Convert.ToInt32((this.cmbBoxEspecialidades.SelectedItem as dynamic).Value);

                PlanActual.State = BusinessEntity.States.Modified;
            }

            else if(mf == "Baja")
            {
                PlanActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(PlanActual);
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

        private void FillComboBoxEspecialidad()
        {
            EspecialidadLogic el = new EspecialidadLogic();

            List<Especialidad> especialidades = el.GetAll();

            cmbBoxEspecialidades.DisplayMember = "Text";
            cmbBoxEspecialidades.ValueMember = "Value";

            foreach (Especialidad e in especialidades)
            {
                cmbBoxEspecialidades.Items.Add(new
                {
                    Text = e.Descripcion,
                    Value = e.ID.ToString()
                }
                );
            }
        }

        private int SeleccionarEspecialidad()
        {
            for (int i = 0; i < this.cmbBoxEspecialidades.Items.Count; i++)
            {
                if ((this.cmbBoxEspecialidades.Items[i] as dynamic).Value == this.PlanActual.IDEspecialidad.ToString())
                {
                    return i;
                } 
            };

            return -1;
        }
    }
}
