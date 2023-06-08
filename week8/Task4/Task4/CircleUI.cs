using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class CircleUI
    {
        public  static Circle AddCircle()
        {
            Console.Write("Entre radius ");
            int radius = int.Parse(Console.ReadLine());
            Circle c1 = new Circle(radius, "Circle ");
            return c1;
        }
    }
}
