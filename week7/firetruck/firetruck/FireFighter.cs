using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firetruck
{
     public  class FireFighter : Person
     {
        public FireFighter(string name) : base(name)
        {

        }
        public void drive()
        {
            Console.WriteLine(name + " is Driving the Truck");
        }
        public void extinguishFire()
        {
            Console.WriteLine(name + " is Extinguishing the Fire");
        }
    }
}
