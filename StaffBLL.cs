using CourierDB.DAL;
using CourierDB.DomainClasses;
using System.Data;

namespace CourierDB.BLL
{
    internal class StaffBLL
    {
        private StaffDAL dal = new StaffDAL();

        public DataTable GetAllStaff()               => dal.GetAllStaff();
        public DataTable GetStaffByID(int staffID)    => dal.GetStaffByID(staffID);
        public DataTable GetStaffByBranch(int bid)    => dal.GetStaffByBranch(bid);

        public string AddStaff(CourierStaff s)
        {
            if (s.UserID <= 0)
                return "A valid user must be selected.";
            if (s.BranchID <= 0)
                return "A valid branch must be selected.";
            if (string.IsNullOrWhiteSpace(s.Designation))
                return "Designation is required.";
            if (string.IsNullOrWhiteSpace(s.CNIC) || s.CNIC.Length != 13)
                return "CNIC must be exactly 13 digits (no dashes).";

            dal.AddStaff(s);
            return "Staff member added successfully.";
        }

        public string UpdateStaff(CourierStaff s)
        {
            if (s.StaffID <= 0)
                return "Invalid staff ID.";
            if (s.BranchID <= 0)
                return "A valid branch must be selected.";
            if (string.IsNullOrWhiteSpace(s.Designation))
                return "Designation is required.";
            if (string.IsNullOrWhiteSpace(s.CNIC) || s.CNIC.Length != 13)
                return "CNIC must be exactly 13 digits (no dashes).";

            dal.UpdateStaff(s);
            return "Staff record updated successfully.";
        }

        public string DeleteStaff(int staffID)
        {
            if (staffID <= 0) return "Invalid staff ID.";
            dal.DeleteStaff(staffID);
            return "Staff record deleted.";
        }
    }
}
