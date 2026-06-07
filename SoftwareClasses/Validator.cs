using System.Text.RegularExpressions;

namespace CourierDB.SoftwareClasses
{
    public class Validator
    {
        public static bool IsValidEmail(string email)
        {
            // Simple check — just needs @ symbol
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@");
        }

        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^03[0-9]{9}$");
        }

        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static bool IsPositiveDecimal(string value, out decimal result)
        {
            return decimal.TryParse(value, out result) && result > 0;
        }

        public static bool IsPositiveInt(string value, out int result)
        {
            return int.TryParse(value, out result) && result > 0;
        }
    }
}