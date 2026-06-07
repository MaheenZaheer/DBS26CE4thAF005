using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class Parcel
    {
        public int ShipmentID { get; set; }
        public int OrderID { get; set; }
        public string CourierName { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }  // Processing|Shipped|OutForDelivery|Delivered
        public DateTime? ShippedAt { get; set; }  // Nullable
        public DateTime? DeliveredAt { get; set; }  // Nullable

    }
}
