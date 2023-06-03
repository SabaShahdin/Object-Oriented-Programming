using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BL;

namespace Store.UI
{
    public class ProductUI
    {
        public static Product addProduct ()
        {
             Console.Clear();        
             Console.WriteLine("Enter the product details:");
             Console.Write("Name: ");
             string Name = Console.ReadLine();
             Console.Write("Category (Groceries/Fresh Fruit): ");
             string Category = Console.ReadLine();
             Console.Write("Price: ");
            int Price = int.Parse(Console.ReadLine());
             Console.Write("Stock Quantity: ");
             int Quantity = int.Parse(Console.ReadLine());
             Console.Write("Minimum Stock Quantity: ");
             int  MinimumQuantity = int.Parse(Console.ReadLine());
             Product c1 = new Product  (Name, Category, Price, Quantity, MinimumQuantity);
           return c1 ;
        }
       public  static int  menuProduct ()
        {
            Console.Clear();
            int  option;
            Console.WriteLine("Press 1 to add products");
            Console.WriteLine("Press 2 to view products");
            Console.WriteLine("Press 3 to find highest price product");
            Console.WriteLine("Press 4 to calculate sales tax of all products");
            Console.WriteLine("Press 5 to check stock");
            Console.WriteLine("Press 6 to exit");
            Console.WriteLine("Entre your option ");
            option = int.Parse (Console.ReadLine());
            return option;
        }
    }
}
