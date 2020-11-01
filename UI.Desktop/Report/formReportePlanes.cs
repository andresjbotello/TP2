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
    public partial class formReportePlanes : Form
    {
        public formReportePlanes()
        {
            InitializeComponent();
            this.Load += formReportePlanes_Load;
        }
        private void formReportePlanes_Load(object sender, EventArgs e)
        {
            CargarReporte();
            this.reportViewer1.RefreshReport();
        }

        private void CargarReporte()
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report.informePlanes.rdlc";
            this.reportViewer1.LocalReport.DataSources.Clear();
            RellenarReporte();
            this.reportViewer1.RefreshReport();
        }

        public void RellenarReporte()
        {
            PlanLogic pl = new PlanLogic();
            List<reportesPlanesObject> rpo = pl.GetAll().ConvertAll<reportesPlanesObject>(new Converter<Plan, reportesPlanesObject>(PlanToreportesPlanesObject));
            ReportDataSource rds1 = new ReportDataSource("Planes", rpo);
            this.reportViewer1.LocalReport.DataSources.Add(rds1);
        }

        private static reportesPlanesObject PlanToreportesPlanesObject(Plan p)
        {
            return new reportesPlanesObject(p);
        }

    }
}
