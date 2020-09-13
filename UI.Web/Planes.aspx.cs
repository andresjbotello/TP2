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
    public partial class Planes : System.Web.UI.Page
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

        private PlanLogic _planes;
        public PlanLogic PLogic
        {
            get
            {
                if (_planes == null)
                {
                    _planes = new PlanLogic();
                }
                return _planes;
            }
        }
        private EspecialidadLogic _especialidad;
        public EspecialidadLogic ELogic
        {
            get
            {
                if (_especialidad == null)
                {
                    _especialidad = new EspecialidadLogic();
                }
                return _especialidad;
            }
        }
        private Plan Entity
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
                this.LoadGrid();
                Label mpLabel;
                mpLabel = (Label)Master.FindControl("MenuItemLabel");
                if (mpLabel != null)
                {
                    mpLabel.Visible = true;
                    mpLabel.Text = "Planes";
                }
            }
        }
        private void LoadGrid()
        {

            this.gridView.DataSource = this.PLogic.GetAll();
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
                this.formPanel.Visible = true;
                this.EnableForm(true);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadForm(int id)
        {
            this.Entity = PLogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.ddlEspecialidades.SelectedValue = this.Entity.IDEspecialidad.ToString();
        }

        private static List<Especialidad> _ListaEspecialidades;
        public List<Especialidad> ListaEspecialidades
        {
            get { return _ListaEspecialidades; }
            set { _ListaEspecialidades = value; }
        }

        private void cargaListaEspecialidades()
        {
            ListaEspecialidades = ELogic.GetAll();
            this.ddlEspecialidades.DataSource = ListaEspecialidades;
            this.ddlEspecialidades.DataValueField = "id";
            this.ddlEspecialidades.DataTextField = "Descripcion";
            this.ddlEspecialidades.DataBind();
        }


        private void LoadEntity(Plan plan)
        {
            plan.Descripcion = this.descripcionTextBox.Text;
            plan.IDEspecialidad = Convert.ToInt32(this.ddlEspecialidades.SelectedItem.Value);

        }

        private void SaveEntity(Plan plan)
        {
            try
            {
                this.PLogic.Save(plan);
            }
            catch
            {

            }
        }

        private void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;

        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {

                this.formPanel.Visible = true;
                this.descripcionTextBox.ReadOnly = true;
                this.ddlEspecialidades.Visible = false;
                this.especialidadLabel.Visible = false;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);

            }
        }



        private void DeleteEntity(int ID)
        {
            try
            {
                this.PLogic.Delete(ID);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
            this.EnableForm(true);
            cargaListaEspecialidades();
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
                    this.Entity = new Plan();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Plan();
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

        }

        protected void lbMostarListadoPlanes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Reportes/ReportePlanes.aspx");
        }
    }
}
