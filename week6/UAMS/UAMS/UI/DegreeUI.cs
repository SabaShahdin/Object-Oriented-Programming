using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;
using UAMS.DL;


namespace UAMS.UI
{
    class DegreeUI
    {
        public static Degree TakeInputForDegree()
        {
            Console.WriteLine("Entre name of degree");
            string title = Console.ReadLine();
            Console.WriteLine("Entre  degree duration ");
            int duration = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre degree seats");
            int seats = int.Parse(Console.ReadLine());
            Degree d = new Degree(title, duration, seats);

            Console.WriteLine("Entre how many sujects you want to entre");
            int num = int.Parse(Console.ReadLine());
            for (int x = 0; x < num; x++)
            {
                Subject  s = SubjectUI.TakeInputForSubject();
                if(d.AddSubject(s))
                {
                    if(!(SubjectCurd.sub.Contains(s)))
                    {
                        SubjectCurd.AddSubjectIntoList(s);
                        SubjectCurd.storeDataInFile("subject.txt" , s);
                    }
                    Console.WriteLine("Subject added");
                }
                else
                {
                    Console.WriteLine("Subject not  added");
                    Console.WriteLine("20 credit hour limit exceeds ");
                    x--;
                }
            }
            return d;
        }
        public static void viewDegreeProgram()
        {
            foreach(Degree d in DegreeCurd.degrees)
            {
                Console.WriteLine(d.tittle);
            }
        }
   }
}
