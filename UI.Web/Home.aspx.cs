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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Hacemos esto para que si luego volves a entrar por el menu de inscripciones puedas ver todos las inscripciones no solo las del curso que viene dado
            Session["curso_id"] = null;
            Usuario usu = (Usuario)this.Session["usuario"];
            PersonaLogic plo = new PersonaLogic();
            if (usu != null)
            {
                Persona p = plo.GetOne(usu.IdPersona);
                if (p.TipoPersona == Persona.TipoPersonas.Alumno)
                {
                    this.mostrarMenu(false);
                    this.liInscripciones.Visible = true;
                }
                if (p.TipoPersona == Persona.TipoPersonas.Profesor)
                {
                    this.mostrarMenu(false);
                    this.liInscripcionesDC.Visible = true;
                }
                if (p.TipoPersona == Persona.TipoPersonas.Admin)
                {
                    this.mostrarMenu(true);
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
           

        }

        //Oculta todo, lo uso para que alumno no pueda tocar nada
        private void mostrarMenu(bool mostrar)
        {
            liComisiones.Visible = mostrar;
            liCursos.Visible = mostrar;
            liMaterias.Visible = mostrar;
            liPersonas.Visible = mostrar;
            liInscripcionesDC.Visible = mostrar;
            liInscripciones.Visible = mostrar;
            liPlanes.Visible = mostrar;
            liEspecialidades.Visible = mostrar;
        }
    }
}


