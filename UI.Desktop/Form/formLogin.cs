using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class formLogin : Form
    {

        private UsuarioLogic _usuarioLogic;
        public UsuarioLogic UsuarioLogic { get => _usuarioLogic; set => _usuarioLogic = value; }

        public formLogin()
        {
            InitializeComponent();
            UsuarioLogic = new UsuarioLogic();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string u = this.txtUsuario.Text;
            string p = this.txtPass.Text;

            Usuario usr = UsuarioLogic.Login(u, p);

            if (usr != null && usr.Habilitado) 
            {
                this.Hide();
                formMain fm = new formMain(usr);
                fm.ShowDialog();
                formLogin fl = new formLogin();
                fl.ShowDialog();
            }
        
            else if(usr != null && usr.Habilitado == false)
            {
                MessageBox.Show("Usuario no habilitado", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lnkOlvidePass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Es Ud. un usuario muy descuidado, haga memoria", "Olvidé mi contraseña", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #region Diseño
        private void txtUsuaurio_Enter(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuaurio_Leave(object sender, EventArgs e)
        {
            if(txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if(txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.LightGray;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if(txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }
        #endregion 
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
