namespace UI.Desktop
{
    partial class DocenteCursoDesktop
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
            this.components = new System.ComponentModel.Container();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblIDDocente = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblIDCurso = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbBoxCursos = new System.Windows.Forms.ComboBox();
            this.cmbBoxDocentes = new System.Windows.Forms.ComboBox();
            this.planAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbBoxTiposCargo = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Location = new System.Drawing.Point(421, 221);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(278, 221);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(44, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(159, 20);
            this.txtID.TabIndex = 9;
            // 
            // lblIDDocente
            // 
            this.lblIDDocente.AutoSize = true;
            this.lblIDDocente.Location = new System.Drawing.Point(278, 73);
            this.lblIDDocente.Name = "lblIDDocente";
            this.lblIDDocente.Size = new System.Drawing.Size(48, 13);
            this.lblIDDocente.TabIndex = 5;
            this.lblIDDocente.Text = "Docente";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Location = new System.Drawing.Point(3, 147);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(35, 13);
            this.lblCargo.TabIndex = 2;
            this.lblCargo.Text = "Cargo";
            // 
            // lblIDCurso
            // 
            this.lblIDCurso.AutoSize = true;
            this.lblIDCurso.Location = new System.Drawing.Point(3, 73);
            this.lblIDCurso.Name = "lblIDCurso";
            this.lblIDCurso.Size = new System.Drawing.Size(34, 13);
            this.lblIDCurso.TabIndex = 1;
            this.lblIDCurso.Text = "Curso";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(3, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 13);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIDCurso, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCargo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblIDDocente, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbBoxCursos, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbBoxDocentes, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbBoxTiposCargo, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.34247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.65753F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 292);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbBoxCursos
            // 
            this.cmbBoxCursos.FormattingEnabled = true;
            this.cmbBoxCursos.Location = new System.Drawing.Point(44, 76);
            this.cmbBoxCursos.Name = "cmbBoxCursos";
            this.cmbBoxCursos.Size = new System.Drawing.Size(159, 21);
            this.cmbBoxCursos.TabIndex = 19;
            // 
            // cmbBoxDocentes
            // 
            this.cmbBoxDocentes.FormattingEnabled = true;
            this.cmbBoxDocentes.Location = new System.Drawing.Point(359, 76);
            this.cmbBoxDocentes.Name = "cmbBoxDocentes";
            this.cmbBoxDocentes.Size = new System.Drawing.Size(199, 21);
            this.cmbBoxDocentes.TabIndex = 20;
            // 
            // planAdapterBindingSource
            // 
            this.planAdapterBindingSource.DataSource = typeof(Data.Database.PlanAdapter);
            // 
            // cmbBoxTiposCargo
            // 
            this.cmbBoxTiposCargo.FormattingEnabled = true;
            this.cmbBoxTiposCargo.Location = new System.Drawing.Point(44, 150);
            this.cmbBoxTiposCargo.Name = "cmbBoxTiposCargo";
            this.cmbBoxTiposCargo.Size = new System.Drawing.Size(159, 21);
            this.cmbBoxTiposCargo.TabIndex = 21;
            // 
            // DocenteCursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 322);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DocenteCursoDesktop";
            this.Text = "Informacion de Docente Curso";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblIDDocente;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblIDCurso;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource planAdapterBindingSource;
        private System.Windows.Forms.ComboBox cmbBoxCursos;
        private System.Windows.Forms.ComboBox cmbBoxDocentes;
        private System.Windows.Forms.ComboBox cmbBoxTiposCargo;
    }
}