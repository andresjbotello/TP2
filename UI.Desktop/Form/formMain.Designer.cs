namespace UI.Desktop
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnsPrincipal = new System.Windows.Forms.MenuStrip();
            this.mnuArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_listaDeUsuarios = new System.Windows.Forms.Button();
            this.btn_listaDeMaterias = new System.Windows.Forms.Button();
            this.btn_listaDePlanes = new System.Windows.Forms.Button();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(800, 24);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSalir});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(60, 20);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(96, 22);
            this.mnuSalir.Text = "Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // btn_listaDeUsuarios
            // 
            this.btn_listaDeUsuarios.Location = new System.Drawing.Point(61, 57);
            this.btn_listaDeUsuarios.Name = "btn_listaDeUsuarios";
            this.btn_listaDeUsuarios.Size = new System.Drawing.Size(151, 23);
            this.btn_listaDeUsuarios.TabIndex = 3;
            this.btn_listaDeUsuarios.Text = "Lista de Usuarios";
            this.btn_listaDeUsuarios.UseVisualStyleBackColor = true;
            this.btn_listaDeUsuarios.Click += new System.EventHandler(this.btn_abrirDGV);
            // 
            // btn_listaDeMaterias
            // 
            this.btn_listaDeMaterias.Location = new System.Drawing.Point(61, 109);
            this.btn_listaDeMaterias.Name = "btn_listaDeMaterias";
            this.btn_listaDeMaterias.Size = new System.Drawing.Size(151, 23);
            this.btn_listaDeMaterias.TabIndex = 5;
            this.btn_listaDeMaterias.Text = "Lista de Materias";
            this.btn_listaDeMaterias.UseVisualStyleBackColor = true;
            this.btn_listaDeMaterias.Click += new System.EventHandler(this.btn_listaDeMaterias_Click);
            // 
            // btn_listaDePlanes
            // 
            this.btn_listaDePlanes.Location = new System.Drawing.Point(61, 158);
            this.btn_listaDePlanes.Name = "btn_listaDePlanes";
            this.btn_listaDePlanes.Size = new System.Drawing.Size(151, 23);
            this.btn_listaDePlanes.TabIndex = 7;
            this.btn_listaDePlanes.Text = "Lista de Planes";
            this.btn_listaDePlanes.UseVisualStyleBackColor = true;
            this.btn_listaDePlanes.Click += new System.EventHandler(this.btn_listaDePlanes_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_listaDePlanes);
            this.Controls.Add(this.btn_listaDeMaterias);
            this.Controls.Add(this.btn_listaDeUsuarios);
            this.Controls.Add(this.mnsPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Name = "formMain";
            this.Text = "Academia";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.formMain_Shown);
            this.mnsPrincipal.ResumeLayout(false);
            this.mnsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnsPrincipal;
        private System.Windows.Forms.ToolStripMenuItem mnuArchivo;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.Button btn_listaDeUsuarios;
        private System.Windows.Forms.Button btn_listaDeMaterias;
        private System.Windows.Forms.Button btn_listaDePlanes;
    }
}