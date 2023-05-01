using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1();
            task2();
            task3();
            Console.ReadKey();

        }
        static void task1()
        {
            Student s1 = new Student("jack");
            Console.WriteLine(s1.name);
            Student s2 = new Student("jill");
            Console.WriteLine(s2.name);
        }
        static void task2 ()
        {
            Student s1 = new Student("jack" , 1061F , 1028F , 211F , 86.32F);
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
        }
        static void task3()
        {
            Student s1 = new Student("jack", 1061F, 1028F, 211F, 86.32F);
            Console.WriteLine(s1.name);
            Console.WriteLine(s1.matricMarks);
            Console.WriteLine(s1.fscMarks);
            Console.WriteLine(s1.ecatMarks);
            Console.WriteLine(s1.aggregates);

            Student s2 = new Student("jOHN", 161F, 108F, 21F, 86.2F);
            Console.WriteLine(s2.name);
            Console.WriteLine(s2.matricMarks);
            Console.WriteLine(s2.fscMarks);
            Console.WriteLine(s2.ecatMarks);
            Console.WriteLine(s2.aggregates);
        }
    }
}
