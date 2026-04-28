using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace TicketsApp
{
    public static class TicketService
    {
        private static SqlConnection GetConnection()
        {
            string connectionString = "Data Source=10.12.0.2;Initial Catalog=ticket;User ID=mc;Password=medeea.01";
            return new SqlConnection(connectionString);
        }

        public static bool CreateTicket(string ticketName, string description, string status, int userId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CreateTicket", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TicketName", ticketName);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Description", description);
                        cmd.Parameters.AddWithValue("@Status", status);
                        cmd.Parameters.AddWithValue("@UserId", userId);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        internal static bool CreateTicket(Ticket newTicket)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("CreateTicket", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TicketName", newTicket.Title);
                        cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                        cmd.Parameters.AddWithValue("@Description", newTicket.Description);
                        cmd.Parameters.AddWithValue("@Status", newTicket.Status);
                        cmd.Parameters.AddWithValue("@UserId", newTicket.User.Id);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public static List<Ticket> GetAllTickets()
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetAllTickets", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string ticketName = reader.GetString(1);
                                DateTime date = reader.GetDateTime(2);
                                string description = reader.GetString(3);
                                string status = reader.GetString(4);
                                int userId = reader.GetInt32(5);

                                tickets.Add(new Ticket(id, ticketName, description, new User(userId, "unknown", "unknown"))
                                {
                                    Status = status
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return tickets;
        }

        public static List<Ticket> GetUserTickets(User user)
        {
            List<Ticket> tickets = new List<Ticket>();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetUserTickets", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@UserId", user.Id);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string ticketName = reader.GetString(1);
                                DateTime date = reader.GetDateTime(2);
                                string description = reader.GetString(3);
                                string status = reader.GetString(4);

                                tickets.Add(new Ticket(id, ticketName, description, user)
                                {
                                    Status = status
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return tickets;
        }

        public static bool UpdateTicket(Ticket ticket)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateTicket", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", ticket.Id);
                        cmd.Parameters.AddWithValue("@TicketName", ticket.Title);
                        cmd.Parameters.AddWithValue("@Description", ticket.Description);
                        cmd.Parameters.AddWithValue("@Status", ticket.Status);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public static string GetUserEmailByTicketId(int ticketId)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("GetUserEmailByTicketId", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TicketId", ticketId);

                        var email = cmd.ExecuteScalar() as string;
                        return email;
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public static void SendTicketClosedEmail(Ticket ticket)
        {
            try
            {
                
                string email = GetUserEmailByTicketId(ticket.Id);
                if (string.IsNullOrEmpty(email))
                {
                    Console.WriteLine("Email not found for the user.");
                    return;
                }

                SmtpClient smtpClient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("medeea.criste@vernicolor.com", "Verni123."),
                    EnableSsl = true,
                };

                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("medeea.criste@vernicolor.com"),
                    Subject = "Your Ticket Has Been Closed",
                    Body = $" {ticket.User.Username},\n\nYour ticket '{ticket.Title}' has been closed by the admin.",
                    IsBodyHtml = false,
                };

               
                mailMessage.To.Add(email);

                smtpClient.Send(mailMessage);
                Console.WriteLine("Email sent successfully!");
            }
            catch (SmtpFailedRecipientException ex)
            {
                Console.WriteLine($"Failed recipient: {ex.FailedRecipient}");
                Console.WriteLine($"SMTP Error: {ex.Message}");
            }
            catch (SmtpException ex)
            {
                Console.WriteLine($"SMTP Error: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

