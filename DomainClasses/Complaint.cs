using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class Complaint
    {
        public int ComplaintID { get; set; }
        public int UserID { get; set; }
        public int? ParcelID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime FiledAt { get; set; }
    }
}
