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
            Product[] p1 = new Product[10];
            char choice;
            int count = 0;          
            do
            {
                choice = menu();
                if (choice == '1')
                {
                    p1[count] = add();
                    count = count + 1;
                }
                if(choice == '2')
                {
                    viewProduct(p1, count);
                }
                if(choice == '3')
                {
                    total(p1, count);
                }
                if(choice == '4')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("invalid option ");
                }
             } 
            while (choice != '4');
            Console.WriteLine("press any key to continue ");
            Console.ReadKey();

        }
        static char menu()
        {
            Console.Clear();
            char option;
            Console.WriteLine ("press 1 to add products");
            Console.WriteLine("press 2 to VIEW products");
            Console.WriteLine("press 3 to check total price of products");
            Console.WriteLine("press 4 to exit");
            Console.WriteLine("Entre your option");
            option = char.Parse(Console.ReadLine());
            return option;
        }
        static Product add()
        {
            Console.Clear();
            Product p1 = new Product();
            Console.Write("Entre id of product  ");
            p1.ID = Console.ReadLine();
            Console.Write("Entre name of product  ");
            p1.name = Console.ReadLine();
            Console.Write("Entre price of product  ");
            p1.price = int.Parse(Console.ReadLine());
            Console.Write("Entre catogory of product  ");
            p1.catogery = char.Parse(Console.ReadLine());
            Console.Write("Entre name of brand  of product  ");
            p1.brandName = Console.ReadLine();
            Console.Write("Entre country name of product  ");
            p1.country = Console.ReadLine();
            return p1;
        }
        static void viewProduct(Product[] p1, int count)
        {
            Console.Clear();
            for (int x =0; x < count; x ++ )
            {
                Console.WriteLine("ProductId {0}  productName {1}  productPrice {2}  productCategory {3}  productBrand {4}  productCountry{5} ", p1[x].ID, p1[x].name, p1[x].price, p1[x].catogery, p1[x].brandName, p1[x].country);
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        static void total(Product[] p1 , int count )
        {
            Console.Clear();
            int sum = 0;
            if (count == 0)
            {
                Console.WriteLine("No record found ");
            }
            else
            {
                for (int x = 0; x < count; x++)
                {
                    sum = sum + p1[x].price;
                }
                Console.WriteLine("total worth of store {0} ", sum);
            }
            Console.ReadKey();
        }
    }
}
