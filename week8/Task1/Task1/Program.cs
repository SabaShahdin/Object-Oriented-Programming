using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Cylinder c = new Cylinder();
            double h = 2.0;
            double r = 3.0;
            c.SetHeight(h);
            c.setRadius(r);
            double volume1 = c.getVolume();
            Console.WriteLine("The volunme1 is " + volume1);
           
            Cylinder c1 = new Cylinder(1.0, 1.0);
            Cylinder c2 = new Cylinder(1.0, 1.0, "red");
            double volume = c1.getVolume();
            Console.WriteLine("The volunme is " + volume);
            Console.ReadKey();
        }
    }
}
