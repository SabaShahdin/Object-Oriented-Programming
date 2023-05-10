using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Product
    {
        public string productName;
        public int productPrice;
        public int numberOfproducts;
        public string day;
        public int oneDayRecord;

        public Product ()
        {

        }
        public Product(string productName , int productPrice)
        {
            this.productName = productName;
            this.productPrice = productPrice;
        }
        public Product(string productName, int numberofProduct , string day)
        {
            this.productName = productName;
            this.numberOfproducts = numberofProduct;
            this.day = day;
        }
        public int searchProduct(List<Product> product, string newProduct)
        {
            for (int x = 0; x < product.Count; x++)
            {
                if (product == null)
                {
                        return -1;
                }
              else   if (newProduct == product[x].productName)
                {
                    return x;
                }
            }
            return -1;

        }
        public int searchPrice(List<Product> product , Product p)
        {
            for (int x = 0; x < product.Count; x++)
            {
                if (product == null)
                {
                        return -1;
                }
                if (p.productName == product[x].productName)
                {
                    return x;
                }
            }
            return -1;
        }
    }
}
