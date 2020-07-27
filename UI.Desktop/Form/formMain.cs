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

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        private Usuario _usuario;
        public Usuario Usuario { get => _usuario; set => _usuario = value; }

        public formMain(Usuario usr)
        {
            InitializeComponent();
            Usuario = usr;
        }

        
        private void btn_abrirDGV(object sender, EventArgs e)
        {
            UI.Desktop.Usuarios usr = new UI.Desktop.Usuarios();
            usr.ShowDialog();
        }

        private void mnuUsuarios_Click(object sender, EventArgs e)
        {
            UI.Desktop.Usuarios usr = new UI.Desktop.Usuarios();
            usr.ShowDialog();
        }

        private void mnuMaterias_Click(object sender, EventArgs e)
        {
            UI.Desktop.Materias mtr = new UI.Desktop.Materias();
            mtr.ShowDialog();
        }

        private void mnuPlanes_Click(object sender, EventArgs e)
        {
            UI.Desktop.Planes pln = new Planes();
            pln.ShowDialog();
        }

        private void mnuEspecialidades_Click(object sender, EventArgs e)
        {
            UI.Desktop.Especialiades esp = new Especialiades();
            esp.ShowDialog();
        }

        private void mnuCursos_Click(object sender, EventArgs e)
        {
            UI.Desktop.Cursos crs = new Cursos();
            crs.ShowDialog();
        }

        private void mnuPersonas_Click(object sender, EventArgs e)
        {
            UI.Desktop.Personas personas = new Personas();
            personas.ShowDialog();
        }

        private void mnuModulos_Click(object sender, EventArgs e)
        {
            UI.Desktop.Modulos mdl = new Modulos();
            mdl.ShowDialog();
        }

        private void mnuDocentesConCursos_Click(object sender, EventArgs e)
        {
            UI.Desktop.DocentesCursos docCursos = new DocentesCursos();
            docCursos.ShowDialog();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
