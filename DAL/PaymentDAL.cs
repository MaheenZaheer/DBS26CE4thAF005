using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.DAL
{
    internal class PaymentDAL
    {
        public int AddPayment(Payment pay)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@orderID", pay.OrderID),
                new MySqlParameter("@amount",  pay.Amount),
                new MySqlParameter("@method",  pay.Method),
                new MySqlParameter("@status",  pay.Status)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO payment (order_id,amount,method,status) " +
                "VALUES (@orderID,@amount,@method,@status)", p);
        }

        public DataTable GetPaymentByOrder(int orderID)
        {
            MySqlParameter[] p = { new MySqlParameter("@orderID", orderID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM payment WHERE order_id=@orderID", p);
        }

        public int Updatepaymenttatus(int paymentID, string status)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@status",    status),
                new MySqlParameter("@paymentID", paymentID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE payment SET status=@status WHERE payment_id=@paymentID", p);
        }

        // Uses stored procedure sp_ProcessRefund
        public DataTable ProcessRefund(int orderID, string reason)
        {
            MySqlParameter[] p = {
                new MySqlParameter("p_order_id", orderID),
                new MySqlParameter("p_reason",   reason)
            };
            return DatabaseHelper.ExecuteStoredProcedure("sp_ProcessRefund", p);
        }

    }
}
