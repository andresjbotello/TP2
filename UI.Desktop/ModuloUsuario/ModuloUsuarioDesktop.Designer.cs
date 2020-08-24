namespace UI.Desktop
{
    partial class ModuloUsuarioDesktop
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
            this.txtIDModUsr = new System.Windows.Forms.TextBox();
            this.lblAlta = new System.Windows.Forms.Label();
            this.lblIDUsr = new System.Windows.Forms.Label();
            this.lblIDMod = new System.Windows.Forms.Label();
            this.lblIDModUsr = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.planAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtBaja = new System.Windows.Forms.TextBox();
            this.txtAlta = new System.Windows.Forms.TextBox();
            this.txtModi = new System.Windows.Forms.TextBox();
            this.lblBaja = new System.Windows.Forms.Label();
            this.lblModi = new System.Windows.Forms.Label();
            this.lblConsulta = new System.Windows.Forms.Label();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.txtIDMod = new System.Windows.Forms.TextBox();
            this.txtIDUsr = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Location = new System.Drawing.Point(644, 312);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnAceptar.Location = new System.Drawing.Point(536, 312);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtIDModUsr
            // 
            this.txtIDModUsr.Location = new System.Drawing.Point(117, 4);
            this.txtIDModUsr.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDModUsr.Name = "txtIDModUsr";
            this.txtIDModUsr.ReadOnly = true;
            this.txtIDModUsr.Size = new System.Drawing.Size(211, 22);
            this.txtIDModUsr.TabIndex = 9;
            // 
            // lblAlta
            // 
            this.lblAlta.AutoSize = true;
            this.lblAlta.Location = new System.Drawing.Point(536, 0);
            this.lblAlta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAlta.Name = "lblAlta";
            this.lblAlta.Size = new System.Drawing.Size(32, 17);
            this.lblAlta.TabIndex = 5;
            this.lblAlta.Text = "Alta";
            // 
            // lblIDUsr
            // 
            this.lblIDUsr.AutoSize = true;
            this.lblIDUsr.Location = new System.Drawing.Point(4, 155);
            this.lblIDUsr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDUsr.Name = "lblIDUsr";
            this.lblIDUsr.Size = new System.Drawing.Size(74, 17);
            this.lblIDUsr.TabIndex = 2;
            this.lblIDUsr.Text = "ID Usuario";
            // 
            // lblIDMod
            // 
            this.lblIDMod.AutoSize = true;
            this.lblIDMod.Location = new System.Drawing.Point(4, 77);
            this.lblIDMod.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDMod.Name = "lblIDMod";
            this.lblIDMod.Size = new System.Drawing.Size(71, 17);
            this.lblIDMod.TabIndex = 1;
            this.lblIDMod.Text = "ID Modulo";
            // 
            // lblIDModUsr
            // 
            this.lblIDModUsr.AutoSize = true;
            this.lblIDModUsr.Location = new System.Drawing.Point(4, 0);
            this.lblIDModUsr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDModUsr.Name = "lblIDModUsr";
            this.lblIDModUsr.Size = new System.Drawing.Size(105, 17);
            this.lblIDModUsr.TabIndex = 0;
            this.lblIDModUsr.Text = "ID Mod Usuario";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.txtIDUsr, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDMod, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIDModUsr, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIDMod, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblIDUsr, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtIDModUsr, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAlta, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtAlta, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBaja, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtModi, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBaja, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblModi, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblConsulta, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtConsulta, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.34247F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.65753F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(748, 359);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // planAdapterBindingSource
            // 
            this.planAdapterBindingSource.DataSource = typeof(Data.Database.PlanAdapter);
            // 
            // txtBaja
            // 
            this.txtBaja.Location = new System.Drawing.Point(643, 80);
            this.txtBaja.Name = "txtBaja";
            this.txtBaja.Size = new System.Drawing.Size(100, 22);
            this.txtBaja.TabIndex = 22;
            // 
            // txtAlta
            // 
            this.txtAlta.Location = new System.Drawing.Point(643, 3);
            this.txtAlta.Name = "txtAlta";
            this.txtAlta.Size = new System.Drawing.Size(100, 22);
            this.txtAlta.TabIndex = 23;
            // 
            // txtModi
            // 
            this.txtModi.Location = new System.Drawing.Point(643, 158);
            this.txtModi.Name = "txtModi";
            this.txtModi.Size = new System.Drawing.Size(100, 22);
            this.txtModi.TabIndex = 24;
            // 
            // lblBaja
            // 
            this.lblBaja.AutoSize = true;
            this.lblBaja.Location = new System.Drawing.Point(535, 77);
            this.lblBaja.Name = "lblBaja";
            this.lblBaja.Size = new System.Drawing.Size(36, 17);
            this.lblBaja.TabIndex = 25;
            this.lblBaja.Text = "Baja";
            // 
            // lblModi
            // 
            this.lblModi.AutoSize = true;
            this.lblModi.Location = new System.Drawing.Point(535, 155);
            this.lblModi.Name = "lblModi";
            this.lblModi.Size = new System.Drawing.Size(86, 17);
            this.lblModi.TabIndex = 26;
            this.lblModi.Text = "Modificacion";
            // 
            // lblConsulta
            // 
            this.lblConsulta.AutoSize = true;
            this.lblConsulta.Location = new System.Drawing.Point(535, 231);
            this.lblConsulta.Name = "lblConsulta";
            this.lblConsulta.Size = new System.Drawing.Size(63, 17);
            this.lblConsulta.TabIndex = 27;
            this.lblConsulta.Text = "Consulta";
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(643, 234);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(100, 22);
            this.txtConsulta.TabIndex = 28;
            // 
            // txtIDMod
            // 
            this.txtIDMod.Location = new System.Drawing.Point(116, 80);
            this.txtIDMod.Name = "txtIDMod";
            this.txtIDMod.Size = new System.Drawing.Size(100, 22);
            this.txtIDMod.TabIndex = 29;
            // 
            // txtIDUsr
            // 
            this.txtIDUsr.Location = new System.Drawing.Point(116, 158);
            this.txtIDUsr.Name = "txtIDUsr";
            this.txtIDUsr.Size = new System.Drawing.Size(100, 22);
            this.txtIDUsr.TabIndex = 30;
            // 
            // ModuloUsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 396);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ModuloUsuarioDesktop";
            this.Text = "Modulo Usuario";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planAdapterBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtIDModUsr;
        private System.Windows.Forms.Label lblAlta;
        private System.Windows.Forms.Label lblIDUsr;
        private System.Windows.Forms.Label lblIDMod;
        private System.Windows.Forms.Label lblIDModUsr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.BindingSource planAdapterBindingSource;
        private System.Windows.Forms.TextBox txtAlta;
        private System.Windows.Forms.TextBox txtBaja;
        private System.Windows.Forms.TextBox txtModi;
        private System.Windows.Forms.Label lblBaja;
        private System.Windows.Forms.Label lblModi;
        private System.Windows.Forms.Label lblConsulta;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.TextBox txtIDUsr;
        private System.Windows.Forms.TextBox txtIDMod;
    }
}