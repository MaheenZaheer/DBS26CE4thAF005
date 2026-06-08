using CourierDB.DAL;
using CourierDB.DomainClasses;
using System.Data;

namespace CourierDB.BLL
{
    internal class ZoneBLL
    {
        private ZoneDAL dal = new ZoneDAL();

        public DataTable GetAllZones()   => dal.GetAllZones();
        public DataTable GetActiveZones() => dal.GetActiveZones();
        public DataTable GetZoneByID(int zoneID) => dal.GetZoneByID(zoneID);

        public string AddZone(DeliveryZone z)
        {
            if (string.IsNullOrWhiteSpace(z.ZoneName))  return "Zone name is required.";
            if (string.IsNullOrWhiteSpace(z.Cities))    return "Cities are required.";
            if (z.BaseRate <= 0)                         return "Base rate must be greater than 0.";
            if (z.PerKgRate <= 0)                        return "Per-kg rate must be greater than 0.";

            dal.AddZone(z);
            return "Zone added successfully.";
        }

        public string UpdateZone(DeliveryZone z)
        {
            if (z.ZoneID <= 0)                           return "Invalid zone ID.";
            if (string.IsNullOrWhiteSpace(z.ZoneName))  return "Zone name is required.";
            if (string.IsNullOrWhiteSpace(z.Cities))    return "Cities are required.";
            if (z.BaseRate <= 0)                         return "Base rate must be greater than 0.";
            if (z.PerKgRate <= 0)                        return "Per-kg rate must be greater than 0.";

            dal.UpdateZone(z);
            return "Zone updated successfully.";
        }

        public string DeleteZone(int zoneID)
        {
            if (zoneID <= 0) return "Invalid zone ID.";
            dal.DeleteZone(zoneID);
            return "Zone deleted successfully.";
        }
    }
}
