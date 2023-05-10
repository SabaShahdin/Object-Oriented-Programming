using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Product
    {
        public string name;
        public string Category;
        public int Price;
        List<Product> product = new List<Product>();
        public Product(string n)
        {
            this.name = n;
        }
        public Product(string n, string C, int price)
        {
            this.name = n;
            this.Category = C;
            this.Price = price;
        }
        public void  calculateTax(List<Product> product)
        {          
             float tax = 0.0F;
            for(int x = 0; x < product.Count; x++)
            {
                if (product[x].Category == "Grocery")
                {
                    tax = product[x].Price * 10 / 100F;
                }
                else if (product[x].Category == "Fruit")
                {
                    tax = product[x].Price * 5 / 100F;
                }
                else
                {
                    tax = product[x].Price * 15 / 100F;
                }
                Console.WriteLine("Sales tax of product is  " + product[x].name + "       " + product[x].Category + "      " + product[x].Price + "      " + tax);
            }
                
        }
    }
}
