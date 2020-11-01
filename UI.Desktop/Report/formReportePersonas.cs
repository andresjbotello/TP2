using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop.Report
{
    public partial class formReportePersonas : Form
    {
        public formReportePersonas()
        {
            InitializeComponent();
            this.Load += formReportePersonas_Load;
        }
        private void formReportePersonas_Load(object sender, EventArgs e)
        {
            CargarReporte();
            this.reportViewer1.RefreshReport();
        }

        private void CargarReporte()
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report.informePersonas.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            RellenarReporte();
            this.reportViewer1.RefreshReport();
        }

        public void RellenarReporte()
        {
            PersonaLogic pl = new PersonaLogic();
            List<reportesPersonasObject> rpo = pl.GetAll().ConvertAll<reportesPersonasObject>(new Converter<Persona, reportesPersonasObject>(PersonasToreportesPersonasObject));
            ReportDataSource rds1 = new ReportDataSource("Personas", rpo);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
        }

        private static reportesPersonasObject PersonasToreportesPersonasObject(Persona p)
        {
            return new reportesPersonasObject(p);
        }

    }
}