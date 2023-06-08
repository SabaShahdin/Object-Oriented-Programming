using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class Person
    {
        protected string name;
        protected string address;

        public Person (string name , string address)
        {
            this.name = name;
            this.address = address;
        }
        public void setname (string name )
        {
            this.name = name;
        }
        public void setaddress(string address)
        {
            this.address = address;
        }
        public string getname()
        {
            return name;
        }
        public string getaddress()
        {
            return address;
        }
        public virtual string  toString()
        {
            return "Name :" + name + "Address : " + address; 
        }
    }

}
