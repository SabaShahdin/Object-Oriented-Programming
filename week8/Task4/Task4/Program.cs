using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {

            Circle c1 = new Circle();
            c1 = CircleUI.AddCircle();
            Rectangle r1 = new Rectangle();
            r1 = RectangleUI.Addrectangle();
            Circle c2 = new Circle();
            c2 = CircleUI.AddCircle();
            Rectangle r2 = new Rectangle();
            r2 = RectangleUI.Addrectangle();
            Square s3 = new Square();
            s3 = SquareUI.AddSquare();
            ShapeDL.AddIntoList(r1);
            ShapeDL.AddIntoList(c1);
            ShapeDL.AddIntoList(s3);
            ShapeDL.AddIntoList(r2);
            ShapeDL.AddIntoList(c2);

            foreach(Shape s1 in ShapeDL.s)
            {
                double Area =  s1.getArea();
                Console.WriteLine("The area is " + Area + "and  " + s1.toString());
            }
            Console.ReadKey();
        }
    }
}
