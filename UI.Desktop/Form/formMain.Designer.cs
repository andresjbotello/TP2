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
            this.mnuUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuModulos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDocentesConCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modulosUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnsPrincipal
            // 
            this.mnsPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mnsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuArchivo});
            this.mnsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mnsPrincipal.Name = "mnsPrincipal";
            this.mnsPrincipal.Size = new System.Drawing.Size(1067, 28);
            this.mnsPrincipal.TabIndex = 1;
            this.mnsPrincipal.Text = "menuStrip1";
            // 
            // mnuArchivo
            // 
            this.mnuArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUsuarios,
            this.mnuMaterias,
            this.mnuComisiones,
            this.mnuPlanes,
            this.mnuEspecialidades,
            this.mnuCursos,
            this.mnuPersonas,
            this.mnuModulos,
            this.modulosUsuariosToolStripMenuItem,
            this.mnuDocentesConCursos,
            this.mnuSalir,
            this.salirToolStripMenuItem});
            this.mnuArchivo.Name = "mnuArchivo";
            this.mnuArchivo.Size = new System.Drawing.Size(73, 24);
            this.mnuArchivo.Text = "Archivo";
            // 
            // mnuUsuarios
            // 
            this.mnuUsuarios.Name = "mnuUsuarios";
            this.mnuUsuarios.Size = new System.Drawing.Size(229, 26);
            this.mnuUsuarios.Text = "Usuarios";
            this.mnuUsuarios.Click += new System.EventHandler(this.mnuUsuarios_Click);
            // 
            // mnuMaterias
            // 
            this.mnuMaterias.Name = "mnuMaterias";
            this.mnuMaterias.Size = new System.Drawing.Size(229, 26);
            this.mnuMaterias.Text = "Materias";
            this.mnuMaterias.Click += new System.EventHandler(this.mnuMaterias_Click);
            // 
            // mnuComisiones
            // 
            this.mnuComisiones.Name = "mnuComisiones";
            this.mnuComisiones.Size = new System.Drawing.Size(229, 26);
            this.mnuComisiones.Text = "Comisiones";
            this.mnuComisiones.Click += new System.EventHandler(this.mnuComisiones_Click);
            // 
            // mnuPlanes
            // 
            this.mnuPlanes.Name = "mnuPlanes";
            this.mnuPlanes.Size = new System.Drawing.Size(229, 26);
            this.mnuPlanes.Text = "Planes";
            this.mnuPlanes.Click += new System.EventHandler(this.mnuPlanes_Click);
            // 
            // mnuEspecialidades
            // 
            this.mnuEspecialidades.Name = "mnuEspecialidades";
            this.mnuEspecialidades.Size = new System.Drawing.Size(229, 26);
            this.mnuEspecialidades.Text = "Especialidades";
            this.mnuEspecialidades.Click += new System.EventHandler(this.mnuEspecialidades_Click);
            // 
            // mnuCursos
            // 
            this.mnuCursos.Name = "mnuCursos";
            this.mnuCursos.Size = new System.Drawing.Size(229, 26);
            this.mnuCursos.Text = "Cursos";
            this.mnuCursos.Click += new System.EventHandler(this.mnuCursos_Click);
            // 
            // mnuPersonas
            // 
            this.mnuPersonas.Name = "mnuPersonas";
            this.mnuPersonas.Size = new System.Drawing.Size(229, 26);
            this.mnuPersonas.Text = "Personas";
            this.mnuPersonas.Click += new System.EventHandler(this.mnuPersonas_Click);
            // 
            // mnuModulos
            // 
            this.mnuModulos.Name = "mnuModulos";
            this.mnuModulos.Size = new System.Drawing.Size(229, 26);
            this.mnuModulos.Text = "Modulos";
            this.mnuModulos.Click += new System.EventHandler(this.mnuModulos_Click);
            // 
            // mnuDocentesConCursos
            // 
            this.mnuDocentesConCursos.Name = "mnuDocentesConCursos";
            this.mnuDocentesConCursos.Size = new System.Drawing.Size(229, 26);
            this.mnuDocentesConCursos.Text = "Docentes con Cursos";
            this.mnuDocentesConCursos.Click += new System.EventHandler(this.mnuDocentesConCursos_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(229, 26);
            this.mnuSalir.Text = "Cerrar Sesion";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // modulosUsuariosToolStripMenuItem
            // 
            this.modulosUsuariosToolStripMenuItem.Name = "modulosUsuariosToolStripMenuItem";
            this.modulosUsuariosToolStripMenuItem.Size = new System.Drawing.Size(229, 26);
            this.modulosUsuariosToolStripMenuItem.Text = "Modulos Usuarios";
            this.modulosUsuariosToolStripMenuItem.Click += new System.EventHandler(this.modulosUsuariosToolStripMenuItem_Click);
            // 
            // formMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.mnsPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnsPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.ToolStripMenuItem mnuUsuarios;
        private System.Windows.Forms.ToolStripMenuItem mnuMaterias;
        private System.Windows.Forms.ToolStripMenuItem mnuPlanes;
        private System.Windows.Forms.ToolStripMenuItem mnuEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem mnuCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuPersonas;
        private System.Windows.Forms.ToolStripMenuItem mnuModulos;
        private System.Windows.Forms.ToolStripMenuItem mnuDocentesConCursos;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuComisiones;
        private System.Windows.Forms.ToolStripMenuItem modulosUsuariosToolStripMenuItem;
    }
}