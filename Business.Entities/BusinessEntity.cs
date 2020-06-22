using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {

        public BusinessEntity()
        {
            this.State = States.New;
        }

        private int _ID;
        public int ID { get => _ID; set => _ID = value; }

        private States _State;
        public States State { get => _State; set => _State = value; }


        public enum States 
        {
            Deleted, New, Modified, Unmodified
        }
    }
}
