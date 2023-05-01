using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    class Program
    {
        static void Main(string[] args)
        {
           // task1();
            task2();
            
            Console.ReadKey();
        }
        static void task1 ()
        {
            Student s1 = new Student();
            s1.name = "Jack";
            Student s2 = new Student(s1);
            Console.WriteLine(s1.name);
            Console.WriteLine(s2.name);
        }
        static void task2()
        {
            List<int> number = new List<int>() {1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int x in number)
            {
                Console.WriteLine(x);

            }

        }
    }
}
