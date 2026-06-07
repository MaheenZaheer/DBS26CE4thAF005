using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.SoftwareClasses
{
    internal class DatabaseHelper
    {
        private static string connectionString =
    "Server=localhost;Database=CourierDB;Uid=root;Pwd=2)Dkx&86c0;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        // INSERT / UPDATE / DELETE
        public static int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("DatabaseHelper", ex.Message, ex.StackTrace);
                throw;
            }
        }

        // SELECT — returns DataTable
        public static DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("DatabaseHelper", ex.Message, ex.StackTrace);
                throw;
            }
        }

        // Stored Procedure — returns DataTable
        public static DataTable ExecuteStoredProcedure(string procName,
                                                        MySqlParameter[] parameters = null)
        {
            try
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(procName, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                Logger.LogError("DatabaseHelper", ex.Message, ex.StackTrace);
                throw;
            }
        }

    }
}
