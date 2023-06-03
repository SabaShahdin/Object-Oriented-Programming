using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.BL;
namespace Store.DL
{
    public class CustomerCurd
    {
        public static void BuyProduct(List <Product> pro)
        {
           Console.WriteLine("Entre name of prodcut you want to buy");
           string name = Console.ReadLine();
           foreach(Product p1 in pro)
           { 
              if(name == p1.Name)
              {
              Console.WriteLine("Product Found");
              Console.WriteLine("Entre quantity you woh like to buy");
              int quantity = int.Parse (Console.ReadLine());
              p1.Quantity = p1.Quantity - quantity;
                break;
              }
              else
              {
                    Console.WriteLine("Product not present");
              }
           }
        }
        public static void GenerateInvoice(List<Product> products)
        {
            float totalAmount ;            
            foreach (Product product in products)
            {  
              float tax = ProductCurd.calculateTax();
              totalAmount = (product.Price + tax) * product.Quantity;
              Console.WriteLine("productName \t\t price \t\t   Quantity \t\t  totalAmount ");
              Console.WriteLine(product.Name  + "\t\t" +  product.Price +  "\t\t" +   product.Quantity  + "\t\t" +   totalAmount );
            }

        }
    }
}
