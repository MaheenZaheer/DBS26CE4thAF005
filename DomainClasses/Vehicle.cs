using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class Vehicle
    {
        public int VehicleID { get; set; }
        public string RegistrationNo { get; set; }
        public string VehicleType { get; set; }
        public decimal CapacityKg { get; set; }
        public int BranchID { get; set; }
        public bool IsAvailable { get; set; }
    }
}
