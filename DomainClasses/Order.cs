using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class Order
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int AddressID { get; set; }
        public int? DiscountID { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountApplied { get; set; }
        public string Status { get; set; }  // Pending|Confirmed|Shipped|Delivered|Cancelled
        public DateTime OrderDate { get; set; }

    }
}
