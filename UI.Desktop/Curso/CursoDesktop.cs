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
    public partial class CursoDesktop : ApplicationForm
    {
        private Business.Entities.Curso _cursoActual;
        public Curso CursoActual { get => _cursoActual; set => _cursoActual = value; }

        public CursoDesktop()
        {
            InitializeComponent();
        }

        public CursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.CursoActual.ID.ToString();
            this.txtCupo.Text = Convert.ToString(this.CursoActual.Cupo);
            this.txtidMateria.Text = Convert.ToString(this.CursoActual.IDMateria);
            this.txtCal.Text = Convert.ToString(this.CursoActual.AnioCalendario);
            this.txtidCom.Text = Convert.ToString(this.CursoActual.IDComision);

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
                Curso c = new Business.Entities.Curso();
                CursoActual = c;
                CursoActual.State = BusinessEntity.States.New; 

                CursoActual.IDMateria = Convert.ToInt32(this.txtidMateria.Text);
                CursoActual.IDComision = Convert.ToInt32(this.txtidCom.Text);
                CursoActual.AnioCalendario = Convert.ToInt32(this.txtCal.Text);
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);

            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = CursoActual.ID.ToString();
                CursoActual.IDMateria = Convert.ToInt32(this.txtidMateria.Text);
                CursoActual.IDComision = Convert.ToInt32(this.txtidCom.Text);
                CursoActual.AnioCalendario = Convert.ToInt32(this.txtCal.Text);
                CursoActual.Cupo = Convert.ToInt32(this.txtCupo.Text);

                CursoActual.State = BusinessEntity.States.Modified;
            }

            else if(mf == "Baja")
            {
                CursoActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);
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
