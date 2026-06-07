using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class VehicleDAL
    {
        public DataTable GetAllVehicles()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT v.vehicle_id, v.registration_no, v.vehicle_type, " +
                "v.capacity_kg, v.is_available, b.shop_name AS branch_name " +
                "FROM vehicle v " +
                "LEFT JOIN branch b ON v.branch_id = b.seller_id " +
                "ORDER BY v.vehicle_id DESC");
        }

        public DataTable GetAvailableVehicles()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT vehicle_id, registration_no, vehicle_type, capacity_kg " +
                "FROM vehicle WHERE is_available = 1 ORDER BY registration_no");
        }

        public DataTable GetVehiclesByBranch(int branchID)
        {
            MySqlParameter[] p = { new MySqlParameter("@bid", branchID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vehicle WHERE branch_id = @bid ORDER BY vehicle_id", p);
        }

        public DataTable GetVehicleByID(int vehicleID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", vehicleID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM vehicle WHERE vehicle_id = @id", p);
        }

        public int AddVehicle(Vehicle v)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@regno",    v.RegistrationNo),
                new MySqlParameter("@type",     v.VehicleType),
                new MySqlParameter("@capacity", v.CapacityKg),
                new MySqlParameter("@branch",   v.BranchID),
                new MySqlParameter("@avail",    v.IsAvailable ? 1 : 0)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO vehicle (registration_no, vehicle_type, capacity_kg, branch_id, is_available) " +
                "VALUES (@regno, @type, @capacity, @branch, @avail)", p);
        }

        public int UpdateVehicle(Vehicle v)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@regno",    v.RegistrationNo),
                new MySqlParameter("@type",     v.VehicleType),
                new MySqlParameter("@capacity", v.CapacityKg),
                new MySqlParameter("@branch",   v.BranchID),
                new MySqlParameter("@avail",    v.IsAvailable ? 1 : 0),
                new MySqlParameter("@id",       v.VehicleID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE vehicle SET registration_no=@regno, vehicle_type=@type, " +
                "capacity_kg=@capacity, branch_id=@branch, is_available=@avail " +
                "WHERE vehicle_id=@id", p);
        }

        public int DeleteVehicle(int vehicleID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", vehicleID) };
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM vehicle WHERE vehicle_id = @id", p);
        }

        public int SetAvailability(int vehicleID, bool isAvailable)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@avail", isAvailable ? 1 : 0),
                new MySqlParameter("@id",    vehicleID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE vehicle SET is_available=@avail WHERE vehicle_id=@id", p);
        }
    }
}
