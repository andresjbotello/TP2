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
using UI.Desktop.Report;

namespace UI.Desktop
{
    public partial class formMain : Form
    {
        private Usuario _usuario;

        private Persona _persona;
        public Usuario Usuario { get => _usuario; set => _usuario = value; }
        public Persona Persona { get => _persona; set => _persona = value; }

        public formMain(Usuario usr)
        {
            InitializeComponent();
            Usuario = usr;
        }

        private void mnuMaterias_Click(object sender, EventArgs e)
        {
            UI.Desktop.Materias mtr = new UI.Desktop.Materias(Persona);
            mtr.ShowDialog();
        }

        private void mnuComisiones_Click(object sender, EventArgs e)
        {
            UI.Desktop.Comisiones com = new UI.Desktop.Comisiones(Persona);
            com.ShowDialog();
        }

        private void mnuPlanes_Click(object sender, EventArgs e)
        {
            UI.Desktop.Planes pln = new Planes(Persona);
            pln.ShowDialog();
        }

        private void mnuEspecialidades_Click(object sender, EventArgs e)
        {
            UI.Desktop.Especialiades esp = new Especialiades(Persona);
            esp.ShowDialog();
        }

        private void mnuCursos_Click(object sender, EventArgs e)
        {
            UI.Desktop.Cursos crs = new Cursos(Persona);
            crs.ShowDialog();
        }

        private void mnuPersonas_Click(object sender, EventArgs e)
        {
            UI.Desktop.Personas personas = new Personas(Persona);
            personas.ShowDialog();
        }

        private void mnuModulos_Click(object sender, EventArgs e)
        {
            UI.Desktop.Modulos mdl = new Modulos(Persona);
            mdl.ShowDialog();
        }

        private void mnuDocentesConCursos_Click(object sender, EventArgs e)
        {
            UI.Desktop.DocentesCursos docCursos = new DocentesCursos(Persona);
            docCursos.ShowDialog();
        }

        private void modulosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UI.Desktop.ModulosUsuarios modUsuarios = new ModulosUsuarios(Persona);
            modUsuarios.ShowDialog();
        }

        private void mnuSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //Oculta todo, lo uso para que alumno no pueda tocar nada
        private void mostrarMenu(bool mostrar)
        {
            mnuMaterias.Visible = mostrar;
            mnuPlanes.Visible = mostrar;
            mnuEspecialidades.Visible = mostrar;
            mnuCursos.Visible = mostrar;
            mnuPersonas.Visible = mostrar;
            mnuModulos.Visible = mostrar;
            mnuModUsuarios.Visible = mostrar;
            mnuDocentesConCursos.Visible = mostrar;
            tsmReportePersona.Visible = mostrar;
            tsmReportePlanes.Visible = mostrar;
            mnuReportes.Visible = mostrar;
        }


        private void formMain_Shown(object sender, EventArgs e)
        {
            PersonaLogic plo = new PersonaLogic();
            Persona = plo.GetOne(Usuario.ID);
            if (Persona != null)
            {
                if (Persona.TipoPersona == Business.Entities.Persona.TipoPersonas.Alumno)
                {
                    this.mostrarMenu(false);
                    mnuMaterias.Visible = true;
                    mnuPlanes.Visible = true;

                }
                if (Persona.TipoPersona == Persona.TipoPersonas.Profesor)
                {
                    this.mostrarMenu(false);
                    mnuMaterias.Visible = true;
                }
                if (Persona.TipoPersona == Persona.TipoPersonas.Admin)
                {
                    this.mostrarMenu(true);
                }
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void planesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formReportePlanes rplanes = new formReportePlanes();
            rplanes.ShowDialog();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formReportePersonas frp = new formReportePersonas();
            frp.ShowDialog();
        }
    }
}
