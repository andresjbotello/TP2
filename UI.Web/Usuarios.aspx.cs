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
    public partial class Usuarios : System.Web.UI.Page
    {
        private UsuarioLogic _logic;
        public UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }
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

        private Usuario Entity
        {
            get;
            set;
        }

        //PAra rellenar el droplist de personas
        private static List<Persona> _ListaPersonas;
        public List<Persona> ListaPersonas
        {
            get { return _ListaPersonas; }
            set { _ListaPersonas = value; }
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
                    mpLabel.Text = "Usuarios";
                }
            }
        }
        private void LoadGrid()
        {
            //this.gridView.DataSource = this.Logic.GetAll();
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
            //this.Entity = this.Logic.GetOne(id);
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.habilitadoCheckbox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;

        }


        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.Email = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckbox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            //this.Logic.Save(usuario);
        }

        private void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.nombreUsuarioLabel.Enabled = enable;
            this.claveTextBox.Visible = enable;
            this.claveLabel.Visible = enable;
            this.repetirClaveTextBox.Visible = enable;
            this.repetirClaveLabel.Visible = enable;
            //this.aceptarLinkButton.Enabled = enable;
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.nombreUsuarioTextBox.Visible = false;
                this.RequiredFieldValidator2.Visible = false;
                this.RequiredFieldValidator1.Visible = false;
                this.RegularExpressionValidarEmail.Visible = false;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        ///Debido a que los controles quedan deshabilitados luego de ingresar al formulario para eliminar un Usuario
        ///hay que volver a habilitarlos antes de Editar. Para lograr esto alcanza con agregar una llamada
        ///al método EnableForm en el Event Handler de editarLinkButton ya existente. (Nota que se encontraba en el tp) 

        private void DeleteEntity(int ID)
        {
            //this.Logic.Delete(ID);
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
            this.EnableForm(true);
            ListaPersonas = PLogic.GetAll(Persona.TipoPersonas.Alumno);

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
                    this.Entity = new Usuario();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
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
            this.nombreTextBox.Text = string.Empty;
            this.apellidoTextBox.Text = string.Empty;
            this.emailTextBox.Text = string.Empty;
            this.habilitadoCheckbox.Checked = false;
            this.nombreUsuarioTextBox.Text = string.Empty;

        }
    }
}