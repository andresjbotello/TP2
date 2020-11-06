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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (this.Session["usuario"] != null)
                {
                    Response.Redirect("Home.aspx");
                }
            }
            
        }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            estadolbl.Text = string.Format("Contacte a División Alumnos");
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            // Acá delegamos la validación al servidor
            UsuarioLogic userLogic = new UsuarioLogic();
            //Se puede ingresar sin claves para las pruebas
            if (this.txtUsuario.Text != "" && this.txtClave.Text != "")
            {
                Usuario u = userLogic.Login(this.txtUsuario.Text.ToString(), this.txtClave.Text.ToString());
                if (u != null)
                {
                    Session["usuario"] = u;
                    Response.Redirect("Home.aspx");
                }    
            }
            estadolbl.Text = string.Format("Clave y/o Usuario invalido/s");
        }
    }
}