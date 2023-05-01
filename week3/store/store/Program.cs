using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace store
{
    class Program
    {
        static void Main(string[] args)
        {
            List <Store> product = new List<Store> ();
            Store products = new Store();
            string choice ;           
            string path = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\lab\\week3\\store\\store\\Product.txt" ;
             readData ( path ,  product);
            do
            {
                choice = menu();
                if (choice == "1")
                {
                  product.Add( addProduct());
                   writeFile(product , path);
                }
                if(choice == "2")
                {
                    products.viewProducts(product);
                }
                if(choice == "3")
                {
                    Console.Clear();
                    products.Find(product);
                    Console.ReadKey();
                }
                if(choice == "4")
                {
                     Console.Clear();
                    products.calculateTax(product);                     
                     Console.ReadKey();
                }
                if(choice == "5")
                {
                    Console.Clear();
                    bool flag =  products.stockQuantity(product );
                    if(flag == true)
                    {
                        Console.WriteLine("Order products");
                    }
                    else
                    {
                        Console.WriteLine("Products are of enough quantity" );
                    }                      
                     Console.ReadKey();
                }
            }       
            while (choice != "6");
        }
        static string menu ()
        {
            Console.Clear();
            string option;
            Console.WriteLine("Press 1 to add products");
            Console.WriteLine("Press 2 to view products");
            Console.WriteLine("Press 3 to find highest price product");
            Console.WriteLine("Press 4 to calculate sales tax of all products");
            Console.WriteLine("Press 5 to check stock");
            Console.WriteLine("Press 6 to exit");
            Console.WriteLine("Entre your option ");
            option = Console.ReadLine();
            return option;
        }
        static Store  addProduct ()
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
            Store c1 = new Store (Name, Category, Price, Quantity, MinimumQuantity);
           return c1 ;
        }
        static void readData (string path , List<Store> product)
        {
           if (File.Exists(path))
           {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                   Store c1 = new Store ();
                   c1.Name = parseData(record, 1);
                   c1.Category = parseData(record , 2);
                   c1.Price = int . Parse (parseData(record, 3));
                   c1.Quantity= int . Parse (parseData(record, 4));
                   c1.MinimumQuantity = int . Parse (parseData(record, 5));
                   product.Add(c1);
                 }
               fileVariable.Close();
           }
           else
           {
                  Console.WriteLine("Not Exists");
           }
        }
        static void writeFile(List<Store> product , string path )
        {
            StreamWriter file = new StreamWriter(path , false);
            for (int x  = 0; x < product.Count ; x++)
            {
                file.WriteLine(product[x].Name +  ","  + product[x].Category +  ","  + product[x].Price +  ","  + product[x].Quantity +  ","  + product[x].MinimumQuantity);
            }               
                file.Flush();
                file.Close(); 
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
    }
}
