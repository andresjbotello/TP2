using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Cursos : System.Web.UI.Page
    {
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
        private EspecialidadLogic _especilidades;
        public EspecialidadLogic ELogic
        {
            get
            {
                if (_especilidades == null)
                {
                    _especilidades = new EspecialidadLogic();
                }
                return _especilidades;
            }
        }

        private MateriaLogic _materias;
        public MateriaLogic MLogic
        {
            get
            {
                if (_materias == null)
                {
                    _materias = new MateriaLogic();
                }
                return _materias;
            }
        }

        private ComisionLogic _comision;
        public ComisionLogic ComLogic
        {
            get
            {
                if (_comision == null)
                {
                    _comision = new ComisionLogic();
                }
                return _comision;
            }
        }

        private PlanLogic _plan;
        public PlanLogic PLogic
        {
            get
            {
                if (_plan == null)
                {
                    _plan = new PlanLogic();
                }
                return _plan;
            }
        }
        # region listas
        private static List<Especialidad> _ListaEspecialidades;
        public List<Especialidad> ListaEspecialidades
        {
            get { return _ListaEspecialidades; }
            set { _ListaEspecialidades = value; }
        }

        private static List<Materia> _listaMaterias;
        public List<Materia> listaMaterias
        {
            get { return _listaMaterias; }
            set { _listaMaterias = value; }
        }

        private static List<Comision> _listaComisiones;
        public List<Comision> listaComisiones
        {
            get { return _listaComisiones; }
            set { _listaComisiones = value; }
        }

        private static List<Plan> _listaPlanes;
        public List<Plan> listaPlanes
        {
            get { return _listaPlanes; }
            set { _listaPlanes = value; }
        }
        #endregion
        private CursoLogic _cursos;
        public CursoLogic CLogic
        {
            get
            {
                if (_cursos == null)
                {
                    _cursos = new CursoLogic();
                }
                return _cursos;
            }
        }
        private static List<Materia> _ListaMaterias;
        public List<Materia> ListaMaterias
        {
            get { return _ListaMaterias; }
            set { _ListaMaterias = value; }
        }

        private Curso Entity
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
                else
                {
                    return 0;
                }
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
                listaMaterias = MLogic.GetAll();
                listaComisiones = ComLogic.GetAll();
                ListaEspecialidades = ELogic.GetAll();
                listaPlanes = PLogic.GetAll();
                this.LoadGrid();
                Label mpLabel;
                mpLabel = (Label)Master.FindControl("MenuItemLabel");
                if (mpLabel != null)
                {
                    mpLabel.Visible = true;
                    mpLabel.Text = "Cursos";
                }
            }
        }
        private void LoadGrid()
        {

            this.gridView.DataSource = this.CLogic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;

        }

        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {

                this.CargaTodo();
                this.formPanel.Visible = true;
                this.EnableForm(true);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }
        }

        private void CargaTodo()
        {
            this.cargaListaEspecialidades();
            this.llenarListaPlanes();
            this.llenarMaterias();
            this.llenarComisiones();
        }

        private void LoadForm(int id)
        {

            this.Entity = CLogic.GetOne(id);
            this.nroCursoTextBox.Text = this.Entity.ID.ToString();
            this.ddlMaterias.SelectedValue = this.Entity.IDMateria.ToString();
            this.ddlComisiones.SelectedValue = this.Entity.IDComision.ToString();



        }

        private void cargaListaEspecialidades()
        {

            this.ddlEspecialidades.DataSource = ListaEspecialidades;
            this.ddlEspecialidades.DataValueField = "ID";
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataBind();
        }
        private void llenarListaPlanes()
        {

            if (ddlEspecialidades.SelectedValue == null) { }
            else
            {
                List<Plan> listaPlanesFiltrados = new List<Plan>();
                ddlPlanes.DataSource = null;
                int selecteVal = Convert.ToInt32(ddlEspecialidades.SelectedValue);
                listaPlanesFiltrados = listaPlanes.Where(plan => plan.IDEspecialidad == selecteVal).ToList();
                ddlPlanes.DataSource = listaPlanesFiltrados;
                ddlPlanes.DataValueField = "id";
                ddlPlanes.DataTextField = "Descripcion";
                ddlPlanes.DataBind();
            }

        }

        private void llenarMaterias()
        {
            List<Materia> listaMateriasFiltrados = new List<Materia>();
            ddlMaterias.DataSource = null;
            if (ddlPlanes.SelectedValue == null) { }
            else
            {
                int selectValPlan = Convert.ToInt32(ddlPlanes.SelectedItem.Value);
                listaMateriasFiltrados = listaMaterias.Where(mat => mat.IDPlan == selectValPlan).ToList();
                ddlMaterias.DataSource = listaMateriasFiltrados;
                ddlMaterias.DataValueField = "id";
                ddlMaterias.DataTextField = "Descripcion";
                ddlMaterias.DataBind();
            }

        }
        private void llenarComisiones()
        {
            List<Comision> listaComisionFiltrados = new List<Comision>();
            ddlComisiones.DataSource = null;
            if (ddlPlanes.SelectedValue == null) { }
            else
            {
                int selectValPlan = Convert.ToInt32(ddlPlanes.SelectedItem.Value);
                listaComisionFiltrados = listaComisiones.Where(com => com.IDPlan == selectValPlan).ToList();
                ddlComisiones.DataSource = listaComisionFiltrados;
                ddlComisiones.DataValueField = "id";
                ddlComisiones.DataTextField = "Descripcion";
                ddlComisiones.DataBind();
            }

        }


        private void LoadEntity(Curso curso)
        {
            curso.AnioCalendario = Convert.ToInt32(this.AnoTextBox.Text);
            curso.IDComision = Convert.ToInt32(this.ddlComisiones.SelectedValue);
            curso.IDMateria = Convert.ToInt32(this.ddlMaterias.SelectedValue);

        }

        private void SaveEntity(Curso curso)
        {
            this.CLogic.Save(curso);
        }

        private void EnableForm(bool enable)
        {

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.CupoTextBox.Visible = false;
                this.AnoTextBox.Visible = false;
                this.AnoLabel.Visible = false;
                this.ddlComisiones.Visible = false;
                this.ddlPlanes.Visible = false;
                this.ddlMaterias.Visible = false;
                this.ddlEspecialidades.Visible = false;
                this.ComisionLabel.Visible = false;
                this.materiaLabel.Visible = false;
                this.PlanesLabel.Visible = false;
                this.EspecialidadesLabel.Visible = false;
                this.CupoLabel.Visible = false;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }



        private void DeleteEntity(int ID)
        {
            try
            {
                this.CLogic.Delete(ID);
            }
            catch (Exception ex)
            {
                this.Info.Visible = true;
                this.Info.Text = ex.Message;
            }
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {

            this.CargaTodo();
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.EnableForm(true);

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
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.formPanel.Visible = false;
        }




        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarListaPlanes();

        }

        protected void ddlPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarMaterias();
            llenarComisiones();
        }

        protected void lbReporteCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Reportes/ReporteCursos.aspx");
        }
    }
}