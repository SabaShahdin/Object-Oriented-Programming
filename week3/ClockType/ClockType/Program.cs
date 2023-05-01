using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockType
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock empty = new Clock();
            Console.WriteLine("Start time");
            empty.printTime();

            Clock time = new Clock (8);
            Console.WriteLine("Hour  Min  sec :  ");
            time.printTime();

            Clock time1 = new Clock(8 , 4);
            Console.WriteLine("Hour  Min  sec :  ");
            time1.printTime();

            Clock time2 = new Clock(8, 4 ,  2);
            Console.WriteLine("Hour  Min  sec :  ");
            time2.printTime();

            time2.incrementSecond();
            Console.WriteLine("Hour  Min  sec :  ");
            time2.printTime();

            time2.incrementMin();
            Console.WriteLine("Hour  Min  sec :  ");
            time2.printTime();

            time2.incrementHours();
            Console.WriteLine("Hour  Min  sec :  ");
            time2.printTime();

            bool flag = time2.isEqual(9, 5, 3);
            Console.WriteLine("flag  = "  + flag);

            Clock c1 = new Clock(9, 5, 3);
            flag = time2.isEqual(c1);
            Console.WriteLine("flag  = " + flag);


            Console.ReadKey();
        }
    }
}
