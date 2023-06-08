using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class Student
    {
        public string name;
        public string session;
        public bool isDayScholar;
        public int entryMarks;
        public int HSMarks;

        public double calculateMerit()
        {
            double merit = 0.0F;
            merit = (((HSMarks / 1100.0f) * 0.45F) + ((entryMarks/ 400.0F) * 0.55F)) * 100.0F;
            return merit;
        }
    }
}
