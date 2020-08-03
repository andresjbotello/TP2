using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class MateriaDesktop : ApplicationForm
    {
        private Business.Entities.Materia _materiaActual;
        public Materia MateriaActual { get => _materiaActual; set => _materiaActual = value; }

        public MateriaDesktop()
        {
            InitializeComponent();
            FillComboBoxPlan();
        }

        public MateriaDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.cmbBoxPlanes.SelectedIndex = SeleccionarPlan();
            this.txtMateria.Text = this.MateriaActual.Descripcion;
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            

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
                Materia m = new Business.Entities.Materia();
                MateriaActual = m;

                MateriaActual.IDPlan = Convert.ToInt32((this.cmbBoxPlanes.SelectedItem as dynamic).Value);
                MateriaActual.Descripcion = this.txtMateria.Text;
                MateriaActual.HSSemanales = Convert.ToInt32(this.txtHSSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(this.txtHSTotales.Text);


            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = MateriaActual.ID.ToString();
                MateriaActual.IDPlan = Convert.ToInt32((this.cmbBoxPlanes.SelectedItem as dynamic).Value);
                MateriaActual.Descripcion = this.txtMateria.Text;
                MateriaActual.HSSemanales = Convert.ToInt32(this.txtHSSemanales.Text);
                MateriaActual.HSTotales = Convert.ToInt32(this.txtHSTotales.Text);
                MateriaActual.State = BusinessEntity.States.Modified;
            }

            else if (mf == "Baja")
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(MateriaActual);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            this.Close();    
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillComboBoxPlan()
        {
            PlanLogic pl = new PlanLogic();

            List<Plan> planes = pl.GetAll();

            cmbBoxPlanes.DisplayMember = "Text";
            cmbBoxPlanes.ValueMember = "Value";

            foreach (Plan p in planes)
            {
                cmbBoxPlanes.Items.Add(new
                {
                    Text = p.Descripcion,
                    Value = p.ID.ToString()
                }
                );
            }
        }

        private int SeleccionarPlan()
        {
            for (int i = 0; i < this.cmbBoxPlanes.Items.Count; i++)
            {
                if ((this.cmbBoxPlanes.Items[i] as dynamic).Value == this.MateriaActual.IDPlan.ToString())
                {
                    return i;
                }
            };

            return -1;
        }
    }
}
