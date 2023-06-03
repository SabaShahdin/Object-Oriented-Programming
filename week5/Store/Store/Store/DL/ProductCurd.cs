using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BL;

namespace Store.DL
{
    public class ProductCurd
    {
        public static List <Product> products =new List<Product> ();

        public static void viewProducts()
        {
            foreach(Product pro in products)
            {
                Console.WriteLine("Name {0} , Price {1}  , Category {2} , Quantity  {3} , MinimumQuantity {4} " , pro.Name  , pro.Price  , pro.Category , pro.Quantity , pro. MinimumQuantity);                
            }
           Console.WriteLine ("Press any key to continue ") ;
           Console.ReadKey();
        }
        public static int largest ()
        {
            int index  = 0 ;
            int large = products[index].Price ;
            
            for(int x = 0 ;  x < products.Count ; x++)
            {
                if(large < products[x].Price)
                {
                    large = products[x].Price;
                    index = x;
                }
            }
            return index;
        }
        public static void Find ()
        {
            int large = largest ();
            Console.WriteLine ("The product of largest price is   "  + products[large].Name +  "       " +  products[large].Category +  "       "+  products[large]. Price );
            Console.WriteLine ("Press any key to continue ") ;
            Console.ReadKey();
        }

        public static float calculateTax()
        {
            float tax = 0.0F;
            Console.WriteLine ("Enter name of product...");
            string nameOfProduct =  Console.ReadLine();
            int search = SearchPrice(nameOfProduct);
            if(search != -1)
            { 
                if (products[search].Category == "Grocery")
                {
                  tax = products[search].Price * 10 / 100F;
                }
                else if (products[search].Category == "Fruit")
                { 
                 tax = products[search].Price * 5 / 100F;
                }
                else
                {
                   tax = products[search].Price * 15 / 100F;
                }
            }
            else 
            { 
                  Console.WriteLine("Product not found");
            }
            
            Console.WriteLine("Sales tax of product is  " +  products[search].Name +   "       " + products[search].Category +  "      " +  products[search].Price  + "      " + tax);
            return tax;
        }
        public static int SearchPrice(string nameOfProduct)
        {
           for (int x = 0 ; x < products.Count  ; x ++ )
           {
               if (nameOfProduct == products[x].Name)
               {
                    return x ;
               }
           }
            return -1;
        }
        public static  bool stockQuantity()
        {
            Console.WriteLine ("Enter name of product...");
            string nameOfProduct =  Console.ReadLine();
            int search = SearchPrice(nameOfProduct);
            bool flag = true;
            if(search != -1)
            { 
               if(products[search].Quantity < products[search].MinimumQuantity)
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
        public static void AddIntoList(Product p1 )
        {
            products.Add(p1);
        }
    }
}
