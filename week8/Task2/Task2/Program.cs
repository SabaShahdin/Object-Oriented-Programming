using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> p1 = new List<Person>();
         
            Student s = new Student("Ali", "house23" , "BSCS" ,  2022 ,  8900);
            Student s1 = new Student("Hamza", "house2", "DO", 4500, 9000);
            Staff s2 = new Staff("Ahamd", "uiui", "Sps", 788);
            Staff s3 = new Staff("Haris", "ui", "ty", 7880);
            p1.Add(s);
            p1.Add(s1);
            p1.Add(s2);
            p1.Add(s3);
            foreach(Person p in p1)
            {
                Console.WriteLine(p.toString());
            }
         
            Console.ReadKey();
            


        }
    }
}
