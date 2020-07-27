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
    public partial class Modulos : Form
    {
        private Persona _persona;
        public Persona Persona { get => _persona; set => _persona = value; }

        public Modulos(Persona p)
        {
            InitializeComponent();
            Persona = p;
            bool e = Validaciones.Permisos(Persona);
            tsbNuevo.Enabled = e;
            tsbEditar.Enabled = e;
            tsbEliminar.Enabled = e;
            this.dgvModulos.AutoGenerateColumns = false;
            this.dgvModulos.MultiSelect = false;
            this.dgvModulos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Listar();
        }


        public void Listar()
        {
            ModuloLogic mdl = new ModuloLogic();
            this.dgvModulos.DataSource = mdl.GetAll();
        }

        private void Modulo_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            ModuloDesktop md = new ModuloDesktop(ApplicationForm.ModoForm.Alta);
            md.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvModulos.SelectedRows.Count > 0) 
            {
                int ID = ((Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
                ModuloDesktop pd = new ModuloDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                pd.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para editarla");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulos.SelectedRows.Count > 0)
            {
                int ID = ((Modulo)this.dgvModulos.SelectedRows[0].DataBoundItem).ID;
                ModuloDesktop ud = new ModuloDesktop(ID, ApplicationForm.ModoForm.Baja);
                ud.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para eliminarla");
            }
        }
    }
}
