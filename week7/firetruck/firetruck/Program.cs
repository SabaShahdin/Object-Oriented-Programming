using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firetruck
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("entre length of ladder");
            int length = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre colour of ladder");
            string colour = Console.ReadLine();

            Ladder l1 = new Ladder(length, colour);
            truck t1 = new truck(l1);

            Console.WriteLine("entre type of pipe");
            string pipe = (Console.ReadLine());
            Console.WriteLine("Entre shape  of pipe ");
            string shape = Console.ReadLine();
            Console.WriteLine("Entre diameter of pipe");
            int diameter = int.Parse(Console.ReadLine());

            HosePipe h1 = new HosePipe(pipe, shape, diameter);
            t1.SetHosePipe(h1);

            Console.WriteLine("Entre your name ");
            string name = Console.ReadLine();
            FireFighter f1 = new FireFighter(name);
         
        }
    }
}
