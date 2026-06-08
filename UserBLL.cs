using CourierDB.DAL;
using CourierDB.DomainClasses;
using CourierDB.SoftwareClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierDB.BLL
{
    internal class UserBLL
    {
        private UserDAL dal = new UserDAL();

        public DataTable Login(string email, string password)
        {
            if (!Validator.IsValidEmail(email))
                throw new System.Exception("Invalid email format.");
            string hash = PasswordHasher.Hash(password);
            return dal.Login(email, hash);
        }

        public DataTable GetAllUsers() => dal.GetAllUsers();

        public string AddUser(User u)
        {
            if (!Validator.IsNotEmpty(u.Name)) return "Name is required.";
            if (!Validator.IsValidEmail(u.Email)) return "Invalid email.";
            if (!Validator.IsValidPhone(u.Phone)) return "Phone must be 11 digits starting 03.";
            u.PasswordHash = PasswordHasher.Hash(u.PasswordHash);
            dal.AddUser(u);
            return "User added successfully.";
        }

        public string UpdateUser(User u)
        {
            if (!Validator.IsNotEmpty(u.Name)) return "Name is required.";
            if (!Validator.IsValidEmail(u.Email)) return "Invalid email.";
            dal.UpdateUser(u);
            return "User updated successfully.";
        }

        public void DeleteUser(int userID) => dal.DeleteUser(userID);

    }
}
