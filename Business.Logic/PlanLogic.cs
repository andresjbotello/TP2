using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Business.Logic
{
    public class PlanLogic: BusinessLogic
    {
        public PlanLogic()
        {
            PlanData = new PlanAdapter();
        }

        private PlanAdapter _PlanData;
        public PlanAdapter PlanData { get => _PlanData; set => _PlanData = value; }


        public Business.Entities.Plan GetOne(int id)
        {
            return PlanData.GetOne(id);
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }

        public void Save(Business.Entities.Plan obj)
        {
            PlanData.Save(obj);
        }

        public void Delete(int id)
        {
            PlanData.Delete(id);
        }
    }
}
