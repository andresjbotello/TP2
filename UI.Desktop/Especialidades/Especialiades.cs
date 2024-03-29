﻿using System;
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
    public partial class Especialiades : Form
    {
        private Persona _persona;
        public Persona Persona { get => _persona; set => _persona = value; }

        public Especialiades(Persona p)
        {
            InitializeComponent();
            Persona = p;
            bool e = Validaciones.Permisos(Persona);
            tsbNuevo.Enabled = e;
            tsbEditar.Enabled = e;
            tsbEliminar.Enabled = e;
            this.dgvEspecialidades.AutoGenerateColumns = false;
            this.dgvEspecialidades.MultiSelect = false;
            this.dgvEspecialidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Listar();
        }


        public void Listar()
        {
            Business.Logic.EspecialidadLogic el = new Business.Logic.EspecialidadLogic();
            this.dgvEspecialidades.DataSource = el.GetAll();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadDesktop ed = new EspecialidadDesktop(ApplicationForm.ModoForm.Alta);
            ed.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvEspecialidades.SelectedRows.Count > 0) 
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ed = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                ed.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para editarla");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvEspecialidades.SelectedRows.Count > 0)
            {
                int ID = ((Business.Entities.Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;
                EspecialidadDesktop ed = new EspecialidadDesktop(ID, ApplicationForm.ModoForm.Baja);
                ed.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para eliminarla");
            }
        }
    }
}
