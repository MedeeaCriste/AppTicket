using System;
using System.Data.SqlClient;

namespace TicketsApp
{
    public static class GetNextCounter
    {
        public static int GetNextTicketId()
        {
            int nextId = 1;

            using (SqlConnection conn = DatabaseHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetNextTicketId", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    nextId = (int)cmd.ExecuteScalar();
                }
            }

            return nextId;
        }
    }
}
