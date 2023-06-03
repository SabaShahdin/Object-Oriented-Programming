using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS.DL
{
    public class DegreeCurd
    {
        public static List<Degree> degrees = new List<Degree>();
        
        public static void AddDataIntoDegreeList (Degree d)
        {
            degrees.Add(d);
        }
        public static void viewDegreeProgram()
        {
            foreach(Degree d in degrees)
            {
                Console.WriteLine(d.tittle);
            }
        }
    }
}
