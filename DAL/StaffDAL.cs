using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace CourierDB.DAL
{
    internal class StaffDAL
    {
        public DataTable GetAllStaff()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT cs.staff_id, u.name AS staff_name, u.email, u.phone, " +
                "b.shop_name AS branch_name, cs.designation, cs.cnic, " +
                "cs.join_date, cs.is_active " +
                "FROM courier_staff cs " +
                "JOIN users u  ON cs.user_id   = u.user_id " +
                "LEFT JOIN branch b ON cs.branch_id = b.seller_id " +
                "ORDER BY cs.staff_id DESC");
        }

        public DataTable GetStaffByID(int staffID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", staffID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT cs.*, u.name, u.email, u.phone, b.shop_name AS branch_name " +
                "FROM courier_staff cs " +
                "JOIN users u ON cs.user_id = u.user_id " +
                "LEFT JOIN branch b ON cs.branch_id = b.seller_id " +
                "WHERE cs.staff_id = @id", p);
        }

        public DataTable GetStaffByBranch(int branchID)
        {
            MySqlParameter[] p = { new MySqlParameter("@bid", branchID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT cs.staff_id, u.name AS staff_name, cs.designation, cs.is_active " +
                "FROM courier_staff cs " +
                "JOIN users u ON cs.user_id = u.user_id " +
                "WHERE cs.branch_id = @bid AND cs.is_active = 1", p);
        }

        public int AddStaff(CourierStaff s)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@uid",    s.UserID),
                new MySqlParameter("@branch", s.BranchID),
                new MySqlParameter("@desig",  s.Designation),
                new MySqlParameter("@cnic",   s.CNIC),
                new MySqlParameter("@join",   s.JoinDate.Date),
                new MySqlParameter("@active", s.IsActive ? 1 : 0)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO courier_staff (user_id, branch_id, designation, cnic, join_date, is_active) " +
                "VALUES (@uid, @branch, @desig, @cnic, @join, @active)", p);
        }

        public int UpdateStaff(CourierStaff s)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@branch", s.BranchID),
                new MySqlParameter("@desig",  s.Designation),
                new MySqlParameter("@cnic",   s.CNIC),
                new MySqlParameter("@join",   s.JoinDate.Date),
                new MySqlParameter("@active", s.IsActive ? 1 : 0),
                new MySqlParameter("@id",     s.StaffID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE courier_staff SET branch_id=@branch, designation=@desig, " +
                "cnic=@cnic, join_date=@join, is_active=@active " +
                "WHERE staff_id=@id", p);
        }

        public int DeleteStaff(int staffID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", staffID) };
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM courier_staff WHERE staff_id = @id", p);
        }
    }
}
