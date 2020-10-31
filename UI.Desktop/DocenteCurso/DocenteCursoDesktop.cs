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
            FillComboBoxs();
        }

        public DocenteCursoDesktop(ModoForm modo) : this()
        {
            Modo = modo;
        }

        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            if (Convert.ToString(modo) == "Baja")
            {
                ReadOnlyFields();
            }
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            DocenteCursoActual = dcl.GetOne(ID);
            MapearDeDatos();
        }

        public void ReadOnlyFields()
        {
            this.cmbBoxCursos.Enabled = false;
            this.cmbBoxDocentes.Enabled = false;
            this.cmbBoxTiposCargo.Enabled = false;
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.DocenteCursoActual.ID.ToString();
            this.cmbBoxCursos.SelectedIndex = SeleccionarCurso();
            this.cmbBoxDocentes.SelectedIndex = SeleccionarDocente();
            this.cmbBoxTiposCargo.SelectedIndex = SeleccionarTipoCargo();

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

                DocenteCursoActual.IDCurso = Convert.ToInt32((this.cmbBoxCursos.SelectedItem as dynamic).Value);
                DocenteCursoActual.IDDocente = Convert.ToInt32((this.cmbBoxDocentes.SelectedItem as dynamic).Value);
                DocenteCursoActual.SetTipoCargoById(Convert.ToInt32((this.cmbBoxTiposCargo.SelectedItem as dynamic).Value));

            }
            else if (mf == "Modificacion")
            {
                this.txtID.Text = DocenteCursoActual.ID.ToString();
                DocenteCursoActual.IDCurso = Convert.ToInt32((this.cmbBoxCursos.SelectedItem as dynamic).Value);
                DocenteCursoActual.IDDocente = Convert.ToInt32((this.cmbBoxDocentes.SelectedItem as dynamic).Value);
                DocenteCursoActual.SetTipoCargoById(Convert.ToInt32((this.cmbBoxTiposCargo.SelectedItem as dynamic).Value));
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

        private void FillComboBoxs()
        {
            this.FillComboBoxCursos();
            this.FillComboBoxDocentes();
            this.FillComboBoxTipoCargo();
        }

        private void FillComboBoxCursos()
        {
            CursoLogic cur = new CursoLogic();

            List<Curso> cursos = cur.GetAll();

            cmbBoxCursos.DisplayMember = "Text";
            cmbBoxCursos.ValueMember = "Value";

            foreach (Curso c in cursos)
            {
                cmbBoxCursos.Items.Add(new
                {
                    Text = c.ID.ToString(),
                    Value = c.ID.ToString()
                }
                );
            }
        }

        private void FillComboBoxDocentes()
        {
            PersonaLogic per = new PersonaLogic();

            List<Persona> personas = per.GetAll(Persona.TipoPersonas.Profesor);

            cmbBoxDocentes.DisplayMember = "Text";
            cmbBoxDocentes.ValueMember = "Value";

            foreach (Persona p in personas)
            {
                cmbBoxDocentes.Items.Add(new
                {
                    Text = p.Nombre + ' ' + p.Apellido,
                    Value = p.ID.ToString()
                }
                );
            }
        }

        private void FillComboBoxTipoCargo()
        {
            cmbBoxTiposCargo.DisplayMember = "Text";
            cmbBoxTiposCargo.ValueMember = "Value";

            for (int tipoCargo = (int) DocenteCurso.TiposCargos.Teoria; tipoCargo <= (int)DocenteCurso.TiposCargos.AuxiliarPractica; tipoCargo++)
            {
                String texto = "";

                switch (tipoCargo)
                {
                    case (int)DocenteCurso.TiposCargos.Teoria:
                        texto = "Teoría";
                        break;
                    case (int)DocenteCurso.TiposCargos.Practica:
                        texto = "Práctica";
                        break;
                    case (int)DocenteCurso.TiposCargos.AuxiliarTeoria:
                        texto = "Auxiliar de Teoría";
                        break;
                    case (int)DocenteCurso.TiposCargos.AuxiliarPractica:
                        texto = "Auxiliar de Práctica";
                        break;
                }

                cmbBoxTiposCargo.Items.Add(new
                {
                    Text = texto,
                    Value = tipoCargo.ToString()
                }
);
            }

        }

        private int SeleccionarCurso()
        {
            for (int i = 0; i < this.cmbBoxCursos.Items.Count; i++)
            {
                if ((this.cmbBoxCursos.Items[i] as dynamic).Value == this.DocenteCursoActual.IDCurso.ToString())
                {
                    return i;
                }
            };

            return -1;
        }

        private int SeleccionarDocente()
        {
            for (int i = 0; i < this.cmbBoxDocentes.Items.Count; i++)
            {
                if ((this.cmbBoxDocentes.Items[i] as dynamic).Value == this.DocenteCursoActual.IDDocente.ToString())
                {
                    return i;
                }
            };

            return -1;
        }

        private int SeleccionarTipoCargo()
        {
            for (int i = 0; i < this.cmbBoxTiposCargo.Items.Count; i++)
            {
                if ((this.cmbBoxTiposCargo.Items[i] as dynamic).Value == this.DocenteCursoActual.GetIDTipoCargo().ToString())
                {
                    return i;
                }
            };

            return -1;
        }

    }
}
