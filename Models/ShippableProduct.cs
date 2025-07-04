using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FawryTask.Interfaces;

namespace FawryTask.Models
{
    public class ShippableProduct : Product, IShippableProduct
    {
        public double Weight { get; }

        public ShippableProduct(string name, double price, int quantity, double weight)
            : base(name, price, quantity)
        {
            Weight = weight;
        }

        public string GetName()
        {
            return Name;
        }

        public double GetWeight()
        {
            return Weight;
        }
    }

}
