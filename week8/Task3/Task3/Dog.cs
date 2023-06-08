using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Dog : Mammal 
    {
        public Dog(string name) : base(name)
        {
            this.name = name;
        }
        public override string toString()
        {
            return "[Dog  : ]" + "\t" + base.toString();
        }
        public override void greet()
        {
            Console.WriteLine("Woof");
        }
        public  void greet(Dog d1)
        {
            Console.WriteLine("Wooof");
        }
    }
}
