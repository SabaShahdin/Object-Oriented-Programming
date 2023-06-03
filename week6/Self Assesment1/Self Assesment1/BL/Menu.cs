using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assesment1.BL
{
    public class Menu
    {
        public string name;
        public string type;
        public int price;

        public Menu(string name , string type , int price )
        {
            this.name = name;
            this.type = type;
            this.price = price;

        }
        public Menu ()
        {

        }
    }
}
