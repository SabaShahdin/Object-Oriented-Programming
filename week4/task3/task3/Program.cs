using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> product = new List<Product>();
            List<Customer> customer = new List<Customer>();
            Product p1 = null;
            Customer c1 = null;
            int option;
            do
            {
                option = menu();
                if (option == 1)
                {
                    p1 = addProduct();
                    product.Add(p1);
                }
                if (option == 2)
                {
                    p1.calculateTax(product);
                }
                if (option == 3)
                {
                    c1 = addCustomer();
                    customer.Add(c1);
                    viewProducts(product);
                    Console.WriteLine("Entre prodcut you want to add to the cart");
                    string productName = Console.ReadLine();
                    for (int x = 0; x < product.Count; x++)
                    {
                        if (productName == product[x].name)
                        {
                            c1.addProducts(p1);
                            int productPrice = product[x].Price ;
                            string productCategory = product[x].Category;
                            Console.WriteLine("Prodcut added successfully");
                        }
                        else
                        {
                            Console.WriteLine("Prodcut not found ");
                        }
                    }
                }
                if(option ==4)
                {
                     viewCustomer (customer);
                    product = c1.GetProducts();
                    Console.WriteLine("productNmae {0}  , productCategory{1} , productprice {2} " , p1.name , p1.Category , p1.Price );
                }
                Console.ReadKey();
            } while (option != 6);
        }
        static Product addProduct()
        {
            Console.Clear();
            Console.WriteLine("Enter the product details:");
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Category (Groceries/Fresh Fruit): ");
            string Category = Console.ReadLine();
            Console.Write("Price : ");
            int Price = int.Parse(Console.ReadLine());
            Product c1 = new Product(Name, Category, Price);
            return c1;
        }
         static int menu ()
        {
            Console.Clear();
           int  option;
            Console.WriteLine("Press 1 to add products");
            Console.WriteLine("Press 2 to check sales tax");
            Console.WriteLine("Press 3 to add your data as a customer");
            Console.WriteLine("Press 4 to check customer data");
            Console.WriteLine("Press 5 to exit");
            Console.WriteLine("Entre your option ");
            option =int.Parse( Console.ReadLine());
            return option;
        }
        static Customer addCustomer()
        {
            Console.Clear();
            Console.WriteLine("Enter your  details:");
            Console.Write("Name: ");
            string Name = Console.ReadLine();
            Console.Write("Address ");
            string address= Console.ReadLine();
            Console.Write("Contact: ");
            string contact = Console.ReadLine();
            Customer c1 = new Customer(Name, address , contact);
            return c1;
        }
        static void viewProducts(List<Product> c1)
        {
            Console.Clear();
            for (int x = 0; x < c1.Count; x++)
            {
                Console.WriteLine("Name :  {0} , Price {1}  , Category {2}  ", c1[x].name, c1[x].Price, c1[x].Category);

            }
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }
         static void viewCustomer (List<Customer> c1)
        {
            Console.Clear();
            for (int x = 0; x < c1.Count; x++)
            {
                Console.WriteLine("Name :  {0} , Address {1}  , Contact {2}  ", c1[x].name, c1[x].address , c1[x].contact);

            }
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }
    }
}
