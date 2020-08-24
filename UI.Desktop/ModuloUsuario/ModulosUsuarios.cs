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
    public partial class ModulosUsuarios : Form
    {
        private Persona _persona;
        public Persona Persona { get => _persona; set => _persona = value; }

        public ModulosUsuarios(Persona p)
        {
            InitializeComponent();
            Persona = p;
            bool e = Validaciones.Permisos(Persona);
            tsbNuevo.Enabled = e;
            tsbEditar.Enabled = e;
            tsbEliminar.Enabled = e;
            this.dgvModulosUsuarios.AutoGenerateColumns = false;
            this.dgvModulosUsuarios.MultiSelect = false;
            this.dgvModulosUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Listar();
        }


        public void Listar()
        {
            DocenteCursoLogic dcl = new DocenteCursoLogic();
            this.dgvModulosUsuarios.DataSource = dcl.GetAll();
        }

        private void DocentesCursos_Load(object sender, EventArgs e)
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
            DocenteCursoDesktop pd = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            pd.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if(this.dgvModulosUsuarios.SelectedRows.Count > 0) 
            {
                int ID = ((DocenteCurso)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop dcd = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                dcd.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para editarla");
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (this.dgvModulosUsuarios.SelectedRows.Count > 0)
            {
                int ID = ((DocenteCurso)this.dgvModulosUsuarios.SelectedRows[0].DataBoundItem).ID;
                DocenteCursoDesktop dcd = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
                dcd.ShowDialog();
                this.Listar();
            }
            else
            {
                MessageBox.Show("Elija una fila para eliminarla");
            }
        }
    }
}
