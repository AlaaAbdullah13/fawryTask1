using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask.Models
{
    public class Cart
    {
        private List<CartItem> items = new();

        public void Add(Product product, int quantity)
        {
            if (quantity > product.Quantity)
            {
                Console.WriteLine($"Not enough quantity for {product.Name}.");
                return;
            }

            items.Add(new CartItem(product, quantity));
        }

        public List<CartItem> GetItems() => items;
        public bool IsEmpty() => !items.Any();
        public double GetSubtotal() => items.Sum(i => i.TotalPrice);
    }

}
