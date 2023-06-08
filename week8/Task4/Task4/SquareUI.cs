using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    public class SquareUI
    {
        public static Square AddSquare()
        {
           Console.Write("Entre length ");
            int length = int.Parse(Console.ReadLine());
           Square s3 = new Square(length,  "Square");
            return s3;
         }
    }
}
