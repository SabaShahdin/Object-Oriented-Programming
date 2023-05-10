using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    class Customer
    {
        public string name;
        public string address;
        public string contact;
        public List<Product>  purchasedProduct = new List<Product> ();
        public Customer (string name , string address , string contact)
        {
            this.name = name;
            this.address = address;
            this.contact = contact;
        }
        public List<Product> GetProducts()
        {
            return purchasedProduct;
        }
        public void addProducts(Product product)
        {
            purchasedProduct.Add(product);
        }
    }
}
