using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
          //  task1();
         //   task2();
            task3();
            Console.ReadKey();
        }
        static void task1()
        {
            Student s1 = new Student();
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregates);
        }
        static void task2()
        {
            Student s2 = new Student();
        }
        static void task3()
        {
            Student s1 = new Student();
            Console.WriteLine(s1.name);
        }
    }
}
