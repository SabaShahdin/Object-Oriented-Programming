using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock empty = new Clock();
            Console.WriteLine("Start time");
            empty.printTime();

            Clock time2 = new Clock(12, 0, 0);
            Console.WriteLine("Hour  Min  sec :  ");
            time2.printTime();

            time2.elapsedHours();
            Console.WriteLine("Hour  Min  sec :  ");
            time2.printElapsed();

            time2.Remaing();
            time2.Remaining();
            Console.WriteLine("Hour  Min  sec :  ");
            time2.printRemian();

            Console.ReadKey();

        }
    }
}
