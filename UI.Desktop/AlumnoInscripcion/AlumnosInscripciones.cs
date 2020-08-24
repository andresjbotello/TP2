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
    public partial class AlumnosInscripciones : Form
    {
        private Persona _persona;
        public Persona Persona { get => _persona; set => _persona = value; }

        public AlumnosInscripciones(Persona p)
        {
            InitializeComponent();
            Persona = p;
            bool e = Validaciones.Permisos(Persona);
            tsbNuevo.Enabled = e;
            tsbEditar.Enabled = e;
            tsbEliminar.Enabled = e;
            this.dgvAlumnosInscripciones.AutoGenerateColumns = false;
            this.dgvAlumnosInscripciones.MultiSelect = false;
            this.dgvAlumnosInscripciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Listar();
        }


        public void Listar()
        {
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            this.dgvAlumnosInscripciones.DataSource = ail.GetAll();
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
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
            AlumnoInscripcionDesktop pd = new AlumnoInscripcionDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvAlumnosInscripciones.SelectedRows.Count > 0) 
            {
                int ID = ((DocenteCurso)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop aid = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                aid.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para editarla");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvAlumnosInscripciones.SelectedRows.Count > 0)
            {
                int ID = ((AlumnoInscripcion)this.dgvAlumnosInscripciones.SelectedRows[0].DataBoundItem).ID;
                AlumnoInscripcionDesktop aid = new AlumnoInscripcionDesktop(ID, ApplicationForm.ModoForm.Baja);
                aid.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para eliminarla");
            }
        }
    }
}
