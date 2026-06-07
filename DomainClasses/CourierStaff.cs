using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DomainClasses
{
    internal class CourierStaff
    {
        public int StaffID { get; set; }
        public int UserID { get; set; }
        public int BranchID { get; set; }
        public string Designation { get; set; }
        public string CNIC { get; set; }
        public DateTime JoinDate { get; set; }
        public bool IsActive { get; set; }
    }
}
