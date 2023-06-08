using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    public class DayScholar : Student
    {
        public string pickPoint;
        public int busNo;
        public int pickUpDistance;

        public int getBusFee ()
        {
            int fee = 0;
            fee = 2000;
            return fee;
        }
    }
}
