using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class Discount
    {
        public int DiscountID { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }  // Percentage | Fixed
        public decimal Value { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; }

    }
}
