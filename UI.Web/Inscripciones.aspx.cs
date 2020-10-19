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
    public partial class Inscripciones : System.Web.UI.Page
    {
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        List<Persona> Alumnos = new List<Persona>();
        List<Curso> Cursos = new List<Curso>();

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

        public FormModes FormMode
        {
            get
            {
                return (FormModes)this.ViewState["FormMode"];
            }
            set { this.ViewState["FormMode"] = value; }
        }

        private AlumnoInscripcionLogic _inscripciones;

        public AlumnoInscripcionLogic ILogic
        {
            get
            {
                if (_inscripciones == null)
                {
                    _inscripciones = new AlumnoInscripcionLogic();
                }
                return _inscripciones;
            }
        }

        private AlumnoInscripcion Entity
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
                    mpLabel.Text = "Inscripciones";
                }
                Usuario usu = (Usuario)this.Session["usuario"];
                Persona pers = PLogic.GetOne(usu.IdPersona);
                if (pers.TipoPersona != Persona.TipoPersonas.Profesor && pers.TipoPersona != Persona.TipoPersonas.Admin)
                {
                    ddlAlumno.Enabled = false;
                    ddlCurso.Enabled = false;
                    lbEditar.Visible = false;
                }
            }
        }

        private void LoadGrid()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            this.PanelABM.Visible = false;
            if (Session["curso_id"] != null)
            {
                int curso_id = (int)Session["curso_id"];
                inscripciones = this.ILogic.GetAll();
                inscripciones = inscripciones.Where(x => x.IDCurso == curso_id).ToList();
                this.lbNuevo.Visible = false;
            }
            else
            {
                Usuario usu = (Usuario)this.Session["usuario"];
                Persona pers = PLogic.GetOne(usu.IdPersona);
                if (pers.TipoPersona == Persona.TipoPersonas.Alumno)
                {
                    inscripciones = this.ILogic.GetAll();
                    inscripciones = inscripciones.Where(x => x.IDAlumno == pers.ID).ToList();
                }
                else
                {
                    inscripciones = this.ILogic.GetAll();
                }
            }
            this.gvInscripciones.DataSource = inscripciones;
            this.gvInscripciones.DataBind();
        }

        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvInscripciones.SelectedValue;
            this.PanelABM.Visible = false;
        }
        protected void editarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.PanelABM.Visible = true;
                this.EnableForm(true);
                if (Session["curso_id"] != null)
                {
                    this.ddlAlumno.Enabled = false;
                    this.ddlCurso.Enabled = false;
                }
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadForm(int id)
        {
            this.llenarDDL();

            this.Entity = ILogic.GetOne(id);

            this.tbNota.Text = Entity.Nota.ToString();
        }

        private void llenarDDL()
        {
            this.cargaListaAlumnos();
            this.cargaListaCursos();
            this.cargaListaCondiciones();
        }

        private void cargaListaCursos()
        {
            Cursos = new CursoLogic().GetAll();
            this.ddlCurso.DataSource = Cursos;
            this.ddlCurso.DataValueField = "ID";
            this.ddlCurso.DataTextField = "ID";
            this.ddlCurso.DataBind();
        }

        private void cargaListaAlumnos()
        {
            Alumnos = new PersonaLogic().GetAll(Persona.TipoPersonas.Alumno);
            this.ddlAlumno.DataSource = Alumnos;
            this.ddlAlumno.DataValueField = "ID";
            this.ddlAlumno.DataTextField = "Apellido";
            this.ddlAlumno.DataBind();
        }
        private void cargaListaCondiciones()
        {
            List<AlumnoInscripcion.Condicion> lista = new List<AlumnoInscripcion.Condicion>();
            lista = Enum.GetValues(typeof(AlumnoInscripcion.Condicion)).Cast<AlumnoInscripcion.Condicion>().ToList();
            ddlCondicion.DataSource = lista;
            ddlCondicion.DataBind();
        }
        private void LoadEntity(AlumnoInscripcion inscripcion)
        {
            Usuario usu = (Usuario)this.Session["usuario"];
            Persona pers = PLogic.GetOne(usu.IdPersona);
            if (pers.TipoPersona == Persona.TipoPersonas.Alumno)
            {
                inscripcion.IDAlumno = pers.ID;
            }
            else
            {
                inscripcion.IDAlumno = Convert.ToInt32(this.ddlAlumno.SelectedValue);
            }

            inscripcion.IDCurso = Convert.ToInt32(this.ddlCurso.SelectedValue);
            inscripcion.CondicionActual = ddlCondicion.SelectedValue;
            inscripcion.Nota = Convert.ToInt32(tbNota.Text);
        }

        private void SaveEntity(AlumnoInscripcion inscripcion)
        {
            this.ILogic.Save(inscripcion);
        }
        private void EnableForm(bool enable)
        {

            this.ddlCurso.Enabled = enable;
            this.ddlCondicion.Enabled = enable;
            this.tbNota.Enabled = enable;
            Usuario usu = (Usuario)this.Session["usuario"];
            Persona pers = PLogic.GetOne(usu.IdPersona);
            if (pers.TipoPersona == Persona.TipoPersonas.Alumno)
            {
                this.ddlAlumno.Visible = false;
            }
            else
            {
                this.ddlAlumno.Visible = enable;
            }
        }

        protected void eliminarLinkButton_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.PanelABM.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
        private void DeleteEntity(int ID)
        {
            this.ILogic.Delete(ID);
        }


        protected void nuevoLinkButton_Click(object sender, EventArgs e)
        {
            this.PanelABM.Visible = true;
            this.FormMode = FormModes.Alta;
            this.clearForm();
            this.EnableForm(true);
            this.llenarDDL();


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
                    this.Entity = new AlumnoInscripcion();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;
                case FormModes.Alta:
                    this.Entity = new AlumnoInscripcion();
                    this.LoadEntity(this.Entity);
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();
                    break;

                default:
                    break;
            }

            this.PanelABM.Visible = false;
        }
        private void clearForm()
        {
            this.tbNota.Text = string.Empty;
        }

        //private bool validar()
        //{
        //    if (Convert.ToInt32(tbNota) >= 0 && Convert.ToInt32(tbNota.Text) <= 10)
        //    {
        //        return true;
        //    }
        //    else
        //    {

        //    }
        //}

    }
}