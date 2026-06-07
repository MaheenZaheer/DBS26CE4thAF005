using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.SoftwareClasses
{
    internal class Logger
    {
        public static void LogError(string module, string message, string stackTrace = null)
        {
            try
            {
                string query = "INSERT INTO error_log (module, message, stack_trace, logged_at) "
                             + "VALUES (@module, @message, @stackTrace, NOW())";

                MySqlParameter[] p = {
                    new MySqlParameter("@module",     module     ?? "Unknown"),
                    new MySqlParameter("@message",    message    ?? "No message"),
                    new MySqlParameter("@stackTrace", stackTrace ?? "")
                };
                DatabaseHelper.ExecuteNonQuery(query, p);
            }
            catch { /* Silently fail — logging must never crash the app */ }
        }

    }
}
