using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FawryTask.Interfaces;
using FawryTask.Models;


namespace FawryTask.Services
{
    public class CheckoutService
    {
        private const double ShippingFeePerKg = 30;

        public void Checkout(Customer customer, Cart cart)
        {
            if (cart.IsEmpty())
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            var items = cart.GetItems();
            List<IShippableProduct> shippableItems = new();
            double totalWeight = 0;

            foreach (var item in items)
            {
                if (item.Product.IsExpired())
                {
                    Console.WriteLine($" {item.Product.Name} is expired.");
                    return;
                }

                if (item.Quantity > item.Product.Quantity)
                {
                    Console.WriteLine($"{item.Product.Name} is out of stock.");
                    return;
                }

                item.Product.DecreaseStock(item.Quantity);

                if (item.Product is IShippableProduct shippable)
                {
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        shippableItems.Add(shippable);
                        totalWeight += shippable.GetWeight();
                    }
                }
            }

            double subtotal = cart.GetSubtotal();
            double shipping = totalWeight > 0 ? ShippingFeePerKg : 0;
            double totalAmount = subtotal + shipping;

            if (!customer.Deduct(totalAmount))
            {
                Console.WriteLine(" Insufficient balance.");
                return;
            }

            if (shippableItems.Any())
                ShippingService.Ship(shippableItems);

            Console.WriteLine("Checkout receipt:");
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Quantity}x {item.Product.Name} = {item.TotalPrice}");
            }

            Console.WriteLine("----------------------");
            Console.WriteLine($"Subtotal: {subtotal}");
            Console.WriteLine($"Shipping: {shipping}");
            Console.WriteLine($"Total Paid: {totalAmount}");
            Console.WriteLine($"Customer Balance: {customer.Balance}");
        }
    }


}
