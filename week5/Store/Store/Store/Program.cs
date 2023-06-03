using Store.BL;
using Store.DL;
using Store.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "User.txt";
            int option;
            bool check = UserCurd.readData(path);
            if (check)
            {
                Console.WriteLine("Data Loaded SuccessFully");
            }
            else
            {
                Console.WriteLine("Data Not Loaded");
            }
            Console.ReadKey();
            do
            {
                Console.Clear();
                option = UserUI.menu();
                Console.Clear();
                if (option == 1)
                {
                    User user = UserUI.takeInputWithoutRole();
                    if (user != null)
                    {
                        user = UserCurd.signIn(user);
                        if (user.isAdmin() == true)
                        {
                            AdminMenu();
                        }
                        else if (user.isAdmin() == false)
                        {
                            Customer();
                        }
                        else
                        {
                            Console.WriteLine("Invalid User");
                        }
                    }
                }
                else if (option == 2)
                {
                    User user = UserUI.takeInputWithRole();
                    if (user != null)
                    {
                        UserUI.storeDataInFile(path, user);
                        UserCurd.storeDataInList(user);
                    }
                }
                Console.ReadKey();
            }
            while (option != 3);
        }
       static void AdminMenu()
        {
            int choice ;
            do
            {
                choice = ProductUI.menuProduct();
                if (choice == 1)
                {
                   Product p1 = ProductUI.addProduct () ;
                   ProductCurd.AddIntoList(p1);
                }
                if(choice == 2)
                {
                    ProductCurd.viewProducts();
                }
                if(choice == 3)
                {
                    
                    ProductCurd.Find();
                }
                if(choice == 4)
                {
                    ProductCurd.calculateTax();
                    Console.ReadKey();
                }
                if(choice == 5)
                {
                    Console.Clear();
                    bool flag =  ProductCurd.stockQuantity();
                    if(flag == true)
                    {
                        Console.WriteLine("Order products");
                    }
                    else
                    {
                        Console.WriteLine("Products are of enough quantity" );
                    }    

                     Console.ReadKey();
                     Console.Clear();
                }
            }       
            while (choice != 6);
        }
        static void Customer()
        {
            int choice ;
            do
            {
                choice = CustomerUI. CustomerMenu();
                if(choice == 1)
                {
                    ProductCurd.viewProducts();
                }
                else if(choice == 2)
                {
                    CustomerCurd. BuyProduct(ProductCurd.products);
                }
                if(choice == 3)
                {
                    CustomerUI.printCustomer();
                    CustomerCurd.GenerateInvoice(ProductCurd.products);

                }

                    Console.ReadKey();
                     Console.Clear();
            }
             while(choice != 4);
        }
    }
}
