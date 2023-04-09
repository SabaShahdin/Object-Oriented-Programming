using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[5];
            string[] password = new string[5];
            string[] productName = new string[5];
            int[] productPrice = new int[5];
            int sellingCount = 0;
            string productPath = "C:\\Users\\hp\\OneDrive\\Documents\\semester2\\oop(lab)\\PD1\\products.txt";
            readProductData(productPath, productName, productPrice, ref sellingCount);
            char adminOption;
            adminOption = admin_menu();
            clearScreen();
            while (adminOption != '5')
            {  
                if (adminOption == '1')
                {
                    viewProducts(productName, productPrice, sellingCount);
                    clearScreen();
                    adminOption = admin_menu();
                }
                else if (adminOption == '2')
                {
                   
                    clearScreen();
                    Console.WriteLine("Enter Product Name: ");
                    string newProduct = Console.ReadLine();
                    Console.WriteLine("Enter Price: ");
                    int newPrice = int.Parse(Console.ReadLine());
                    addProductForSelling(newProduct, newPrice, productName, productPrice, ref sellingCount);
                    adminOption = admin_menu();
                }
                else if (adminOption == '3')
                {
                    clearScreen();
                    Console.WriteLine("Enter Product Name you want to Update: ");
                    string newProduct = Console.ReadLine();
                    updateProductForSelling(newProduct, productName, productPrice, ref sellingCount);
                    adminOption = admin_menu();
                }
                else if (adminOption == '4')
                {
                    clearScreen();
                    Console.WriteLine("Enter Product Name you want to Delete: ");
                    string newProduct = Console.ReadLine();
                    deleteProductForSelling(newProduct, productName, productPrice, ref sellingCount);
                    adminOption = admin_menu();
                }
                clearScreen();
                saveProductData(productPath, productName, productPrice, sellingCount);

            }
        }
        static void saveProductData(string productPath, string[] productName, int[] productPrice, int sellingCount)
        {
            StreamWriter file = new StreamWriter(productPath, false);
            for (int x = 0; x < sellingCount; x++)
            {
                file.WriteLine(productName[x] + "," + productPrice[x]);
            }
            file.Flush();
            file.Close();
        }
        static void viewProducts(string[] productName, int[] productPrice, int sellingCount)
        {
            Console.WriteLine("Product\t\tPrice");
            for (int x = 0; x < sellingCount; x++)
            {
                Console.WriteLine(productName[x] + "\t\t" + productPrice[x]);
            }
        }
        static void updateProductForSelling(string newProduct, string[] productName, int[] productPrice, ref int sellingCount)
        {
            int update = searchProduct(newProduct, productName, sellingCount);
            if (update >= 0 && update <= 4)
            {
                Console.WriteLine("Product Found");
                Console.WriteLine("Enter the Updated price");
                int newPrice = int.Parse(Console.ReadLine());
                productPrice[update] = newPrice;
            }
            else
            {
                clearScreen();
                Console.WriteLine("Product Does Not Exists.");
            }
        }

        static void deleteProductForSelling(string newProduct, string[] productName, int[] productPrice, ref int sellingCount)
        {
            int delete = searchProduct(newProduct, productName, sellingCount);
            if (delete >= 0 && delete <= 4)
            {
                Console.WriteLine("Product Found");
                for (int x = delete; x < sellingCount - 1; x++)
                {
                    productName[x] = productName[x + 1];
                    productPrice[x] = productPrice[x + 1];
                }
                sellingCount = sellingCount - 1;
            }
        }
        static int searchProduct(string newProduct, string[] productName, int sellingCount)
        {
            for (int x = 0; x < sellingCount; x++)
            {
                if (newProduct == productName[x])
                {
                    return x;
                }
            }
            return -1;
        }
        static void addProductForSelling(string newProduct, int newPrice, string[] productName, int[] productPrice, ref int sellingCount)
        {
            if (sellingCount <= 4)
            {
                productName[sellingCount] = newProduct;
                productPrice[sellingCount] = newPrice;
                sellingCount = sellingCount + 1;
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
        static void readProductData(string productPath, string[] productName, int[] productPrice, ref int sellingCount)
        {
            StreamReader fp = new StreamReader(productPath);
            string record;
            while ((record = fp.ReadLine()) != null)
            {
                if (sellingCount > 4)
                {
                    break;
                }
                productName[sellingCount] = parseData(record, 1);
                productPrice[sellingCount] = int.Parse(parseData(record, 2));
                sellingCount = sellingCount + 1;
            }
            fp.Close();
        }
        static char admin_menu()
        {
            Console.Clear();
            char op;
            Console.WriteLine(" \t1.\t View list of products and price");
            Console.WriteLine(" \t2.\t Add product  and their prices");
            Console.WriteLine(" \t3.\t Delete  selling product and their prices");
            Console.WriteLine(" \t4.\t Update selling products and their prcices");
            Console.WriteLine(" \t5.\t Exit: ");
            Console.WriteLine(" \tEnter Option: ");
            op = char.Parse(Console.ReadLine());
            return op;
        }
        static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
