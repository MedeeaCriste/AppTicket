using System;
using System.Data;
using System.Data.SqlClient;

namespace TicketsApp
{
    public static class UserService
    {
        private static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=10.12.0.2;Initial Catalog=ticket;User ID=mc;Password=medeea.01";
            return new SqlConnection(connectionString);
        }

        public static User Login(string username, string password)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("LoginUser", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string userType = reader.GetString(3);
                            string email = reader.IsDBNull(4) ? null : reader.GetString(4);
                            return new User(id, reader.GetString(1), reader.GetString(2), userType, email);
                        }
                    }
                }
            }
            return null;
        }

        public static bool SendPasswordResetEmail(string email)
        {
            string resetCode = GenerateResetCode();

            bool emailSent = EmailService.SendEmail(email, "Password Reset Code", $"Your reset code is: {resetCode}");

            if (emailSent)
            {
                SaveResetCode(email, resetCode);
                return true;
            }
            return false;
        }

        private static void SaveResetCode(string email, string resetCode)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET ResetCode = @ResetCode WHERE Email = @Email", conn)) 
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@ResetCode", resetCode);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static string GenerateResetCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

        public static bool VerifyResetCode(string email, string code, string newPassword)
        {
            bool isCodeValid = CheckResetCode(email, code);

            if (isCodeValid)
            {
                UpdateUserPassword(email, newPassword);
                ClearResetCode(email); 
                return true;
            }
            return false;
        }

        private static void UpdateUserPassword(string email, string newPassword)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Password = @NewPassword WHERE Email = @Email", conn))   
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@NewPassword", (newPassword)); 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static void ClearResetCode(string email)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET ResetCode = NULL WHERE Email = @Email", conn)) 
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private static bool CheckResetCode(string email, string code)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Users WHERE Email = @Email AND ResetCode = @ResetCode", conn)) 
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@ResetCode", code);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        public static bool UserExists(string username)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UserExists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool EmailExists(string email)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("EmailExists", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Email", email);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public static bool CreateAccount(string username, string password, string email)
        {
            if (UserExists(username) || EmailExists(email)) return false;

            string hashedPassword = HashPassword(password);

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("CreateUserAccount", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", hashedPassword);
                    cmd.Parameters.AddWithValue("@Email", email);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

        internal static Admin LoginAdmin(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}