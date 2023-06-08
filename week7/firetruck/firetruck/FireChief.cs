using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firetruck
{
    public class FireChief : Person
    {
        public FireChief(string name) : base(name)
        {

        }
        public void delegateResponsibility(string FirefighteName)
        {
            Console.WriteLine("Tell " + FirefighteName + " to extinguish fire");
        }
    }
}
