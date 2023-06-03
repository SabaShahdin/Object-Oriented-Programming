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
        public static Degree GetDegree()
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
                d.AddSubject(SubjectUI.GetSubject());
            }
            return d;
        }
    }
}
