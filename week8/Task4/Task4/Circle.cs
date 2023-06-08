using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class Circle : Shape
    {
        private int radius;

        public Circle(int radius, string name) : base(name)
        {
            this.radius = radius;
            this.name = name;
        }
        public Circle ()
        {

        }
        public void setRadius(int radius)
        {
            this.radius = radius;
        }
        public int getRadius()
        {
            return radius;

        }
        public override double getArea()
        {
            double area = 2 * 3.14 * radius * radius;
            return area;
        }
        public override string toString()
        {
            return  base.toString();
        }
    }
}
