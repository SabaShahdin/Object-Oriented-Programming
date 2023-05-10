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
            List<student> stu = new List<student>();

            int option;
               student s = null;
            do
            {
                option = menu();
                Console.Clear();
              
                if (option == 1)
                {   
                    s = addStudent();
                    stu.Add(s);
                }
                if(option == 2)
                {                   
                    float marks = s.calculateMerit();
                    Console.WriteLine ("Your merit is   " + marks);
                }
                if(option == 3)
                {
                    bool flag =  true;                    
                    flag = s.isEligile();
                    if(flag == true)
                    {
                        Console.WriteLine("Congratulions");
                    }
                    else
                    {
                         Console.WriteLine("Better luck next time");
                    }
                }
                 Console.ReadKey();
                 Console.Clear();
               
            } 
            while (option != 4);

        }
        static int menu ()
        {
            int choice;
            Console.WriteLine("1.ADD STUDENT");
            Console.WriteLine("2.Calculate merit");
            Console.WriteLine("3.Check scholarship");
            Console.WriteLine("entre your option");
            choice = int.Parse(Console.ReadLine());
            return choice;
        }
        static student addStudent ()
        {
            Console.WriteLine("Entre name ");
            string name = Console.ReadLine();
            Console.WriteLine("Entre rollNo");
            int rollNo = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre cgpa");
            float cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Entre matric marks");
            float matric = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre fsc marks");
            float fsc = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre ecat marks");
            float ecat = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre home town ");
            string homeTown = Console.ReadLine();
            Console.WriteLine("Entre is hostillite or not ");
            bool isHostellite = bool.Parse(Console.ReadLine());
            Console.WriteLine("Entre is hostillite or not ");
            bool isTakingScholarship = bool.Parse(Console.ReadLine());
            student s1 = new student(name, rollNo, cgpa, matric, fsc, ecat, homeTown, isHostellite, isTakingScholarship);
            return s1;
        }
       static void viewProducts(List<student> c1)
        
       {
            Console.Clear();
            for (int x = 0; x < c1.Count; x++)
            {
                Console.WriteLine("Name {0}  cgpa {1} ", c1[x].name, c1[x].cgpa);
            }

        }
    }
}
