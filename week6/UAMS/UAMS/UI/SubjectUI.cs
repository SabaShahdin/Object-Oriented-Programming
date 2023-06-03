using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.UI
{
    class SubjectUI
    {
        public static void RegisterSubjects(Student s)
        {
            Console.Write("Entre how many subjects you want to enter ");
            int count = int.Parse(Console.ReadLine());
            for (int x = 0; x < count; x++)
            {
                Console.WriteLine("entre the subject code");
                string code = Console.ReadLine();
                bool flag = false;
                foreach (Subject sub in s.regDegree.subjects)
                {
                    if (code == sub.code && !(s.regSubject.Contains(sub)))
                    {
                        if(s.regStudentSubject(sub))
                        { 
                          flag = true;
                          break;
                        }
                        else
                        {
                            Console.WriteLine("A student can have more thna 9 credit hours ");
                            flag = true;
                            break;

                        }
                    }
                }
                if (flag == false)
                {
                    Console.Write("Entre valid Course");
                    x--;
                }
            }
        }
        public static Subject   TakeInputForSubject()
        {
            Console.WriteLine("Entre subject code ");
            string code = Console.ReadLine();
            Console.WriteLine("Entre subject type ");
            string type = Console.ReadLine();
            Console.WriteLine("Entre subject credit hours ");
            int creditHours = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre subject fees ");
            int fees = int.Parse(Console.ReadLine());
            Subject s = new Subject(code,  type, creditHours ,  fees);
            return s;
        }
        public static void viewSubjects(Student s)
        {
            if (s.regDegree != null)
            {
                foreach (Subject s1 in s.regDegree.subjects)
                {
                    Console.WriteLine(s1.code + "\t\t" + s1.type);
                }
            }
        }
    }
}
