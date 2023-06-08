using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Console.WriteLine("entre true if you are day scholar");
            s1.isDayScholar = bool.Parse(Console.ReadLine());
            if (s1.isDayScholar == true)
            {

                DayScholar d1 = new DayScholar();
                d1.name = "Ahmad";
                d1.busNo = 1;
                Console.WriteLine(d1.name + " is allocated " + d1.busNo);
            }
            else
            {
                Hostellite h1 = new Hostellite();
                h1.name = "Ali";
                h1.roomNumber = 10;
                Console.WriteLine(h1.name + " is allocated " + h1.roomNumber);
            }
            Console.ReadKey();
        }
    }
}
