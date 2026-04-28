using System;
using System.Data.SqlClient;

namespace TicketsApp
{
    public static class DatabaseHelper
    {
        private static string connectionString = @"Data Source=10.12.0.2;Initial Catalog=ticket;User ID=mc;Password=medeea.01";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
