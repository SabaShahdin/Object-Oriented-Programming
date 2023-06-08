using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Mammal : Animal 
    {
        public Mammal(string name ) : base (name)
        {
            this.name = name;
        }
        public override string toString()
        {
            return "[mammal : ]" + "\t" +  base.toString();
        }
        public override  void greet()
        {
            Console.WriteLine("voice");
        }
    }
}
