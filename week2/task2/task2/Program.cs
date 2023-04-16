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
            Studenst[] s1 = new Studenst[10];
            char option;
            int count = 0;
            do
            {
                option = menu();
                Console.Clear();
                if (option == '1')
                {
                    s1[count] = add();
                    count = count + 1;
                }
                else if (option == '2')
                {
                    viewStudents(s1, count);
                }
                else if (option == '3')
                {
                    topStudents(s1, count);
                }
                else if (count == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                }
            }
            while (option != '4');
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static char menu()
        {
              Console.Clear();
            char option;
            Console.WriteLine("Press 1 to add students");
            Console.WriteLine("Press 2 to view students");
            Console.WriteLine("Press 3 to view top three  students");
            Console.WriteLine("Press 4 to exit");
            Console.WriteLine("Entre your option ");
            option = char.Parse(Console.ReadLine());
            return option;
        }
        static Studenst add()
        {
              Console.Clear();
            Studenst s1 = new Studenst();
            Console.WriteLine("Entre name of students");
            s1.name = Console.ReadLine();
            Console.WriteLine("Entre roll number of students");
            s1.rollNO = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre cgpa of students");
            s1.cgpa = float.Parse(Console.ReadLine());
            Console.WriteLine("Entre y or n for hostilled student or not ");
            s1.isHostellide = char.Parse(Console.ReadLine());
            Console.WriteLine("Entre department of student ");
            s1.department = Console.ReadLine();
            return s1;
        }           
        static void viewStudents (Studenst[] s1 , int count)
        {
            Console.Clear();
            for (int x = 0 ; x < count ; x ++)
            {
               Console.WriteLine("name {0} , rollNo{1} , cgpa {2} , isHostillied {3} , department {4} " , s1[x].name , s1[x].rollNO , s1[x].cgpa ,s1[x].isHostellide  , s1[x].department);
            }
            Console.WriteLine ("Press any key to continue ") ;
           Console.Read();
        }
        static void topStudents (Studenst[] s1 , int count )
        {
            Console.Clear();
            if(count == 0 )
            {
              Console.WriteLine("NO record found");
            }
           else  if(count == 1)
           {
                 viewStudents(s1 , count);
           }
            else
            {
                  for (int x =0 ; x < count ; x++)
                  { 
                         int index = largest(s1 , x , count);
                          Studenst temp = s1[index];
                          s1[index] = s1[x];
                          s1[x] = temp ;
                  }
                  viewStudents(s1 , count);
                 
            }
            
        }
        static int largest (Studenst[] s1 , int start , int end)
        {
            int index = start;
            float large = s1[start].cgpa;
            for (int x = start; x < end; x ++ )
            {
                if(large <s1[x].cgpa)
                {
                    large = s1[x].cgpa;
                    index = x;
                }
            }
            return index;
        }
     }
}
