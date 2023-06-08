using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class RectangleUI
    {
        public static Rectangle Addrectangle()
        {
            Console.Write("Entre height ");
            int height = int.Parse(Console.ReadLine());
            Console.Write("Entre width");
            int width = int.Parse(Console.ReadLine());
            Rectangle r1 = new Rectangle(height, width, "Rectangle");
            return r1;
        }
    }
}
