namespace UI.Desktop
{
    partial class AlumnoInscripcionDesktop
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
            this.txtIDInscripcion = new System.Windows.Forms.TextBox();
            this.lblCondicion = new System.Windows.Forms.Label();
            this.lblIDCurso = new System.Windows.Forms.Label();
            this.lblIDAlumno = new System.Windows.Forms.Label();
            this.lblIDInscripcion = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.planAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblNota = new System.Windows.Forms.Label();
            this.txtIDAlumno = new System.Windows.Forms.TextBox();
            this.txtIDCurso = new System.Windows.Forms.TextBox();
            this.txtCondicion = new System.Windows.Forms.TextBox();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Location = new System.Drawing.Point(589, 271);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 28);
            this.btnCancelar.TabIndex = 18;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(426, 271);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtIDInscripcion
            // 
            this.txtIDInscripcion.Location = new System.Drawing.Point(104, 4);
            this.txtIDInscripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIDInscripcion.Name = "txtIDInscripcion";
            this.txtIDInscripcion.ReadOnly = true;
            this.txtIDInscripcion.Size = new System.Drawing.Size(211, 22);
            this.txtIDInscripcion.TabIndex = 9;
            // 
            // lblCondicion
            // 
            this.lblCondicion.AutoSize = true;
            this.lblCondicion.Location = new System.Drawing.Point(426, 89);
            this.lblCondicion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCondicion.Name = "lblCondicion";
            this.lblCondicion.Size = new System.Drawing.Size(70, 17);
            this.lblCondicion.TabIndex = 5;
            this.lblCondicion.Text = "Condicion";
            // 
            // lblIDCurso
            // 
            this.lblIDCurso.AutoSize = true;
            this.lblIDCurso.Location = new System.Drawing.Point(4, 179);
            this.lblIDCurso.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDCurso.Name = "lblIDCurso";
            this.lblIDCurso.Size = new System.Drawing.Size(62, 17);
            this.lblIDCurso.TabIndex = 2;
            this.lblIDCurso.Text = "ID Curso";
            // 
            // lblIDAlumno
            // 
            this.lblIDAlumno.AutoSize = true;
            this.lblIDAlumno.Location = new System.Drawing.Point(4, 89);
            this.lblIDAlumno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDAlumno.Name = "lblIDAlumno";
            this.lblIDAlumno.Size = new System.Drawing.Size(72, 17);
            this.lblIDAlumno.TabIndex = 1;
            this.lblIDAlumno.Text = "ID Alumno";
            // 
            // lblIDInscripcion
            // 
            this.lblIDInscripcion.AutoSize = true;
            this.lblIDInscripcion.Location = new System.Drawing.Point(4, 0);
            this.lblIDInscripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDInscripcion.Name = "lblIDInscripcion";
            this.lblIDInscripcion.Size = new System.Drawing.Size(92, 17);
            this.lblIDInscripcion.TabIndex = 0;
            this.lblIDInscripcion.Text = "ID Inscripción";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblIDInscripcion, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIDAlumno, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIDCurso, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCondicion, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDInscripcion, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNota, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDAlumno, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDCurso, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCondicion, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNota, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.34247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.65753F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(748, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // planAdapterBindingSource
            // 
            this.planAdapterBindingSource.DataSource = typeof(Data.Database.PlanAdapter);
            // 
            // lblNota
            // 
            this.lblNota.AutoSize = true;
            this.lblNota.Location = new System.Drawing.Point(426, 179);
            this.lblNota.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNota.Name = "lblNota";
            this.lblNota.Size = new System.Drawing.Size(38, 17);
            this.lblNota.TabIndex = 22;
            this.lblNota.Text = "Nota";
            // 
            // txtIDAlumno
            // 
            this.txtIDAlumno.Location = new System.Drawing.Point(103, 92);
            this.txtIDAlumno.Name = "txtIDAlumno";
            this.txtIDAlumno.Size = new System.Drawing.Size(212, 22);
            this.txtIDAlumno.TabIndex = 23;
            // 
            // txtIDCurso
            // 
            this.txtIDCurso.Location = new System.Drawing.Point(103, 182);
            this.txtIDCurso.Name = "txtIDCurso";
            this.txtIDCurso.Size = new System.Drawing.Size(212, 22);
            this.txtIDCurso.TabIndex = 24;
            // 
            // txtCondicion
            // 
            this.txtCondicion.Location = new System.Drawing.Point(533, 92);
            this.txtCondicion.Name = "txtCondicion";
            this.txtCondicion.Size = new System.Drawing.Size(212, 22);
            this.txtCondicion.TabIndex = 25;
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(533, 182);
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(212, 22);
            this.txtNota.TabIndex = 26;
            // 
            // AlumnoInscripcionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "AlumnoInscripcionDesktop";
            this.Text = "Informacion de Alumno Inscripcion";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtIDInscripcion;
        private System.Windows.Forms.Label lblCondicion;
        private System.Windows.Forms.Label lblIDCurso;
        private System.Windows.Forms.Label lblIDAlumno;
        private System.Windows.Forms.Label lblIDInscripcion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource planAdapterBindingSource;
        private System.Windows.Forms.Label lblNota;
        private System.Windows.Forms.TextBox txtIDAlumno;
        private System.Windows.Forms.TextBox txtIDCurso;
        private System.Windows.Forms.TextBox txtCondicion;
        private System.Windows.Forms.TextBox txtNota;
    }
}