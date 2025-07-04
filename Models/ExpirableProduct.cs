using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryTask.Models
{
    public class ExpirableProduct : Product
    {
        public DateTime ExpiryDate { get; }

        public ExpirableProduct(string name, double price, int quantity, DateTime expiryDate)
            : base(name, price, quantity)
        {
            ExpiryDate = expiryDate;
        }

        public override bool IsExpired()
        {
            return DateTime.Now > ExpiryDate;
        }
    }

}
