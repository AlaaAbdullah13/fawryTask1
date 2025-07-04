using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FawryTask.Interfaces;

namespace FawryTask.Services
{
    public class ShippingService
    {
        public static void Ship(List<IShippableProduct> items)
        {
            if (!items.Any()) return;

            Console.WriteLine("\n Shipment notice:");
            double totalWeight = 0;

            foreach (var item in items)
            {
                Console.WriteLine($"{item.GetName()} - {item.GetWeight()}kg");
                totalWeight += item.GetWeight();
            }

            Console.WriteLine($"Total package weight: {totalWeight}kg\n");
        }
    }

}
