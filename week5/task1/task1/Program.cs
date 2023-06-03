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
            Student s2 = new Student("ABC", 12, 1028);
            Student s3 = new Student("BBB", 13, 1000);
            Student s4 = new Student("BBB", 8, 890);
            List<Student> s1 = new List<Student>() { s2, s3, s4 };
            List<Student> sortedList = s1. OrderByDescending(o => o.marks).ToList();
            foreach(Student stu in sortedList)
            {
                Console.WriteLine(stu.name + "," + stu.rollNo + "," + stu.marks);
            }
            List<float> a = new List<float>() { 0.1F, 1.1F, 4.5F, 3.2F, 0.0F, 7.9F, 4.3F };
            a.Sort();
            foreach(float f in a )
            {
                Console.WriteLine(f + "  ");
            }
            List<String> s = new List<string>() { "ABC", "a", "and", "bag", "tan", "qw" };
            s.Sort();
            foreach(string i in s)
            {
                Console.WriteLine(i + "  ");
            }

            Console.ReadKey();
        }
    }
}
