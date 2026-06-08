using CourierDB.DAL;
using CourierDB.DomainClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.BLL
{
    internal class PaymentBLL
    {
        private PaymentDAL dal = new PaymentDAL();

        public string AddPayment(Payment pay)
        {
            if (pay.Amount <= 0) return "Amount must be greater than 0.";
            string[] methods = { "Cash", "Card", "EasyPaisa", "JazzCash" };
            if (System.Array.IndexOf(methods, pay.Method) < 0)
                return "Invalid payment method.";
            dal.AddPayment(pay);
            return "Payment recorded.";
        }

        public DataTable GetPaymentByOrder(int orderID) => dal.GetPaymentByOrder(orderID);

        public DataTable ProcessRefund(int orderID, string reason)
        {
            if (string.IsNullOrWhiteSpace(reason))
                throw new System.Exception("Refund reason is required.");
            return dal.ProcessRefund(orderID, reason);
        }

    }
}
