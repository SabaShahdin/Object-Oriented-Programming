using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.BL
{
    public class Product
    {
        public string Name;
        public string Category;
        public int Price;
        public int Quantity;
        public int MinimumQuantity;

        public Product (string name , string Category , int price , int quantity , int MinimumQuantity )
        {
            this.Name = name;
            this.Category = Category ;
            this.Price = price;
            this.Quantity = quantity;
            this.MinimumQuantity = MinimumQuantity;
        }
    }
}
