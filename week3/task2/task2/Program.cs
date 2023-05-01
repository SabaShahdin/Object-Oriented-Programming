using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {

            Student s1 = new Student();
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregates);

            Console.WriteLine("VALUES FOR OBJECT 2");

            Student s2 = new Student();
            Console.WriteLine(s2.name);
            Console.WriteLine(s2.matricMarks);
            Console.WriteLine(s2.fscMarks);
            Console.WriteLine(s2.ecatMarks);
            Console.WriteLine(s2.aggregates);
            Console.ReadKey();
        }
    }
}
