using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.IO;

namespace HRMOptimus.Application.Common.Services
{
    public class EmailService
    {
        public EmailService()
        {
        }

        public void SendEmail(string msg)
        {
            var bodyBuilder = new BodyBuilder();
            string htmlFilePath = "../mail_start.html";
            string htmlFilePath2 = "../mail_end.html";
            bodyBuilder.HtmlBody = File.ReadAllText(htmlFilePath) + $"<a style='color:#ffffff' href='http://localhost:4200/emailChange/{msg}'>Zmień adres e-mail</a>" + File.ReadAllText(htmlFilePath2);
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("tester@gmail.com"));
            email.To.Add(MailboxAddress.Parse("janek@jan.pl"));
            email.Subject = "Test email subject";
            //email.Body = new TextPart(TextFormat.Html) { Text = $"<h1>{msg}</h1>" };
            email.Body = bodyBuilder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.mailtrap.io", 587, SecureSocketOptions.StartTls);
            //smtp.Authenticate("5c55bad3ff10bf", "c79cabb73c312d");
            smtp.Authenticate("d7cbfe59b1dce0", "e57280990c9f41");
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}