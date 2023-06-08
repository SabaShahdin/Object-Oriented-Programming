using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    public class Animal
    {
        protected string name;

        public Animal (string name )
        {
            this.name = name;
        }
        public virtual string toString()
        {
            return "[AnimalName :]" + "\t" + name;
        }
        public virtual void greet()
        {
            Console.WriteLine("voice");
        }
    }
}
