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
    public partial class Especialidades : System.Web.UI.Page
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

        private EspecialidadLogic _especialidades;
        public EspecialidadLogic ELogic
        {
            get
            {
                if (_especialidades == null)
                {
                    _especialidades = new EspecialidadLogic();
                }
                return _especialidades;
            }
        }

        private Especialidad Entity
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
                            mpLabel.Text = "Especialidades";
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

            this.gridView.DataSource = this.ELogic.GetAll();
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
                this.formPanel.Visible = true;
                this.EnableForm(true);
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }
        }

        private void LoadForm(int id)
        {
            this.Entity = ELogic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;


        }


        private void LoadEntity(Especialidad especialidad)
        {
            especialidad.Descripcion = this.descripcionTextBox.Text;

        }

        private void SaveEntity(Especialidad especialidad)
        {
            this.ELogic.Save(especialidad);
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
                this.descripcionTextBox.Visible = false;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }



        private void DeleteEntity(int ID)
        {
            this.ELogic.Delete(ID);
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
            this.EnableForm(true);

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
                    this.Entity = new Especialidad();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Especialidad();
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

        protected void lnkReporte_Click(object sender, EventArgs e)
        {
            Response.Redirect("Report/reporteEspecialidades.aspx");
        }
    }
}