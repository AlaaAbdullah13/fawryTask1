using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask.Models
{

      public class Product
        {
            public string Name { get; }
            public double Price { get; }
            public int Quantity { get; private set; }

            public Product(string name, double price, int quantity)
            {
                Name = name;
                Price = price;
                Quantity = quantity;
            }

            public virtual bool IsExpired()
            {
                return false;
            }

            public bool DecreaseStock(int amount)
            {
                if (Quantity >= amount)
                {
                    Quantity -= amount;
                    return true;
                }
                return false;
            }
        }
    

}
