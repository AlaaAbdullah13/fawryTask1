using FawryTask.Models;
using FawryTask.Services;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(" Welcome to Fawry E-Commerce\n");

        Console.Write(" Enter your name: ");
        string name = Console.ReadLine();

        double balance;
        while (true)
        {
            Console.Write(" Enter your balance: ");
            if (double.TryParse(Console.ReadLine(), out balance) && balance >= 0)
                break;

            Console.WriteLine("Invalid input. Please enter a valid number for balance.");
        }

        var customer = new Customer(name, balance);

        // avaliable Products
        var products = new List<Product>
        {
            new ShippableProduct("Cheese", 100, 5, 0.2),
            new ExpirableProduct("Biscuits", 150, 3, DateTime.Now.AddDays(2)),
            new ShippableProduct("TV", 200, 2, 500),
            new Product("Scratch Card", 50, 10)
        };

        var cart = new Cart();

        // show products and add to cart
        while (true)
        {
            Console.WriteLine("\nAvailable Products:");
            for (int i = 0; i < products.Count; i++)
            {
                var p = products[i];
                Console.WriteLine($"{i + 1}. {p.Name} - Price: {p.Price} - Available: {p.Quantity}");
            }

            Console.Write("\n Enter product number to add to cart (0 to checkout): ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine(" Invalid input. Please enter a number.");
                continue;
            }

            if (choice == 0)
                break;

            if (choice < 1 || choice > products.Count)
            {
                Console.WriteLine(" Invalid product number. Please try again.");
                continue;
            }

            var selectedProduct = products[choice - 1];

            Console.Write($"Enter quantity for {selectedProduct.Name}: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                continue;
            }

            if (qty > selectedProduct.Quantity)
            {
                Console.WriteLine($" Not enough stock. Only {selectedProduct.Quantity} available.");
                continue;
            }

            cart.Add(selectedProduct, qty);
            Console.WriteLine($" Added {qty} x {selectedProduct.Name} to your cart.");
        }

        Console.WriteLine("\n Proceeding to checkout...\n");

        var checkoutService = new CheckoutService();
        checkoutService.Checkout(customer, cart);

        Console.WriteLine("\n Thank you for shopping with Fawry!");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
