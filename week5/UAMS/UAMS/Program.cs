using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;
using UAMS.UI;
namespace UAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            int option;
            do
            {
                option = menu ();

                if (option == 1)
                { 
                    if(DegreeCurd.degrees.Count > 0 )
                    {
                        Student s = UserUI.takeInputForStudent();
                        StudentCurd.AddStudentIntoList(s);

                    }

                }
                if(option == 2)
                {
                    Degree d = DegreeUI.GetDegree();
                    DegreeCurd.AddDataIntoDegreeList(d);
                }
                if(option == 3)
                {
                    List<Student> sortStudentList = new List<Student>();
                    sortStudentList = StudentCurd.sortStudentsByMerit();
                    StudentCurd.giveAdmission(sortStudentList);
                    UserUI.printStudent();
                }
                else if(option == 4)
                {
                    UserUI.viewRegisteredStudents();
                }
                else if(option == 5)
                {
                    string degreeName;
                    Console.WriteLine("Entre degree name ");
                    degreeName = Console.ReadLine();
                    UserUI.viewStudentInDegree(degreeName);
                }
                else if(option == 6)
                {
                    Console.WriteLine("Entre the student name ");
                    string name = Console.ReadLine();
                    Student s = StudentCurd.StudentPresent(name);
                    if(s != null)
                    {
                        SubjectUI.viewSubjects(s);
                        SubjectUI.RegisterSubjects(s);
                    }
                }
                else if(option == 7)
                {
                    StudentCurd.CalculateFeeForAll();
                }

                Console.ReadKey();
                Console.Clear();
            }
            while (option != 8);
        }
         static int menu()
        {
            Console.Clear();
            int option;
            Console.WriteLine("Press 1 to add students");
            Console.WriteLine("Press 2 to Add Degree Program");
            Console.WriteLine("Press 3 to Generate Merit List");
            Console.WriteLine("Press 4 to View Registered Students");
            Console.WriteLine("Press 5 to View student of specfic program");
            Console.WriteLine("Press 6 to register students for a specfic subject");
            Console.WriteLine("Press 7 to calculate fee of specfic student");
            Console.WriteLine("Entre your option ");
            option = int.Parse(Console.ReadLine());
            return option;
        }
    }
}
