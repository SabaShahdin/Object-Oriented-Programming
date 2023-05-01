using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Admin> products = new List<Admin>();
            string path = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\PD\\PD2\\Products.txt" ;
            char choice;
             readData ( path ,  products);
            do
            {
                choice = admin_menu();
                if (choice == '1')
                {
                    products.Add(addProduct());
                   
                }
                if (choice == '2')
                {
                    viewProducts(products);
                    Console.WriteLine("Press any key to continue");
            Console.ReadKey();
                }
                if (choice == '3')
                {                    
                    Console.Clear();
                    viewProducts(products);
                    Console.WriteLine("Enter Product Name you want to Delete: ");
                    string newProduct = Console.ReadLine();
                    deleteProductForSelling(products, newProduct);
                      Console.WriteLine("Press any key to continue");
            Console.ReadKey();
                }
                if(choice == '4')
                {
                    Console.Clear();
                    viewProducts(products);
                    Console.WriteLine("Enter Product Name you want to Update: ");
                    string newProduct = Console.ReadLine();
                    updateProductForSelling( products , newProduct);
                      Console.WriteLine("Press any key to continue");
            Console.ReadKey();
                }
                writeFile(products, path);
            } while (choice != '5');
        }
        static char admin_menu()
        {
            Console.Clear();
            char op;
            Console.WriteLine("1. Add product and their prices");
            Console.WriteLine("2. View prodcut and their prices");
            Console.WriteLine("3. Delete  selling product and their prices");
            Console.WriteLine("4. Update selling products and their prcices");
            Console.WriteLine("5. Exit: ");
            Console.WriteLine("Enter Option: ");
            op = char.Parse(Console.ReadLine());
            return op;
        }
        static Admin addProduct()
        {
            Console.Clear();
            Admin c1 = new Admin();
            Console.WriteLine("Entre name of the product");
            c1.productName = Console.ReadLine();
            Console.WriteLine("Entre price of the product..");
            c1.productPrice = int.Parse(Console.ReadLine());
            return c1;
        }
        static void viewProducts(List<Admin> c1)
        
       {
            Console.Clear();
            for (int x = 0; x < c1.Count; x++)
            {
                Console.WriteLine("ProductName {0}  ProductPrice {1} ", c1[x].productName, c1[x].productPrice);
            }

        }
        static int searchProduct(List<Admin> product, string newProduct)
        {
            for (int x = 0; x < product.Count; x++)
            {
                if (newProduct ==  product[x].productName)
                {
                    return x;
                }
            }
            return -1;
        }
        static void deleteProductForSelling(List<Admin> product , string newProduct)
        {
            int delete = searchProduct(product , newProduct);
            if (delete >= 0 && delete <= 4)
            {
                Console.WriteLine("Product Found");
                product .RemoveAt(delete);
                Console.WriteLine("Product deleted successfully");

            }
            else
            {
                Console.WriteLine("Product not  Found");
            }

        }
         static void updateProductForSelling(List<Admin> product , string newProduct)
         {
            int update = searchProduct(product , newProduct);
            if (update >= 0 && update <= 4)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine("Enter the Updated price");
                int newPrice = int.Parse(Console.ReadLine());
                product[update].productPrice = newPrice;
                Console.WriteLine("Product  price update successfully");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Product Does Not Exists.");
            }
        }
        static string parseData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length; x++)
            {
                if (record[x] == ',')
                {
                    comma++;
                }
                else if (comma == field)
                {
                    item = item + record[x];
                }
            }
            return item;
        }
        static void readData (string path , List<Admin> product)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                   Admin c1 = new Admin();
                   c1.productName = parseData(record, 1);
                   c1.productPrice = int . Parse (parseData(record, 2));
                   product.Add(c1);
                 }
               fileVariable.Close();
            }
            else
            {
                  Console.WriteLine("Not Exists");
            }
        }
        static void writeFile(List<Admin> product , string path )
        {
            StreamWriter file = new StreamWriter(path , false);
            for (int x  = 0; x < product.Count ; x++)
            {
                file.WriteLine(product[x].productName +  ","  + product[x].productPrice);
            }               
                file.Flush();
                file.Close(); 
        }
    }
}
