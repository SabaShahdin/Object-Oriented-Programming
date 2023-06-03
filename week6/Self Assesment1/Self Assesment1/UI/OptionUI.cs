using Self_Assesment1.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assesment1.UI
{
    public class OptionUI
    {
        public static string menues()
        {
            Console.WriteLine(" 1. Add a Menu item");
            Console.WriteLine(" 2.View the Cheapest Item in the menu");
            Console.WriteLine(" 3.View the Drink’s Menu ");
            Console.WriteLine(" 4.View the Food’s Menu");
            Console.WriteLine(" 5.Add Order");
            Console.WriteLine(" 6.Fulfill the Order");
            Console.WriteLine(" 7.View the Orders’s List");
            Console.WriteLine(" 8.Total Payable Amount");
            Console.WriteLine(" 9.Exit");
            Console.WriteLine("Enter your option");
            string option = Console.ReadLine();
            return option;
        }
        public static CoffeeShop AddCoffee()
        {
            Console.WriteLine("Entre name of the shop you want to enter menu");
            string name = Console.ReadLine();
            CoffeeShop c1 = new CoffeeShop(name);
            return c1 ;
        }
        
    }
}
