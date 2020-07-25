using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void formMain_Shown(object sender, EventArgs e)
        {
            formLogin appLogin = new formLogin();
            if(appLogin.ShowDialog() != DialogResult.OK)
            {
                this.Dispose();
            }
        }

        private void btn_abrirDGV(object sender, EventArgs e)
        {
            UI.Desktop.Usuarios usr = new UI.Desktop.Usuarios();
            usr.ShowDialog();
        }

        private void btn_listaDeMaterias_Click(object sender, EventArgs e)
        {
            UI.Desktop.Materias mtr = new UI.Desktop.Materias();
            mtr.ShowDialog();
        }

        private void btn_listaDePlanes_Click(object sender, EventArgs e)
        {
            UI.Desktop.Planes pln = new Planes();
            pln.ShowDialog();
        }

        private void btn_listaDeEspecialidades_Click(object sender, EventArgs e)
        {
            UI.Desktop.Especialiades esp = new Especialiades();
            esp.ShowDialog();
        }

        private void btnListaDeCursos_Click(object sender, EventArgs e)
        {
            UI.Desktop.Cursos crs = new Cursos();
            crs.ShowDialog();
        }
    }
}
