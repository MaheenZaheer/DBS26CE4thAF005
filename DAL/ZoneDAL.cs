using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System.Data;

namespace CourierDB.DAL
{
    internal class ZoneDAL
    {
        public DataTable GetAllZones()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT zone_id, zone_name, cities, base_rate, per_kg_rate, is_active " +
                "FROM delivery_zone ORDER BY zone_id");
        }

        public DataTable GetActiveZones()
        {
            return DatabaseHelper.ExecuteQuery(
                "SELECT zone_id, zone_name, cities, base_rate, per_kg_rate " +
                "FROM delivery_zone WHERE is_active = 1 ORDER BY zone_name");
        }

        public DataTable GetZoneByID(int zoneID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", zoneID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM delivery_zone WHERE zone_id = @id", p);
        }

        public int AddZone(DeliveryZone z)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@name",   z.ZoneName),
                new MySqlParameter("@cities", z.Cities),
                new MySqlParameter("@base",   z.BaseRate),
                new MySqlParameter("@perkg",  z.PerKgRate),
                new MySqlParameter("@active", z.IsActive ? 1 : 0)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO delivery_zone (zone_name, cities, base_rate, per_kg_rate, is_active) " +
                "VALUES (@name, @cities, @base, @perkg, @active)", p);
        }

        public int UpdateZone(DeliveryZone z)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@name",   z.ZoneName),
                new MySqlParameter("@cities", z.Cities),
                new MySqlParameter("@base",   z.BaseRate),
                new MySqlParameter("@perkg",  z.PerKgRate),
                new MySqlParameter("@active", z.IsActive ? 1 : 0),
                new MySqlParameter("@id",     z.ZoneID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE delivery_zone SET zone_name=@name, cities=@cities, " +
                "base_rate=@base, per_kg_rate=@perkg, is_active=@active " +
                "WHERE zone_id=@id", p);
        }

        public int DeleteZone(int zoneID)
        {
            MySqlParameter[] p = { new MySqlParameter("@id", zoneID) };
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM delivery_zone WHERE zone_id = @id", p);
        }
    }
}
