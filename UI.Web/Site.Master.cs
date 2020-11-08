using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            };
            Usuario usu = (Usuario)this.Session["usuario"];
            this.lbNombreUsuario.Text = String.Concat(usu.Apellido, ", ", usu.Nombre);
            PersonaLogic plo = new PersonaLogic();
            Persona p = plo.GetOne(usu.IdPersona);
            this.lbTipo.Text = p.TipoPersona.ToString();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void GotoHome(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}