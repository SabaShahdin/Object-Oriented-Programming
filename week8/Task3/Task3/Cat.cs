using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Cat : Mammal 
    {
        public Cat (string name ) : base (name)
        {
            this.name = name;
        }
        public override string toString()
        {
            return "[Cat : ]" + "\t" + base.toString();
        }
        public override void greet()
        {
            Console.WriteLine("Meow");
        }
    }
}
