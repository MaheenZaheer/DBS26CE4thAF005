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
    internal class UserDAL
    {
        public DataTable GetAllUsers()
        {
            return DatabaseHelper.ExecuteQuery("SELECT * FROM users");
        }

        public DataTable GetUserByID(int userID)
        {
            MySqlParameter[] p = { new MySqlParameter("@userID", userID) };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM users WHERE user_id = @userID", p);
        }

        public DataTable Login(string email, string passwordHash)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@email",        email),
                new MySqlParameter("@passwordHash", passwordHash)
            };
            return DatabaseHelper.ExecuteQuery(
                "SELECT * FROM users WHERE email=@email AND password_hash=@passwordHash", p);
        }

        public int AddUser(User u)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@name",  u.Name),
                new MySqlParameter("@email", u.Email),
                new MySqlParameter("@hash",  u.PasswordHash),
                new MySqlParameter("@phone", u.Phone),
                new MySqlParameter("@role",  u.Role)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "INSERT INTO users (name,email,password_hash,phone,role) " +
                "VALUES (@name,@email,@hash,@phone,@role)", p);
        }

        public int UpdateUser(User u)
        {
            MySqlParameter[] p = {
                new MySqlParameter("@name",   u.Name),
                new MySqlParameter("@email",  u.Email),
                new MySqlParameter("@phone",  u.Phone),
                new MySqlParameter("@userID", u.UserID)
            };
            return DatabaseHelper.ExecuteNonQuery(
                "UPDATE users SET name=@name, email=@email, phone=@phone " +
                "WHERE user_id=@userID", p);
        }

        public int DeleteUser(int userID)
        {
            MySqlParameter[] p = { new MySqlParameter("@userID", userID) };
            return DatabaseHelper.ExecuteNonQuery(
                "DELETE FROM users WHERE user_id=@userID", p);
        }

    }
}
