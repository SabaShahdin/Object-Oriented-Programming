using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Staff :Person
    {
        protected string school;
        protected double pay;

        public Staff(string name , string address , string school , double pay) : base (name , address)
        {
            this.name = name;
            this.address = address;
            this.school = school;
            this.pay = pay;

        }
        public void setSchool(string school)
        {
            this.school = school;
        }
        public string  getSchool()
        {
            return school;
        }
        public void setpay(double pay)
        {
            this.pay = pay;
        }
        public double getPay()
        {
            return pay;
        }
        public override string toString()
        {
            return "School : " + school + "Pay : " + pay;
        }
    }

}
