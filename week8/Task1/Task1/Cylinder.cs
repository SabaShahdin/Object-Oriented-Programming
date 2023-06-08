using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Cylinder : Circle
    {
        private double height;

        public Cylinder() : base()
        {

        }
        public Cylinder(double height)
        {
            this.height = height;
        }
        public Cylinder(double height , double radius) : base (radius)
        {
            this.height = height;
            this.radius = radius;
        }
        public Cylinder(double height, double radius , string colour) : base(radius , colour)
        {
            this.height = height;
            this.radius = radius;
            this.colour = colour;
        }
        public void SetHeight (double height)
        {
            this.height = height;
        }
        public double getHeight()
        {
            return height;
        }
        public double getVolume()
        {
            double volume;
            volume = 3.14 * radius * radius * height;
            return volume;
        }
    }
}
