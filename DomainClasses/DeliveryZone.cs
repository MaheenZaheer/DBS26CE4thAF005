using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class DeliveryZone
    {
     
            public int ZoneID { get; set; }
            public string ZoneName { get; set; }
            public string Cities { get; set; }
            public decimal BaseRate { get; set; }
            public decimal PerKgRate { get; set; }
            public bool IsActive { get; set; }
        }
    }

