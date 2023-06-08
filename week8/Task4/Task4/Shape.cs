using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Shape
    {
        protected string name;
        public Shape ()
        {

        }
        public Shape (string name)
        {
            this.name = name;
        }
        public virtual double getArea()
        {
            return 0.0;
        }
        public virtual string toString()
        {
            return "name : " + name;
        }
    }
}
