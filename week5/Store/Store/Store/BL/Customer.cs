using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL
{
    public class Customer
    {
        public string name;
        public string address;
        public string phoneNumber;

        public Customer (string name , string address , string phoneNumber)
        {
            this.name = name ;
            this.address = address;
            this.phoneNumber = phoneNumber;
        }
    }
}
