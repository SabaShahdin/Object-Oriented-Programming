using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class ShapeDL
    {
        public static List<Shape> s = new List<Shape>();
        public static void AddIntoList(Shape s1)
        {
            s.Add(s1);
        }
    }
}
