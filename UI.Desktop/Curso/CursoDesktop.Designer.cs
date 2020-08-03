namespace UI.Desktop
{
    partial class CursoDesktop
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
            this.txtCal = new System.Windows.Forms.TextBox();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCupo = new System.Windows.Forms.Label();
            this.lblanioCal = new System.Windows.Forms.Label();
            this.lblidComision = new System.Windows.Forms.Label();
            this.lblidMateria = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cmbBoxMaterias = new System.Windows.Forms.ComboBox();
            this.cmbBoxComisiones = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCal
            // 
            this.txtCal.Location = new System.Drawing.Point(347, 59);
            this.txtCal.Name = "txtCal";
            this.txtCal.Size = new System.Drawing.Size(221, 20);
            this.txtCal.TabIndex = 12;
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(347, 115);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(221, 20);
            this.txtCupo.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Location = new System.Drawing.Point(420, 227);
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
            this.btnAceptar.Location = new System.Drawing.Point(266, 227);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(58, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(175, 20);
            this.txtID.TabIndex = 9;
            // 
            // lblCupo
            // 
            this.lblCupo.AutoSize = true;
            this.lblCupo.Location = new System.Drawing.Point(260, 112);
            this.lblCupo.Name = "lblCupo";
            this.lblCupo.Size = new System.Drawing.Size(32, 13);
            this.lblCupo.TabIndex = 6;
            this.lblCupo.Text = "Cupo";
            // 
            // lblanioCal
            // 
            this.lblanioCal.AutoSize = true;
            this.lblanioCal.Location = new System.Drawing.Point(260, 56);
            this.lblanioCal.Name = "lblanioCal";
            this.lblanioCal.Size = new System.Drawing.Size(81, 13);
            this.lblanioCal.TabIndex = 5;
            this.lblanioCal.Text = "Anio Calendario";
            // 
            // lblidComision
            // 
            this.lblidComision.AutoSize = true;
            this.lblidComision.Location = new System.Drawing.Point(3, 112);
            this.lblidComision.Name = "lblidComision";
            this.lblidComision.Size = new System.Drawing.Size(49, 13);
            this.lblidComision.TabIndex = 2;
            this.lblidComision.Text = "Comisión";
            // 
            // lblidMateria
            // 
            this.lblidMateria.AutoSize = true;
            this.lblidMateria.Location = new System.Drawing.Point(3, 56);
            this.lblidMateria.Name = "lblidMateria";
            this.lblidMateria.Size = new System.Drawing.Size(42, 13);
            this.lblidMateria.TabIndex = 1;
            this.lblidMateria.Text = "Materia";
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
            this.tableLayoutPanel1.Controls.Add(this.lblidMateria, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblidComision, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblanioCal, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCupo, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCupo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCal, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbBoxMaterias, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbBoxComisiones, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(571, 280);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cmbBoxMaterias
            // 
            this.cmbBoxMaterias.FormattingEnabled = true;
            this.cmbBoxMaterias.Location = new System.Drawing.Point(58, 59);
            this.cmbBoxMaterias.Name = "cmbBoxMaterias";
            this.cmbBoxMaterias.Size = new System.Drawing.Size(196, 21);
            this.cmbBoxMaterias.TabIndex = 19;
            // 
            // cmbBoxComisiones
            // 
            this.cmbBoxComisiones.FormattingEnabled = true;
            this.cmbBoxComisiones.Location = new System.Drawing.Point(58, 115);
            this.cmbBoxComisiones.Name = "cmbBoxComisiones";
            this.cmbBoxComisiones.Size = new System.Drawing.Size(196, 21);
            this.cmbBoxComisiones.TabIndex = 20;
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 296);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CursoDesktop";
            this.Text = "Informacion del Curso";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtCal;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCupo;
        private System.Windows.Forms.Label lblanioCal;
        private System.Windows.Forms.Label lblidComision;
        private System.Windows.Forms.Label lblidMateria;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cmbBoxMaterias;
        private System.Windows.Forms.ComboBox cmbBoxComisiones;
    }
}