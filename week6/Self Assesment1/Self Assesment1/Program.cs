using Self_Assesment1.BL;
using Self_Assesment1.DL;
using Self_Assesment1.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_Assesment1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string path = "order.txt";
            string path1 = "menu.txt";
            bool flag1 = MenuCurd.readMenuFile(path1);
            bool flag = OrderCurd.readFromFile(path);
            if(flag == true)
            {
                Console.WriteLine("Data loaded succefully");

            }
            else
            {
                Console.WriteLine("Data  not loaded ");
            }
            if (flag1 == true)
            {
                Console.WriteLine("Data loaded succefully");

            }
            else
            {
                Console.WriteLine("Data  not loaded ");
            }
            Console.Clear();
            Console.ReadKey();
            Menu m1 = new Menu();
            string choice;
            do
            {
                Console.Clear();
                choice =  MenuUI.menues();

                if(choice == "1")
                {
                    CoffeeShop c1 = MenuUI.AddCoffee();
                    MenuCurd.menu = MenuUI.AddMenuItem();
                    MenuCurd.writeMenuFile(path1);
                }
                else if(choice == "2")
                {
                    m1 = MenuCurd.viewCheapestItem();
                    if (m1 != null)
                    {
                        Console.WriteLine("The cheapest item is " + m1.name + "\t" + m1.type + "\t" + m1.price);
                    }
                    else
                    {
                        Console.WriteLine("no record found");
                    }
                }
                else if(choice == "3")
                {
                    Console.WriteLine("The drinks menu is ");
                    List<Menu> drink = new List<Menu>();
                    drink = MenuCurd.viewDrinks();
                    foreach(Menu m in drink)
                    {                       
                        Console.WriteLine(m.name + "\t" + m.type + "\t" + m.price);
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("The food menu is ");
                    List<Menu> food = new List<Menu>();
                    food  = MenuCurd.viewFood();
                    foreach (Menu m in food)
                    {
                        Console.WriteLine(m.name + "\t" + m.type + "\t" + m.price);
                    }
                }
                else if(choice == "5")
                {
                    Console.WriteLine("Entre name of the item");
                    string name = Console.ReadLine();
                    bool flag2 = OrderCurd.AddOrder(name);
                    if(flag2 == true)
                    {
                        Console.WriteLine("the order is currently available ");
                        OrderCurd.order.Add(name);
                        Console.WriteLine("Order added");
                    }
                    else if(flag2 == false )
                    {
                        Console.WriteLine("the order is currently unavailable ");
                    }
                    OrderCurd.writeFile(path);
                }
                else if(choice == "6")
                {
                    Console.WriteLine("Entre the name of your order");
                    string name = Console.ReadLine();
                    OrderCurd.FullfillOrder(name);
                }
                else if(choice == "7")
                {
                    OrderCurd.viewOrder();
                }
                else if(choice == "8")
                {
                    OrderCurd.totalPayable();
                }

                Console.ReadKey();
                Console.Clear();
            }
            while (choice != "9");
        }
     
    }
}
