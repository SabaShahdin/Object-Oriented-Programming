using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> a = new List<Animal>();
            Cat c1 = new Cat("tom");
            Cat c2 = new Cat("Pink");
            Dog d1 = new Dog("jack");
            Dog d2 = new Dog("jj");
            a.Add(c1);
            a.Add(c2);
            a.Add(d1);
            a.Add(d2);
            foreach(Animal an in a)
            {
                an.greet();
               Console.WriteLine( an.toString()) ;
            }
            Console.ReadKey();
        }
    }
}
