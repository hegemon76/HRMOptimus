using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace HRMOptimus.Application.Common.Services
{
    public class EmailService
    {
        public EmailService()
        {
        }

        public void SendEmail(string msg)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("tester@gmail.com"));
            email.To.Add(MailboxAddress.Parse("janek@jan.pl"));
            email.Subject = "Test email subject";
            email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>{msg}</h1>" };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mailtrap.io", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("5c55bad3ff10bf", "c79cabb73c312d");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}