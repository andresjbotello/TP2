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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        private DocenteCurso _docenteCursoActual;
        public DocenteCurso DocenteCursoActual { get => _docenteCursoActual; set => _docenteCursoActual = value; }

        public DocenteCursoDesktop()
        {
            InitializeComponent();
        }

        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            DocenteCursoActual = dcl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.DocenteCursoActual.ID.ToString();
            this.txtIDCurso.Text = this.DocenteCursoActual.IDCurso.ToString();
            this.txtIDDocente.Text = this.DocenteCursoActual.IDDocente.ToString();
            this.txtCargo.Text = this.DocenteCursoActual.GetIDTipoCargo().ToString();

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
                DocenteCurso dc = new DocenteCurso();
                DocenteCursoActual = dc;
                DocenteCursoActual.State = BusinessEntity.States.New; 

                DocenteCursoActual.IDCurso = int.Parse(this.txtIDCurso.Text);
                DocenteCursoActual.IDDocente = int.Parse(this.txtIDDocente.Text);
                DocenteCursoActual.SetTipoCargoById(int.Parse(this.txtCargo.Text));

            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = DocenteCursoActual.ID.ToString();
                DocenteCursoActual.IDCurso = int.Parse(this.txtIDCurso.Text);
                DocenteCursoActual.IDDocente = int.Parse(this.txtIDDocente.Text);
                DocenteCursoActual.SetTipoCargoById(int.Parse(this.txtCargo.Text));
                DocenteCursoActual.State = BusinessEntity.States.Modified;
            }

            else if(mf == "Baja")
            {
                DocenteCursoActual.State = BusinessEntity.States.Deleted;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            dcl.Save(DocenteCursoActual);
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
