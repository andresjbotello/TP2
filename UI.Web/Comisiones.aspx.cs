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
    public partial class Comisiones : System.Web.UI.Page
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

        private static List<Plan> _listaPlanes;
        public List<Plan> listaPlanes
        {
            get { return _listaPlanes; }
            set { _listaPlanes = value; }
        }
        #endregion
        private ComisionLogic _comision;
        public ComisionLogic CLogic
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
        private static List<Materia> _ListaMaterias;
        public List<Materia> ListaMaterias
        {
            get { return _ListaMaterias; }
            set { _ListaMaterias = value; }
        }

        private Comision Entity
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
            Usuario usu = (Usuario)this.Session["usuario"];
            PersonaLogic plo = new PersonaLogic();
            if (usu != null)
            {
                Persona p = plo.GetOne(usu.ID);
                if (p.TipoPersona == Persona.TipoPersonas.Alumno)
                {
                    Response.Redirect("Home.aspx");
                }
                if (p.TipoPersona == Persona.TipoPersonas.Profesor)
                {
                    Response.Redirect("Home.aspx");
                }
                if (p.TipoPersona == Persona.TipoPersonas.Admin)
                {
                    if (!IsPostBack)
                    {
                        this.LoadGrid();
                        Label mpLabel;
                        mpLabel = (Label)Master.FindControl("MenuItemLabel");
                        if (mpLabel != null)
                        {
                            mpLabel.Visible = true;
                            mpLabel.Text = "Comisiones";
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
        private void LoadGrid()
        {
            this.formPanel.Visible = false;
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
                cargaListaEspecialidades();
                llenarListaPlanes();
                this.formPanel.Visible = true;
                this.EnableForm(true);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }
        }

        private void LoadForm(int id)
        {
            this.Entity = CLogic.GetOne(id);
            this.DescComTextBox.Text = this.Entity.Descripcion;
            this.anoEspecialidadTextBox.Text = this.Entity.AnioEspecialidad.ToString();
        }

        private void cargaListaEspecialidades()
        {
            ListaEspecialidades = ELogic.GetAll();
            this.ddlEspecialidades.DataSource = ListaEspecialidades;
            this.ddlEspecialidades.DataValueField = "id";
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataBind();
        }
        private void llenarListaPlanes()
        {

            if (ddlEspecialidades.SelectedValue == null) { }
            else
            {
                listaPlanes = PLogic.GetAll();
                List<Plan> listaPlanesFiltrados = new List<Plan>();
                ddlPlanes.DataSource = null;
                int selecteVal = Convert.ToInt32(ddlEspecialidades.SelectedItem.Value);
                listaPlanesFiltrados = listaPlanes.Where(plan => plan.IDEspecialidad == selecteVal).ToList();
                ddlPlanes.DataSource = listaPlanesFiltrados;
                ddlPlanes.DataValueField = "id";
                ddlPlanes.DataTextField = "Descripcion";
                ddlPlanes.DataBind();
            }

        }


        private void LoadEntity(Comision comision)
        {
            comision.Descripcion = this.DescComTextBox.Text;
            comision.AnioEspecialidad = Convert.ToInt32(this.anoEspecialidadTextBox.Text);
            comision.IDPlan = Convert.ToInt32(this.ddlPlanes.SelectedValue);

        }

        private void SaveEntity(Comision comision)
        {
            this.CLogic.Save(comision);
        }

        private void EnableForm(bool enable)
        {
            this.DescComTextBox.Enabled = enable;
            this.anoEspecialidadTextBox.Enabled = enable;
            this.ddlPlanes.Enabled = enable;
            this.ddlEspecialidades.Enabled = enable;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }



        private void DeleteEntity(int ID)
        {
            this.CLogic.Delete(ID);
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            cargaListaEspecialidades();
            llenarListaPlanes();
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
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
                    this.Entity = new Comision();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Comision();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.formPanel.Visible = false;
        }



        private void clearForm()
        {
            this.DescComTextBox.Text = string.Empty;
            this.anoEspecialidadTextBox.Text = string.Empty;

        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarListaPlanes();

        }

    }
}