using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Circle
    {
        protected double radius;
        protected string colour;
        public Circle()
        {

        }
        public Circle (double radius)
        {
            this.radius = radius;
        }
        public Circle(double radius , string colour)
        {
            this.radius = radius;
            this.colour = colour;
        }
        public void setRadius(double radius)
        {
            this.radius = radius;
        }
        public void setColour(string colour)
        {
            this.colour = colour;
        }
        public double getRadius()
        {
            return radius;
        }
        public string getColour()
        {
            return colour;
        }
        public double getArea()
        {
            double area;
            area = 3.14 * radius * radius;
            return area;
        }
        public string toString()
        {
            string r = radius.ToString();
            return r;
        }
    }
}
