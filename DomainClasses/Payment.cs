using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class Payment
    {
        public int PaymentID { get; set; }
        public int OrderID { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }  // Cash|Card|EasyPaisa|JazzCash
        public string Status { get; set; }  // Pending|Completed|Failed|Refunded
        public DateTime PaidAt { get; set; }

    }
}
