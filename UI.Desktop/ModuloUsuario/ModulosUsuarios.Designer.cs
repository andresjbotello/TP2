namespace UI.Desktop
{
    partial class ModulosUsuarios
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModulosUsuarios));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tlDocentesCursos = new System.Windows.Forms.TableLayoutPanel();
            this.dgvModulosUsuarios = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsDocentesCursos = new System.Windows.Forms.ToolStrip();
            this.tsbNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsbEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminar = new System.Windows.Forms.ToolStripButton();
            this.IDModulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consulta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlDocentesCursos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).BeginInit();
            this.tsDocentesCursos.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlDocentesCursos);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1035, 507);
            this.toolStripContainer1.Location = new System.Drawing.Point(16, 15);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1035, 538);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsDocentesCursos);
            // 
            // tlDocentesCursos
            // 
            this.tlDocentesCursos.ColumnCount = 2;
            this.tlDocentesCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentesCursos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlDocentesCursos.Controls.Add(this.dgvModulosUsuarios, 0, 0);
            this.tlDocentesCursos.Controls.Add(this.btnActualizar, 0, 1);
            this.tlDocentesCursos.Controls.Add(this.btnSalir, 1, 1);
            this.tlDocentesCursos.Location = new System.Drawing.Point(37, 23);
            this.tlDocentesCursos.Margin = new System.Windows.Forms.Padding(4);
            this.tlDocentesCursos.Name = "tlDocentesCursos";
            this.tlDocentesCursos.RowCount = 2;
            this.tlDocentesCursos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlDocentesCursos.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlDocentesCursos.Size = new System.Drawing.Size(940, 448);
            this.tlDocentesCursos.TabIndex = 0;
            // 
            // dgvModulosUsuarios
            // 
            this.dgvModulosUsuarios.AllowUserToAddRows = false;
            this.dgvModulosUsuarios.AllowUserToDeleteRows = false;
            this.dgvModulosUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvModulosUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDModulo,
            this.IDUsuario,
            this.Alta,
            this.Baja,
            this.Modificacion,
            this.Consulta});
            this.tlDocentesCursos.SetColumnSpan(this.dgvModulosUsuarios, 2);
            this.dgvModulosUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvModulosUsuarios.Location = new System.Drawing.Point(4, 4);
            this.dgvModulosUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvModulosUsuarios.Name = "dgvModulosUsuarios";
            this.dgvModulosUsuarios.ReadOnly = true;
            this.dgvModulosUsuarios.RowHeadersWidth = 51;
            this.dgvModulosUsuarios.Size = new System.Drawing.Size(932, 404);
            this.dgvModulosUsuarios.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(728, 416);
            this.btnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(100, 28);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(836, 416);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 28);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsDocentesCursos
            // 
            this.tsDocentesCursos.Dock = System.Windows.Forms.DockStyle.None;
            this.tsDocentesCursos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsDocentesCursos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNuevo,
            this.tsbEditar,
            this.tsbEliminar});
            this.tsDocentesCursos.Location = new System.Drawing.Point(4, 0);
            this.tsDocentesCursos.Name = "tsDocentesCursos";
            this.tsDocentesCursos.Size = new System.Drawing.Size(248, 27);
            this.tsDocentesCursos.TabIndex = 0;
            // 
            // tsbNuevo
            // 
            this.tsbNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsbNuevo.Image")));
            this.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNuevo.Name = "tsbNuevo";
            this.tsbNuevo.Size = new System.Drawing.Size(76, 24);
            this.tsbNuevo.Text = "Nuevo";
            this.tsbNuevo.Click += new System.EventHandler(this.tsbNuevo_Click);
            // 
            // tsbEditar
            // 
            this.tsbEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditar.Image")));
            this.tsbEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditar.Name = "tsbEditar";
            this.tsbEditar.Size = new System.Drawing.Size(72, 24);
            this.tsbEditar.Text = "Editar";
            this.tsbEditar.Click += new System.EventHandler(this.tsbEditar_Click);
            // 
            // tsbEliminar
            // 
            this.tsbEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminar.Image")));
            this.tsbEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminar.Name = "tsbEliminar";
            this.tsbEliminar.Size = new System.Drawing.Size(87, 24);
            this.tsbEliminar.Text = "Eliminar";
            this.tsbEliminar.Click += new System.EventHandler(this.tsbEliminar_Click);
            // 
            // IDModulo
            // 
            this.IDModulo.DataPropertyName = "IdModulo";
            this.IDModulo.HeaderText = "ID Modulo";
            this.IDModulo.MinimumWidth = 6;
            this.IDModulo.Name = "IDModulo";
            this.IDModulo.ReadOnly = true;
            this.IDModulo.Width = 125;
            // 
            // IDUsuario
            // 
            this.IDUsuario.DataPropertyName = "IdUsuario";
            this.IDUsuario.HeaderText = "ID Usuario";
            this.IDUsuario.MinimumWidth = 6;
            this.IDUsuario.Name = "IDUsuario";
            this.IDUsuario.ReadOnly = true;
            this.IDUsuario.Width = 125;
            // 
            // Alta
            // 
            this.Alta.DataPropertyName = "PermiteAlta";
            this.Alta.HeaderText = "Alta";
            this.Alta.MinimumWidth = 6;
            this.Alta.Name = "Alta";
            this.Alta.ReadOnly = true;
            this.Alta.Width = 125;
            // 
            // Baja
            // 
            this.Baja.DataPropertyName = "PermiteBaja";
            this.Baja.HeaderText = "Baja";
            this.Baja.MinimumWidth = 6;
            this.Baja.Name = "Baja";
            this.Baja.ReadOnly = true;
            this.Baja.Width = 125;
            // 
            // Modificacion
            // 
            this.Modificacion.DataPropertyName = "PermiteModificacion";
            this.Modificacion.HeaderText = "Modificacion";
            this.Modificacion.MinimumWidth = 6;
            this.Modificacion.Name = "Modificacion";
            this.Modificacion.ReadOnly = true;
            this.Modificacion.Width = 125;
            // 
            // Consulta
            // 
            this.Consulta.DataPropertyName = "PermiteConsulta";
            this.Consulta.HeaderText = "Consulta";
            this.Consulta.MinimumWidth = 6;
            this.Consulta.Name = "Consulta";
            this.Consulta.ReadOnly = true;
            this.Consulta.Width = 125;
            // 
            // ModulosUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ModulosUsuarios";
            this.Text = "Modulos Usuarios";
            this.Load += new System.EventHandler(this.DocentesCursos_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlDocentesCursos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModulosUsuarios)).EndInit();
            this.tsDocentesCursos.ResumeLayout(false);
            this.tsDocentesCursos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlDocentesCursos;
        private System.Windows.Forms.DataGridView dgvModulosUsuarios;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStrip tsDocentesCursos;
        private System.Windows.Forms.ToolStripButton tsbNuevo;
        private System.Windows.Forms.ToolStripButton tsbEditar;
        private System.Windows.Forms.ToolStripButton tsbEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDModulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consulta;
    }
}

