using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace _2_lygis_egzaminas
{
    public class MailSend
    {

        public static void MailSender(string text)
        {
            {

                    var smtpClient = new SmtpClient("smtp.office365.com")
                    {
                        Port = 587,
                        Credentials = new NetworkCredential("gedas.valikonis@codeacademylt.onmicrosoft.com", "Aa91955483."),
                        EnableSsl = true,
                    };
                Console.Clear();
                Console.Write("Kokiu email'u siusti: ");
                string? mail = "";
                bool isGoodMail=false;
                do
                {
                    mail = Console.ReadLine();
                    mail ??= "";
                    isGoodMail = IsEmail(mail);
                    if(!isGoodMail)
                        Console.WriteLine("Neteisigai ivedete emaila. Bandykite is naujo.");
                }
                while (!IsEmail(mail));

                smtpClient.Send("gedas.valikonis@codeacademylt.onmicrosoft.com", mail, $"{Restorant.restoranas1.Name} kvitas", $"{text}");
                Console.WriteLine("Laiškas išsiųstas!");
                Console.WriteLine("Spausk bet koki mygtuka ir tesk darba.");
                Console.ReadKey();

            }

            static bool IsEmail(string text)
            {
                if (string.IsNullOrWhiteSpace(text)) return false;

                // Reguliarioji išraiška el. pašto adresui
                string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(text, pattern);
            }

        }
    }
}
