using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace UI.Desktop.Report
{
    public class reportesPlanesObject
    {
        int _id;

        string _plan;

        string _especialidad;

            

        public reportesPlanesObject(Plan plan)
        {
            this.Id = plan.ID;
            this.Plan = plan.Descripcion;
            this.Especialidad = plan.Especialidad.Descripcion;
        }

        public int Id { get => _id; set => _id = value; }
        public string Plan { get => _plan; set => _plan = value; }
        public string Especialidad { get => _especialidad; set => _especialidad = value; }
    }
}
