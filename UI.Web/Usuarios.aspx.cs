using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        UsuarioLogic _usuarioLogic;

        public UsuarioLogic UsuarioLogic { get => (_usuarioLogic == null) ? new UsuarioLogic() : _usuarioLogic; set => _usuarioLogic = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Llamar unicamente cuando es la primera vez que se ingresa
            if (Page.IsPostBack == false)
            {
                this.LoadGrid();
            }
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = this.UsuarioLogic.GetAll();
            this.GridView.DataBind();
        }
        
    }
}