using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;
using System.Web.DynamicData;

namespace UI.Web
{
    public partial class Personas : System.Web.UI.Page
    {
        List<Persona> _ListaPersonas;

        public List<Persona> ListaPersonas { get => _ListaPersonas; set => _ListaPersonas = value; }

        private PersonaLogic _persona;
        public PersonaLogic PLogic
        {
            get
            {
                if (_persona == null)
                {
                    _persona = new PersonaLogic();
                }
                return _persona;
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

        private Persona Entity
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
                            mpLabel.Text = "Personas";
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
            this.ListaPersonas = this.PLogic.GetAll();
            this.gridView.DataSource = this.ListaPersonas;
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
            this.Entity = this.PLogic.GetOne(id);

            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.direccionTextBox.Text = this.Entity.Direccion;
            this.telefonoTextBox.Text = this.Entity.Telefono;
            this.fechaNacimientoTextBox.Text = this.Entity.FechaNacimiento.ToString();
            this.legajoTextBox.Text = this.Entity.Legajo.ToString();
            this.ddlPlanes.SelectedValue = this.Entity.IDPlan.ToString();
            this.ddlTipoPersonas.SelectedValue = this.Entity.GetIDTipoPersona().ToString();

            this.usuarioTextBox.Text = this.Entity.Usuario.NombreUsuario;
            this.habilitadoCheckBox.Checked = this.Entity.Usuario.Habilitado;
        }

        private void LoadEntity(Persona persona)
        {
            persona.Nombre = this.nombreTextBox.Text;
            persona.Apellido = this.apellidoTextBox.Text;
            persona.Email = this.emailTextBox.Text;
            persona.Direccion = this.direccionTextBox.Text;
            persona.Telefono = this.telefonoTextBox.Text;
            persona.FechaNacimiento = Convert.ToDateTime(this.fechaNacimientoTextBox.Text);
            persona.Legajo = int.Parse(this.legajoTextBox.Text);
            persona.IDPlan = Convert.ToInt32(this.ddlPlanes.SelectedItem.Value);
            persona.SetTipoPersonaById(Convert.ToInt32(this.ddlTipoPersonas.SelectedItem.Value));

            persona.Usuario.NombreUsuario = this.nombreTextBox.Text;
            persona.Usuario.Nombre = this.nombreTextBox.Text;
            persona.Usuario.Apellido = this.apellidoTextBox.Text;
            persona.Usuario.Email = this.emailTextBox.Text;
            persona.Usuario.Habilitado = this.habilitadoCheckBox.Checked;

        }

        private void SaveEntity(Persona persona)
        {
            this.PLogic.Save(persona, true);
        }

        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.direccionTextBox.Enabled = enable;
            this.telefonoTextBox.Enabled = enable;
            this.fechaNacimientoTextBox.Enabled = enable;
            this.legajoTextBox.Enabled = enable;
            this.ddlPlanes.Enabled = enable;
            this.ddlTipoPersonas.Enabled = enable;
            this.habilitadoCheckBox.Enabled = enable;
            this.usuarioTextBox.Enabled = enable;
        }

        #region Accion buttons click

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

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.planLabel.Visible = true;
                this.ddlPlanes.Enabled = false;
                this.tipoPersonaLabel.Visible = true;
                this.ddlTipoPersonas.Enabled = false;
                this.nombreTextBox.ReadOnly = true;
                this.apellidoTextBox.ReadOnly = true;
                this.emailTextBox.ReadOnly = true;
                this.fechaNacimientoTextBox.ReadOnly = true;
                this.direccionTextBox.ReadOnly = true;
                this.telefonoTextBox.ReadOnly = true;
                this.legajoTextBox.ReadOnly = true;
                this.usuarioTextBox.ReadOnly = true;
                this.habilitadoCheckBox.Enabled = false;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.SelectedID = -1;
            this.gridView.SelectedIndex = -1;
            this.formPanel.Visible = true;
            this.ddlPlanes.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
            this.EnableForm(true);
            this.ddlPlanes.ClearSelection();
            this.ddlTipoPersonas.ClearSelection();
            this.cargaListas();

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
                    Persona p = (from persona in ListaPersonas
                                 where persona.ID == this.SelectedID
                                 select persona).First();

                    p.State = BusinessEntity.States.Deleted;
                    this.SaveEntity(p);
                    this.SelectedID = -1;
                    this.gridView.SelectedIndex = -1;
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = (from persona in ListaPersonas
                                   where persona.ID == this.SelectedID
                                   select persona).First();
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.SelectedID = -1;
                    this.gridView.SelectedIndex = -1;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
                    this.Entity.Usuario = new Usuario();
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
            this.cargaListaPlanes();
            this.cargaListaTiposPersona();
            this.cargaListaTiposPersona();
        }

        private void cargaListaPlanes()
        {
            ListaPlanes = PlanLogic.GetAll();
            this.ddlPlanes.DataSource = ListaPlanes;
            this.ddlPlanes.DataValueField = "id";
            this.ddlPlanes.DataTextField = "Descripcion";
            this.ddlPlanes.DataBind();
        }

        private void cargaListaTiposPersona()
        {
            if (this.ddlTipoPersonas.Items.Count == 0)
            {
                List<Persona.TipoPersonas> tipoPersonas = Enum.GetValues(typeof(Persona.TipoPersonas)).Cast<Persona.TipoPersonas>().ToList();

                foreach (Persona.TipoPersonas tipoPersona in tipoPersonas)
                {
                    ListItem item = new ListItem(tipoPersona.ToString(), ((int)tipoPersona).ToString());

                    this.ddlTipoPersonas.Items.Add(item);
                }
            }

        }
        #endregion



        private void clearForm()
        {
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.direccionTextBox.Text = string.Empty;
            this.telefonoTextBox.Text = string.Empty;
            this.legajoTextBox.Text = string.Empty;
            this.usuarioTextBox.Text = string.Empty;
            this.fechaNacimientoTextBox.Text = string.Empty;

        }

    }
}