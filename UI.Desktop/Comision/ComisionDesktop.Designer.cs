namespace UI.Desktop
{
    partial class ComisionDesktop
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
            this.txtAnioEspecialidad = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtIDCom = new System.Windows.Forms.TextBox();
            this.lblAnioEspecialidad = new System.Windows.Forms.Label();
            this.lblIDPlan = new System.Windows.Forms.Label();
            this.lblDescCom = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.txtDescCom = new System.Windows.Forms.TextBox();
            this.txtIDPlan = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAnioEspecialidad
            // 
            this.txtAnioEspecialidad.Location = new System.Drawing.Point(464, 73);
            this.txtAnioEspecialidad.Margin = new System.Windows.Forms.Padding(4);
            this.txtAnioEspecialidad.Name = "txtAnioEspecialidad";
            this.txtAnioEspecialidad.Size = new System.Drawing.Size(293, 22);
            this.txtAnioEspecialidad.TabIndex = 12;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancelar.Location = new System.Drawing.Point(560, 280);
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
            this.btnAceptar.Location = new System.Drawing.Point(356, 280);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(100, 28);
            this.btnAceptar.TabIndex = 17;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtIDCom
            // 
            this.txtIDCom.Location = new System.Drawing.Point(94, 4);
            this.txtIDCom.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDCom.Name = "txtIDCom";
            this.txtIDCom.ReadOnly = true;
            this.txtIDCom.Size = new System.Drawing.Size(183, 22);
            this.txtIDCom.TabIndex = 9;
            // 
            // lblAnioEspecialidad
            // 
            this.lblAnioEspecialidad.AutoSize = true;
            this.lblAnioEspecialidad.Location = new System.Drawing.Point(339, 69);
            this.lblAnioEspecialidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAnioEspecialidad.Name = "lblAnioEspecialidad";
            this.lblAnioEspecialidad.Size = new System.Drawing.Size(117, 17);
            this.lblAnioEspecialidad.TabIndex = 5;
            this.lblAnioEspecialidad.Text = "Año Especialidad";
            // 
            // lblIDPlan
            // 
            this.lblIDPlan.AutoSize = true;
            this.lblIDPlan.Location = new System.Drawing.Point(4, 69);
            this.lblIDPlan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDPlan.Name = "lblIDPlan";
            this.lblIDPlan.Size = new System.Drawing.Size(53, 17);
            this.lblIDPlan.TabIndex = 2;
            this.lblIDPlan.Text = "ID Plan";
            // 
            // lblDescCom
            // 
            this.lblDescCom.AutoSize = true;
            this.lblDescCom.Location = new System.Drawing.Point(339, 0);
            this.lblDescCom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescCom.Name = "lblDescCom";
            this.lblDescCom.Size = new System.Drawing.Size(82, 17);
            this.lblDescCom.TabIndex = 1;
            this.lblDescCom.Text = "Descripción";
            this.lblDescCom.Click += new System.EventHandler(this.lblidMateria_Click);
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(4, 0);
            this.lblID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(82, 17);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID Comision";
            // 
            // txtDescCom
            // 
            this.txtDescCom.Location = new System.Drawing.Point(464, 4);
            this.txtDescCom.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescCom.Name = "txtDescCom";
            this.txtDescCom.Size = new System.Drawing.Size(293, 22);
            this.txtDescCom.TabIndex = 11;
            // 
            // txtIDPlan
            // 
            this.txtIDPlan.Location = new System.Drawing.Point(94, 73);
            this.txtIDPlan.Margin = new System.Windows.Forms.Padding(4);
            this.txtIDPlan.Name = "txtIDPlan";
            this.txtIDPlan.Size = new System.Drawing.Size(183, 22);
            this.txtIDPlan.TabIndex = 13;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAnioEspecialidad, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDCom, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtAnioEspecialidad, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblDescCom, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescCom, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblIDPlan, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtIDPlan, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(761, 345);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 364);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ComisionDesktop";
            this.Text = "Informacion de la comisión";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtAnioEspecialidad;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtIDCom;
        private System.Windows.Forms.Label lblAnioEspecialidad;
        private System.Windows.Forms.Label lblIDPlan;
        private System.Windows.Forms.Label lblDescCom;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtDescCom;
        private System.Windows.Forms.TextBox txtIDPlan;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}