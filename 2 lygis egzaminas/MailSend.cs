using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace _2_lygis_egzaminas
{
    public class MailSend
    {

        public static void MailSender()
        {
            string smtpAddress = "smtp.gmail.com";
            int portNumber = 587; // Paprastai 587 arba 465
            bool enableSSL = true;

            // Siuntėjo informacija
            string emailFrom = "your-email@gmail.com";
            string password = "your-email-password"; // Slaptažodis arba programėlės slaptažodis

            // Gavėjo informacija
            string emailTo = "recipient-email@example.com";
            string subject = "Test Email";
            string body = "This is a test email sent from a C# application.";

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    mail.To.Add(emailTo);
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = false; // Jei laiškas HTML formatu, nustatykite į true

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                        Console.WriteLine("Email sent successfully.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }

        }
    }
}
