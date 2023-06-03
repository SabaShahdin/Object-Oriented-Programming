using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    public class Subject
    {
        public string code;
        public int creditHours;
        public string type;
        public int subjectFees;


        public Subject(string code, int creditHours, string type, int subjectFees)
        {
            this.code = code;
            this.creditHours = creditHours;
            this.type = type;
            this.subjectFees = subjectFees;
        }
    }
}
