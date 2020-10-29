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
    public partial class AlumnoInscripcionDesktop : ApplicationForm
    {
        private AlumnoInscripcion _alumnoInscripcionActual;

        public AlumnoInscripcion AlumnoInscripcionActual { get => _alumnoInscripcionActual; set => _alumnoInscripcionActual = value; }

        public AlumnoInscripcionDesktop()
        {
            InitializeComponent();
        }

        public AlumnoInscripcionDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public AlumnoInscripcionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            AlumnoInscripcionActual = ail.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtIDInscripcion.Text = this.AlumnoInscripcionActual.ID.ToString();
            this.txtIDAlumno.Text = this.AlumnoInscripcionActual.IDAlumno.ToString();
            this.txtIDCurso.Text = this.AlumnoInscripcionActual.IDCurso.ToString();
            this.txtCondicion.Text = this.AlumnoInscripcionActual.CondicionActual;
            this.txtNota.Text = this.AlumnoInscripcionActual.Nota.ToString();

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
                AlumnoInscripcion ai = new AlumnoInscripcion();
                AlumnoInscripcionActual = ai;
                AlumnoInscripcionActual.State = BusinessEntity.States.New;

                AlumnoInscripcionActual.IDAlumno = Convert.ToInt32(this.txtIDAlumno.Text);
                AlumnoInscripcionActual.IDCurso = Convert.ToInt32(this.txtIDCurso.Text);
                AlumnoInscripcionActual.CondicionActual = this.txtCondicion.Text;
                AlumnoInscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);

            }
            else if (mf == "Modificacion")
            {
                this.txtIDInscripcion.Text = AlumnoInscripcionActual.ID.ToString();
                AlumnoInscripcionActual.IDAlumno = Convert.ToInt32(this.txtIDAlumno.Text);
                AlumnoInscripcionActual.IDCurso = Convert.ToInt32(this.txtIDCurso.Text);
                AlumnoInscripcionActual.CondicionActual = this.txtCondicion.Text;
                AlumnoInscripcionActual.Nota = Convert.ToInt32(this.txtNota.Text);
                AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
            }

            else if(mf == "Baja")
            {
                AlumnoInscripcionActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            AlumnoInscripcionLogic ail = new AlumnoInscripcionLogic();
            ail.Save(AlumnoInscripcionActual);
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
