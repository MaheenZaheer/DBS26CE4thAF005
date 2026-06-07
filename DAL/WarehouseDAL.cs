using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class WarehouseDAL
    {
        public DataTable GetAllWarehouses()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT warehouse_id, warehouse_name, city, address, " +
                "capacity_units, used_units, is_active " +
                "FROM warehouse ORDER BY warehouse_id");
        }

        public DataTable GetActiveWarehouses()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT warehouse_id, warehouse_name, city, " +
                "(capacity_units - used_units) AS free_units " +
                "FROM warehouse WHERE is_active = 1 ORDER BY warehouse_name");
        }

        public DataTable GetWarehouseByID(int warehouseID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", warehouseID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM warehouse WHERE warehouse_id = @id", p);
        }

        public int AddWarehouse(string name, string city, string address,
                                int capacity, int used, bool isActive)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@name",   name),
                new MySqlParameter("@city",   city),
                new MySqlParameter("@addr",   address),
                new MySqlParameter("@cap",    capacity),
                new MySqlParameter("@used",   used),
                new MySqlParameter("@active", isActive ? 1 : 0)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO warehouse (warehouse_name, city, address, capacity_units, used_units, is_active) " +
                "VALUES (@name, @city, @addr, @cap, @used, @active)", p);
        }

        public int UpdateWarehouse(int warehouseID, string name, string city,
                                   string address, int capacity, int used, bool isActive)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@name",   name),
                new MySqlParameter("@city",   city),
                new MySqlParameter("@addr",   address),
                new MySqlParameter("@cap",    capacity),
                new MySqlParameter("@used",   used),
                new MySqlParameter("@active", isActive ? 1 : 0),
                new MySqlParameter("@id",     warehouseID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE warehouse SET warehouse_name=@name, city=@city, address=@addr, " +
                "capacity_units=@cap, used_units=@used, is_active=@active " +
                "WHERE warehouse_id=@id", p);
        }

        public int DeleteWarehouse(int warehouseID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", warehouseID) };
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM warehouse WHERE warehouse_id = @id", p);
        }
    }
}
