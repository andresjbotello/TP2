using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UI.Web
{
	public partial class DocentesCursos : System.Web.UI.Page
	{
        private DocenteCursoLogic _docenteCursoLogic;
        public DocenteCursoLogic DCLogic
        {
            get
            {
                if (_docenteCursoLogic == null)
                {
                    _docenteCursoLogic = new DocenteCursoLogic();
                }
                return _docenteCursoLogic;
            }
        }

        private PersonaLogic _personaLogic;

        public PersonaLogic PersonaLogic
        {
            get
            {
                if (_personaLogic == null)
                {
                    _personaLogic = new PersonaLogic();
                }
                return _personaLogic;
            }
        }

        private static List<Persona> _ListaPersonas;
        public List<Persona> ListaPersonas
        {
            get { return _ListaPersonas; }
            set { _ListaPersonas = value; }
        }



        private CursoLogic _cursoLogic;

        public CursoLogic CursoLogic
        {
            get
            {
                if (_cursoLogic == null)
                {
                    _cursoLogic = new CursoLogic();
                }
                return _cursoLogic;
            }
        }

        private static List<Curso> _ListaCursos;
        public List<Curso> ListaCursos
        {
            get { return _ListaCursos; }
            set { _ListaCursos = value; }
        }
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }
        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set { this.ViewState["FormMode"] = value; }
        }

        private DocenteCurso Entity
        {
            get;
            set;
        }

        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                return -1;
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }

        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                this.LoadGrid();
                Label mpLabel;
                mpLabel = (Label)Master.FindControl("MenuItemLabel");
                if (mpLabel != null)
                {
                    mpLabel.Visible = true;
                    mpLabel.Text = "Docentes y Cursos";
                }
            }
        }

        private void LoadGrid()
        {
            this.gridView.DataSource = this.DCLogic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
            this.formPanel.Visible = false;
        }


        private void LoadForm(int id)
        {
            this.cargaListas();
            this.Entity = this.DCLogic.GetOne(id);
            this.ddlDocentes.SelectedValue = this.Entity.IDDocente.ToString();
            this.ddlCursos.SelectedValue = this.Entity.IDCurso.ToString();
            this.ddlCargos.SelectedValue = this.Entity.GetIDTipoCargo().ToString();
        }


        private void LoadEntity(DocenteCurso docenteCurso)
        {
            docenteCurso.IDDocente = Convert.ToInt32(this.ddlDocentes.SelectedItem.Value);
            docenteCurso.IDCurso = Convert.ToInt32(this.ddlCursos.SelectedItem.Value);
            docenteCurso.SetTipoCargoById(Convert.ToInt32(this.ddlCargos.SelectedItem.Value));
        }

        private void SaveEntity(DocenteCurso docenteCurso)
        {
            this.DCLogic.Save(docenteCurso);
        }

        private void EnableForm(bool enable)
        {
            this.ddlDocentes.Enabled = enable;
            this.ddlCursos.Enabled = enable;
            this.ddlCargos.Enabled = enable;
        }


        private void DeleteEntity(int ID)
        {
            this.DCLogic.Delete(ID);
        }

        #region Accion Buttons Click
        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.EnableForm(true);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.SelectedID = -1;
            this.gridView.SelectedIndex = -1;
            this.formPanel.Visible = true;
            this.docenteLabel.Visible = true;
            this.ddlDocentes.Visible = true;
            this.cursoLabel.Visible = true;
            this.ddlCursos.Visible = true;
            this.cargoLabel.Visible = true;
            this.ddlCargos.Visible = true;
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);
            this.ddlDocentes.ClearSelection();
            this.ddlCursos.ClearSelection();
            this.ddlCargos.ClearSelection();
            this.cargaListas();

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.docenteLabel.Visible = false;
                this.ddlDocentes.Visible = false;
                this.cursoLabel.Visible = false;
                this.ddlCursos.Visible = false;
                this.cargoLabel.Visible = false;
                this.ddlCargos.Visible = false;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
        }

        protected void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.SelectedID = -1;
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new DocenteCurso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.SelectedID = -1;
                    this.gridView.SelectedIndex = -1;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
                    this.SelectedID = -1;
                    this.gridView.SelectedIndex = -1;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.formPanel.Visible = false;
        }

        #endregion



        #region Carga Listas
        private void cargaListas()
        {
            this.cargaListaDocentes();
            this.cargaListaCursos();
            this.cargaListaCargos();
        }

        private void cargaListaDocentes()
        {
            ListaPersonas = PersonaLogic.GetAll(Persona.TipoPersonas.Profesor);
            this.ddlDocentes.DataSource = ListaPersonas;
            this.ddlDocentes.DataValueField = "id";
            this.ddlDocentes.DataTextField = "Nombre";
            this.ddlDocentes.DataBind();
        }

        private void cargaListaCursos()
        {
            ListaCursos = CursoLogic.GetAll();
            this.ddlCursos.DataSource = ListaCursos;
            this.ddlCursos.DataValueField = "id";
            this.ddlCursos.DataTextField = "Id";
            this.ddlCursos.DataBind();
        }

        private void cargaListaCargos()
        {
            if (this.ddlCargos.Items.Count == 0)
            {
                List<DocenteCurso.TiposCargos> tiposCargos = Enum.GetValues(typeof(DocenteCurso.TiposCargos)).Cast<DocenteCurso.TiposCargos>().ToList();

                foreach (DocenteCurso.TiposCargos tipoCargo in tiposCargos)
                {
                    ListItem item = new ListItem(tipoCargo.ToString(), ((int)tipoCargo).ToString());

                    this.ddlCargos.Items.Add(item);
                }
            }

        }
        #endregion
    }
}