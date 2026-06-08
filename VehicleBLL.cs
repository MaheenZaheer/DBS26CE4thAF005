using CourierDB.DAL;
using CourierDB.DomainClasses;
using System.Data;

namespace CourierDB.BLL
{
    internal class VehicleBLL
    {
        private VehicleDAL dal = new VehicleDAL();

        public DataTable GetAllVehicles()              => dal.GetAllVehicles();
        public DataTable GetAvailableVehicles()        => dal.GetAvailableVehicles();
        public DataTable GetVehiclesByBranch(int bid)  => dal.GetVehiclesByBranch(bid);
        public DataTable GetVehicleByID(int vehicleID) => dal.GetVehicleByID(vehicleID);

        public string AddVehicle(Vehicle v)
        {
            if (string.IsNullOrWhiteSpace(v.RegistrationNo))
                return "Registration number is required.";
            if (string.IsNullOrWhiteSpace(v.VehicleType))
                return "Vehicle type is required.";
            if (v.CapacityKg <= 0)
                return "Capacity must be greater than 0.";
            if (v.BranchID <= 0)
                return "A valid branch must be selected.";

            dal.AddVehicle(v);
            return "Vehicle added successfully.";
        }

        public string UpdateVehicle(Vehicle v)
        {
            if (v.VehicleID <= 0)                          return "Invalid vehicle ID.";
            if (string.IsNullOrWhiteSpace(v.RegistrationNo)) return "Registration number is required.";
            if (v.CapacityKg <= 0)                         return "Capacity must be greater than 0.";

            dal.UpdateVehicle(v);
            return "Vehicle updated successfully.";
        }

        public string DeleteVehicle(int vehicleID)
        {
            if (vehicleID <= 0) return "Invalid vehicle ID.";
            dal.DeleteVehicle(vehicleID);
            return "Vehicle deleted successfully.";
        }

        public string SetAvailability(int vehicleID, bool isAvailable)
        {
            if (vehicleID <= 0) return "Invalid vehicle ID.";
            dal.SetAvailability(vehicleID, isAvailable);
            return isAvailable ? "Vehicle marked as available." : "Vehicle marked as unavailable.";
        }
    }
}
