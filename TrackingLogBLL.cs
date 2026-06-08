using CourierDB.DAL;
using System.Data;

namespace CourierDB.BLL
{
    internal class TrackingLogBLL
    {
        private TrackingLogDAL dal = new TrackingLogDAL();

        // ── Get full tracking history for frmTrackingLog ───────────────────
        public DataTable GetLogByParcelID(int parcelID)
        {
            if (parcelID <= 0)
                throw new System.Exception("Invalid parcel ID.");
            return dal.GetLogByParcelID(parcelID);
        }

        // ── Get parcel header summary (tracking code, names, status) ──────
        public DataTable GetParcelHeader(int parcelID)
        {
            if (parcelID <= 0)
                throw new System.Exception("Invalid parcel ID.");
            return dal.GetParcelHeader(parcelID);
        }

        // ── Get most recent log entry ──────────────────────────────────────
        public DataTable GetLatestLogEntry(int parcelID)
        {
            if (parcelID <= 0)
                throw new System.Exception("Invalid parcel ID.");
            return dal.GetLatestLogEntry(parcelID);
        }

        // ── Total log entries for status label ────────────────────────────
        public int GetLogCount(int parcelID)
        {
            if (parcelID <= 0) return 0;
            return dal.GetLogCount(parcelID);
        }
    }
}
