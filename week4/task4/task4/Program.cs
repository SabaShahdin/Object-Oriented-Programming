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
            List <Student> stu = new List<Student> ();
            List <Degree> deg = new List<Degree> ();
           List <Subject> sub = new List<Subject>();
            List <Student> students = new List<Student> ();
            int option;
           Student s1  = null;
            Degree d  = null;
            Subject s  = null;
            do
            {
                option = menu();
                if(option ==1)
                {
                    s1 = addStudent(d , deg);
                    s1.merit = s1.calculatemerit();
                    Console.WriteLine ("Merit of student is" + s1.merit);
                    Console.ReadKey();
                    stu.Add(s1);
                }
                if(option == 2)
                {
                    d = AddDegree(sub);
                    Console.WriteLine("Entre how many sujects you want to entre");
                    int num = int.Parse(Console.ReadLine());
                    for(int x = 0 ; x < num ; x++)
                    {
                         s = AddSubjects();  
                         sub.Add(s);
                         d.AddSubject(s);
                    }                                                      
                }
                else if (option == 3)
                {
                    List<Student> sortStudentList = new List<Student>();
                   sortStudentList =  sortStudentsByMerit(stu);
                   giveAdmission(stu , students , deg ,  sortStudentList);
                   printStudent(stu);
                }
                else if (option == 4)
                {
                   viewRegisteredStudents(students);
                }
                else if (option == 5)
                {
                        string degName;
                        Console.Write("Enter Degree Name: ");
                        degName = Console.ReadLine();
                        viewStudentInDegree( students , degName , d);
                }
                else if (option == 6)
                {
                     Console.Write("Enter the Student Name: ");
                    string name = Console.ReadLine();
                    Student s3 = StudentPresent(name , stu);
                    if (s3 != null)
                    {
                        viewSubjects(sub);
                        registerSubjects(s1 , sub , s);
                        viewRegister(s1, s1.regSubject);
                    }
                  }
                else if (option == 7)
                {
                   int fee = s1.calculateFees(sub);
                   Console.WriteLine("The toatl fees is " + fee);
                }
                Console.ReadKey();
                Console.Clear();
            }
            while (option != 8);
        }
        static int menu ()
        {
             Console.Clear();
           int  option;
            Console.WriteLine("Press 1 to add students");
            Console.WriteLine("Press 2 to Add Degree Program");
            Console.WriteLine("Press 3 to Generate Merit List");
            Console.WriteLine("Press 4 to View Registered Students");
            Console.WriteLine("Press 5 to View student of specfic program");
            Console.WriteLine("Press 6 to register students for a specfic subject");
            Console.WriteLine("Press 7 to calculate fee of specfic student");
            Console.WriteLine("Entre your option ");
            option =int.Parse( Console.ReadLine());
            return option;
        }
        static Student addStudent(Degree d , List<Degree> deggrees)
        {
            Console.Clear();
            Console.WriteLine ("Entre name of student");
            string name = Console.ReadLine();
            Console.WriteLine("Entre student age ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre student fsc  marks");
            int fsc = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre student ecat marks ");
            int ecat = int.Parse(Console.ReadLine());           
            foreach(Degree d1 in deggrees)
            {
                Console.WriteLine("Available Degree program " + d1.tittle);
            } 
             Console.WriteLine("Entre your  number of prefeernces");
             int pre = int.Parse(Console.ReadLine());
            List<Degree> preferences = new List<Degree> ();
               for (int x = 0; x < pre; x++)
               {
                  Console.WriteLine("Enter your preference:");
                  string tittle = Console.ReadLine();
                   foreach (Degree deg in deggrees)
                   {
                       if (deg.tittle == tittle)
                       {                       
                        Console.WriteLine ("Degree  exists");
                        preferences.Add(deg);
                       }
                       else
                       {
                          Console.WriteLine ("Degree does not exists");
                       }
                   }
               }   
            Student s2 = new Student (name , age , fsc , ecat , preferences);
            return s2 ;
        }
        static Degree AddDegree1()
        {
             Console.WriteLine ("Entre name of degree");
            string title = Console.ReadLine();
            Console.WriteLine("Entre  degree duration ");
            int duration  = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre degree seats");
            int seats = int.Parse(Console.ReadLine());
            Degree d = new Degree(title , duration , seats);
            return d ;
        }
        static Degree AddDegree(List <Subject> sub)
        {
            Console.Clear();
            Console.WriteLine ("Entre name of degree");
            string title = Console.ReadLine();
            Console.WriteLine("Entre  degree duration ");
            int duration  = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre degree seats");
            int seats = int.Parse(Console.ReadLine());           
            Degree d = new Degree(title , duration , seats);
            return d ;
        }
        static Subject AddSubjects ()
        {
            Console.WriteLine ("Entre subject code ");
            string code = Console.ReadLine();
             Console.WriteLine("Entre subject type ");
            string type = Console.ReadLine();
            Console.WriteLine("Entre subject credit hours ");
            int creditHours   = int.Parse(Console.ReadLine());          
            Console.WriteLine("Entre subject fees ");
            int fees  = int .Parse(Console.ReadLine());
            Subject s  = new Subject(code , creditHours , type , fees);
            return s;
        }
        static void registerSubjects(Student s , List<Subject> s1 , Subject s2)
        {
            Console.Write ("Entre how many subjects you want to enter ");
            int count = int.Parse (Console.ReadLine ());
            for(int x =0 ; x < count ; x++)
            {
                Console.WriteLine("entre the subject code");
                string code = Console.ReadLine();
                bool flag = false ;
                foreach(Subject  sub in s.regDegree.subjects)
                {
                    if(code == sub.code && !(s.regSubject.Contains(sub)))
                    {
                        s.regStudentSubject(s2 , s1 , code );
                        flag = true;
                        break;
                    }
                }
                if(flag == false)
                {
                    Console.Write("Entre valid Course");
                    x--;
                }
            }
        }
        static List<Student> sortStudentsByMerit(List <Student> stu)
        {
            List<Student> sortStudentList = new List<Student>();
            foreach(Student s in stu )
            {
              float merit =  s.calculatemerit();
            }
            sortStudentList = stu.OrderByDescending (o => o.merit).ToList();
            return sortStudentList;
        }
        static void giveAdmission(List <Student> s1 , List <Student> s2 , List <Degree> prefernce , List <Student> sortStudentList )
        {
            foreach(Student s in sortStudentList)
            {
                foreach (Degree d in s. preferences)
                {
                    if(d.seats > 0 && s.regDegree == null)
                    {
                        s.regDegree = d ;
                        d.seats--;
                        break;
                    }
                }
               
            }      
            
        }
        static void printStudent(List <Student> studentList)
        {
            foreach(Student s in studentList)
            {
                if(s.regDegree != null)
                { 
                     Console.WriteLine( s.name + "got admission is " + s.regDegree.tittle );
                }
                else
                {
                   Console.WriteLine( s.name + " did not admission  " );
                }
        }
    }
        static void viewRegisteredStudents(List <Student> s1)
        {
            Console.WriteLine("name   \t   age     \t  fsc   \t   ecat ");
            foreach(Student s in s1)
            {
                Console.WriteLine(s.name + "\t" +  s.age +  "\t" + s.fsc + "\t" +  s.ecat );
            }
        }
        static void viewStudentInDegree(List <Student> s1 , string degName , Degree d1)
        {
            Console.WriteLine("name   \t   age     \t  fsc   \t   ecat ");
            foreach(Student s in s1)
            {
                if(degName == d1.tittle)
                { 
                  Console.WriteLine(s.name + s.age + s.fsc + s.ecat );
                }
            }
        }
         static Student StudentPresent(string name , List<Student> stu)
         {
            foreach(Student s1 in stu)
            {
                if(s1.name == name)
                {
                    return s1;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        static void viewSubjects(List<Subject> sub)
        {
             Console.WriteLine("code  \t  creditHours \t    type  \t subjectFees");
            foreach(Subject s in sub)
            {
                Console.WriteLine(s.code + "\t" + s.creditHours + "\t" +  s.type + "\t" +  s.subjectFees);
            }
        }
        static void viewRegister(Student s1 , List<Subject> regSubject)
        {
            Console.WriteLine("code  \t  creditHours \t    type  \t subjectFees");
            foreach(Subject s in regSubject)
            {
                  Console.WriteLine(s.code + s.type + s.creditHours + s.subjectFees);
            }
        }
        
    }
}
