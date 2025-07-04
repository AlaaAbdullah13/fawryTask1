using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask.Models
{
    public class CartItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public double TotalPrice => Product.Price * Quantity;
    }

}
