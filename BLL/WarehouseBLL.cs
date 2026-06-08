using CourierDB.DAL;
using System.Data;

namespace CourierDB.BLL
{
    internal class WarehouseBLL
    {
        private WarehouseDAL dal = new WarehouseDAL();

        public DataTable GetAllWarehouses()                     => dal.GetAllWarehouses();
        public DataTable GetActiveWarehouses()                   => dal.GetActiveWarehouses();
        public DataTable GetWarehouseByID(int warehouseID)       => dal.GetWarehouseByID(warehouseID);

        public string AddWarehouse(string name, string city, string address,
                                   int capacity, int used, bool isActive)
        {
            if (string.IsNullOrWhiteSpace(name))    return "Warehouse name is required.";
            if (string.IsNullOrWhiteSpace(city))    return "City is required.";
            if (capacity <= 0)                       return "Capacity must be greater than 0.";
            if (used < 0)                            return "Used units cannot be negative.";
            if (used > capacity)                     return "Used units cannot exceed capacity.";

            dal.AddWarehouse(name.Trim(), city.Trim(), address?.Trim() ?? "", capacity, used, isActive);
            return "Warehouse added successfully.";
        }

        public string UpdateWarehouse(int warehouseID, string name, string city,
                                      string address, int capacity, int used, bool isActive)
        {
            if (warehouseID <= 0)                    return "Invalid warehouse ID.";
            if (string.IsNullOrWhiteSpace(name))    return "Warehouse name is required.";
            if (string.IsNullOrWhiteSpace(city))    return "City is required.";
            if (capacity <= 0)                       return "Capacity must be greater than 0.";
            if (used < 0)                            return "Used units cannot be negative.";
            if (used > capacity)                     return "Used units cannot exceed capacity.";

            dal.UpdateWarehouse(warehouseID, name.Trim(), city.Trim(),
                                address?.Trim() ?? "", capacity, used, isActive);
            return "Warehouse updated successfully.";
        }

        public string DeleteWarehouse(int warehouseID)
        {
            if (warehouseID <= 0) return "Invalid warehouse ID.";
            dal.DeleteWarehouse(warehouseID);
            return "Warehouse deleted successfully.";
        }
    }
}
