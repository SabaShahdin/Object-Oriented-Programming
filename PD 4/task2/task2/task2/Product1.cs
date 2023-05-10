using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Product1
    {
        public string productName1;
        public int productPrice1;
        public int numberOfproducts1;
        public string day1;
        public int oneDayRecord1;

        public Product1()
        {

        }
        public Product1(string productName, int productPrice)
        {
            this.productName1 = productName;
            this.productPrice1 = productPrice;
        }
        public Product1(string productName, int numberofProduct, string day)
        {
            this.productName1 = productName;
            this.numberOfproducts1 = numberofProduct;
            this.day1 = day;
        }
        public int searchProduct1(List<Product1> product1, string newProduct1)
        {
            for (int x = 0; x < product1.Count; x++)
            {
                if (product1 == null)
                {
                        return -1;
                }
               else  if (newProduct1 == product1[x].productName1)
                {
                    return x;
                }
            }
            return -1;

        }
        public int searchPrice1(List<Product1> product1, Product1 p)
        {
            for (int x = 0; x < product1.Count; x++)
            {
                if (product1 == null)
                {
                        return -1;
                }
               else  if (p.productName1 == product1[x].productName1)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}
