using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace store
{
    class Store
    {
        public string Name;
        public string Category;
        public int Price;
        public int Quantity;
        public int MinimumQuantity;

        public Store()
        {
            Console.WriteLine("Default Constructor");
        }
        public Store(string n, string C, int price , int quantity , int M )
        {
            Name = n;
            Category = C;
            Price = price;
            Quantity = quantity;
            MinimumQuantity = M;
        }
        public Store (Store s1)
        {
            s1.Name = Name;
            s1.Category = Category;
            s1.Price = Price;
        }
        public void  calculateTax(List <Store> product)
        {
            float tax = 0.0F;
            Console.WriteLine ("Enter name of product...");
            string nameOfProduct =  Console.ReadLine();
            int search = SearchPrice(nameOfProduct , product);
            if(search != -1)
            { 
                if (product[search].Category == "Grocery")
                {
                  tax = product[search].Price * 10 / 100F;
                }
                else if (product[search].Category == "Fruit")
                { 
                 tax = product[search].Price * 5 / 100F;
                }
                else
                {
                   tax = product[search].Price * 15 / 100F;
                }
            }
            else 
            { 
                  Console.WriteLine("Product not found");
            }
            Console.WriteLine("Sales tax of product is  " +  product[search].Name +   "       " + product[search].Category +  "      " +  product[search].Price  + "      " + tax);
        }
        public int SearchPrice(string nameOfProduct , List<Store> product)
        {
           for (int x = 0; x < product.Count; x++)
           {
               if (nameOfProduct == product[x].Name)
               {
                    return x;
               }
           }
            return -1;
        }
        public  bool stockQuantity(List <Store> product)
        {
             Console.WriteLine ("Enter name of product...");
            string nameOfProduct =  Console.ReadLine();
            int search = SearchPrice(nameOfProduct , product);
            bool flag = true;
            if(search != -1)
            { 
            if(product[search].Quantity < product[search].MinimumQuantity)
            {
                 flag = true;
            }
            else
            {
                flag= false;
            }
            }
            else
            {
                Console.WriteLine ("Product not found");
                    
            }
            return flag ;
        }
        public  void viewProducts(List<Store> c1)
        {
            Console.Clear();
            for (int x = 0; x < c1.Count; x++)
            {
                Console.WriteLine("Name :  {0} , Price {1}  , Category {2} , Quantity  {3} , MinimumQuantity {4} " , c1[x].Name  , c1[x].Price  , c1[x].Category , c1[x].Quantity , c1[x]. MinimumQuantity);
                
            }
           Console.WriteLine ("Press any key to continue ") ;
           Console.ReadKey();
        }
        public int largest (List<Store>  s1 )
        {
            int index  = 0 ;
            int large = s1[index].Price ;
            
            for (int x = 0 ; x < s1.Count; x ++ )
            {
                if(large < s1[x].Price)
                {
                    large = s1[x].Price;
                    index = x;
                }
            }
            return index;
        }
        public  void Find (List<Store> c1)
        {
            int large = largest (c1);
            Console.WriteLine ("The product of largest price is   "  +  c1[large].Name +  "       " +  c1[large].Category +  "       "+  c1[large]. Price );
            Console.WriteLine ("Press any key to continue ") ;
            Console.ReadKey();
        }
    }
}
