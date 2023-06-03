using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Self_Assesment1.BL;
using Self_Assesment1.DL;

namespace Self_Assesment1.UI
{
    public class MenuUI
    {
        public static List<Menu> AddMenuItem()
        {
            string takeInput = "1";
            while (takeInput == "1")
            {
                Console.WriteLine("Entre name of the item");
                string name = Console.ReadLine();
                Console.WriteLine("entre type of the item");
                string type = Console.ReadLine();
                Console.WriteLine("Entre the price of item ");
                int price = int.Parse(Console.ReadLine());
                Menu m1 = new Menu(name, type, price);
                Console.WriteLine("entre 1 to take input for new item ");
                takeInput = Console.ReadLine();              
                MenuCurd.AddIntoList(m1);
            }
            return MenuCurd.menu;
        }
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
