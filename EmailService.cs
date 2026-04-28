using System;
using System.Net;
using System.Net.Mail;

public static class EmailService
{
    public static bool SendEmail(string toEmail, string subject, string body)
    {
        try
        {
            var fromAddress = new MailAddress("medeea.criste@vernicolor.com");
            var toAddress = new MailAddress(toEmail); 
            const string fromPassword = "Verni123.";

            var smtp = new SmtpClient
            {
                Host = "smtp-mail.outlook.com", 
                Port = 587,                    
                EnableSsl = true,              
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject, 
                Body = body        
            })
            {
                smtp.Send(message); 
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending email: {ex.Message}");
            return false; 
        }
    }
}
