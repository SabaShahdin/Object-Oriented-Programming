using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BL;

namespace Store.UI
{
    public class CustomerUI
    {
       public  static int  CustomerMenu()
        {
            Console.Clear();
            int  option;
            Console.WriteLine("Press 1 to view products");
            Console.WriteLine("Press 2 to Buy the products");
            Console.WriteLine("Press 3 to Generate invoice");
            Console.WriteLine("Press 4 to exit");
            Console.WriteLine("Entre your option ");
            option = int.Parse (Console.ReadLine());
            return option;
        }
        public static void printCustomer()
        {
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter customer address:");
            string address = Console.ReadLine();
            Console.WriteLine("Enter customer phone number:");
            string phone = Console.ReadLine();
            Customer cus = new Customer (name , address , phone);
        }
    }
}
