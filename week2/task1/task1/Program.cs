using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    class Program
    {
        class Students
        {
            public string name;
            public int rollNo;
            public float cgpa;
        }
        static void Main(string[] args)
        {
            // TASK1 
            task1();
            task2();
          
            Console.Read();

        }
        static void task1 ()
        {
            Students s1 = new Students();
            s1.name = "ahmad";
            s1.rollNo = 23;
            s1.cgpa = 2.4F;
            Console.WriteLine("name {0}  rollNo  {1}  cgpa {2} ", s1.name, s1.rollNo, s1.cgpa);
            // second record
            Students s2 = new Students();
            s2.name = "ali";
            s2.rollNo = 43;
            s2.cgpa = 6.5F;
            Console.WriteLine("name {0}  rollNo  {1}  cgpa {2} ", s2.name, s2.rollNo, s2.cgpa);
        }
        static void task2 ()
        {
            Students s1 = new Students();
            Console.WriteLine("Enter name of student ");
            s1.name = Console.ReadLine();
            Console.WriteLine("Enter roll no of student ");
            s1.rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre cgpa of students");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("name {0}  rollNo  {1}  cgpa {2} ", s1.name, s1.rollNo, s1.cgpa);
            Console.ReadKey();

        }
    }
}
