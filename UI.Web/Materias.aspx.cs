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
    public partial class Materias : System.Web.UI.Page
    {
        private MateriaLogic _materia;
        public MateriaLogic MLogic
        {
            get
            {
                if (_materia == null)
                {
                    _materia = new MateriaLogic();
                }
                return _materia;
            }
        }
        private PlanLogic _plan;
        public PlanLogic PlanLogic
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
        private static List<Plan> _ListaPlanes;
        public List<Plan> ListaPlanes
        {
            get { return _ListaPlanes; }
            set { _ListaPlanes = value; }
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

        private Materia Entity
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
                Persona p = plo.GetOne(usu.IdPersona);
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
                            mpLabel.Text = "Materias";
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
            this.gridView.DataSource = this.MLogic.GetAll();
            this.gridView.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;
            this.formPanel.Visible = false;

        }

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

        private void LoadForm(int id)
        {
            this.cargaListaPlanes();
            this.Entity = this.MLogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.HsSemanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.HsTotalesTextBox.Text = this.Entity.HSTotales.ToString();
            this.ddlPlanes.SelectedValue = this.Entity.IDPlan.ToString();
        }
        private void cargaListaPlanes()
        {
            ListaPlanes = PlanLogic.GetAll();
            this.ddlPlanes.DataSource = ListaPlanes;
            this.ddlPlanes.DataValueField = "id";
            this.ddlPlanes.DataTextField = "Descripcion";
            this.ddlPlanes.DataBind();
        }


        private void LoadEntity(Materia materia)
        {
            materia.Descripcion = this.descripcionTextBox.Text;
            materia.HSSemanales = Convert.ToInt32(this.HsSemanalesTextBox.Text);
            materia.HSTotales = Convert.ToInt32(this.HsTotalesTextBox.Text);
            materia.IDPlan = Convert.ToInt32(this.ddlPlanes.SelectedItem.Value);
        }

        private void SaveEntity(Materia materia)
        {
            this.MLogic.Save(materia);
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.HsTotalesTextBox.Enabled = enable;
            this.HsSemanalesTextBox.Enabled = enable;
            this.ddlPlanes.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.planLabel.Visible = false;
                this.ddlPlanes.Visible = false;
                this.HsTotalesTextBox.ReadOnly = true;
                this.HsSemanalesTextBox.ReadOnly = true;
                this.descripcionTextBox.ReadOnly = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }



        private void DeleteEntity(int ID)
        {
            this.MLogic.Delete(ID);
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.ddlPlanes.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
            this.EnableForm(true);
            this.ddlPlanes.ClearSelection();
            this.cargaListaPlanes();

        }

        protected void cancelarLinkButton_Click(object sender, EventArgs e)
        {
            this.LoadGrid();
            // Se hace asi? Improvise pero no tengo ni idea
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
                    this.Entity = new Materia();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Materia();
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
            this.descripcionTextBox.Text = string.Empty;
            this.HsSemanalesTextBox.Text = string.Empty;
            this.HsTotalesTextBox.Text = string.Empty;

        }



    }
}
