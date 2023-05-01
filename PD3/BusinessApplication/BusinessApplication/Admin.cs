using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BusinessApplication
{
    public class Admin
    {
        public string ProductName;
        public int ProductPrice;
        public Admin()
        {

        }
        public Admin(string ProductName , int ProductPrice)
        {
            this.ProductName = ProductName;
            this.ProductPrice = ProductPrice;
        }
        public Admin AddProduct()
        {
            Console.WriteLine("Entre the name of product");
            string ProductName = Console.ReadLine();
            Console.WriteLine("Entre the price of product");
            int ProductPrice = int.Parse(Console.ReadLine());
            Admin product = new Admin(ProductName, ProductPrice);
            if (ProductName != null && ProductPrice != 0)
            {
                return product;
            }
            else
            {
                return null;
            }
        }
        public bool read(string path, List<Admin> products)
        {
            if (File.Exists(path))
            {
                StreamReader fileVariable = new StreamReader(path);
                string record;
                while ((record = fileVariable.ReadLine()) != null)
                {
                    string ProductName = parseAdminData(record, 1);
                    int ProductPrice = int.Parse(parseAdminData(record, 2));
                    Admin product = new Admin(ProductName, ProductPrice);
                    storeInList(products, product);
                }
                fileVariable.Close();
                return true;
            }
            return false;
        }
        static string parseAdminData(string record, int field)
        {
            int comma = 1;
            string item = "";
            for (int x = 0; x < record.Length;
           x++)
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
        public void storeInList(List<Admin> Products, Admin product)
        {
            Products.Add(product);
        }
        public  void storeInFile(string path , List<Admin> products)
        {
            StreamWriter file = new StreamWriter(path, false);
            foreach(Admin store in products)
            { 
             file.WriteLine(store.ProductName + "," + store.ProductPrice);
            }
            file.Flush();
            file.Close();
        }
        public  void viewProducts(List<Admin> products)
        {
            Console.Clear();
            foreach (Admin store in products)
            {
                Console.WriteLine("ProductName {0}  ProductPrice {1} ", store.ProductName, store.ProductPrice);
            }
        }
        public  int searchProduct(List<Admin> product, string newProduct)
        {
            for (int x = 0; x < product.Count; x++)
            {
                if (newProduct == product[x].ProductName)
                {
                    return x;
                }
            }
            return -1;
        }
        public  bool deleteProductForSelling(List<Admin> product, string newProduct)
        {
            int delete = searchProduct(product, newProduct);
            bool flag = true;
            if (delete >= 0 && delete <= 4)
            {
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        public bool  updateProductForSelling(List<Admin> product, string newProduct)
        {
            int update = searchProduct(product, newProduct);
            bool flag = true;
            if (update >= 0 && update <= 4)
            { 
                Console.WriteLine("Product Found");
                Console.WriteLine("Enter the Updated price");
                int newPrice = int.Parse(Console.ReadLine());
                product[update].ProductPrice = newPrice;
                return flag;
            }
            else
            {
                return flag = false;
            }
        }
        public int  menuAdmin()
        {
            int option;
         
            Console.WriteLine(" 1.\t\t Add product  and their prices");
            Console.WriteLine(" 2.\t\t View list of products and price");
            Console.WriteLine(" 3.\t\t Delete  selling product and their prices");
            Console.WriteLine(" 4.\t\t Update selling products and their prcices");
            Console.WriteLine(" 5.\t\t Logout");
            Console.WriteLine("Enter Option");
            option = int.Parse(Console.ReadLine());
            return option;
        }
        public void  adminChoice(List <Admin> Products , string path1 , Admin pro)
        {
            int choice;
            Console.Clear();
            do
            {
                choice = menuAdmin();
                Console.Clear();
                if (choice == 1)
                {
                   Admin  product = pro.AddProduct();
                   pro.storeInList(Products, product);
                }
                if(choice == 2)
                {
                    pro.viewProducts(Products);
                    Console.ReadKey();
                }
               else  if(choice == 3)
                {                    
                    Console.Clear();
                    pro.viewProducts(Products);
                    Console.WriteLine("Enter Product Name you want to Delete: ");
                    string newProduct = Console.ReadLine();
                    bool check = pro.deleteProductForSelling(Products, newProduct);
                    int delete = pro.searchProduct(Products, newProduct);
                    if (check == true)
                    {
                        Console.WriteLine("Product Found");
                        Products.RemoveAt(delete);
                        Console.WriteLine("Product deleted successfully");
                    }
                    else
                    {
                        Console.WriteLine("Product not  Found");
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
               }
                if(choice ==4)
                {
                    Console.Clear();
                    pro.viewProducts(Products);
                    Console.WriteLine("Enter Product Name you want to Update: ");
                    string newProduct = Console.ReadLine();
                    bool check = pro.updateProductForSelling(Products, newProduct);
                    if(check == true)
                    {
                        Console.WriteLine("Product Updated succefully Exists.");
                    }
                    else
                    {
                        Console.WriteLine("Product Does Not Exists.");
                    }
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }
                Console.Clear();
            }
            while (choice != 5);
            pro.storeInFile(path1, Products);
        }
    }

}
