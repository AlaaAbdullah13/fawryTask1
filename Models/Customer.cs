using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask.Models
{
    public class Customer
    {
        public string Name { get; }
        public double Balance { get; private set; }

        public Customer(string name, double balance)
        {
            Name = name;
            Balance = balance;
        }

        public bool Deduct(double amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

}
