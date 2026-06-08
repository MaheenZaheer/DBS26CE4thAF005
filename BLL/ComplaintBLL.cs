using CourierDB.DAL;
using CourierDB.SoftwareClasses;
using System.Data;

namespace CourierDB.BLL
{
    internal class ComplaintBLL
    {
        private ComplaintDAL dal = new ComplaintDAL();

        // ── File a complaint ───────────────────────────────────────────────
        public string FileComplaint(int userID, int? parcelID,
                                    string subject, string description)
        {
            if (!Validator.IsNotEmpty(subject))
                return "Subject is required.";
            if (!Validator.IsNotEmpty(description))
                return "Description is required.";
            if (parcelID.HasValue && parcelID.Value <= 0)
                return "Parcel ID must be a positive number.";

            dal.FileComplaint(userID, parcelID, subject.Trim(), description.Trim());
            return "Complaint filed successfully.";
        }

        // ── Resolve a complaint ────────────────────────────────────────────
        public string ResolveComplaint(int complaintID, int resolvedBy, string remarks)
        {
            if (complaintID <= 0)   return "Invalid complaint ID.";
            if (resolvedBy <= 0)    return "Invalid staff ID.";
            if (!Validator.IsNotEmpty(remarks))
                return "Resolution remarks are required.";

            dal.ResolveComplaint(complaintID, resolvedBy, remarks.Trim());
            return "Complaint resolved successfully.";
        }

        // ── Read complaints ────────────────────────────────────────────────
        public DataTable GetAllComplaints() => dal.GetAllComplaints();

        public DataTable GetComplaintsByUser(int userID)
        {
            if (userID <= 0) throw new System.Exception("Invalid user ID.");
            return dal.GetComplaintsByUser(userID);
        }

        public DataTable GetComplaintByID(int complaintID)
        {
            if (complaintID <= 0) throw new System.Exception("Invalid complaint ID.");
            return dal.GetComplaintByID(complaintID);
        }
    }
}
