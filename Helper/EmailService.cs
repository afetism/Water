using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WaterRemainder.Helper
{
    internal class EmailService
    {
        static string GenerateVerificationCode()
        {
            Random random = new Random();
            return random.Next(1000, 9999).ToString(); 
        }

        static void SendVerificationCode(string toEmail, string code)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress("your-email@gmail.com");
                mail.To.Add(toEmail);
                mail.Subject = "Verification Code";
                mail.Body = $"Your verification code is: {code}";

                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                {
                    smtp.Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password");
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}
